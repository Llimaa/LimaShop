using LimaShop.Customer.Application.Commands.InputModels;
using LimaShop.Customer.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LimaShop.Customer.Application.Commands.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomer, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(UpdateCustomer request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            customer.updateCustomer(request.FullName, request.BirthDate, request.PhoneNumber, request.Email);
            await _customerRepository.Update(customer);
            return Unit.Value;
        }
    }
}
