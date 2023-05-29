using System.Text.Json.Serialization;

namespace FedExAPI.Models
{
	public class TrackMultiPieceResponse
	{
        [JsonPropertyName("transactionId")]
        public string TransactionId { get; set; } = "";

        [JsonPropertyName("customerTransactionId")]
        public string CustomerTransactionId { get; set; } = "";

        [JsonPropertyName("output")]
        public MultiTracking Tracking { get; set; } = new MultiTracking();
    }

	public class TrackMultiPieceRequest
	{
		public TrackMultiPieceRequest(string trackingNumber, string associatedType,
			bool includeDetailedScans = false, string? carrierCode = null, string? trackingNumberUniqueId = null, int resultsPerPage = 0,
			string? pagingToken = null, DateTime? shipDateBegin = null, DateTime? shipDateEnd = null)
		{
			IncludeDetailedScans = includeDetailedScans;
			AssociatedType = associatedType;
			
			MasterTrackingNumberInfo.TrackingNumberDetail.TrackingNumber = trackingNumber;
			MasterTrackingNumberInfo.ShipDateBegin = shipDateBegin?.ToString("yyyy-MM-dd");
			MasterTrackingNumberInfo.ShipDateEnd = shipDateEnd?.ToString("yyyy-MM-dd");
			MasterTrackingNumberInfo.TrackingNumberDetail.CarrierCode = carrierCode;
			MasterTrackingNumberInfo.TrackingNumberDetail.TrackingNumberUniqueId = trackingNumberUniqueId;

			if (resultsPerPage > 0 || !string.IsNullOrEmpty(pagingToken))
			{
				PagingDetail = new PagingDetailRequest
				{
					ResultsPerPage = resultsPerPage > 0 ? resultsPerPage : 5,
					PagingToken = !string.IsNullOrEmpty(pagingToken) ? pagingToken : null
				};
			}
		}
		
		[JsonPropertyName("includeDetailedScans")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public bool IncludeDetailedScans { get; set; }

		[JsonPropertyName("masterTrackingNumberInfo")]
		public TrackingNumberInfo MasterTrackingNumberInfo { get; set; } = new TrackingNumberInfo();

		[JsonPropertyName("associatedType")]
		public string AssociatedType { get; set; } = "";

		[JsonPropertyName("pagingDetails")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public PagingDetailRequest? PagingDetail { get; set; } = null;
	}

	public class TrackingNumberInfo
	{
		[JsonPropertyName("shipDateBegin")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? ShipDateBegin { get; set; } = null;
		
		[JsonPropertyName("shipDateEnd")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? ShipDateEnd { get; set; } = null;
		
		[JsonPropertyName("accountNumber")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? AccountNumber { get; set; } = null;

		[JsonPropertyName("trackingNumberInfo")]
		public TrackingNumberDetail TrackingNumberDetail { get; set; } = new TrackingNumberDetail();
	}
}

