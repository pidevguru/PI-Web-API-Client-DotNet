using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// PointAttributeLinks
	/// </summary>
	[DataContract]
	public class PWAPointAttributeLinks
	{
		public PWAPointAttributeLinks(string Point = null, string Self = null)
		{
			this.Point = Point;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets Point
		/// </summary>
		[DataMember(Name = "Point", EmitDefaultValue = false)]
		public string Point { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
