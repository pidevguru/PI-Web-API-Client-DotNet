using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AnalysisRulePlugIn
	/// </summary>
	[DataContract]
	public class PWAAnalysisRulePlugIn
	{
		public PWAAnalysisRulePlugIn(string AssemblyFileName = null, string AssemblyID = null, List<string> AssemblyLoadProperties = null, string AssemblyTime = null, int? CompatibilityVersion = null, string Description = null, string Id = null, bool? IsBrowsable = null, bool? IsNonEditableConfig = null, PWAAnalysisRulePlugInLinks Links = null, string LoadedAssemblyTime = null, string LoadedVersion = null, string Name = null, string Path = null, string Version = null, PWAWebException WebException = null, string WebId = null)
		{
			this.AssemblyFileName = AssemblyFileName;
			this.AssemblyID = AssemblyID;
			this.AssemblyLoadProperties = AssemblyLoadProperties;
			this.AssemblyTime = AssemblyTime;
			this.CompatibilityVersion = CompatibilityVersion;
			this.Description = Description;
			this.Id = Id;
			this.IsBrowsable = IsBrowsable;
			this.IsNonEditableConfig = IsNonEditableConfig;
			this.Links = Links;
			this.LoadedAssemblyTime = LoadedAssemblyTime;
			this.LoadedVersion = LoadedVersion;
			this.Name = Name;
			this.Path = Path;
			this.Version = Version;
			this.WebException = WebException;
			this.WebId = WebId;
		}
		/// <summary>
		/// Gets or Sets AssemblyFileName
		/// </summary>
		[DataMember(Name = "AssemblyFileName", EmitDefaultValue = false)]
		public string AssemblyFileName { get; set; }

		/// <summary>
		/// Gets or Sets AssemblyID
		/// </summary>
		[DataMember(Name = "AssemblyID", EmitDefaultValue = false)]
		public string AssemblyID { get; set; }

		/// <summary>
		/// Gets or Sets AssemblyLoadProperties
		/// </summary>
		[DataMember(Name = "AssemblyLoadProperties", EmitDefaultValue = false)]
		public List<string> AssemblyLoadProperties { get; set; }

		/// <summary>
		/// Gets or Sets AssemblyTime
		/// </summary>
		[DataMember(Name = "AssemblyTime", EmitDefaultValue = false)]
		public string AssemblyTime { get; set; }

		/// <summary>
		/// Gets or Sets CompatibilityVersion
		/// </summary>
		[DataMember(Name = "CompatibilityVersion", EmitDefaultValue = false)]
		public int? CompatibilityVersion { get; set; }

		/// <summary>
		/// Gets or Sets Description
		/// </summary>
		[DataMember(Name = "Description", EmitDefaultValue = false)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets IsBrowsable
		/// </summary>
		[DataMember(Name = "IsBrowsable", EmitDefaultValue = false)]
		public bool? IsBrowsable { get; set; }

		/// <summary>
		/// Gets or Sets IsNonEditableConfig
		/// </summary>
		[DataMember(Name = "IsNonEditableConfig", EmitDefaultValue = false)]
		public bool? IsNonEditableConfig { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAAnalysisRulePlugInLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets LoadedAssemblyTime
		/// </summary>
		[DataMember(Name = "LoadedAssemblyTime", EmitDefaultValue = false)]
		public string LoadedAssemblyTime { get; set; }

		/// <summary>
		/// Gets or Sets LoadedVersion
		/// </summary>
		[DataMember(Name = "LoadedVersion", EmitDefaultValue = false)]
		public string LoadedVersion { get; set; }

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
		/// Gets or Sets Version
		/// </summary>
		[DataMember(Name = "Version", EmitDefaultValue = false)]
		public string Version { get; set; }

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
