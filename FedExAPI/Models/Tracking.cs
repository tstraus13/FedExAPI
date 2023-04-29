using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FedExAPI.Models
{
	public class Tracking
	{
		[JsonPropertyName("completeTrackResults")]
		public List<TrackingItem> TrackingItems { get; set; } = new List<TrackingItem>();

		[JsonPropertyName("alerts")]
		public string Alerts { get; set; } = "";
	}

	public class TrackingItem
	{
		[JsonPropertyName("trackingNumber")]
		public string TrackingNumber { get; set; } = "";

		[JsonPropertyName("trackResults")]
		public List<TrackingDetail> TrackingDetails { get; set; } = new List<TrackingDetail>();
	}

	public class TrackingDetail
	{
		[JsonPropertyName("trackingNumberInfo")]
		public TrackingNumberDetail TrackingNumberDetail { get; set; } = new TrackingNumberDetail();

		[JsonPropertyName("additionalTrackingInfo")]
		public AdditionalTrackingDetail AdditionalTrackingDetail { get; set; } = new AdditionalTrackingDetail();

		[JsonPropertyName("distanceToDestination")]
		public Distance DistanceToDestination { get; set; } = new Distance();

		[JsonPropertyName("consolidationDetail")]
		public List<ConsolidationDetail> ConsolidationDetails { get; set; } = new List<ConsolidationDetail>();

		[JsonPropertyName("meterNumber")]
		public string MeterNumber { get; set; } = "";

		[JsonPropertyName("returnDetail")]
		public ReturnDetail ReturnDetail { get; set; } = new ReturnDetail();

		[JsonPropertyName("serviceDetail")]
		public ServiceDetail ServiceDetail { get; set; } = new ServiceDetail();

		[JsonPropertyName("destinationLocation")]
		public Location DestinationLocation { get; set; } = new Location();

		[JsonPropertyName("latestStatusDetail")]
		public StatusDetail LatestStatusDetail { get; set; } = new StatusDetail();

		[JsonPropertyName("serviceCommitMessage")]
		public ServiceCommitMessage ServiceCommitMessage { get; set; } = new ServiceCommitMessage();

		[JsonPropertyName("informationNotes")]
		public List<InformationNote> InformationNotes { get; set; } = new List<InformationNote>();

		[JsonPropertyName("error")]
		public Error Error { get; set; } = new Error();

		[JsonPropertyName("specialHandlings")]
		public List<SpecialHandling> SpecialHandlings { get; set; } = new List<SpecialHandling>();

		[JsonPropertyName("availableImages")]
		public List<AvailableImage> AvailableImages { get; set; } = new List<AvailableImage>();

		[JsonPropertyName("deliveryDetails")]
		public DeliveryDetail DeliveryDetail { get; set; } = new DeliveryDetail();

		[JsonPropertyName("scanEvents")]
		public List<ScanEvent> ScanEvents { get; set; } = new List<ScanEvent>();

		[JsonPropertyName("dateAndTimes")]
		public List<DateAndTime> DateAndTimes { get; set; } = new List<DateAndTime>();

		[JsonPropertyName("packageDetails")]
		public PackageDetail PackageDetail { get; set; } = new PackageDetail();

		[JsonPropertyName("goodsClassificationCode")]
		public string GoodsClassificationCode { get; set; } = "";
		
		[JsonPropertyName("holdAtLocation")]
		public Location HoldAtLocation { get; set; } = new Location();

		[JsonPropertyName("customDeliveryOptions")]
		public List<DeliveryOption> CustomDeliveryOptions { get; set; } = new List<DeliveryOption>();
		
		[JsonPropertyName("estimatedDeliveryTimeWindow")]
		public List<DeliveryWindow> EstimatedDeliveryTimeWindow { get; set; } = new List<DeliveryWindow>();
	}

	public class TrackingNumberDetail
	{
		[JsonPropertyName("trackingNumber")]
		public string TrackingNumber { get; set; } = "";

		[JsonPropertyName("carrierCode")]
		public string CarrierCode { get; set; } = "";

		[JsonPropertyName("trackingNumberUniqueId")]
		public string TrackingNumberUniqueId { get; set; } = "";
	}

	public class AdditionalTrackingDetail
	{
		[JsonPropertyName("hasAssociatedShipments")]
		public bool HasAssociatedShipments { get; set; }

		[JsonPropertyName("nickname")]
		public string Nickname { get; set; } = "";

		[JsonPropertyName("packageIdentifiers")]
		public List<PackageIdentifier> PackageIdentifiers { get; set; } = new List<PackageIdentifier>();

		[JsonPropertyName("shipmentNotes")]
		public string Notes { get; set; } = "";
	}

	public class PackageIdentifier
	{
		[JsonPropertyName("type")]
		public string Type { get; set; } = "";

		[JsonPropertyName("value")]
		public string[] Value { get; set; } = Array.Empty<string>();

		[JsonPropertyName("trackingNumberUniqueId")]
		public string TrackingNumberUniqueId { get; set; } = "";
	}

	public class Distance
	{
		[JsonPropertyName("units")]
		public string Units { get; set; } = "";

		[JsonPropertyName("value")]
		public double Value { get; set; }
	}

	public class ConsolidationDetail
	{
		[JsonPropertyName("timeStamp")]
		public string TimeStampText { get; set; } = "";

		[JsonPropertyName("consolidationID")]
		public string ConsolidationId { get; set; } = "";

		[JsonPropertyName("reasonDetail")]
		public ReasonDetail ReasonDetail { get; set; } = new ReasonDetail();

		[JsonPropertyName("packageCount")]
		public int PackageCount { get; set; }

		[JsonPropertyName("eventType")]
		public string EventType { get; set; } = "";


		public DateTime TimeStamp
		{
			get
			{
				return DateTime.TryParse(TimeStampText, out DateTime result) ?
					result : default(DateTime);
			}
		}
	}

	public class ReasonDetail
	{
		[JsonPropertyName("description")]
		public string Description { get; set; } = "";

		[JsonPropertyName("type")]
		public string Type { get; set; } = "";
	}

	public class ReturnDetail
	{
		[JsonPropertyName("authorizationName")]
		public string AuthorizationName { get; set; } = "";

		[JsonPropertyName("reasonDetail")]
		public List<ReasonDetail> ReasonDetails { get; set; } = new List<ReasonDetail>();
	}

	public class ServiceDetail
	{
		[JsonPropertyName("description")]
		public string Description { get; set; } = "";

		[JsonPropertyName("shortDescription")]
		public string ShortDescription { get; set; } = "";

		[JsonPropertyName("type")]
		public string Type { get; set; } = "";
	}

	public class Location
	{
		[JsonPropertyName("locationId")]
		public string LocationId { get; set; } = "";

		[JsonPropertyName("locationContactAndAddress")]
		public ContactAndAddress LocationContactAndAddress { get; set; } = new ContactAndAddress();

		[JsonPropertyName("locationType")]
		public string Type { get; set; } = "";
	}

	public class ContactAndAddress
	{
		[JsonPropertyName("contact")]
		public Contact Contact { get; set; } = new Contact();

		[JsonPropertyName("address")]
		public Address Address { get; set; } = new Address();
	}

	public class Contact
	{
		[JsonPropertyName("personName")]
		public string PersonName { get; set; } = "";

		[JsonPropertyName("phoneNumber")]
		public string PhoneNumber { get; set; } = "";

		[JsonPropertyName("companyName")]
		public string CompanyName { get; set; } = "";
	}

	public class Address
	{
		[JsonPropertyName("addressClassification")]
		public string AddressClassification { get; set; } = "";

		[JsonPropertyName("residential")]
		public bool Residential { get; set; }

		[JsonPropertyName("streetLines")]
		public string[] StreetLines { get; set; } = Array.Empty<string>();

		[JsonPropertyName("city")]
		public string City { get; set; } = "";

		[JsonPropertyName("urbanizationCode")]
		public string UrbanizationCode { get; set; } = "";

		[JsonPropertyName("stateOrProvinceCode")]
		public string StateOrProvinceCode { get; set; } = "";

		[JsonPropertyName("postalCode")]
		public string PostalCode { get; set; } = "";

		[JsonPropertyName("countryCode")]
		public string CountryCode { get; set; } = "";

		[JsonPropertyName("countryName")]
		public string CountryName { get; set; } = "";
	}

	public class StatusDetail
	{
		[JsonPropertyName("scanLocation")]
		public Location ScanLocation { get; set; } = new Location();

		[JsonPropertyName("code")]
		public string Code { get; set; } = "";

		[JsonPropertyName("derivedCode")]
		public string DerivedCode { get; set; } = "";

		[JsonPropertyName("ancillaryDetails")]
		public List<AncillaryDetail> AncillaryDetails { get; set; } = new List<AncillaryDetail>();

		[JsonPropertyName("statusByLocale")]
		public string StatusByLocale { get; set; } = "";

		[JsonPropertyName("description")]
		public string Description { get; set; } = "";

		[JsonPropertyName("delayDetail")]
		public DelayDetail DelayDetail { get; set; } = new DelayDetail();
	}

	public class AncillaryDetail
	{
		[JsonPropertyName("reason")]
		public string Reason { get; set; } = "";

		[JsonPropertyName("reasonDescription")]
		public string ReasonDescription { get; set; } = "";

		[JsonPropertyName("action")]
		public string Action { get; set; } = "";

		[JsonPropertyName("actionDescription")]
		public string ActionDescription { get; set; } = "";
	}

	public class DelayDetail
	{
		[JsonPropertyName("type")]
		public string Type { get; set; } = "";

		[JsonPropertyName("subType")]
		public string SubType { get; set; } = "";

		[JsonPropertyName("status")]
		public string Status { get; set; } = "";
	}

	public class ServiceCommitMessage
	{
		[JsonPropertyName("message")]
		public string Message { get; set; } = "";

		[JsonPropertyName("type")]
		public string Type { get; set; } = "";
	}

	public class InformationNote
	{
		[JsonPropertyName("code")]
		public string Code { get; set; } = "";
		
		[JsonPropertyName("description")]
		public string Description { get; set; } = "";
	}

	public class Error
	{
		[JsonPropertyName("code")]
		public string Code { get; set; } = "";
		
		[JsonPropertyName("parameterList")]
		public List<Parameter> ParameterList = new List<Parameter>();

		[JsonPropertyName("message")]
		public string Message { get; set; } = "";
	}

	public class Parameter
	{
		[JsonPropertyName("value")]
		public string Value { get; set; } = "";
		
		[JsonPropertyName("key")]
		public string Key { get; set; } = "";
	}

	public class SpecialHandling
	{
		[JsonPropertyName("description")]
		public string Description { get; set; } = "";

		[JsonPropertyName("type")]
		public string Type { get; set; } = "";

		[JsonPropertyName("paymentType")]
		public string PaymentType { get; set; } = "";
	}

	public class AvailableImage
	{
		[JsonPropertyName("size")]
		public string Size { get; set; } = "";

		[JsonPropertyName("type")]
		public string Type { get; set; } = "";
	}

	public class DeliveryDetail
	{
		[JsonPropertyName("receivedByName")]
		public string ReceivedByName { get; set; } = "";

		[JsonPropertyName("destinationServiceArea")]
		public string DestinationServiceArea { get; set; } = "";

		[JsonPropertyName("destinationServiceAreaDescription")]
		public string DestinationServiceAreaDescription { get; set; } = "";

		[JsonPropertyName("locationDescription")]
		public string LocationDescription { get; set; } = "";

		[JsonPropertyName("actualDeliveryAddress")]
		public Address ActualDeliveryAddress { get; set; } = new Address();

		[JsonPropertyName("deliveryToday")]
		public bool DeliveryToday { get; set; }

		[JsonPropertyName("locationType")]
		public string LocationType { get; set; } = "";

		[JsonPropertyName("signedByName")]
		public string SignedByName { get; set; } = "";

		[JsonPropertyName("officeOrderDeliveryMethod")]
		public string OfficeOrderDeliveryMethod { get; set; } = "";

		[JsonPropertyName("deliveryAttempts")]
		public string DeliveryAttemptsText { get; set; } = "";

		[JsonPropertyName("deliveryOptionEligibilityDetails")]
		public List<DeliveryOptionEligibilityDetail> DeliveryOptionEligibilityDetails { get; set; } =
			new List<DeliveryOptionEligibilityDetail>();

		public int DeliveryAttempts
		{
			get
			{
				return int.TryParse(DeliveryAttemptsText, out int result) ? result : 0;
			}
		}
	}

	public class DeliveryOptionEligibilityDetail
	{
		[JsonPropertyName("option")]
		public string Option { get; set; } = "";

		[JsonPropertyName("eligibility")]
		public string Eligibility { get; set; } = "";
	}

	public class ScanEvent
	{
		[JsonPropertyName("date")]
		public string DateText { get; set; } = "";

		[JsonPropertyName("derivedStatus")]
		public string DerivedStatus { get; set; } = "";

		[JsonPropertyName("scanLocation")]
		public Location ScanLocation { get; set; } = new Location();
		
		[JsonPropertyName("locationId")]
		public string LocationId { get; set; } = "";

		[JsonPropertyName("locationType")]
		public string LocationType { get; set; } = "";
		
		[JsonPropertyName("exceptionDescription")]
		public string ExceptionDescription { get; set; } = "";

		[JsonPropertyName("eventDescription")]
		public string EventDescription { get; set; } = "";

		[JsonPropertyName("eventType")]
		public string EventType { get; set; } = "";
		
		[JsonPropertyName("derivedStatusCode")]
		public string DerivedStatusCode { get; set; } = "";

		[JsonPropertyName("exceptionCode")]
		public string ExceptionCode { get; set; } = "";

		[JsonPropertyName("delayDetail")]
		public DelayDetail DelayDetail { get; set; } = new DelayDetail();
		
		public DateTime Date
		{
			get
			{
				return DateTime.TryParse(DateText, out DateTime result) ? result : default(DateTime);
			}
		}
	}

	public class DateAndTime
	{
		[JsonPropertyName("dateTime")]
		public string DateTime { get; set; } = "";

		[JsonPropertyName("type")]
		public string Type { get; set; } = "";
	}

	public class PackageDetail
	{
		[JsonPropertyName("physicalPackagingType")]
		public string PhysicalPackagingType { get; set; } = "";

		[JsonPropertyName("sequenceNumber")]
		public string SequenceNumberText { get; set; } = "";
		
		[JsonPropertyName("undeliveredCount")]
		public string UndeliveredCountText { get; set; } = "";

		[JsonPropertyName("packagingDescription")]
		public PackagingDescription PackagingDescription { get; set; } = new PackagingDescription();

		[JsonPropertyName("count")]
		public string CountText { get; set; } = "";

		[JsonPropertyName("weightAndDimensions")]
		public WeightAndDimensions WeightAndDimensions { get; set; } = new WeightAndDimensions();

		[JsonPropertyName("packageContent")]
		public string[] PackageContent { get; set; } = Array.Empty<string>();

		[JsonPropertyName("contentPieceCount")]
		public string ContentPieceCountText { get; set; } = "";

		[JsonPropertyName("declaredValue")]
		public DeclaredValue DeclaredValue { get; set; } = new DeclaredValue();
		
		public int SequenceNumber
		{
			get
			{
				return int.TryParse(SequenceNumberText, out int result) ? result : 0;
			}
		}
		
		public int UndeliveredCount
		{
			get
			{
				return int.TryParse(UndeliveredCountText, out int result) ? result : 0;
			}
		}
		
		public int Count
		{
			get
			{
				return int.TryParse(CountText, out int result) ? result : 0;
			}
		}

		public int ContentPieceCount
		{
			get
			{
				return int.TryParse(ContentPieceCountText, out int result) ? result : 0;
			}
		}
	}
	
	public class PackagingDescription
	{
		[JsonPropertyName("description")]
		public string Description { get; set; } = "";

		[JsonPropertyName("type")]
		public string Type { get; set; } = "";
	}

	public class WeightAndDimensions
	{
		[JsonPropertyName("weight")]
		public List<Weight> Weights { get; set; } = new List<Weight>();
		
		[JsonPropertyName("dimensions")]
		public List<Dimension> Dimensions { get; set; } = new List<Dimension>();
	}

	public class Weight
	{
		[JsonPropertyName("unit")]
		public string Unit { get; set; } = "";

		[JsonPropertyName("value")]
		public string ValueText { get; set; } = "";

		public double Value
		{
			get
			{
				return double.TryParse(ValueText, out double result) ? result : 0;
			}
		}
	}

	public class Dimension
	{
		[JsonPropertyName("length")]
		public int Length { get; set; }

		[JsonPropertyName("width")]
		public int Width { get; set; }
		
		[JsonPropertyName("height")]
		public int Height { get; set; }

		[JsonPropertyName("units")]
		public string Unit { get; set; } = "";
	}

	public class DeclaredValue
	{
		[JsonPropertyName("currency")]
		public string Currency { get; set; } = "";
		
		[JsonPropertyName("value")]
		public double Value { get; set; }
	}

	public class DeliveryOption
	{
		[JsonPropertyName("requestedAppointmentDetail")]
		public AppointmentDetail RequestedAppointmentDetail { get; set; } = new AppointmentDetail();

		[JsonPropertyName("description")]
		public string Description { get; set; } = "";
		
		[JsonPropertyName("type")]
		public string Type { get; set; } = "";

		[JsonPropertyName("status")]
		public string Status { get; set; } = "";
	}

	public class AppointmentDetail
	{
		[JsonPropertyName("date")]
		public string DateText { get; set; } = "";

		[JsonPropertyName("window")]
		public List<DeliveryWindow> AppointmentWindows { get; set; } = new List<DeliveryWindow>();

		public DateTime Date
		{
			get
			{
				return DateTime.TryParse(DateText, out DateTime result) ? result : default(DateTime);
			}
		}
	}

	public class DeliveryWindow
	{
		[JsonPropertyName("description")]
		public string Description { get; set; } = "";

		[JsonPropertyName("window")]
		public DateTimeWindow Window { get; set; } = new DateTimeWindow();
		
		[JsonPropertyName("type")]
		public string Type { get; set; } = "";
	}
	
	public class DateTimeWindow
	{
		[JsonPropertyName("begins")]
		public string BeginsText { get; set; } = "";
		
		[JsonPropertyName("ends")]
		public string EndsText { get; set; } = "";

		public DateTime Begins
		{
			get
			{
				return DateTime.TryParse(BeginsText, out DateTime result) ? result : default(DateTime);
			}
		}
		
		public DateTime Ends
		{
			get
			{
				return DateTime.TryParse(EndsText, out DateTime result) ? result : default(DateTime);
			}
		}
	}
}
