using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// SecurityEntry
	/// </summary>
	[DataContract]
	public class PWASecurityEntry
	{
		public PWASecurityEntry(List<string> AllowRights = null, List<string> DenyRights = null, PWASecurityEntryLinks Links = null, string Name = null, string SecurityIdentityName = null, PWAWebException WebException = null)
		{
			this.AllowRights = AllowRights;
			this.DenyRights = DenyRights;
			this.Links = Links;
			this.Name = Name;
			this.SecurityIdentityName = SecurityIdentityName;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets AllowRights
		/// </summary>
		[DataMember(Name = "AllowRights", EmitDefaultValue = false)]
		public List<string> AllowRights { get; set; }

		/// <summary>
		/// Gets or Sets DenyRights
		/// </summary>
		[DataMember(Name = "DenyRights", EmitDefaultValue = false)]
		public List<string> DenyRights { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWASecurityEntryLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets SecurityIdentityName
		/// </summary>
		[DataMember(Name = "SecurityIdentityName", EmitDefaultValue = false)]
		public string SecurityIdentityName { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
