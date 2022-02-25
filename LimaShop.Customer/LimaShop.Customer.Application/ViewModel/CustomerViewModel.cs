using LimaShop.Customer.Core.Entities;
using System;

namespace LimaShop.Customer.Application.ViewModel
{
    public class CustomerViewModel
    {
        public CustomerViewModel(Guid id,string fullName, DateTime birthDate, string phoneNumber, AddressCustomerViewModel address, string email, bool active)
        {
            FullName = fullName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            Active = active;
            Id = id;
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public AddressCustomerViewModel Address { get; set; }
        public string Email { get; private set; }
        public bool Active { get; set; }

        public static CustomerViewModel FromEntity(CustomerEntity customer)
        {
            return new CustomerViewModel(customer.Id, customer.FullName, customer.BirthDate, customer.PhoneNumber, AddressCustomerViewModel.FromEntity(customer.Address), customer.Email, customer.Active);
        }
    }
}
