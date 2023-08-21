using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// ItemsSecurityIdentity
	/// </summary>
	[DataContract]
	public class PWAItemsSecurityIdentity
	{
		public PWAItemsSecurityIdentity(List<PWASecurityIdentity> Items = null, PWAPaginationLinks Links = null)
		{
			this.Items = Items;
			this.Links = Links;
		}
		/// <summary>
		/// Gets or Sets Items
		/// </summary>
		[DataMember(Name = "Items", EmitDefaultValue = false)]
		public List<PWASecurityIdentity> Items { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAPaginationLinks Links { get; set; }

	}
}
