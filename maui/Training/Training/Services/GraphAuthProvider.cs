using System;
using System.Net.Http.Headers;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace Training;

internal class GraphAuthProvider : IAuthenticationProvider
{
    private readonly IConfidentialClientApplication client;

    public GraphAuthProvider(IConfidentialClientApplication client)
    {
        this.client = client;
    }

    public async Task AuthenticateRequestAsync(HttpRequestMessage request)
    {
        var authResult = await client.AcquireTokenForClient(new[]
        {
            "https://graph.microsoft.com/.default"

        }).ExecuteAsync();

        request.Headers.Authorization = 
            new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
    }
}