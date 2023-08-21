using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// StreamUpdatesRetrieve
	/// </summary>
	[DataContract]
	public class PWAStreamUpdatesRetrieve
	{
		public PWAStreamUpdatesRetrieve(List<PWADataPipeEvent> Events = null, PWAErrors Exception = null, string LatestMarker = null, string RequestedMarker = null, string Source = null, string SourceName = null, string SourcePath = null, string Status = null)
		{
			this.Events = Events;
			this.Exception = Exception;
			this.LatestMarker = LatestMarker;
			this.RequestedMarker = RequestedMarker;
			this.Source = Source;
			this.SourceName = SourceName;
			this.SourcePath = SourcePath;
			this.Status = Status;
		}
		/// <summary>
		/// Gets or Sets Events
		/// </summary>
		[DataMember(Name = "Events", EmitDefaultValue = false)]
		public List<PWADataPipeEvent> Events { get; set; }

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
		/// Gets or Sets RequestedMarker
		/// </summary>
		[DataMember(Name = "RequestedMarker", EmitDefaultValue = false)]
		public string RequestedMarker { get; set; }

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
