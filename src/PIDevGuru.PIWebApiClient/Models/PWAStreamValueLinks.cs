using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// StreamValueLinks
	/// </summary>
	[DataContract]
	public class PWAStreamValueLinks
	{
		public PWAStreamValueLinks(string Source = null)
		{
			this.Source = Source;
		}
		/// <summary>
		/// Gets or Sets Source
		/// </summary>
		[DataMember(Name = "Source", EmitDefaultValue = false)]
		public string Source { get; set; }

	}
}
