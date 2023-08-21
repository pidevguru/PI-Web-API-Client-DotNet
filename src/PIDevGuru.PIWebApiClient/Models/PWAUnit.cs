using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Unit
	/// </summary>
	[DataContract]
	public class PWAUnit
	{
		public PWAUnit(string Abbreviation = null, string Description = null, double? Factor = null, string Id = null, PWAUnitLinks Links = null, string Name = null, double? Offset = null, string Path = null, double? ReferenceFactor = null, double? ReferenceOffset = null, string ReferenceUnitAbbreviation = null, PWAWebException WebException = null, string WebId = null)
		{
			this.Abbreviation = Abbreviation;
			this.Description = Description;
			this.Factor = Factor;
			this.Id = Id;
			this.Links = Links;
			this.Name = Name;
			this.Offset = Offset;
			this.Path = Path;
			this.ReferenceFactor = ReferenceFactor;
			this.ReferenceOffset = ReferenceOffset;
			this.ReferenceUnitAbbreviation = ReferenceUnitAbbreviation;
			this.WebException = WebException;
			this.WebId = WebId;
		}
		/// <summary>
		/// Gets or Sets Abbreviation
		/// </summary>
		[DataMember(Name = "Abbreviation", EmitDefaultValue = false)]
		public string Abbreviation { get; set; }

		/// <summary>
		/// Gets or Sets Description
		/// </summary>
		[DataMember(Name = "Description", EmitDefaultValue = false)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or Sets Factor
		/// </summary>
		[DataMember(Name = "Factor", EmitDefaultValue = false)]
		public double? Factor { get; set; }

		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAUnitLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets Offset
		/// </summary>
		[DataMember(Name = "Offset", EmitDefaultValue = false)]
		public double? Offset { get; set; }

		/// <summary>
		/// Gets or Sets Path
		/// </summary>
		[DataMember(Name = "Path", EmitDefaultValue = false)]
		public string Path { get; set; }

		/// <summary>
		/// Gets or Sets ReferenceFactor
		/// </summary>
		[DataMember(Name = "ReferenceFactor", EmitDefaultValue = false)]
		public double? ReferenceFactor { get; set; }

		/// <summary>
		/// Gets or Sets ReferenceOffset
		/// </summary>
		[DataMember(Name = "ReferenceOffset", EmitDefaultValue = false)]
		public double? ReferenceOffset { get; set; }

		/// <summary>
		/// Gets or Sets ReferenceUnitAbbreviation
		/// </summary>
		[DataMember(Name = "ReferenceUnitAbbreviation", EmitDefaultValue = false)]
		public string ReferenceUnitAbbreviation { get; set; }

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
