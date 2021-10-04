using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankAgency.Domain
{
    public abstract class BankAccount
    {
        public BankAccount(Client client)
        {
            Random random = new Random();
            AccountNumber = random.Next(50000, 100000);
            VerifyingDigit = random.Next(0, 9);

            Situation = AccountSituation.Created;
            Client = client ?? throw new Exception("Client must be informed.");
        }

        public void Open(string password)
        {
            SetPassword(password);
            Situation = AccountSituation.Opened;
            OpeningDate = DateTime.Now;
        }

        private void SetPassword(string password)
        {
            password = password.CheckEmptyString();
            if (!Regex.IsMatch(password, @"(?=.*?[a-z])(?=.*?[0-9]).{8,}$")) //expressao regular que pode ser feita com a ajuda de sites
            {
                throw new Exception("Invalid Password.");
            }
            Password = password;
        }

        public virtual void Withdraw(decimal value, string password) //virtual sobrescrito na classe filha
        {
            if (Password != password)
            {
                throw new Exception("Wrong Password");
            }

            if (Balance < value)
            {
                throw new Exception("Insufficient Balance");
            }

            Balance -= value;
        }

        public int AccountNumber { get; init; }
        public int VerifyingDigit { get; init; }
        public decimal Balance { get; protected set; }
        public DateTime? OpeningDate { get; private set; }
        public DateTime? ClosingDate { get; private set; }
        public AccountSituation Situation { get; private set; }
        public string Password { get; private set; }
        public Client Client { get; init; }
    }
}
