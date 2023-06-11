using Core.Domain;
using Mc2.CrudTest.Application.Commands.Customers;
using Mc2.CrudTest.Domain.IRepository;
using MediatR;

namespace Mc2.CrudTest.Application.CommandHandlers.Customers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _repository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetAsync(request.Id) ??
                throw new RecordNotFoundException("CustomerNotFound");

            customer.Delete(request.CurrentUserId, request.TimeStamp);
            _repository.Delete(customer);

            return await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
