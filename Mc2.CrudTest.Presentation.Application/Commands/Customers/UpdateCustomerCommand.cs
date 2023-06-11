using Core.Application;
using Core.Domain;
using Mc2.CrudTest.Shared.Models;

namespace Mc2.CrudTest.Application.Commands.Customers
{
    public record UpdateCustomerCommand : CustomerSharedModel, IBaseUpdateCommand<bool, long>
    {
        public long Id { get; private set; }
        public void SetId(long id)
            => Id = id == 0 ?
                throw new DomainException("RecordIdIsNotSet")
                : id;
    }
}
