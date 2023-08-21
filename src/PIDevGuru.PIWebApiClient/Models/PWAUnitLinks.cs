using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// UnitLinks
	/// </summary>
	[DataContract]
	public class PWAUnitLinks
	{
		public PWAUnitLinks(string Class = null, string ReferenceUnit = null, string Self = null)
		{
			this.Class = Class;
			this.ReferenceUnit = ReferenceUnit;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets Class
		/// </summary>
		[DataMember(Name = "Class", EmitDefaultValue = false)]
		public string Class { get; set; }

		/// <summary>
		/// Gets or Sets ReferenceUnit
		/// </summary>
		[DataMember(Name = "ReferenceUnit", EmitDefaultValue = false)]
		public string ReferenceUnit { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
