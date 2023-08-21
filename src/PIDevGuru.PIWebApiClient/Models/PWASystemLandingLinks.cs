using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// SystemLandingLinks
	/// </summary>
	[DataContract]
	public class PWASystemLandingLinks
	{
		public PWASystemLandingLinks(string CacheInstances = null, string Configuration = null, string Self = null, string Status = null, string UserInfo = null, string Versions = null)
		{
			this.CacheInstances = CacheInstances;
			this.Configuration = Configuration;
			this.Self = Self;
			this.Status = Status;
			this.UserInfo = UserInfo;
			this.Versions = Versions;
		}
		/// <summary>
		/// Gets or Sets CacheInstances
		/// </summary>
		[DataMember(Name = "CacheInstances", EmitDefaultValue = false)]
		public string CacheInstances { get; set; }

		/// <summary>
		/// Gets or Sets Configuration
		/// </summary>
		[DataMember(Name = "Configuration", EmitDefaultValue = false)]
		public string Configuration { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

		/// <summary>
		/// Gets or Sets Status
		/// </summary>
		[DataMember(Name = "Status", EmitDefaultValue = false)]
		public string Status { get; set; }

		/// <summary>
		/// Gets or Sets UserInfo
		/// </summary>
		[DataMember(Name = "UserInfo", EmitDefaultValue = false)]
		public string UserInfo { get; set; }

		/// <summary>
		/// Gets or Sets Versions
		/// </summary>
		[DataMember(Name = "Versions", EmitDefaultValue = false)]
		public string Versions { get; set; }

	}
}
