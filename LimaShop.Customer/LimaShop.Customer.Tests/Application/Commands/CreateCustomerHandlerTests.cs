using LimaShop.Customer.Application.Commands.Handlers;
using LimaShop.Customer.Application.Commands.InputModels;
using LimaShop.Customer.Core.Entities;
using LimaShop.Customer.Core.Repositories;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LimaShop.Customer.Tests.Application.Commands
{
    public class CreateCustomerHandlerTests
    {
        [Fact]
        public async Task IsCreatedCustomerOk_ReturnIdNewCustomer()
        {
            var addressCustomer = new AddressCustomer("Brasil", "Para", "Belem", "Centro", "lisboa", "10", "65345000");
            var createCustomer = new CreateCustomer("Marcos", DateTime.Now.AddYears(-20), "9400394023", addressCustomer, "lima@gmail.com");
            var customerEntity = createCustomer.ToEntity();

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(cr => cr.Insert(customerEntity));

            var createCustomerHandler = new CreateCustomerHandler(customerRepositoryMock.Object);
            await createCustomerHandler.Handle(createCustomer, new CancellationToken());

            customerRepositoryMock.Verify(cr => cr.Insert(It.IsAny<CustomerEntity>()), Times.Once);
        }
    }
}
