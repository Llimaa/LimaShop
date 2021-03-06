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
    public class DesactiveCustomerHanderTests
    {
        [Fact]
        public async Task DesactiveCustomerIsOK_UpdateIsActiveForTrue()
        {
            var address = new Address("Brasil", "Para", "Belem", "Centro", "linda", "102", "68537000");
            var customer = new CustomerEntity("Marcos", DateTime.Now.AddYears(-20), "94991204594", address, "lima@gmail.com");
            var desactiveCustomer = new DesactiveCustomer(customer.Id);
            customer.DesactiveCustomer();


            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(cr => cr.GetByIdAsync(customer.Id).Result).Returns(customer);

            var customerHandler = new DesactiveCustomerHander(customerRepositoryMock.Object);

            await customerHandler.Handle(desactiveCustomer, new CancellationToken());

            Assert.False(customer.Active);
            customerRepositoryMock.Verify(cr => cr.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}

