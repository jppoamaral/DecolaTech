using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAgency.Domain;

namespace BankAgency.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address = new Address("Av. Alexandre Dumas", "04717-002", "Sao Paulo", "SP");
            Client client = new Client("Joao", "529.362.338-95", "59.407.484-8", address);

            CheckingAccount account = new CheckingAccount(client, 100);
            string password = "abc12345";
            account.Open(password);

            account.Withdraw(10, password);
        }
    }
}
