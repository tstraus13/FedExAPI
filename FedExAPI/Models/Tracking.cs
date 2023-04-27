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

		// TODO: Continue Tracking Info HERE
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
		public string[] Value { get; set; } = new string[0];

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
				if (DateTime.TryParse(TimeStampText, out DateTime result))
					return result;

				return default(DateTime);
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


    public static class CarrierCodes
	{
		public static readonly string FDXE					= "FDXE";
        public static readonly string FDXG					= "FDXG";
        public static readonly string FXSP					= "FXSP";
        public static readonly string FXFR					= "FXFR";
        public static readonly string FDXC					= "FDXC";
        public static readonly string FXCC					= "FXCC";
        public static readonly string FEDEX_CARGO			= "FEDEX_CARGO";
        public static readonly string FEDEX_CUSTOM_CRITICAL = "FEDEX_CUSTOM_CRITICAL";
        public static readonly string FEDEX_EXPRESS			= "FEDEX_EXPRESS";
        public static readonly string FEDEX_FREIGHT			= "FEDEX_FREIGHT";
        public static readonly string FEDEX_GROUND			= "FEDEX_GROUND";
        public static readonly string FEDEX_OFFICE			= "FEDEX_OFFICE";
        public static readonly string FEDEX_KINKOS			= "FEDEX_KINKOS";
        public static readonly string FX					= "FX";
        public static readonly string FDFR					= "FDFR";
        public static readonly string FDEG					= "FDEG";
        public static readonly string FXK					= "FXK";
        public static readonly string FDC					= "FDC";
        public static readonly string FDCC					= "FDCC";
    }

	public static class PackageIdentifierTypes
	{
		public static readonly string BILL_OF_LADING						= "BILL_OF_LADING";
		public static readonly string COD_RETURN_TRACKING_NUMBER			= "COD_RETURN_TRACKING_NUMBER";
		public static readonly string CUSTOMER_AUTHORIZATION_NUMBER			= "CUSTOMER_AUTHORIZATION_NUMBER";
		public static readonly string CUSTOMER_REFERENCE					= "CUSTOMER_REFERENCE";
		public static readonly string DEPARTMENT							= "DEPARTMENT";
		public static readonly string DOCUMENT_AIRWAY_BILL					= "DOCUMENT_AIRWAY_BILL";
		public static readonly string EXPRESS_ALTERNATE_REFERENCE			= "EXPRESS_ALTERNATE_REFERENCE";
		public static readonly string FEDEX_OFFICE_JOB_ORDER_NUMBER			= "FEDEX_OFFICE_JOB_ORDER_NUMBER";
		public static readonly string FREE_FORM_REFERENCE					= "FREE_FORM_REFERENCE";
		public static readonly string GROUND_INTERNATIONAL					= "GROUND_INTERNATIONAL";
		public static readonly string GROUND_SHIPMENT_ID					= "GROUND_SHIPMENT_ID";
		public static readonly string GROUP_MPS								= "GROUP_MPS";
		public static readonly string INTERNATIONAL_DISTRIBUTION			= "INTERNATIONAL_DISTRIBUTION";
		public static readonly string INVOICE								= "INVOICE";
		public static readonly string JOB_GLOBAL_TRACKING_NUMBER			= "JOB_GLOBAL_TRACKING_NUMBER";
		public static readonly string ORDER_GLOBAL_TRACKING_NUMBER			= "ORDER_GLOBAL_TRACKING_NUMBER";
		public static readonly string ORDER_TO_PAY_NUMBER					= "ORDER_TO_PAY_NUMBER";
		public static readonly string OUTBOUND_LINK_TO_RETURN				= "OUTBOUND_LINK_TO_RETURN";
		public static readonly string PART_NUMBER							= "PART_NUMBER";
		public static readonly string PARTNER_CARRIER_NUMBER				= "PARTNER_CARRIER_NUMBER";
		public static readonly string PURCHASE_ORDER						= "PURCHASE_ORDER";
		public static readonly string REROUTE_TRACKING_NUMBER				= "REROUTE_TRACKING_NUMBER";
		public static readonly string RETURN_MATERIALS_AUTHORIZATION		= "RETURN_MATERIALS_AUTHORIZATION";
		public static readonly string RETURNED_TO_SHIPPER_TRACKING_NUMBER	= "RETURNED_TO_SHIPPER_TRACKING_NUMBER";
		public static readonly string SHIPPER_REFERENCE						= "SHIPPER_REFERENCE";
		public static readonly string STANDARD_MPS							= "STANDARD_MPS";
		public static readonly string TRACKING_CONTROL_NUMBER				= "TRACKING_CONTROL_NUMBER";
		public static readonly string TRACKING_NUMBER_OR_DOORTAG			= "TRACKING_NUMBER_OR_DOORTAG";
		public static readonly string TRANSBORDER_DISTRIBUTION				= "TRANSBORDER_DISTRIBUTION";
		public static readonly string TRANSPORTATION_CONTROL_NUMBER			= "TRANSPORTATION_CONTROL_NUMBER";
		public static readonly string VIRTUAL_CONSOLIDATION					= "VIRTUAL_CONSOLIDATION";
    }

	public static class DistanceUnits
	{
		public static readonly string Kilometers	= "KM";
		public static readonly string Miles			= "MI";
	}

    // TODO: Add Event Types from Consolidation Details (ex. PACKAGE_ADDED_TO_CONSOLIDATION)

	// TODO: Add Reason Detail Types from Reason Detail under Consolidation Details (ex. REJECTED)
}

