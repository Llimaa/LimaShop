using LimaShop.Customer.Core.ValueObjects;

namespace LimaShop.Customer.Application.Commands.InputModels
{
    public class AddressCustomer
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Longradouro { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCore { get; set; }

        public Address ToEntity()
        {
            return new Address(Country, State, City, Longradouro, Street, Number, ZipCore);
        }
    }
}
