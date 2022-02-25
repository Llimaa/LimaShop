using LimaShop.Customer.Core.Shared;
using LimaShop.Customer.Core.ValueObjects;
using System;

namespace LimaShop.Customer.Core.Entities
{
    public class CustomerEntity : EntityBase
    {
        public CustomerEntity()
        {

        }
        public CustomerEntity(string fullName, DateTime birthDate, string phoneNumber, Address address, string email)
        {
            FullName = fullName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            Active = true;
        }

        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }

        public void updateCustomer(string fullName, DateTime birtDate, string phoneNumber, string email)
        {
            FullName = fullName;
            BirthDate = birtDate;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        public void ActiveCustomer()
        {
            if (!Active)
                Active = !Active;
        }

        public void DesactiveCustomer()
        {
            if (Active)
                Active = !Active;
        }
    }
}
