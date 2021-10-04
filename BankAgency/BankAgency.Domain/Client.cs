using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAgency.Domain
{
    public class Client
    {
        public Client(string name, string cpf, string rg, Address address)
        {
            //if (string.IsNullOrWhiteSpace(name))
            //throw new Exception("Property must be filled");

            Name = name.CheckEmptyString();
            CPF = cpf.CheckEmptyString();
            RG = rg.CheckEmptyString();
            Address = address ?? throw new Exception("Address must be submitted");

        }

        public string Name { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public Address Address { get; set; }
    }
}
