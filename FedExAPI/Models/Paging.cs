using System.Text.Json.Serialization;

namespace FedExAPI.Models
{
	public class PagingDetailRequest
	{
		[JsonPropertyName("resultsPerPage")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public int ResultsPerPage { get; set; }

		[JsonPropertyName("pagingToken")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? PagingToken { get; set; }
	}
	
	public class PagingDetailResponse
	{
		[JsonPropertyName("moreDataAvailable")]
		public bool MoreDataAvailable { get; set; }

		[JsonPropertyName("pagingToken")]
		public string PagingToken { get; set; } = "";
	}
}
