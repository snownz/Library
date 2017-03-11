using System;
using System.Runtime.Serialization;

namespace Library.Domain.FilterException
{
    [Serializable]
    public class ModelNotExistsException : Exception
    {
        public ModelNotExistsException()
        {
        }

        public ModelNotExistsException(string message) : base(message)
        {
        }

        public ModelNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
