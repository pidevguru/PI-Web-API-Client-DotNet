using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Itemsstring
	/// </summary>
	[DataContract]
	public class PWAItemsstring
	{
		public PWAItemsstring(List<string> Items = null)
		{
			this.Items = Items;
		}
		/// <summary>
		/// Gets or Sets Items
		/// </summary>
		[DataMember(Name = "Items", EmitDefaultValue = false)]
		public List<string> Items { get; set; }

	}
}
