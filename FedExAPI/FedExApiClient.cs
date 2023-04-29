using FedExAPI.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FedExAPI
{
    public class FedExApiClient
    {
        private string _clientId, _clientSecret;
        private bool _sandboxEnvironment;

        private readonly HttpClient _httpClient;
        private OAuth _auth;

        public FedExApiClient(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _sandboxEnvironment = false;

            _auth = new OAuth();

            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(_sandboxEnvironment ? "https://apis-sandbox.fedex.com" : "");
        }

        public FedExApiClient(string clientId, string clientSecret, bool sandboxEnvironment = false)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _sandboxEnvironment = sandboxEnvironment;

            _auth = new OAuth();

            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(_sandboxEnvironment ? "https://apis-sandbox.fedex.com" : "");
        }

        public async Task<ApiResponse<OAuth>> RetrieveOAuth()
        {
            var result = new ApiResponse<OAuth>();

            FormUrlEncodedContent content = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", _clientId),
                    new KeyValuePair<string, string>("client_secret", _clientSecret)
                }
            );
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await _httpClient.PostAsync("/oauth/token", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                if (string.IsNullOrEmpty(responseContent?.Trim()))
                    return result;

                result.Error = JsonSerializer.Deserialize<ApiError>(responseContent);

                return result;
            }

            result.Data = JsonSerializer.Deserialize<OAuth>(responseContent);
            return result;
        }

        //public async Task<ApiResponse<>>
    }
}

// TODO: Add Event Types from Consolidation Details (ex. PACKAGE_ADDED_TO_CONSOLIDATION)

// TODO: Add Reason Detail Types from Reason Detail under Consolidation Details (ex. REJECTED)

// TODO: Add Service Types from Service Detail - https://developer.fedex.com/api/en-us/guides/api-reference.html#servicetypes

// TODO: Add Currency Codes from Package Detail - https://developer.fedex.com/api/en-us/guides/api-reference.html#currencycodes