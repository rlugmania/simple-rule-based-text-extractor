using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TextExtractor.Exceptions
{
    public sealed class LocatorNotImplementedException : Exception
    {
        public LocatorNotImplementedException()
        {
        }

        public LocatorNotImplementedException(string message) : base(message)
        {
        }

        public LocatorNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public LocatorNotImplementedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
