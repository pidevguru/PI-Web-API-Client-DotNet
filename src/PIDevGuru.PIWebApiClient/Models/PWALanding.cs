using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Landing
	/// </summary>
	[DataContract]
	public class PWALanding
	{
		public PWALanding(PWALandingLinks Links = null, PWAWebException WebException = null)
		{
			this.Links = Links;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWALandingLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
