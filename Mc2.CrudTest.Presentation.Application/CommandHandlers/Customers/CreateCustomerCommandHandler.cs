
using Mc2.CrudTest.Application.Commands.Customers;
using Mc2.CrudTest.Domain.Entities.CustomerAggregate;
using Mc2.CrudTest.Domain.IRepository;
using MediatR;

namespace Mc2.CrudTest.Application.CommandHandlers.Customers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repository;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _repository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // if we have other Business Rule Validation can be checked here and throw new domain exception


            Customer customer = new(request.FirstName, request.Lastname, request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAccountNumber);
            await _repository.CreateAsync(customer);
            return await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
