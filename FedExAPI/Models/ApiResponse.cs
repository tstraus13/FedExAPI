using System;
namespace FedExAPI.Models
{
	public class ApiResponse<T>
	{
		public T? Data { get; set; }

		public Error? Error { get; set; }
	}
}

