using Core.Domain;
using Mc2.CrudTest.Application.Commands.Customers;
using Mc2.CrudTest.Domain.IRepository;
using MediatR;

namespace Mc2.CrudTest.Application.CommandHandlers.Customers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repository;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _repository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }
        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetAsync(request.Id) ?? 
                throw new RecordNotFoundException("CustomerNotFound");

            customer.Update(request.FirstName, request.Lastname, request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAccountNumber);

            return await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
