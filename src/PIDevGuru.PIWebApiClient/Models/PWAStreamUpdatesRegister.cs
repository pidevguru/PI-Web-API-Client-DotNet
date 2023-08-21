using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// StreamUpdatesRegister
	/// </summary>
	[DataContract]
	public class PWAStreamUpdatesRegister
	{
		public PWAStreamUpdatesRegister(PWAErrors Exception = null, string LatestMarker = null, string Source = null, string SourceName = null, string SourcePath = null, string Status = null)
		{
			this.Exception = Exception;
			this.LatestMarker = LatestMarker;
			this.Source = Source;
			this.SourceName = SourceName;
			this.SourcePath = SourcePath;
			this.Status = Status;
		}
		/// <summary>
		/// Gets or Sets Exception
		/// </summary>
		[DataMember(Name = "Exception", EmitDefaultValue = false)]
		public PWAErrors Exception { get; set; }

		/// <summary>
		/// Gets or Sets LatestMarker
		/// </summary>
		[DataMember(Name = "LatestMarker", EmitDefaultValue = false)]
		public string LatestMarker { get; set; }

		/// <summary>
		/// Gets or Sets Source
		/// </summary>
		[DataMember(Name = "Source", EmitDefaultValue = false)]
		public string Source { get; set; }

		/// <summary>
		/// Gets or Sets SourceName
		/// </summary>
		[DataMember(Name = "SourceName", EmitDefaultValue = false)]
		public string SourceName { get; set; }

		/// <summary>
		/// Gets or Sets SourcePath
		/// </summary>
		[DataMember(Name = "SourcePath", EmitDefaultValue = false)]
		public string SourcePath { get; set; }

		/// <summary>
		/// Gets or Sets Status
		/// </summary>
		[DataMember(Name = "Status", EmitDefaultValue = false)]
		public string Status { get; set; }

	}
}
