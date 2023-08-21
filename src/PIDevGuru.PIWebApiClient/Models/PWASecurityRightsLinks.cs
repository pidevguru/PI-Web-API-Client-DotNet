using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// SecurityRightsLinks
	/// </summary>
	[DataContract]
	public class PWASecurityRightsLinks
	{
		public PWASecurityRightsLinks(string Owner = null, string Self = null)
		{
			this.Owner = Owner;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets Owner
		/// </summary>
		[DataMember(Name = "Owner", EmitDefaultValue = false)]
		public string Owner { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
