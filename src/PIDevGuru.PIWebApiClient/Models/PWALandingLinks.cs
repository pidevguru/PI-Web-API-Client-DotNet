using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// LandingLinks
	/// </summary>
	[DataContract]
	public class PWALandingLinks
	{
		public PWALandingLinks(string AssetServers = null, string DataServers = null, string Search = null, string Self = null, string System = null)
		{
			this.AssetServers = AssetServers;
			this.DataServers = DataServers;
			this.Search = Search;
			this.Self = Self;
			this.System = System;
		}
		/// <summary>
		/// Gets or Sets AssetServers
		/// </summary>
		[DataMember(Name = "AssetServers", EmitDefaultValue = false)]
		public string AssetServers { get; set; }

		/// <summary>
		/// Gets or Sets DataServers
		/// </summary>
		[DataMember(Name = "DataServers", EmitDefaultValue = false)]
		public string DataServers { get; set; }

		/// <summary>
		/// Gets or Sets Search
		/// </summary>
		[DataMember(Name = "Search", EmitDefaultValue = false)]
		public string Search { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

		/// <summary>
		/// Gets or Sets System
		/// </summary>
		[DataMember(Name = "System", EmitDefaultValue = false)]
		public string System { get; set; }

	}
}
