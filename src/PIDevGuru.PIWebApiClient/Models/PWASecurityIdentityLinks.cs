using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// SecurityIdentityLinks
	/// </summary>
	[DataContract]
	public class PWASecurityIdentityLinks
	{
		public PWASecurityIdentityLinks(string AssetServer = null, string Security = null, string SecurityEntries = null, string SecurityMappings = null, string Self = null)
		{
			this.AssetServer = AssetServer;
			this.Security = Security;
			this.SecurityEntries = SecurityEntries;
			this.SecurityMappings = SecurityMappings;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets AssetServer
		/// </summary>
		[DataMember(Name = "AssetServer", EmitDefaultValue = false)]
		public string AssetServer { get; set; }

		/// <summary>
		/// Gets or Sets Security
		/// </summary>
		[DataMember(Name = "Security", EmitDefaultValue = false)]
		public string Security { get; set; }

		/// <summary>
		/// Gets or Sets SecurityEntries
		/// </summary>
		[DataMember(Name = "SecurityEntries", EmitDefaultValue = false)]
		public string SecurityEntries { get; set; }

		/// <summary>
		/// Gets or Sets SecurityMappings
		/// </summary>
		[DataMember(Name = "SecurityMappings", EmitDefaultValue = false)]
		public string SecurityMappings { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
