using ScorchGore.Configuration;
using ScorchGore.Extensions;
using System.Net.Http.Headers;
using System.Text;

namespace ScorchGore.ApiClient;

internal class GoreApiClient
{
    internal static bool InitiateGame(Guid token, string payload)
    {
        var client = HttpClientFactory.Create();
        client.BaseAddress = new(InstanceConfiguration.ApiUrl);

        using var request = new HttpRequestMessage(
            HttpMethod.Post,
            "v1/initiate.php"
        );

        var lines = new List<string>
        {
            token.ToGore()
        };

        lines.AddRange(payload.Split(Environment.NewLine));

        request.Content = new StringContent(
            string.Join('\n', lines),
            Encoding.UTF8,
            MediaTypeHeaderValue.Parse("application/json")
        );
        
        using var response = client.Send(request);
        
        response.EnsureSuccessStatusCode();
        
        var body = response.Content.ReadAsStringAsync().Result;

        return true;
    }

    internal static (bool success, string[] payload) Pop(Guid token, int queuePositiom)
    {
        var client = HttpClientFactory.Create();
        client.BaseAddress = new(InstanceConfiguration.ApiUrl);

        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"v1/join.php?token={token.ToGore()}&ordinal={queuePositiom}"
        );

        using var response = client.Send(request);

        if(response.IsSuccessStatusCode)
        {
            var body = response.Content.ReadAsStringAsync().Result;
            var lines = body.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            return (true, lines);
        }

        return (false, []);
    }

    internal static bool Turn(Guid token, int turn, string[] payload)
    {
        var client = HttpClientFactory.Create();
        client.BaseAddress = new(InstanceConfiguration.ApiUrl);

        using var request = new HttpRequestMessage(
            HttpMethod.Patch,
            $"v1/turn.php?token={token.ToGore()}&ordinal={turn}"
        );

        request.Content = new StringContent(
            string.Join('\n', payload),
            Encoding.UTF8,
            MediaTypeHeaderValue.Parse("application/json")
        );

        using var response = client.Send(request);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        var body = response.Content.ReadAsStringAsync().Result;

        return false;
    }
}
