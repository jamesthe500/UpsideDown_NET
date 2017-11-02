using System;
using Microsoft.Extensions.Configuration;

namespace UpsideDown
{
    public interface IGreeter
    {
        string GetGreeting();
    }

    public class Greeter : IGreeter
    {
        private string _greeting;

        public Greeter(IConfiguration configuration)
        {
            _greeting = configuration["grating-greeting"];

        }

        public string GetGreeting()
        {
            return _greeting;
        }
    }
}
