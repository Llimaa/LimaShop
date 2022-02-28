using LimaShop.Customer.Core.Entities;
using LimaShop.Customer.Core.Repositories;
using LimaShop.Customer.Core.ValueObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LimaShop.Customer.Infra.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<CustomerEntity> _collection;
        public CustomerRepository(IMongoDatabase mongoDatabase)
        {
            _collection = mongoDatabase.GetCollection<CustomerEntity>("customers");
        }

        public async Task Insert(CustomerEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Update(CustomerEntity entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public async Task UpdateAddressCustomer(Address address, Guid userId)
        {
            var customer = await GetCustomerById(userId);
            customer.UpdateAddress(address);
            await _collection.ReplaceOneAsync(x => x.Id == userId, customer);
        }
        public async Task ActiveCustomer(CustomerEntity customer)
        {
            customer.ActiveCustomer();
            await _collection.ReplaceOneAsync(x => x.Id == customer.Id, customer);
        }

        public async Task DesactiveCustomer(CustomerEntity customer)
        {
            customer.DesactiveCustomer();
            await _collection.ReplaceOneAsync(x => x.Id == customer.Id, customer);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount == 1 ? true : false;
        }

        public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return await _collection.Find(m => true).ToListAsync();
        }

        public async Task<CustomerEntity> GetByIdAsync(Guid id)
        {
            return await GetCustomerById(id);
        }

        public async Task<CustomerEntity> GetByNameAsync(string name)
        {
            return await _collection.Find(x => x.FullName.ToUpper() == name.ToUpper()).SingleOrDefaultAsync();
        }

        private async Task<CustomerEntity> GetCustomerById(Guid userId)
        {
            return await _collection.Find(x => x.Id == userId).SingleOrDefaultAsync();
        }
    }
}
