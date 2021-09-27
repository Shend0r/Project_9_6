using System;

namespace Project_9_6
{
    internal class SortingException : Exception
    {
        public SortingException(string Message) : base (Message)  { }

        public SortingException(string Message, Exception innerException) : base(Message, innerException) { }       
    }
}
