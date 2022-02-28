using LimaShop.Customer.Application.Commands.Handlers;
using LimaShop.Customer.Application.Commands.InputModels;
using LimaShop.Customer.Core.Entities;
using LimaShop.Customer.Core.Repositories;
using LimaShop.Customer.Core.ValueObjects;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LimaShop.Customer.Tests.Application.Commands
{
    public class UpdateCustomerHandlerTests
    {
        [Fact]
        public async Task IsUpdateCustomer_ReturnId()
        {
            var customerId = Guid.NewGuid();
            var customer = new CustomerEntity("Marcos", DateTime.Now.AddYears(-20), "94991204594", new Address(), "lima@gmail.com");
            var updateCustomer = new UpdateCustomer(customerId, "Lima", DateTime.Now.AddYears(-20), "94995849532", "lima@gmail.com");

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.GetByIdAsync(customerId).Result).Returns(customer);
            customerRepositoryMock.Setup(x => x.Update(customer));

            var customerHandler = new UpdateCustomerHandler(customerRepositoryMock.Object);
            await customerHandler.Handle(updateCustomer, new CancellationToken());

            customerRepositoryMock.Verify(cr => cr.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            customerRepositoryMock.Verify(cr => cr.Update(It.IsAny<CustomerEntity>()), Times.Once);
        }
    }
}
