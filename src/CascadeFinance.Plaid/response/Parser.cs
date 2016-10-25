using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid.response
{
    public class Parser
    {
        public Parser() { }

        public IList<Account> parseAccounts(string json)
        {
            JObject testSearch = JObject.Parse(json);
            IList<JToken> results = testSearch["accounts"].Children().ToList();

            IList<Account> accounts = new List<Account>();
            foreach (JToken result in results)
            {
                Account account = JsonConvert.DeserializeObject<Account>(result.ToString());
                accounts.Add(account);
            }

            return accounts;
        }
    }
}
