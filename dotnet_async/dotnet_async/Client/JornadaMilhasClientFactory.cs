using System.Net.Http.Headers;

namespace dotnet_async.Client;

public class JornadaMilhasClientFactory : IHttpClientFactory
{
    private string url = "http://localhost:5125";

    public HttpClient CreateClient(string name)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        return client;
    }
}