using System.Text.RegularExpressions;

namespace Core.Domain.ValueObjects;

public class PhoneNumber : ValueObject<PhoneNumber>
{
    private readonly string? _value;
    public PhoneNumber(string? number)
    {
        if (string.IsNullOrWhiteSpace(number))
            return;

        number = number!.Replace(" ", string.Empty);
        if (number!.StartsWith("+98"))
        {
            number = number.Replace("+98", "0");
        }
        var regex = new Regex(@"(^(09|9)\d{9}$)");
        if (!regex.IsMatch(number))
            throw new DomainException("MobileNumberIsNotCorrect");

        _value = number;
    }

    public static implicit operator PhoneNumber(string? number) => new(number);
    public static implicit operator string?(PhoneNumber number) => number._value;
    public override string? ToString() => _value;
    protected override bool EqualsCore(PhoneNumber other)
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
