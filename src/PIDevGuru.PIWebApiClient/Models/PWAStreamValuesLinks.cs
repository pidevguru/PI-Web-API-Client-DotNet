using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// StreamValuesLinks
	/// </summary>
	[DataContract]
	public class PWAStreamValuesLinks
	{
		public PWAStreamValuesLinks(string Source = null)
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
