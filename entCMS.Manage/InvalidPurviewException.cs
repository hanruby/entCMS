using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;

namespace entCMS.Manage
{
    public class InvalidPurviewException : SystemException
    {
        public InvalidPurviewException() { }

        public InvalidPurviewException(string message)
            : base(message)
        {
        }

        protected InvalidPurviewException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public InvalidPurviewException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}