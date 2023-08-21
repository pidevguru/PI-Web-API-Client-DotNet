using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Analysis
	/// </summary>
	[DataContract]
	public class PWAAnalysis
	{
		public PWAAnalysis(string AnalysisRulePlugInName = null, bool? AutoCreated = null, List<string> CategoryNames = null, string Description = null, int? GroupId = null, bool? HasNotification = null, bool? HasTarget = null, bool? HasTemplate = null, string Id = null, bool? IsConfigured = null, bool? IsTimeRuleDefinedByTemplate = null, PWAAnalysisLinks Links = null, int? MaximumQueueSize = null, string Name = null, string OutputTime = null, string Path = null, string Priority = null, bool? PublishResults = null, string Status = null, string TargetWebId = null, string TemplateName = null, string TimeRulePlugInName = null, PWAWebException WebException = null, string WebId = null)
		{
			this.AnalysisRulePlugInName = AnalysisRulePlugInName;
			this.AutoCreated = AutoCreated;
			this.CategoryNames = CategoryNames;
			this.Description = Description;
			this.GroupId = GroupId;
			this.HasNotification = HasNotification;
			this.HasTarget = HasTarget;
			this.HasTemplate = HasTemplate;
			this.Id = Id;
			this.IsConfigured = IsConfigured;
			this.IsTimeRuleDefinedByTemplate = IsTimeRuleDefinedByTemplate;
			this.Links = Links;
			this.MaximumQueueSize = MaximumQueueSize;
			this.Name = Name;
			this.OutputTime = OutputTime;
			this.Path = Path;
			this.Priority = Priority;
			this.PublishResults = PublishResults;
			this.Status = Status;
			this.TargetWebId = TargetWebId;
			this.TemplateName = TemplateName;
			this.TimeRulePlugInName = TimeRulePlugInName;
			this.WebException = WebException;
			this.WebId = WebId;
		}
		/// <summary>
		/// Gets or Sets AnalysisRulePlugInName
		/// </summary>
		[DataMember(Name = "AnalysisRulePlugInName", EmitDefaultValue = false)]
		public string AnalysisRulePlugInName { get; set; }

		/// <summary>
		/// Gets or Sets AutoCreated
		/// </summary>
		[DataMember(Name = "AutoCreated", EmitDefaultValue = false)]
		public bool? AutoCreated { get; set; }

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
		/// Gets or Sets GroupId
		/// </summary>
		[DataMember(Name = "GroupId", EmitDefaultValue = false)]
		public int? GroupId { get; set; }

		/// <summary>
		/// Gets or Sets HasNotification
		/// </summary>
		[DataMember(Name = "HasNotification", EmitDefaultValue = false)]
		public bool? HasNotification { get; set; }

		/// <summary>
		/// Gets or Sets HasTarget
		/// </summary>
		[DataMember(Name = "HasTarget", EmitDefaultValue = false)]
		public bool? HasTarget { get; set; }

		/// <summary>
		/// Gets or Sets HasTemplate
		/// </summary>
		[DataMember(Name = "HasTemplate", EmitDefaultValue = false)]
		public bool? HasTemplate { get; set; }

		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets IsConfigured
		/// </summary>
		[DataMember(Name = "IsConfigured", EmitDefaultValue = false)]
		public bool? IsConfigured { get; set; }

		/// <summary>
		/// Gets or Sets IsTimeRuleDefinedByTemplate
		/// </summary>
		[DataMember(Name = "IsTimeRuleDefinedByTemplate", EmitDefaultValue = false)]
		public bool? IsTimeRuleDefinedByTemplate { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAAnalysisLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets MaximumQueueSize
		/// </summary>
		[DataMember(Name = "MaximumQueueSize", EmitDefaultValue = false)]
		public int? MaximumQueueSize { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets OutputTime
		/// </summary>
		[DataMember(Name = "OutputTime", EmitDefaultValue = false)]
		public string OutputTime { get; set; }

		/// <summary>
		/// Gets or Sets Path
		/// </summary>
		[DataMember(Name = "Path", EmitDefaultValue = false)]
		public string Path { get; set; }

		/// <summary>
		/// Gets or Sets Priority
		/// </summary>
		[DataMember(Name = "Priority", EmitDefaultValue = false)]
		public string Priority { get; set; }

		/// <summary>
		/// Gets or Sets PublishResults
		/// </summary>
		[DataMember(Name = "PublishResults", EmitDefaultValue = false)]
		public bool? PublishResults { get; set; }

		/// <summary>
		/// Gets or Sets Status
		/// </summary>
		[DataMember(Name = "Status", EmitDefaultValue = false)]
		public string Status { get; set; }

		/// <summary>
		/// Gets or Sets TargetWebId
		/// </summary>
		[DataMember(Name = "TargetWebId", EmitDefaultValue = false)]
		public string TargetWebId { get; set; }

		/// <summary>
		/// Gets or Sets TemplateName
		/// </summary>
		[DataMember(Name = "TemplateName", EmitDefaultValue = false)]
		public string TemplateName { get; set; }

		/// <summary>
		/// Gets or Sets TimeRulePlugInName
		/// </summary>
		[DataMember(Name = "TimeRulePlugInName", EmitDefaultValue = false)]
		public string TimeRulePlugInName { get; set; }

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
