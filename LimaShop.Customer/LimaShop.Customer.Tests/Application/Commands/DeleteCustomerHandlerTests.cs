using LimaShop.Customer.Application.Commands.Handlers;
using LimaShop.Customer.Application.Commands.InputModels;
using LimaShop.Customer.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LimaShop.Customer.Tests.Application.Commands
{
    public class DeleteCustomerHandlerTests
    {
        [Fact]
        public async Task IsDeleteCustomer_ReturnTrue()
        {
            var cutomerId = Guid.NewGuid();
            var deleteCustomer = new DeleteCustomer(cutomerId);

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(cr => cr.DeleteById(cutomerId).Result).Returns(true);

            var deleteCustomerHandler = new DeleteCustomerHandler(customerRepositoryMock.Object);
            var result = await deleteCustomerHandler.Handle(deleteCustomer, new CancellationToken());

            Assert.True(result);
            customerRepositoryMock.Verify(x => x.DeleteById(It.IsAny<Guid>()), Times.Once);
        }
    }
}
