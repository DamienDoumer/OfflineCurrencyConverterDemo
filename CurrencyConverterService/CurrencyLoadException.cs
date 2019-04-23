using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverterService
{
    public class CurrencyLoadException : Exception
    {
        public CurrencyLoadException() : base("The Service is either not available or internet connection not found.")
        {
        }
    }
}
