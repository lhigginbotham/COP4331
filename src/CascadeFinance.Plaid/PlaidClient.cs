using CascadeFinance.Plaid.request;
using System;
using System.Collections.Generic;

public class PlaidClient
{
    private string accessToken;

    private string client_id;
    private string secret;

	public PlaidClient(string client_id, string secret)
	{
        this.client_id = client_id;
        this.secret = secret;
	}

    public string requestAllAccountData(Credentials credentials, string institution)
    {
        var values = new Dictionary<string, string> {
            { "client_id", client_id },
            { "secret", secret},
            { "username", credentials.username },
            { "password", credentials.password },
            { "type", institution},
        };
        Request request = new Request();
        var returnString = request.handleRequest(values);
        return returnString.Result;
    }
}
