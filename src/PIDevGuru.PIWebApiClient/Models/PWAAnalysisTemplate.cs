using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AnalysisTemplate
	/// </summary>
	[DataContract]
	public class PWAAnalysisTemplate
	{
		public PWAAnalysisTemplate(string AnalysisRulePlugInName = null, List<string> CategoryNames = null, bool? CreateEnabled = null, string Description = null, int? GroupId = null, bool? HasNotificationTemplate = null, bool? HasTarget = null, string Id = null, PWAAnalysisTemplateLinks Links = null, string Name = null, string OutputTime = null, string Path = null, string TargetName = null, string TimeRulePlugInName = null, PWAWebException WebException = null, string WebId = null)
		{
			this.AnalysisRulePlugInName = AnalysisRulePlugInName;
			this.CategoryNames = CategoryNames;
			this.CreateEnabled = CreateEnabled;
			this.Description = Description;
			this.GroupId = GroupId;
			this.HasNotificationTemplate = HasNotificationTemplate;
			this.HasTarget = HasTarget;
			this.Id = Id;
			this.Links = Links;
			this.Name = Name;
			this.OutputTime = OutputTime;
			this.Path = Path;
			this.TargetName = TargetName;
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
		/// Gets or Sets CategoryNames
		/// </summary>
		[DataMember(Name = "CategoryNames", EmitDefaultValue = false)]
		public List<string> CategoryNames { get; set; }

		/// <summary>
		/// Gets or Sets CreateEnabled
		/// </summary>
		[DataMember(Name = "CreateEnabled", EmitDefaultValue = false)]
		public bool? CreateEnabled { get; set; }

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
		/// Gets or Sets HasNotificationTemplate
		/// </summary>
		[DataMember(Name = "HasNotificationTemplate", EmitDefaultValue = false)]
		public bool? HasNotificationTemplate { get; set; }

		/// <summary>
		/// Gets or Sets HasTarget
		/// </summary>
		[DataMember(Name = "HasTarget", EmitDefaultValue = false)]
		public bool? HasTarget { get; set; }

		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAAnalysisTemplateLinks Links { get; set; }

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
		/// Gets or Sets TargetName
		/// </summary>
		[DataMember(Name = "TargetName", EmitDefaultValue = false)]
		public string TargetName { get; set; }

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
