using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OAuthTester.Engine.Exceptions
{
    [Serializable]
    public class OAuthEngineException : Exception
    {
        public OAuthEngineException()
        {
        }

        public OAuthEngineException(string message) : base(message)
        {
        }

        public OAuthEngineException(string message, Exception inner) : base(message, inner)
        {
        }

        protected OAuthEngineException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
