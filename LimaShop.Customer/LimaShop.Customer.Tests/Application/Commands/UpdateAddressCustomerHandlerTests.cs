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
    public class UpdateAddressCustomerHandlerTests
    {
        [Fact]
        public async Task IsUpdateAddressCustomer_ReturnId()
        {
            var customerId = Guid.NewGuid();
            var addressCustomer = new AddressCustomer("Brasil", "Para", "Belem", "Centro", "lisboa", "10", "65345000");
            var updateAddressCustomer = new UpdateAddressCustomer(customerId, addressCustomer);
       


            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(cr => cr.UpdateAddressCustomer(addressCustomer.ToEntity(), customerId));

            var updateAddressCustomerHandler = new UpdateAddressCustomerHandler(customerRepositoryMock.Object);
            await updateAddressCustomerHandler.Handle(updateAddressCustomer, new CancellationToken());

            customerRepositoryMock.Verify(cr => cr.UpdateAddressCustomer(It.IsAny<Address>(), customerId), Times.Once);
        }
    }
}
