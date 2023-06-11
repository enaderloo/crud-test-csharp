using System.Text.RegularExpressions;

namespace Core.Domain.ValueObjects;

public class Email : ValueObject<Email>
{
    private readonly string _value;

    public Email(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            return;
        var regex = new Regex(@"^[A-Za-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$");
        var isValid = regex.IsMatch(code.Trim());
        if (!isValid)
            throw new DomainException("EmailIsNotValid");
        _value = code.Trim().ToLower();
    }
    public static implicit operator Email(string code) => new(code);
    public static implicit operator string(Email code) => code._value;
    public override string ToString() => _value;

    protected override bool EqualsCore(Email other)
    {
        return other is not null &&
               _value == other._value;
    }

    protected override int GetHashCodeCore()
    {
        return _value
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
}
