using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LanguageCards.Data.DalOperation
{
    public class DalOperationException : Exception
    {
        DalOperationStatusCode StatusCode { get; }

        public DalOperationException() : base() { }
        public DalOperationException(DalOperationStatusCode statusCode) : base()
        {
            StatusCode = statusCode;
        }
        public DalOperationException(string message) : base(message) { }
        public DalOperationException(string message, DalOperationStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
        public DalOperationException(string message, Exception innerException) : base(message, innerException) { }
        public DalOperationException(string message, DalOperationStatusCode statusCode, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
        protected DalOperationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
