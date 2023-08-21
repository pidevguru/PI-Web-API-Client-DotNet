using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// DataReference
	/// </summary>
	[DataContract]
	public class PWADataReference
	{
		public PWADataReference(PWAPIPointDataReference PIPoint = null, string Type = null, PWAWebException WebException = null)
		{
			this.PIPoint = PIPoint;
			this.Type = Type;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets PIPoint
		/// </summary>
		[DataMember(Name = "PIPoint", EmitDefaultValue = false)]
		public PWAPIPointDataReference PIPoint { get; set; }

		/// <summary>
		/// Gets or Sets Type
		/// </summary>
		[DataMember(Name = "Type", EmitDefaultValue = false)]
		public string Type { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
