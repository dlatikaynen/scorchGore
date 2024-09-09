using ScorchGore.Configuration;
using System.Net.Http.Headers;
using System.Text;

namespace ScorchGore.ApiClient;

internal class GoreApiClient
{
    internal static bool InitiateGame(Guid token, string payload)
    {
        using var client = new HttpClient();

        client.BaseAddress = new(InstanceConfiguration.ApiUrl);

        using var request = new HttpRequestMessage(
            HttpMethod.Post,
            "v1/initiate.php"
        );

        var lines = new List<string>
        {
            token.ToString("D").ToUpperInvariant()
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
}
