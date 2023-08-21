using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Element
	/// </summary>
	[DataContract]
	public class PWAElement
	{
		public PWAElement(List<string> CategoryNames = null, string Description = null, List<PWAPropertyError> Errors = null, Dictionary<string, PWAValue> ExtendedProperties = null, bool? HasChildren = null, string Id = null, PWAElementLinks Links = null, string Name = null, string Path = null, List<string> Paths = null, string TemplateName = null, PWAWebException WebException = null, string WebId = null)
		{
			this.CategoryNames = CategoryNames;
			this.Description = Description;
			this.Errors = Errors;
			this.ExtendedProperties = ExtendedProperties;
			this.HasChildren = HasChildren;
			this.Id = Id;
			this.Links = Links;
			this.Name = Name;
			this.Path = Path;
			this.Paths = Paths;
			this.TemplateName = TemplateName;
			this.WebException = WebException;
			this.WebId = WebId;
		}
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
		/// Gets or Sets Errors
		/// </summary>
		[DataMember(Name = "Errors", EmitDefaultValue = false)]
		public List<PWAPropertyError> Errors { get; set; }

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
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAElementLinks Links { get; set; }

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
