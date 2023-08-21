using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// ElementTemplate
	/// </summary>
	[DataContract]
	public class PWAElementTemplate
	{
		public PWAElementTemplate(bool? AllowElementToExtend = null, string BaseTemplate = null, bool? CanBeAcknowledged = null, List<string> CategoryNames = null, string Description = null, Dictionary<string, PWAValue> ExtendedProperties = null, string Id = null, string InstanceType = null, PWAElementTemplateLinks Links = null, string Name = null, string NamingPattern = null, string Path = null, string Severity = null, PWAWebException WebException = null, string WebId = null)
		{
			this.AllowElementToExtend = AllowElementToExtend;
			this.BaseTemplate = BaseTemplate;
			this.CanBeAcknowledged = CanBeAcknowledged;
			this.CategoryNames = CategoryNames;
			this.Description = Description;
			this.ExtendedProperties = ExtendedProperties;
			this.Id = Id;
			this.InstanceType = InstanceType;
			this.Links = Links;
			this.Name = Name;
			this.NamingPattern = NamingPattern;
			this.Path = Path;
			this.Severity = Severity;
			this.WebException = WebException;
			this.WebId = WebId;
		}
		/// <summary>
		/// Gets or Sets AllowElementToExtend
		/// </summary>
		[DataMember(Name = "AllowElementToExtend", EmitDefaultValue = false)]
		public bool? AllowElementToExtend { get; set; }

		/// <summary>
		/// Gets or Sets BaseTemplate
		/// </summary>
		[DataMember(Name = "BaseTemplate", EmitDefaultValue = false)]
		public string BaseTemplate { get; set; }

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
		/// Gets or Sets ExtendedProperties
		/// </summary>
		[DataMember(Name = "ExtendedProperties", EmitDefaultValue = false)]
		public Dictionary<string, PWAValue> ExtendedProperties { get; set; }

		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets InstanceType
		/// </summary>
		[DataMember(Name = "InstanceType", EmitDefaultValue = false)]
		public string InstanceType { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAElementTemplateLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets NamingPattern
		/// </summary>
		[DataMember(Name = "NamingPattern", EmitDefaultValue = false)]
		public string NamingPattern { get; set; }

		/// <summary>
		/// Gets or Sets Path
		/// </summary>
		[DataMember(Name = "Path", EmitDefaultValue = false)]
		public string Path { get; set; }

		/// <summary>
		/// Gets or Sets Severity
		/// </summary>
		[DataMember(Name = "Severity", EmitDefaultValue = false)]
		public string Severity { get; set; }

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
