using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid.response
{
    public class Balance
    {
        private double available;
        private double current;

        public Balance(double available, double current)
        {
            this.available = available;
            this.current = current;
        }
    }
}
