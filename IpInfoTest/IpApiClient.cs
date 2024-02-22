using IpInfoTest.Models;

namespace IpInfoTest
{
    public class IpApiClient(HttpClient httpClient)
    {
        private const string BaseUrl = "http://ip-api.com";
        private readonly HttpClient _httpClient = httpClient;

        public async Task<IpApiResponse?> Get(string? ipAddress, CancellationToken ct)
        {
            var route = $"{BaseUrl}/json/{ipAddress}";
            var response = await _httpClient.GetFromJsonAsync<IpApiResponse>(route, ct);
            return response;
        }
    }
}
