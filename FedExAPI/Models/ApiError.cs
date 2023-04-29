using System;
using System.Text.Json.Serialization;

namespace FedExAPI.Models
{
	public class ApiError
	{
		[JsonPropertyName("transactionId")]
		public string TransactionId { get; set; } = "";

		[JsonPropertyName("customerTransactionId")]
		public string CustomerTransactionId { get; set; } = "";

        [JsonPropertyName("errors")]
		public List<ApiErrorReason> Reasons { get; set; } = new List<ApiErrorReason>();
	}

	public class ApiErrorReason
	{
		[JsonPropertyName("code")]
		public string Code { get; set; } = "";

		[JsonPropertyName("message")]
		public string Message { get; set; } = "";
	}

	public struct ApiErrorCodes
	{
		public const string NOT_AUTHORIZED             = "NOT.AUTHORIZED.ERROR";
		public const string INTERNAL_SERVER_ERROR      = "INTERNAL.SERVER.ERROR";
		public const string TRACKING_REFERENCE_INVALID = "TRACKING.REFERENCETYPE.INVALID";
		public const string FORBIDDEN                  = "FORBIDDEN.ERROR";
		public const string NOT_FOUND                  = "NOT.FOUND.ERROR";
        public const string SERVICE_UNAVAILABLE        = "SERVICE.UNAVAILABLE.ERROR";
    }
}

