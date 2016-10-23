using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid.request
{
    public class Credentials
    {
        private string username;
        private string password;
        private string pin;

        public Credentials(string username, string password, string pin)
        {
            this.username = username;
            this.password = password;
            this.pin = pin;
        }
    }
}
