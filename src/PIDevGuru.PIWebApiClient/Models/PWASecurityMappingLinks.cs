using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// SecurityMappingLinks
	/// </summary>
	[DataContract]
	public class PWASecurityMappingLinks
	{
		public PWASecurityMappingLinks(string AssetServer = null, string Security = null, string SecurityEntries = null, string SecurityIdentity = null, string Self = null)
		{
			this.AssetServer = AssetServer;
			this.Security = Security;
			this.SecurityEntries = SecurityEntries;
			this.SecurityIdentity = SecurityIdentity;
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
		/// Gets or Sets SecurityIdentity
		/// </summary>
		[DataMember(Name = "SecurityIdentity", EmitDefaultValue = false)]
		public string SecurityIdentity { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
