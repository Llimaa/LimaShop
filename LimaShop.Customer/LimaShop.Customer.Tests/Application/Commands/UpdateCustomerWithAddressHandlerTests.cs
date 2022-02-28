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
    public class UpdateCustomerWithAddressHandlerTests
    {
        [Fact]
        public async Task IsUpdateCustomerWithAddress_ReturnValid()
        {
            var customerId = Guid.NewGuid();
            var customer = new CustomerEntity("Marcos", DateTime.Now.AddYears(-20), "94991204594", new Address(), "lima@gmail.com");
            var updateCustomerWithAddress = new UpdateCustomerWithAddress(
                customerId,
                "Marcos",
                DateTime.Now.AddYears(-20),
                "94991204594",
                "lima@gmail.com",
                "Brasil",
                "Para",
                "Belem",
                "Centro",
                "lisboa",
                "10",
                "65345000"
                );

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.GetByIdAsync(customerId).Result).Returns(customer);
            customerRepositoryMock.Setup(x => x.Update(customer));

            var customerHandler = new UpdateCustomerWithAddressHandler(customerRepositoryMock.Object);
            await customerHandler.Handle(updateCustomerWithAddress, new CancellationToken());

            customerRepositoryMock.Verify(cr => cr.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            customerRepositoryMock.Verify(cr => cr.Update(It.IsAny<CustomerEntity>()), Times.Once);
        }
    }
}
