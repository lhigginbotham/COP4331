using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid.Response
{
    public class Meta
    {
        private string name;
        private string number;
        private string limit;

        private Location location;

        public Meta(string name, string number, string limit)
        {
            this.name = name;
            this.number = number;
            this.limit = limit;
        }

        [JsonConstructor]
        public Meta(string name, string number, string limit, Location location)
        {
            this.name = name;
            this.number = number;
            this.limit = limit;
            this.location = location;
        }
    }
}
