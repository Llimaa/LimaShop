using LimaShop.Customer.Application.Commands.InputModels;
using LimaShop.Customer.Core.Repositories;
using LimaShop.Customer.Core.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LimaShop.Customer.Application.Commands.Handlers
{
    public class UpdateAddressCustomerHandler : IRequestHandler<UpdateAddressCustomer, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateAddressCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(UpdateAddressCustomer request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

            var address = new Address(
                request.AddressCustomer.Country,
                request.AddressCustomer.State,
                request.AddressCustomer.City,
                request.AddressCustomer.Longradouro,
                request.AddressCustomer.Street,
                request.AddressCustomer.Number,
                request.AddressCustomer.ZipCore
                );

            customer.UpdateAddress(address);

            await _customerRepository.Update(customer);
            return Unit.Value;

        }
    }
}
