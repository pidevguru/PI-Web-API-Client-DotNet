using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AttributeTraitLinks
	/// </summary>
	[DataContract]
	public class PWAAttributeTraitLinks
	{
		public PWAAttributeTraitLinks(string Self = null)
		{
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
