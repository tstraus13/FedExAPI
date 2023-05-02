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
	
	public class TrackByTrackingNumberRequest
	{
		public TrackByTrackingNumberRequest(string trackingNumber, bool includeDetailedScans = false, string? carrierCode = null,
			string? trackingNumberUniqueId = null, DateTime? shipDateBegin = null, DateTime? shipDateEnd = null)
		{
			IncludeDetailedScans = includeDetailedScans;

			var trackingInfo = new TrackingNumberInfo();
			
			trackingInfo.ShipDateBegin = shipDateBegin?.ToString("yyyy-MM-dd");
			trackingInfo.ShipDateEnd = shipDateEnd?.ToString("yyyy-MM-dd");
			trackingInfo.TrackingNumberDetail.TrackingNumber = trackingNumber;
			trackingInfo.TrackingNumberDetail.CarrierCode = carrierCode;
			trackingInfo.TrackingNumberDetail.TrackingNumberUniqueId = trackingNumberUniqueId;
			
			TrackingNumberInfo.Add(trackingInfo);
		}
		
		public TrackByTrackingNumberRequest(TrackingNumberInfo trackingInfo, bool includeDetailedScans = false)
		{
			IncludeDetailedScans = includeDetailedScans;

			TrackingNumberInfo.Add(trackingInfo);
		}
		
		public TrackByTrackingNumberRequest(IEnumerable<TrackingNumberInfo> trackingInfo, bool includeDetailedScans = false)
		{
			IncludeDetailedScans = includeDetailedScans;

			TrackingNumberInfo.AddRange(trackingInfo);
		}
		
		[JsonPropertyName("includeDetailedScans")]
		//[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public bool IncludeDetailedScans { get; set; }

		[JsonPropertyName("trackingInfo")]
		public List<TrackingNumberInfo> TrackingNumberInfo { get; set; } = new List<TrackingNumberInfo>();
	}
}
