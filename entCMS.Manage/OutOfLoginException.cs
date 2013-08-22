using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;

namespace entCMS.Manage
{
    public class OutOfLoginException : SystemException
    {
        public OutOfLoginException() { }

        public OutOfLoginException(string message)
            : base(message)
        {
        }

        protected OutOfLoginException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public OutOfLoginException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}