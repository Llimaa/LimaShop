using LimaShop.Customer.Core.Entities;
using LimaShop.Customer.Core.ValueObjects;
using System;
using Xunit;

namespace LimaShop.Customer.Tests.Core.Entities
{
    public class CustomerEntityTests
    {

        [Fact]
        public void CreateEntityReturnValue()
        {
            var customer = GenerateNewEntity();
            Assert.NotNull(customer);
            Assert.True(customer.Active);
        }

        [Fact]
        public void IsUpdateUser_ReturnDateUpdated()
        {
            var customer = GenerateNewEntity();
            Assert.Equal("Marcos", customer.FullName);
            customer.updateCustomer("Lima", DateTime.Now.AddYears(-20), "9499304040", "li@gmail.com");
            Assert.Equal("Lima", customer.FullName);
            Assert.Equal(DateTime.Now.ToString("d"), customer.UpdateAt.Value.ToString("d"));
        }

        [Fact]
        public void IsActiveUser_ReturnAviceTrue()
        {
            var customer = GenerateNewEntity();
            customer.DesactiveCustomer();
            Assert.False(customer.Active);

            customer.ActiveCustomer();
            Assert.True(customer.Active);
        }

        [Fact]
        public void IsDesactiveUser_ReturnAviceTrue()
        {
            var customer = GenerateNewEntity();
            Assert.True(customer.Active);
            customer.DesactiveCustomer();
            Assert.False(customer.Active);
        }

        private CustomerEntity GenerateNewEntity()
        {
            return new CustomerEntity("Marcos", DateTime.Now.AddYears(-20), "94991204594", new Address(), "lima@gmail.com");
        }
    }
}
