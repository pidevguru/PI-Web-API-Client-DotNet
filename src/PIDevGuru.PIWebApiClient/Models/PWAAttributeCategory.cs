using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AttributeCategory
	/// </summary>
	[DataContract]
	public class PWAAttributeCategory
	{
		public PWAAttributeCategory(string Description = null, string Id = null, PWAAttributeCategoryLinks Links = null, string Name = null, string Path = null, PWAWebException WebException = null, string WebId = null)
		{
			this.Description = Description;
			this.Id = Id;
			this.Links = Links;
			this.Name = Name;
			this.Path = Path;
			this.WebException = WebException;
			this.WebId = WebId;
		}
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
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAAttributeCategoryLinks Links { get; set; }

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
