using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// EventFrame
	/// </summary>
	[DataContract]
	public class PWAEventFrame
	{
		public PWAEventFrame(string AcknowledgedBy = null, string AcknowledgedDate = null, bool? AreValuesCaptured = null, bool? CanBeAcknowledged = null, List<string> CategoryNames = null, string Description = null, string EndTime = null, Dictionary<string, PWAValue> ExtendedProperties = null, bool? HasChildren = null, string Id = null, bool? IsAcknowledged = null, bool? IsAnnotated = null, bool? IsLocked = null, PWAEventFrameLinks Links = null, string Name = null, string Path = null, List<string> RefElementWebIds = null, PWASecurity Security = null, string Severity = null, string StartTime = null, string TemplateName = null, PWAWebException WebException = null, string WebId = null)
		{
			this.AcknowledgedBy = AcknowledgedBy;
			this.AcknowledgedDate = AcknowledgedDate;
			this.AreValuesCaptured = AreValuesCaptured;
			this.CanBeAcknowledged = CanBeAcknowledged;
			this.CategoryNames = CategoryNames;
			this.Description = Description;
			this.EndTime = EndTime;
			this.ExtendedProperties = ExtendedProperties;
			this.HasChildren = HasChildren;
			this.Id = Id;
			this.IsAcknowledged = IsAcknowledged;
			this.IsAnnotated = IsAnnotated;
			this.IsLocked = IsLocked;
			this.Links = Links;
			this.Name = Name;
			this.Path = Path;
			this.RefElementWebIds = RefElementWebIds;
			this.Security = Security;
			this.Severity = Severity;
			this.StartTime = StartTime;
			this.TemplateName = TemplateName;
			this.WebException = WebException;
			this.WebId = WebId;
		}
		/// <summary>
		/// Gets or Sets AcknowledgedBy
		/// </summary>
		[DataMember(Name = "AcknowledgedBy", EmitDefaultValue = false)]
		public string AcknowledgedBy { get; set; }

		/// <summary>
		/// Gets or Sets AcknowledgedDate
		/// </summary>
		[DataMember(Name = "AcknowledgedDate", EmitDefaultValue = false)]
		public string AcknowledgedDate { get; set; }

		/// <summary>
		/// Gets or Sets AreValuesCaptured
		/// </summary>
		[DataMember(Name = "AreValuesCaptured", EmitDefaultValue = false)]
		public bool? AreValuesCaptured { get; set; }

		/// <summary>
		/// Gets or Sets CanBeAcknowledged
		/// </summary>
		[DataMember(Name = "CanBeAcknowledged", EmitDefaultValue = false)]
		public bool? CanBeAcknowledged { get; set; }

		/// <summary>
		/// Gets or Sets CategoryNames
		/// </summary>
		[DataMember(Name = "CategoryNames", EmitDefaultValue = false)]
		public List<string> CategoryNames { get; set; }

		/// <summary>
		/// Gets or Sets Description
		/// </summary>
		[DataMember(Name = "Description", EmitDefaultValue = false)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or Sets EndTime
		/// </summary>
		[DataMember(Name = "EndTime", EmitDefaultValue = false)]
		public string EndTime { get; set; }

		/// <summary>
		/// Gets or Sets ExtendedProperties
		/// </summary>
		[DataMember(Name = "ExtendedProperties", EmitDefaultValue = false)]
		public Dictionary<string, PWAValue> ExtendedProperties { get; set; }

		/// <summary>
		/// Gets or Sets HasChildren
		/// </summary>
		[DataMember(Name = "HasChildren", EmitDefaultValue = false)]
		public bool? HasChildren { get; set; }

		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets IsAcknowledged
		/// </summary>
		[DataMember(Name = "IsAcknowledged", EmitDefaultValue = false)]
		public bool? IsAcknowledged { get; set; }

		/// <summary>
		/// Gets or Sets IsAnnotated
		/// </summary>
		[DataMember(Name = "IsAnnotated", EmitDefaultValue = false)]
		public bool? IsAnnotated { get; set; }

		/// <summary>
		/// Gets or Sets IsLocked
		/// </summary>
		[DataMember(Name = "IsLocked", EmitDefaultValue = false)]
		public bool? IsLocked { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAEventFrameLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets Path
		/// </summary>
		[DataMember(Name = "Path", EmitDefaultValue = false)]
		public string Path { get; set; }

		/// <summary>
		/// Gets or Sets RefElementWebIds
		/// </summary>
		[DataMember(Name = "RefElementWebIds", EmitDefaultValue = false)]
		public List<string> RefElementWebIds { get; set; }

		/// <summary>
		/// Gets or Sets Security
		/// </summary>
		[DataMember(Name = "Security", EmitDefaultValue = false)]
		public PWASecurity Security { get; set; }

		/// <summary>
		/// Gets or Sets Severity
		/// </summary>
		[DataMember(Name = "Severity", EmitDefaultValue = false)]
		public string Severity { get; set; }

		/// <summary>
		/// Gets or Sets StartTime
		/// </summary>
		[DataMember(Name = "StartTime", EmitDefaultValue = false)]
		public string StartTime { get; set; }

		/// <summary>
		/// Gets or Sets TemplateName
		/// </summary>
		[DataMember(Name = "TemplateName", EmitDefaultValue = false)]
		public string TemplateName { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

		/// <summary>
		/// Gets or Sets WebId
		/// </summary>
		[DataMember(Name = "WebId", EmitDefaultValue = false)]
		public string WebId { get; set; }

	}
}
