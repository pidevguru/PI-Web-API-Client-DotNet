using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// TimeRulePlugInLinks
	/// </summary>
	[DataContract]
	public class PWATimeRulePlugInLinks
	{
		public PWATimeRulePlugInLinks(string AssetServer = null, string Self = null)
		{
			this.AssetServer = AssetServer;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets AssetServer
		/// </summary>
		[DataMember(Name = "AssetServer", EmitDefaultValue = false)]
		public string AssetServer { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
