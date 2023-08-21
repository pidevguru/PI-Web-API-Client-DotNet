using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// ExtendedTimedValues
	/// </summary>
	[DataContract]
	public class PWAExtendedTimedValues
	{
		public PWAExtendedTimedValues(List<PWAExtendedTimedValue> Items = null, string UnitsAbbreviation = null, PWAWebException WebException = null)
		{
			this.Items = Items;
			this.UnitsAbbreviation = UnitsAbbreviation;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets Items
		/// </summary>
		[DataMember(Name = "Items", EmitDefaultValue = false)]
		public List<PWAExtendedTimedValue> Items { get; set; }

		/// <summary>
		/// Gets or Sets UnitsAbbreviation
		/// </summary>
		[DataMember(Name = "UnitsAbbreviation", EmitDefaultValue = false)]
		public string UnitsAbbreviation { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
