﻿using CascadeFinance.Plaid.Request;
using CascadeFinance.Plaid.Response;
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

        public async void PostRequest(string secret)
        {
            PlaidClient pClient = new PlaidClient("test_id", secret);
            Credentials credentials = new Credentials("plaid_test", "plaid_good");
            var responseString = pClient.requestAllAccountData(credentials, "wells");

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

                //var responseString = await response.Content.ReadAsStringAsync();
                Parser parser = new Parser();
                IList<Account> accounts = parser.parseAccounts(responseString);

                IList<Transaction> transactions = parser.parseTransactions(responseString);

                Debug.WriteLine("Final Accounts");
            }
        }
    }
}
