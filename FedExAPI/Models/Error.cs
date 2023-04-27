using System;
using System.Text.Json.Serialization;

namespace FedExAPI.Models
{
	public class Error
	{
		[JsonPropertyName("transactionId")]
		public string TransactionId { get; set; } = "";

		[JsonPropertyName("customerTransactionId")]
		public string CustomerTransactionId { get; set; } = "";

        [JsonPropertyName("errors")]
		public List<ErrorReason> Reasons { get; set; } = new List<ErrorReason>();
	}

	public class ErrorReason
	{
		[JsonPropertyName("code")]
		public string Code { get; set; } = "";

		[JsonPropertyName("message")]
		public string Message { get; set; } = "";
	}

	public static class ErrorCodes
	{
		public static readonly string NOT_AUTHORIZED			 = "NOT.AUTHORIZED.ERROR";
		public static readonly string INTERNAL_SERVER_ERROR		 = "INTERNAL.SERVER.ERROR";
		public static readonly string TRACKING_REFERENCE_INVALID = "TRACKING.REFERENCETYPE.INVALID";
		public static readonly string FORBIDDEN					 = "FORBIDDEN.ERROR";
		public static readonly string NOT_FOUND					 = "NOT.FOUND.ERROR";
        public static readonly string SERVICE_UNAVAILABLE		 = "SERVICE.UNAVAILABLE.ERROR";
    }
}

