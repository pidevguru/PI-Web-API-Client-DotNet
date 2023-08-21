using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// SecurityEntryLinks
	/// </summary>
	[DataContract]
	public class PWASecurityEntryLinks
	{
		public PWASecurityEntryLinks(string SecurableObject = null, string SecurityIdentity = null, string Self = null)
		{
			this.SecurableObject = SecurableObject;
			this.SecurityIdentity = SecurityIdentity;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets SecurableObject
		/// </summary>
		[DataMember(Name = "SecurableObject", EmitDefaultValue = false)]
		public string SecurableObject { get; set; }

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
