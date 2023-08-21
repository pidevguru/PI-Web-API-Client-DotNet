using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AnalysisRule
	/// </summary>
	[DataContract]
	public class PWAAnalysisRule
	{
		public PWAAnalysisRule(string ConfigString = null, string Description = null, string DisplayString = null, string EditorType = null, bool? HasChildren = null, string Id = null, bool? IsConfigured = null, bool? IsInitializing = null, PWAAnalysisRuleLinks Links = null, string Name = null, string Path = null, string PlugInName = null, List<string> SupportedBehaviors = null, string VariableMapping = null, PWAWebException WebException = null, string WebId = null)
		{
			this.ConfigString = ConfigString;
			this.Description = Description;
			this.DisplayString = DisplayString;
			this.EditorType = EditorType;
			this.HasChildren = HasChildren;
			this.Id = Id;
			this.IsConfigured = IsConfigured;
			this.IsInitializing = IsInitializing;
			this.Links = Links;
			this.Name = Name;
			this.Path = Path;
			this.PlugInName = PlugInName;
			this.SupportedBehaviors = SupportedBehaviors;
			this.VariableMapping = VariableMapping;
			this.WebException = WebException;
			this.WebId = WebId;
		}
		/// <summary>
		/// Gets or Sets ConfigString
		/// </summary>
		[DataMember(Name = "ConfigString", EmitDefaultValue = false)]
		public string ConfigString { get; set; }

		/// <summary>
		/// Gets or Sets Description
		/// </summary>
		[DataMember(Name = "Description", EmitDefaultValue = false)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or Sets DisplayString
		/// </summary>
		[DataMember(Name = "DisplayString", EmitDefaultValue = false)]
		public string DisplayString { get; set; }

		/// <summary>
		/// Gets or Sets EditorType
		/// </summary>
		[DataMember(Name = "EditorType", EmitDefaultValue = false)]
		public string EditorType { get; set; }

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
		/// Gets or Sets IsConfigured
		/// </summary>
		[DataMember(Name = "IsConfigured", EmitDefaultValue = false)]
		public bool? IsConfigured { get; set; }

		/// <summary>
		/// Gets or Sets IsInitializing
		/// </summary>
		[DataMember(Name = "IsInitializing", EmitDefaultValue = false)]
		public bool? IsInitializing { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAAnalysisRuleLinks Links { get; set; }

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
		/// Gets or Sets PlugInName
		/// </summary>
		[DataMember(Name = "PlugInName", EmitDefaultValue = false)]
		public string PlugInName { get; set; }

		/// <summary>
		/// Gets or Sets SupportedBehaviors
		/// </summary>
		[DataMember(Name = "SupportedBehaviors", EmitDefaultValue = false)]
		public List<string> SupportedBehaviors { get; set; }

		/// <summary>
		/// Gets or Sets VariableMapping
		/// </summary>
		[DataMember(Name = "VariableMapping", EmitDefaultValue = false)]
		public string VariableMapping { get; set; }

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
