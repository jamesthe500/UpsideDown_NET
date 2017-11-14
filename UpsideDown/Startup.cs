using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace UpsideDown
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IGreeter, Greeter>();

            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                                IHostingEnvironment env, 
                                ILoggerFactory loggerFactory, 
                                IGreeter greeter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                // for exception handling
                app.UseDeveloperExceptionPage();
            } else {
                // for exception handling
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = context => context.Response.WriteAsync("Oops!")
                });
            }

            //app.UseStaticFiles();

            //app.UseDefaultFiles();

            // looks in wwwroot for default files and serves them.
            //app.UseFileServer();

            // gives routing control to MVC?
            app.UseMvc(ConfigureRoutes);

            // a catch all for if a route isn't found
            app.Run(ctx => ctx.Response.WriteAsync("Not Found"));

        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // I think this is supposed to server the default when there is nothing after the base URL. It's not.
            routeBuilder.MapRoute(
                name: "Default", 

                template: "{controller=Home}/{action=Index}/{id?}");
        }


    }
}
