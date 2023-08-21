using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AttributeTemplate
	/// </summary>
	[DataContract]
	public class PWAAttributeTemplate
	{
		public PWAAttributeTemplate(List<string> CategoryNames = null, string ConfigString = null, string DataReferencePlugIn = null, string DefaultUnitsName = null, string DefaultUnitsNameAbbreviation = null, object DefaultValue = null, string Description = null, bool? HasChildren = null, string Id = null, bool? IsConfigurationItem = null, bool? IsExcluded = null, bool? IsHidden = null, bool? IsManualDataEntry = null, PWAAttributeTemplateLinks Links = null, string Name = null, string Path = null, string TraitName = null, string Type = null, string TypeQualifier = null, PWAWebException WebException = null, string WebId = null)
		{
			this.CategoryNames = CategoryNames;
			this.ConfigString = ConfigString;
			this.DataReferencePlugIn = DataReferencePlugIn;
			this.DefaultUnitsName = DefaultUnitsName;
			this.DefaultUnitsNameAbbreviation = DefaultUnitsNameAbbreviation;
			this.DefaultValue = DefaultValue;
			this.Description = Description;
			this.HasChildren = HasChildren;
			this.Id = Id;
			this.IsConfigurationItem = IsConfigurationItem;
			this.IsExcluded = IsExcluded;
			this.IsHidden = IsHidden;
			this.IsManualDataEntry = IsManualDataEntry;
			this.Links = Links;
			this.Name = Name;
			this.Path = Path;
			this.TraitName = TraitName;
			this.Type = Type;
			this.TypeQualifier = TypeQualifier;
			this.WebException = WebException;
			this.WebId = WebId;
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
		/// Gets or Sets DefaultValue
		/// </summary>
		[DataMember(Name = "DefaultValue", EmitDefaultValue = false)]
		public object DefaultValue { get; set; }

		/// <summary>
		/// Gets or Sets Description
		/// </summary>
		[DataMember(Name = "Description", EmitDefaultValue = false)]
		public string Description { get; set; }

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
		public PWAAttributeTemplateLinks Links { get; set; }

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

	}
}
