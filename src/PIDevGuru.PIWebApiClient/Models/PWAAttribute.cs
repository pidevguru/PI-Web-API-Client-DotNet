using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Attribute
	/// </summary>
	[DataContract]
	public class PWAAttribute
	{
		public PWAAttribute(List<string> CategoryNames = null, string ConfigString = null, PWADataReference DataReference = null, string DataReferencePlugIn = null, string DefaultUnitsName = null, string DefaultUnitsNameAbbreviation = null, string Description = null, int? DisplayDigits = null, bool? HasChildren = null, string Id = null, bool? IsConfigurationItem = null, bool? IsExcluded = null, bool? IsHidden = null, bool? IsManualDataEntry = null, PWAAttributeLinks Links = null, string Name = null, string Path = null, List<string> Paths = null, double? Span = null, bool? Step = null, string TraitName = null, string Type = null, string TypeQualifier = null, PWAWebException WebException = null, string WebId = null, double? Zero = null)
		{
			this.CategoryNames = CategoryNames;
			this.ConfigString = ConfigString;
			this.DataReference = DataReference;
			this.DataReferencePlugIn = DataReferencePlugIn;
			this.DefaultUnitsName = DefaultUnitsName;
			this.DefaultUnitsNameAbbreviation = DefaultUnitsNameAbbreviation;
			this.Description = Description;
			this.DisplayDigits = DisplayDigits;
			this.HasChildren = HasChildren;
			this.Id = Id;
			this.IsConfigurationItem = IsConfigurationItem;
			this.IsExcluded = IsExcluded;
			this.IsHidden = IsHidden;
			this.IsManualDataEntry = IsManualDataEntry;
			this.Links = Links;
			this.Name = Name;
			this.Path = Path;
			this.Paths = Paths;
			this.Span = Span;
			this.Step = Step;
			this.TraitName = TraitName;
			this.Type = Type;
			this.TypeQualifier = TypeQualifier;
			this.WebException = WebException;
			this.WebId = WebId;
			this.Zero = Zero;
		}
		/// <summary>
		/// Gets or Sets CategoryNames
		/// </summary>
		[DataMember(Name = "CategoryNames", EmitDefaultValue = false)]
		public List<string> CategoryNames { get; set; }

		/// <summary>
		/// Gets or Sets ConfigString
		/// </summary>
		[DataMember(Name = "ConfigString", EmitDefaultValue = false)]
		public string ConfigString { get; set; }

		/// <summary>
		/// Gets or Sets DataReference
		/// </summary>
		[DataMember(Name = "DataReference", EmitDefaultValue = false)]
		public PWADataReference DataReference { get; set; }

		/// <summary>
		/// Gets or Sets DataReferencePlugIn
		/// </summary>
		[DataMember(Name = "DataReferencePlugIn", EmitDefaultValue = false)]
		public string DataReferencePlugIn { get; set; }

		/// <summary>
		/// Gets or Sets DefaultUnitsName
		/// </summary>
		[DataMember(Name = "DefaultUnitsName", EmitDefaultValue = false)]
		public string DefaultUnitsName { get; set; }

		/// <summary>
		/// Gets or Sets DefaultUnitsNameAbbreviation
		/// </summary>
		[DataMember(Name = "DefaultUnitsNameAbbreviation", EmitDefaultValue = false)]
		public string DefaultUnitsNameAbbreviation { get; set; }

		/// <summary>
		/// Gets or Sets Description
		/// </summary>
		[DataMember(Name = "Description", EmitDefaultValue = false)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or Sets DisplayDigits
		/// </summary>
		[DataMember(Name = "DisplayDigits", EmitDefaultValue = false)]
		public int? DisplayDigits { get; set; }

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
		/// Gets or Sets IsConfigurationItem
		/// </summary>
		[DataMember(Name = "IsConfigurationItem", EmitDefaultValue = false)]
		public bool? IsConfigurationItem { get; set; }

		/// <summary>
		/// Gets or Sets IsExcluded
		/// </summary>
		[DataMember(Name = "IsExcluded", EmitDefaultValue = false)]
		public bool? IsExcluded { get; set; }

		/// <summary>
		/// Gets or Sets IsHidden
		/// </summary>
		[DataMember(Name = "IsHidden", EmitDefaultValue = false)]
		public bool? IsHidden { get; set; }

		/// <summary>
		/// Gets or Sets IsManualDataEntry
		/// </summary>
		[DataMember(Name = "IsManualDataEntry", EmitDefaultValue = false)]
		public bool? IsManualDataEntry { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAAttributeLinks Links { get; set; }

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
		/// Gets or Sets Paths
		/// </summary>
		[DataMember(Name = "Paths", EmitDefaultValue = false)]
		public List<string> Paths { get; set; }

		/// <summary>
		/// Gets or Sets Span
		/// </summary>
		[DataMember(Name = "Span", EmitDefaultValue = false)]
		public double? Span { get; set; }

		/// <summary>
		/// Gets or Sets Step
		/// </summary>
		[DataMember(Name = "Step", EmitDefaultValue = false)]
		public bool? Step { get; set; }

		/// <summary>
		/// Gets or Sets TraitName
		/// </summary>
		[DataMember(Name = "TraitName", EmitDefaultValue = false)]
		public string TraitName { get; set; }

		/// <summary>
		/// Gets or Sets Type
		/// </summary>
		[DataMember(Name = "Type", EmitDefaultValue = false)]
		public string Type { get; set; }

		/// <summary>
		/// Gets or Sets TypeQualifier
		/// </summary>
		[DataMember(Name = "TypeQualifier", EmitDefaultValue = false)]
		public string TypeQualifier { get; set; }

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

		/// <summary>
		/// Gets or Sets Zero
		/// </summary>
		[DataMember(Name = "Zero", EmitDefaultValue = false)]
		public double? Zero { get; set; }

	}
}
