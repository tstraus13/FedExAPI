using System.Text.Json.Serialization;

namespace FedExAPI.Models
{
	public class TrackDocumentResponse
	{
		[JsonPropertyName("transactionId")]
		public string TransactionId { get; set; } = "";

		[JsonPropertyName("customerTransactionId")]
		public string CustomerTransactionId { get; set; } = "";

		[JsonPropertyName("output")]
		public TrackDocument TrackingDocument { get; set; } = new TrackDocument();
	}

	public class TrackDocumentRequest
	{
		public TrackDocumentRequest(string trackingNumber, string documentType, string? documentFormat = null,
			string? carrierCode = null, string? trackingNumberUniqueId = null, DateTime? shipDateBegin = null,
			DateTime? shipDateEnd = null, string? accountNumber = null)
		{
			TrackDocumentDetail.DocumentType = documentType;
			TrackDocumentDetail.DocumentFormat = documentFormat;

			TrackDocumentSpecifications.Add(new TrackingNumberInfo
			{
				TrackingNumberDetail = new TrackingNumberDetail
				{
					TrackingNumber = trackingNumber,
					TrackingNumberUniqueId = trackingNumberUniqueId,
					CarrierCode = carrierCode
				},
				ShipDateBegin = shipDateBegin?.ToString("yyyy-MM-dd"),
				ShipDateEnd = shipDateEnd?.ToString("yyyy-MM-dd"),
				AccountNumber = accountNumber
			});
		}
		
		[JsonPropertyName("trackDocumentDetail")]
		public TrackDocumentDetail TrackDocumentDetail { get; set; } = new TrackDocumentDetail();

		[JsonPropertyName("trackDocumentSpecification")]
		public List<TrackingNumberInfo> TrackDocumentSpecifications { get; set; } = new List<TrackingNumberInfo>();
	}

	public class TrackDocument
	{
		[JsonPropertyName("localization")]
		public Localization Localization { get; set; } = new Localization();

		[JsonPropertyName("documentType")]
		public string DocumentType { get; set; } = "";

		[JsonPropertyName("documentFormat")]
		public string DocumentFormat { get; set; } = "";

		[JsonPropertyName("document")]
		public string[] Document { get; set; } = Array.Empty<string>();

		[JsonPropertyName("alerts")]
		public List<Alert> Alerts { get; set; } = new List<Alert>();
	}

	public class TrackDocumentDetail
	{
		[JsonPropertyName("documentType")]
		public string DocumentType { get; set; } = "";

		[JsonPropertyName("documentFormat")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? DocumentFormat { get; set; } = null;
	}

	public class Localization
	{
		[JsonPropertyName("languageCode")]
		public string LanguageCode { get; set; } = "";

		[JsonPropertyName("localeCode")]
		public string LocaleCode { get; set; } = "";
	}
}
