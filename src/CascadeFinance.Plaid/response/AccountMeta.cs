using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid.response
{
    public class AccountMeta
    {
        private string name;
        private string number;
        private string limit;

        public AccountMeta(string name, string number, string limit)
        {
            this.name = name;
            this.number = number;
            this.limit = limit;
        }
    }
}
