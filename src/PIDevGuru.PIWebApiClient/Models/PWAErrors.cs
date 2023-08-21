using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Errors
	/// </summary>
	[DataContract]
	public class PWAErrors
	{
		public PWAErrors(List<string> Errors = null)
		{
			this.Errors = Errors;
		}
		/// <summary>
		/// Gets or Sets Errors
		/// </summary>
		[DataMember(Name = "Errors", EmitDefaultValue = false)]
		public List<string> Errors { get; set; }

	}
}
