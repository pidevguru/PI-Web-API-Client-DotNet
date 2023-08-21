using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Version
	/// </summary>
	[DataContract]
	public class PWAVersion
	{
		public PWAVersion(string Build = null, string FullVersion = null, string MajorMinorRevision = null, PWAWebException WebException = null)
		{
			this.Build = Build;
			this.FullVersion = FullVersion;
			this.MajorMinorRevision = MajorMinorRevision;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets Build
		/// </summary>
		[DataMember(Name = "Build", EmitDefaultValue = false)]
		public string Build { get; set; }

		/// <summary>
		/// Gets or Sets FullVersion
		/// </summary>
		[DataMember(Name = "FullVersion", EmitDefaultValue = false)]
		public string FullVersion { get; set; }

		/// <summary>
		/// Gets or Sets MajorMinorRevision
		/// </summary>
		[DataMember(Name = "MajorMinorRevision", EmitDefaultValue = false)]
		public string MajorMinorRevision { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
