using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// UnitClassLinks
	/// </summary>
	[DataContract]
	public class PWAUnitClassLinks
	{
		public PWAUnitClassLinks(string AssetServer = null, string CanonicalUnit = null, string Self = null, string Units = null)
		{
			this.AssetServer = AssetServer;
			this.CanonicalUnit = CanonicalUnit;
			this.Self = Self;
			this.Units = Units;
		}
		/// <summary>
		/// Gets or Sets AssetServer
		/// </summary>
		[DataMember(Name = "AssetServer", EmitDefaultValue = false)]
		public string AssetServer { get; set; }

		/// <summary>
		/// Gets or Sets CanonicalUnit
		/// </summary>
		[DataMember(Name = "CanonicalUnit", EmitDefaultValue = false)]
		public string CanonicalUnit { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

		/// <summary>
		/// Gets or Sets Units
		/// </summary>
		[DataMember(Name = "Units", EmitDefaultValue = false)]
		public string Units { get; set; }

	}
}
