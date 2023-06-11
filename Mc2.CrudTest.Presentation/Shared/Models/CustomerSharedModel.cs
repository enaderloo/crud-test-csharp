
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Shared.Models
{
    public record CustomerSharedModel
    {
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$", ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Bank account number is required")]

        //for example => 0000-0000-0000-0000
        [RegularExpression(@"((\d{4})-){3}\d{4}", ErrorMessage = "Invalid bank account number")]
        public string? BankAccountNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
