namespace Mc2.CrudTest.Domain.Entities.CustomerAggregate
{
    public interface ICustomerUniquenessChecker
    {
        bool IsUnique(string customerEmail);
    }
}

