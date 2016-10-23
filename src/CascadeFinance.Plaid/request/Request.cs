using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid.request
{
    public class Request
    {
        public static string URL = "https://tartan.plaid.com/connect";

        public Request()
        {

        }

        public async Task<string> handleRequest(Dictionary<string, string> values)
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(URL, content);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
