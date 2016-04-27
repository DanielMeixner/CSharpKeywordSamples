using System;
using System.Runtime.Serialization;

namespace LockKeywordSample
{
    [Serializable]
    internal class PopulationCantBeNegativeException : Exception
    {
        public PopulationCantBeNegativeException()
        {
        }

        public PopulationCantBeNegativeException(string message) : base(message)
        {
        }

        public PopulationCantBeNegativeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PopulationCantBeNegativeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}