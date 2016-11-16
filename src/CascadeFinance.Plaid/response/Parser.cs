using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid.Response
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

        public IList<Transaction> parseTransactions(string json)
        {
            JObject testSearch = JObject.Parse(json);
            IList<JToken> results = testSearch["transactions"].Children().ToList();

            IList<Transaction> transactions = new List<Transaction>();
            foreach (JToken result in results)
            {
                Transaction transaction = JsonConvert.DeserializeObject<Transaction>(result.ToString());
                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}
