namespace Mc2.CrudTest.Shared.Summaries
{
    public record CustomerSharedSummary
    {
        public string? Firstname { get; init; }
        public string? Lastname { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Email { get; init;}
        public string? BankAccountNumber { get; init;}
    }
}
