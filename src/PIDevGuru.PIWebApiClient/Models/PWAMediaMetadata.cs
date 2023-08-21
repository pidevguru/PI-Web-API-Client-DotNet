using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// MediaMetadata
	/// </summary>
	[DataContract]
	public class PWAMediaMetadata
	{
		public PWAMediaMetadata(string Author = null, string ChangeDate = null, string Description = null, PWAMediaMetadataLinks Links = null, string Name = null, double? Size = null, PWAWebException WebException = null)
		{
			this.Author = Author;
			this.ChangeDate = ChangeDate;
			this.Description = Description;
			this.Links = Links;
			this.Name = Name;
			this.Size = Size;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets Author
		/// </summary>
		[DataMember(Name = "Author", EmitDefaultValue = false)]
		public string Author { get; set; }

		/// <summary>
		/// Gets or Sets ChangeDate
		/// </summary>
		[DataMember(Name = "ChangeDate", EmitDefaultValue = false)]
		public string ChangeDate { get; set; }

		/// <summary>
		/// Gets or Sets Description
		/// </summary>
		[DataMember(Name = "Description", EmitDefaultValue = false)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAMediaMetadataLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets Size
		/// </summary>
		[DataMember(Name = "Size", EmitDefaultValue = false)]
		public double? Size { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
