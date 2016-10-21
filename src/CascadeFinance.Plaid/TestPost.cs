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

                Debug.WriteLine("Ending");
            }

        }
    }
}
