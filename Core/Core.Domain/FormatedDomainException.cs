namespace Core.Domain;

public class FormatedDomainException : Exception
{
    public FormatedDomainException()
    { }

    public FormatedDomainException(string message)
        : base(message)
    { }

    public FormatedDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
