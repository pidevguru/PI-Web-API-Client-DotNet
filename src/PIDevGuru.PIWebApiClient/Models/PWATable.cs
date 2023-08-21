using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Table
	/// </summary>
	[DataContract]
	public class PWATable
	{
		public PWATable(List<string> CategoryNames = null, bool? ConvertToLocalTime = null, string Description = null, string Id = null, PWATableLinks Links = null, string Name = null, string Path = null, string TimeZone = null, PWAWebException WebException = null, string WebId = null)
		{
			this.CategoryNames = CategoryNames;
			this.ConvertToLocalTime = ConvertToLocalTime;
			this.Description = Description;
			this.Id = Id;
			this.Links = Links;
			this.Name = Name;
			this.Path = Path;
			this.TimeZone = TimeZone;
			this.WebException = WebException;
			this.WebId = WebId;
		}
		/// <summary>
		/// Gets or Sets CategoryNames
		/// </summary>
		[DataMember(Name = "CategoryNames", EmitDefaultValue = false)]
		public List<string> CategoryNames { get; set; }

		/// <summary>
		/// Gets or Sets ConvertToLocalTime
		/// </summary>
		[DataMember(Name = "ConvertToLocalTime", EmitDefaultValue = false)]
		public bool? ConvertToLocalTime { get; set; }

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
		public PWATableLinks Links { get; set; }

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
		/// Gets or Sets TimeZone
		/// </summary>
		[DataMember(Name = "TimeZone", EmitDefaultValue = false)]
		public string TimeZone { get; set; }

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
