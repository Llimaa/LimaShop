namespace LimaShop.Customer.Core.ValueObjects
{
    public class Address
    {
        public Address()
        {

        }
        public Address(string country, string state, string city, string longradouro, string street, string number, string zipCore)
        {
            Country = country;
            State = state;
            City = city;
            Longradouro = longradouro;
            Street = street;
            Number = number;
            ZipCore = zipCore;
        }

        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Longradouro { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string ZipCore { get; private set; }
    }
}
