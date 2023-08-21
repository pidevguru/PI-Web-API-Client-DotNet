using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// EnumerationValue
	/// </summary>
	[DataContract]
	public class PWAEnumerationValue
	{
		public PWAEnumerationValue(string Description = null, string Id = null, PWAEnumerationValueLinks Links = null, string Name = null, string Parent = null, string Path = null, bool? SerializeDescription = null, bool? SerializeId = null, bool? SerializeLinks = null, bool? SerializePath = null, bool? SerializeWebId = null, int? Value = null, PWAWebException WebException = null, string WebId = null)
		{
			this.Description = Description;
			this.Id = Id;
			this.Links = Links;
			this.Name = Name;
			this.Parent = Parent;
			this.Path = Path;
			this.SerializeDescription = SerializeDescription;
			this.SerializeId = SerializeId;
			this.SerializeLinks = SerializeLinks;
			this.SerializePath = SerializePath;
			this.SerializeWebId = SerializeWebId;
			this.Value = Value;
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
		public PWAEnumerationValueLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets Parent
		/// </summary>
		[DataMember(Name = "Parent", EmitDefaultValue = false)]
		public string Parent { get; set; }

		/// <summary>
		/// Gets or Sets Path
		/// </summary>
		[DataMember(Name = "Path", EmitDefaultValue = false)]
		public string Path { get; set; }

		/// <summary>
		/// Gets or Sets SerializeDescription
		/// </summary>
		[DataMember(Name = "SerializeDescription", EmitDefaultValue = false)]
		public bool? SerializeDescription { get; set; }

		/// <summary>
		/// Gets or Sets SerializeId
		/// </summary>
		[DataMember(Name = "SerializeId", EmitDefaultValue = false)]
		public bool? SerializeId { get; set; }

		/// <summary>
		/// Gets or Sets SerializeLinks
		/// </summary>
		[DataMember(Name = "SerializeLinks", EmitDefaultValue = false)]
		public bool? SerializeLinks { get; set; }

		/// <summary>
		/// Gets or Sets SerializePath
		/// </summary>
		[DataMember(Name = "SerializePath", EmitDefaultValue = false)]
		public bool? SerializePath { get; set; }

		/// <summary>
		/// Gets or Sets SerializeWebId
		/// </summary>
		[DataMember(Name = "SerializeWebId", EmitDefaultValue = false)]
		public bool? SerializeWebId { get; set; }

		/// <summary>
		/// Gets or Sets Value
		/// </summary>
		[DataMember(Name = "Value", EmitDefaultValue = false)]
		public int? Value { get; set; }

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
