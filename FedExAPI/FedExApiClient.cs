﻿using FedExAPI.Models;
using FedExAPI.Structs;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace FedExAPI
{
    public class FedExApiClient : IDisposable
    {
        private readonly string _clientId, _clientSecret;
        private readonly HttpClient _httpClient;
        private OAuth _auth;

        public FedExApiClient(string clientId, string clientSecret) : this(clientId, clientSecret, false, "en_US") { }

        public FedExApiClient(string clientId, string clientSecret, bool sandboxEnvironment = false, string locale = "en_US")
        {
            _clientId = clientId;
            _clientSecret = clientSecret;

            _auth = new OAuth();

            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(sandboxEnvironment ? "https://apis-sandbox.fedex.com" : "https://apis.fedex.com");
            _httpClient.DefaultRequestHeaders.Add("x-locale", locale);
        }

        public async Task<ApiResponse<OAuth>> RetrieveOAuth()
        {
            var result = new ApiResponse<OAuth>();

            if (!_auth.Expired)
            {
                result.Data = _auth;

                return result;
            }

            var content = new FormUrlEncodedContent(
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

            var auth = JsonSerializer.Deserialize<OAuth>(responseContent);

            if (auth != null)
            {
                _auth = auth;

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    _auth.AccessToken
                );
            }

            result.Data = auth;
                
            return result;
        }

        public async Task<ApiResponse<TrackMultiPieceResponse>> TrackMultiPieceShipment(string trackingNumber, string associatedType,
            bool includeDetailedScans = false, string? carrierCode = null, string? trackingNumberUniqueId = null, int resultsPerPage = 0,
            string? pagingToken = null, DateTime? shipDateBegin = null, DateTime? shipDateEnd = null, string? transactionId = null)
        {
            var requestModel = new TrackMultiPieceRequest(trackingNumber, associatedType,
                includeDetailedScans, carrierCode, trackingNumberUniqueId, resultsPerPage,
                pagingToken, shipDateBegin, shipDateEnd);

            return await TrackMultiPieceShipment(requestModel, transactionId);
        }

        public async Task<ApiResponse<TrackMultiPieceResponse>> TrackMultiPieceShipment(TrackMultiPieceRequest request, string? transactionId = null)
        {
            if (string.IsNullOrEmpty(request.MasterTrackingNumberInfo.TrackingNumberDetail.TrackingNumber) 
                || string.IsNullOrWhiteSpace(request.MasterTrackingNumberInfo.TrackingNumberDetail.TrackingNumber))
                throw new Exception("Tracking Number is Required!");
			
            if (string.IsNullOrEmpty(request.AssociatedType) || string.IsNullOrWhiteSpace(request.AssociatedType))
                throw new Exception("Associated Type is Required!");
            
            var result = new ApiResponse<TrackMultiPieceResponse>();
            
            var requestJson = JsonSerializer.Serialize(request);

            HttpContent content = new StringContent(requestJson, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            
            if (!string.IsNullOrEmpty(transactionId) && !string.IsNullOrWhiteSpace(transactionId))
                content.Headers.Add("x-customer-transaction-id", transactionId);

            if (_auth.Expired)
                await RetrieveOAuth();
            
            var response = await _httpClient.PostAsync("/track/v1/associatedshipments", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (!response.IsSuccessStatusCode)
            {
                if (string.IsNullOrEmpty(responseContent?.Trim()))
                    return result;

                result.Error = JsonSerializer.Deserialize<ApiError>(responseContent);

                return result;
            }
            
            result.Data = JsonSerializer.Deserialize<TrackMultiPieceResponse>(responseContent);

            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient.Dispose();
            }
        }
    }
}

// TODO: Add Event Types from Consolidation Details (ex. PACKAGE_ADDED_TO_CONSOLIDATION)

// TODO: Add Reason Detail Types from Reason Detail under Consolidation Details (ex. REJECTED)

// TODO: Add Service Types from Service Detail - https://developer.fedex.com/api/en-us/guides/api-reference.html#servicetypes

// TODO: Add Currency Codes from Package Detail - https://developer.fedex.com/api/en-us/guides/api-reference.html#currencycodes