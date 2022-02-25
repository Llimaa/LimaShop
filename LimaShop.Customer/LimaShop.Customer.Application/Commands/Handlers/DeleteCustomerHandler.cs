using LimaShop.Customer.Application.Commands.InputModels;
using LimaShop.Customer.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LimaShop.Customer.Application.Commands.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomer, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(DeleteCustomer request, CancellationToken cancellationToken)
        {
            var isDeleted = await _customerRepository.DeleteById(request.CustomerId);
            return isDeleted;
        }
    }
}
