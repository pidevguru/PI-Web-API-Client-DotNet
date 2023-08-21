using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// SystemLanding
	/// </summary>
	[DataContract]
	public class PWASystemLanding
	{
		public PWASystemLanding(PWASystemLandingLinks Links = null, string ProductTitle = null, string ProductVersion = null, PWAWebException WebException = null)
		{
			this.Links = Links;
			this.ProductTitle = ProductTitle;
			this.ProductVersion = ProductVersion;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWASystemLandingLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets ProductTitle
		/// </summary>
		[DataMember(Name = "ProductTitle", EmitDefaultValue = false)]
		public string ProductTitle { get; set; }

		/// <summary>
		/// Gets or Sets ProductVersion
		/// </summary>
		[DataMember(Name = "ProductVersion", EmitDefaultValue = false)]
		public string ProductVersion { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
