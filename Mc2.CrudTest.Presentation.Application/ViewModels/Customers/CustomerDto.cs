using Mc2.CrudTest.Domain.Entities.CustomerAggregate;
using Mc2.CrudTest.Shared.Models;

namespace Mc2.CrudTest.Application.ViewModels.Customers
{
    public record CustomerDto : CustomerSharedModel
    {
        internal static CustomerDto FromEntity(Customer entity) => new()
        {
            Email = entity.Email,
            Lastname = entity.Lastname,
            FirstName = entity.Firstname,
            PhoneNumber = entity.PhoneNumber,
            DateOfBirth = entity.DateOfBirth,
            BankAccountNumber = entity.BankAccountNumber
        };
    }
}
