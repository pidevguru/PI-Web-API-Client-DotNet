using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Annotation
	/// </summary>
	[DataContract]
	public class PWAAnnotation
	{
		public PWAAnnotation(string CreationDate = null, string Creator = null, string Description = null, List<PWAPropertyError> Errors = null, string Id = null, PWAAnnotationLinks Links = null, string Modifier = null, string ModifyDate = null, string Name = null, object Value = null, PWAWebException WebException = null)
		{
			this.CreationDate = CreationDate;
			this.Creator = Creator;
			this.Description = Description;
			this.Errors = Errors;
			this.Id = Id;
			this.Links = Links;
			this.Modifier = Modifier;
			this.ModifyDate = ModifyDate;
			this.Name = Name;
			this.Value = Value;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets CreationDate
		/// </summary>
		[DataMember(Name = "CreationDate", EmitDefaultValue = false)]
		public string CreationDate { get; set; }

		/// <summary>
		/// Gets or Sets Creator
		/// </summary>
		[DataMember(Name = "Creator", EmitDefaultValue = false)]
		public string Creator { get; set; }

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
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAAnnotationLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets Modifier
		/// </summary>
		[DataMember(Name = "Modifier", EmitDefaultValue = false)]
		public string Modifier { get; set; }

		/// <summary>
		/// Gets or Sets ModifyDate
		/// </summary>
		[DataMember(Name = "ModifyDate", EmitDefaultValue = false)]
		public string ModifyDate { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets Value
		/// </summary>
		[DataMember(Name = "Value", EmitDefaultValue = false)]
		public object Value { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
