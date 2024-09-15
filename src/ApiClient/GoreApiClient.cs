using ScorchGore.Configuration;
using ScorchGore.Extensions;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace ScorchGore.ApiClient;

internal class GoreApiClient
{
    #region Event Stuff
    public static object RestEventRoot = new();
    public static object ApiMessageEventRoot = new();

    public delegate void RestCommunicationEventHandler(object sender, RestCommunicationEventArgs e);
    public delegate void ApiMessageEventHandler(object sender, ApiMessageEventArgs e);

    public class RestCommunicationEventArgs(
        HttpMethod method,
        string controller,
        HttpStatusCode status,
        string response
    ) : EventArgs
    {
        public HttpMethod Method => method;
        public string Controller => controller;
        public HttpStatusCode Status => status;
        public string Response => response;
    }

    public class ApiMessageEventArgs(
        string method,
        string token,
        int player, // even/odd for two-player games
        int turn,
        string[] payload
    ) : EventArgs
    {
        public string Method => method;
        public string Token => token;
        public int Player => player;
        public int Turn => turn;
        public string[] Payload => payload;
    }

    internal static event RestCommunicationEventHandler? RestCommunication;
    internal static event ApiMessageEventHandler? ApiMessages;

    protected static void OnRestCommunication(RestCommunicationEventArgs e)
    {
        RestCommunication?.Invoke(RestEventRoot, e);
    }

    protected static void OnApiMessage(ApiMessageEventArgs e)
    {
        ApiMessages?.Invoke(ApiMessageEventRoot, e);
    }
    #endregion

    internal static bool InitiateGame(Guid token, string payload)
    {
        var lines = new List<string>(payload.Split(Environment.NewLine));

        try
        {
            var client = HttpClientFactory.Create();
            client.BaseAddress = new(InstanceConfiguration.ApiUrl);

            using var request = new HttpRequestMessage(
                HttpMethod.Post,
                "v1/initiate.php"
            );

            request.Content = new StringContent(
                $"{token.ToGore()}\n{string.Join('\n', lines)}",
                Encoding.UTF8,
                MediaTypeHeaderValue.Parse("text/plain")
            );

            using var response = client.Send(request);
            var body = response.Content.ReadAsStringAsync().Result;

            OnRestCommunication(new(HttpMethod.Post, "initate", response.StatusCode, body));

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            OnRestCommunication(new(HttpMethod.Post, "initate", HttpStatusCode.ServiceUnavailable, ex.ToString()));
        }
        finally
        {
            /* initiator is always even, 0 is even */
            OnApiMessage(new(nameof(InitiateGame), token.ToGore(), 0, 0, [.. lines]));
        }

        return false;
    }

    internal static (bool success, string[] payload) Pop(Guid token, int queuePositiom)
    {
        var lines = new List<string>();
        var suppressLog = false;

        try
        {
            var client = HttpClientFactory.Create();
            client.BaseAddress = new(InstanceConfiguration.ApiUrl);

            using var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"v1/join.php?token={token.ToGore()}&ordinal={queuePositiom}"
            );

            using var response = client.Send(request);
            var body = response.Content.ReadAsStringAsync().Result;

            suppressLog = response.StatusCode == HttpStatusCode.NotFound;
            if (!suppressLog)
            {
                OnRestCommunication(new(HttpMethod.Get, "join", response.StatusCode, body));
            }

            if (response.IsSuccessStatusCode)
            {
                lines.AddRange(body.Split('\n', StringSplitOptions.RemoveEmptyEntries));

                return (true, [.. lines]);
            }
        }
        catch (Exception ex)
        {
            suppressLog = false;
            OnRestCommunication(new(HttpMethod.Get, "join", HttpStatusCode.ServiceUnavailable, ex.ToString()));
        }
        finally
        {
            if (!suppressLog)
            {
                OnApiMessage(new(nameof(Pop), token.ToGore(), 0, queuePositiom, [.. lines]));
            }
        }

        return (false, []);
    }

    internal static bool Turn(Guid token, int turn, string[] payload)
    {
        try
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
            var body = response.Content.ReadAsStringAsync().Result;
            OnRestCommunication(new(HttpMethod.Patch, "turn", response.StatusCode, body));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

        }
        catch (Exception ex)
        {
            OnRestCommunication(new(HttpMethod.Patch, "turn", HttpStatusCode.ServiceUnavailable, ex.ToString()));
        }
        finally
        {
            OnApiMessage(new(nameof(Turn), token.ToGore(), 0, turn, payload));
        }

        return false;
    }
}
