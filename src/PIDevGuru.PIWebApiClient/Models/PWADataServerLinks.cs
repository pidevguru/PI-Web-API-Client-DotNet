using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// DataServerLinks
	/// </summary>
	[DataContract]
	public class PWADataServerLinks
	{
		public PWADataServerLinks(string EnumerationSets = null, string Points = null, string Self = null)
		{
			this.EnumerationSets = EnumerationSets;
			this.Points = Points;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets EnumerationSets
		/// </summary>
		[DataMember(Name = "EnumerationSets", EmitDefaultValue = false)]
		public string EnumerationSets { get; set; }

		/// <summary>
		/// Gets or Sets Points
		/// </summary>
		[DataMember(Name = "Points", EmitDefaultValue = false)]
		public string Points { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
