using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// ItemsChannelInstance
	/// </summary>
	[DataContract]
	public class PWAItemsChannelInstance
	{
		public PWAItemsChannelInstance(List<PWAChannelInstance> Items = null, PWAPaginationLinks Links = null)
		{
			this.Items = Items;
			this.Links = Links;
		}
		/// <summary>
		/// Gets or Sets Items
		/// </summary>
		[DataMember(Name = "Items", EmitDefaultValue = false)]
		public List<PWAChannelInstance> Items { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAPaginationLinks Links { get; set; }

	}
}
