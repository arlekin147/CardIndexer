using System;

namespace CardIndexer.Configuration
{
    public class InvalidNumeratorException : Exception
    {
        public InvalidNumeratorException(){}
        public InvalidNumeratorException(string message) : base(message){}
        public InvalidNumeratorException(string message, Exception innerException)
        :base(message, innerException){}

    }
}