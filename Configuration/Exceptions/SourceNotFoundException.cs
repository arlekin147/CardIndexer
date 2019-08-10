using System;
namespace CardIndexer.Configuration
{
    public class SourceNotFoundException : Exception
    {
        public SourceNotFoundException(){}
        public SourceNotFoundException(string message) : base(message){}
        public SourceNotFoundException(string message, Exception innerException)
        :base(message, innerException){}
        
    }
}