using System;
using System.Runtime.Serialization;

namespace Library.Domain.FilterException
{
    [Serializable]
    public class DataBaseNotInitializedException : Exception
    {
        public DataBaseNotInitializedException()
        {
        }

        public DataBaseNotInitializedException(string message) : base(message)
        {
        }

        public DataBaseNotInitializedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataBaseNotInitializedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
