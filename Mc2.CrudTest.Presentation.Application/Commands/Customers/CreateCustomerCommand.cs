
using Mc2.CrudTest.Shared.Models;
using MediatR;

namespace Mc2.CrudTest.Application.Commands.Customers
{
    public record CreateCustomerCommand : CustomerSharedModel, IRequest<bool>
    {
    }
}
