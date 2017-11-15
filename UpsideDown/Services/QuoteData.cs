using System;
using System.Collections.Generic;
using UpsideDown.Models;

namespace UpsideDown.Services
{
    public interface IQuoteData
    {
        IEnumerable<Quote> GetAll();
        Quote SelectRandomQuote();
    }

    public class InMemoryQuoteData : IQuoteData
    {
        public InMemoryQuoteData()
        {
            _quotes = new List<Quote>
            {
                new Quote {Id=1, QuoteText="Guys!...", Sayer="Dustin"},
                new Quote {Id=2, QuoteText="Mornings are for coffee and contemplation.", Sayer="Chief Hopper"},
                new Quote {Id=3, QuoteText="Friends don't lie", Sayer="Eleven"},
                new Quote {Id=4, QuoteText="Why are you keeping this curiosity door locked?!", Sayer="Dustin"}
            };
        }

        public IEnumerable<Quote> GetAll()
        {
            return _quotes;
        }

        public Quote SelectRandomQuote()
        {
            int max = _quotes.Count;
            Random rando = new Random();
            int selected = rando.Next(0, max);
            return _quotes[selected];
        }

        List<Quote> _quotes;
    }
}
