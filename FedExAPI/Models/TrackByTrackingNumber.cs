using System.Text.Json.Serialization;

namespace FedExAPI.Models
{
	public class TrackByTrackingNumberResponse
	{
		[JsonPropertyName("transactionId")]
		public string TransactionId { get; set; } = "";

		[JsonPropertyName("customerTransactionId")]
		public string CustomerTransactionId { get; set; } = "";

		[JsonPropertyName("output")]
		public Tracking Tracking { get; set; } = new Tracking();
	}
}
