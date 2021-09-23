using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_9_6
{
    internal class EmptyStringException : Exception
    {
        public EmptyStringException(string Message) : base (Message)  { }

        public EmptyStringException(string Message, Exception innerException) : base(Message, innerException) { }       
    }
}
