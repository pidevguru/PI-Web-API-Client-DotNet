using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Ambiguous
	/// </summary>
	[DataContract]
	public class PWAAmbiguous
	{
		public PWAAmbiguous(string Reason = null)
		{
			this.Reason = Reason;
		}
		/// <summary>
		/// Gets or Sets Reason
		/// </summary>
		[DataMember(Name = "Reason", EmitDefaultValue = false)]
		public string Reason { get; set; }

	}
}
