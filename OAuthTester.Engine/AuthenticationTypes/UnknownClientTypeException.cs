using System.Runtime.Serialization;

namespace OAuthTester.Engine.AuthenticationTypes;

[Serializable]
public class UnknownClientTypeException : Exception
{
    public UnknownClientTypeException()
    {
    }

    public UnknownClientTypeException(Guid clientId) : this($"Unable to locate a client with id {clientId}.") { }


    public UnknownClientTypeException(string message) : base(message)
    {
    }

    public UnknownClientTypeException(string message, Exception inner) : base(message, inner)
    {
    }

    protected UnknownClientTypeException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}