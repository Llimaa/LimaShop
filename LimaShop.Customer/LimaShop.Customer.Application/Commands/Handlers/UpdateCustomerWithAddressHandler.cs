using LimaShop.Customer.Application.Commands.InputModels;
using LimaShop.Customer.Core.Repositories;
using LimaShop.Customer.Core.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LimaShop.Customer.Application.Commands.Handlers
{
    public class UpdateCustomerWithAddressHandler : IRequestHandler<UpdateCustomerWithAddress, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerWithAddressHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerWithAddress request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            customer.updateCustomer(request.FullName, request.BirthDate, request.PhoneNumber, request.Email);

            var address = new Address(request.Country, request.State, request.City, request.Longradouro, request.Street, request.Number, request.ZipCore);

            customer.UpdateAddress(address);
            await _customerRepository.Update(customer);

            return Unit.Value;
        }
    }
}
