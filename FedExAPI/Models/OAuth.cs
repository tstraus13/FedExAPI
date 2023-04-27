using System;
using System.Text.Json.Serialization;

namespace FedExAPI.Models
{
	public class OAuth
	{
		[JsonPropertyName("access_token")]
		public string AccessToken { get; set; } = "";

		[JsonPropertyName("token_type")]
		public string TokenType { get; set; } = "";

		[JsonPropertyName("expires_in")]
		public int ExpiresIn { get; set; }

		[JsonPropertyName("scope")]
		public string Scope { get; set; } = "";


		/// <summary>
		/// Below variables were created for ease of use.
		/// I figured it would be nice to have variables to easily
		/// know if you should get a new authorization token.
		/// </summary>
		
		public DateTime Created { get; } = DateTime.Now;

		public DateTime ExpiresAt
		{
			get
			{
				return Created.AddSeconds(ExpiresIn);
			}
		}

		public bool Expired
		{
			get
			{
				return ExpiresAt < DateTime.Now;
			}
		}
	}
}

