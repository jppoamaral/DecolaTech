using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAgency.Domain
{
    public static class Validations
    {
        public static string CheckEmptyString(this string input)
        {
            return string.IsNullOrWhiteSpace(input) ? throw new Exception("Property must be filled") : input;
        }
    }
}
