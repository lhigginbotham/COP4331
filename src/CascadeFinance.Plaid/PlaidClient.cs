using System;

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
}
