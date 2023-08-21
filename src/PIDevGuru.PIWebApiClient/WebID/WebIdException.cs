using System;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.WebID
{
    [Serializable]
    internal class WebIdException : Exception
    {
        public WebIdException()
        {
        }

        public WebIdException(string message) : base(message)
        {
        }

        public WebIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WebIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}