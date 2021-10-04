using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAgency.Domain
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(Client client, decimal limit) : base(client)
        {
            MaintenanceFeeValue = 0.05M;
            Limit = limit;
        }

        public override void Withdraw(decimal value, string password) //sobrescrevendo a classe herdada
        {
            if (Password != password)
            {
                throw new Exception("Wrong Password");
            }

            if ((Balance + Limit) < value)
            {
                throw new Exception("Insufficient Balance");
            }

            Balance -= value;
        }

        public decimal Limit { get; private set; }
        public decimal MaintenanceFeeValue { get; private set; }
    }
}
