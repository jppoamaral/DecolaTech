using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAgency.Domain
{
    public class Address
    {
        public Address(string street, string zipcode, string city, string state)
        {
            Street = street.CheckEmptyString();
            ZipCode = zipcode.CheckEmptyString();
            City = city.CheckEmptyString();
            State = state.CheckEmptyString();
        }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
