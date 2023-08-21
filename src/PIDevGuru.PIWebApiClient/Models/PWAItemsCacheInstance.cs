using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// ItemsCacheInstance
	/// </summary>
	[DataContract]
	public class PWAItemsCacheInstance
	{
		public PWAItemsCacheInstance(List<PWACacheInstance> Items = null, PWAPaginationLinks Links = null)
		{
			this.Items = Items;
			this.Links = Links;
		}
		/// <summary>
		/// Gets or Sets Items
		/// </summary>
		[DataMember(Name = "Items", EmitDefaultValue = false)]
		public List<PWACacheInstance> Items { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAPaginationLinks Links { get; set; }

	}
}
