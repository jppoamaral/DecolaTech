using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAgency.Domain
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(Client client) : base(client)
        {
            //0.30%
            PercentualRendimento = 0.003M;
        }

        public decimal PercentualRendimento { get; private set; }
    }
}
