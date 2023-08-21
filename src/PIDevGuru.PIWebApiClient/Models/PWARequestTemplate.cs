using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// RequestTemplate
	/// </summary>
	[DataContract]
	public class PWARequestTemplate
	{
		public PWARequestTemplate(string Resource = null)
		{
			this.Resource = Resource;
		}
		/// <summary>
		/// Gets or Sets Resource
		/// </summary>
		[DataMember(Name = "Resource", EmitDefaultValue = false)]
		public string Resource { get; set; }

	}
}
