using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// EnumerationValueLinks
	/// </summary>
	[DataContract]
	public class PWAEnumerationValueLinks
	{
		public PWAEnumerationValueLinks(string EnumerationSet = null, string Parent = null, string Self = null)
		{
			this.EnumerationSet = EnumerationSet;
			this.Parent = Parent;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets EnumerationSet
		/// </summary>
		[DataMember(Name = "EnumerationSet", EmitDefaultValue = false)]
		public string EnumerationSet { get; set; }

		/// <summary>
		/// Gets or Sets Parent
		/// </summary>
		[DataMember(Name = "Parent", EmitDefaultValue = false)]
		public string Parent { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
