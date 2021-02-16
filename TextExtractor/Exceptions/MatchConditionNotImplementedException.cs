using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TextExtractor.Exceptions
{
    public class MatchConditionNotImplementedException : Exception
    {
        public MatchConditionNotImplementedException()
        {
        }

        public MatchConditionNotImplementedException(string message) : base(message)
        {
        }

        public MatchConditionNotImplementedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MatchConditionNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
