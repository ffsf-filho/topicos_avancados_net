using dotnet_async.Modelos;
using System.Net.Http.Json;

namespace dotnet_async.Client;

public class JornadaMilhasClient
{
    private readonly HttpClient client;

    public JornadaMilhasClient(HttpClient httpClient)
    {
        client = httpClient;
    }

    internal async Task<IEnumerable<Voo>?> ConsultarVoos()
    {
        HttpResponseMessage response = await client.GetAsync("/Voos");

        return await response.Content.ReadFromJsonAsync<IEnumerable<Voo>>();
    }

    public async Task<string?> ComprarPassagem(CompraPassagemRequest request)
    {
        return await client.PostAsJsonAsync("/Voos/comprar", request)
                        .Result.Content.ReadFromJsonAsync<string>();
    }
}