using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LimaShop.Customer.Core.Entities;
using LimaShop.Customer.Core.ValueObjects;

namespace LimaShop.Customer.Core.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerEntity>> GetAllAsync();
        Task<CustomerEntity> GetByIdAsync(Guid id);
        Task<CustomerEntity> GetByNameAsync(string name);
        Task Insert(CustomerEntity entity);
        Task Update(CustomerEntity entity);
        Task<bool> DeleteById(Guid id);
        Task ActiveCustomer(Guid customerId);
        Task DesactiveCustomer(Guid customerId);
        Task UpdateAddressCustomer(Address address, Guid customerId);
    }
}
