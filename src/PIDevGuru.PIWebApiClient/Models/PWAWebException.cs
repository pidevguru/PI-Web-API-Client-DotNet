using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// WebException
	/// </summary>
	[DataContract]
	public class PWAWebException
	{
		public PWAWebException(List<string> Errors = null, int? StatusCode = null)
		{
			this.Errors = Errors;
			this.StatusCode = StatusCode;
		}
		/// <summary>
		/// Gets or Sets Errors
		/// </summary>
		[DataMember(Name = "Errors", EmitDefaultValue = false)]
		public List<string> Errors { get; set; }

		/// <summary>
		/// Gets or Sets StatusCode
		/// </summary>
		[DataMember(Name = "StatusCode", EmitDefaultValue = false)]
		public int? StatusCode { get; set; }

	}
}
