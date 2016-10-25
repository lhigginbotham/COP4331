using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid.Request
{
    public class Credentials
    {
        public string username;
        public string password;
        public string pin;

        public Credentials(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Credentials(string username, string password, string pin)
        {
            this.username = username;
            this.password = password;
            this.pin = pin;
        }
    }
}
