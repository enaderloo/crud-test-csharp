using Core.Application;
using Core.Domain;

namespace Mc2.CrudTest.Application.Commands.Customers
{
    public record DeleteCustomerCommand : BaseUpdateWithUserAndTimeStampCommand<bool, long>, IBaseUpdateWithUserAndTimeStampCommand<bool, long>
    //BaseUpdateCommand<bool, long>, IBaseUpdateCommand<bool, long> => if time is not matter
    {
        public DeleteCustomerCommand(long timeStamp) : base(timeStamp)
        { }
        public override void SetId(long id)
        => Id = (id == 0) ?
            throw new DomainException("RecordIdIsNotSet")
            : id;
    }
}
