using CascadeFinance.Plaid.request;
using CascadeFinance.Plaid.response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid
{
    public class TestPost
    {
        public TestPost()
        {
        }

        public async void PostRequest()
        {
            PlaidClient pClient = new PlaidClient("test_id", "test_secret");
            Credentials credentials = new Credentials("plaid_test", "plaid_good");
            pClient.requestAllAccountData(credentials, "wells");

            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    {"client_id", "test_id" },
                    {"secret", "test_secret"},
                    {"username", "plaid_test" },
                    {"password", "plaid_good" },
                    {"type", "wells"},

                };

                var content = new FormUrlEncodedContent(values);

                Debug.WriteLine(content.ToString());

                var response = await client.PostAsync("https://tartan.plaid.com/connect", content);

                var responseString = await response.Content.ReadAsStringAsync();

                //JsonValue value = JsonValue.Parse(responseString);

                JObject testSearch = JObject.Parse(responseString);
                IList<JToken> results = testSearch["accounts"].Children().ToList();

                IList<Account> accounts = new List<Account>();
                foreach(JToken result in results)
                {
                    Account account = JsonConvert.DeserializeObject<Account>(result.ToString());
                    accounts.Add(account);
                }

                Debug.WriteLine(responseString);
            }

        }
    }
}
