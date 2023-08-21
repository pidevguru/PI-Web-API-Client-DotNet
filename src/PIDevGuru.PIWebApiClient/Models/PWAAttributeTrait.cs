using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AttributeTrait
	/// </summary>
	[DataContract]
	public class PWAAttributeTrait
	{
		public PWAAttributeTrait(string Abbreviation = null, bool? AllowChildAttributes = null, bool? AllowDuplicates = null, bool? IsAllowedOnRootAttribute = null, bool? IsTypeInherited = null, bool? IsUOMInherited = null, PWAAttributeTraitLinks Links = null, string Name = null, bool? RequireNumeric = null, bool? RequireString = null, PWAWebException WebException = null)
		{
			this.Abbreviation = Abbreviation;
			this.AllowChildAttributes = AllowChildAttributes;
			this.AllowDuplicates = AllowDuplicates;
			this.IsAllowedOnRootAttribute = IsAllowedOnRootAttribute;
			this.IsTypeInherited = IsTypeInherited;
			this.IsUOMInherited = IsUOMInherited;
			this.Links = Links;
			this.Name = Name;
			this.RequireNumeric = RequireNumeric;
			this.RequireString = RequireString;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets Abbreviation
		/// </summary>
		[DataMember(Name = "Abbreviation", EmitDefaultValue = false)]
		public string Abbreviation { get; set; }

		/// <summary>
		/// Gets or Sets AllowChildAttributes
		/// </summary>
		[DataMember(Name = "AllowChildAttributes", EmitDefaultValue = false)]
		public bool? AllowChildAttributes { get; set; }

		/// <summary>
		/// Gets or Sets AllowDuplicates
		/// </summary>
		[DataMember(Name = "AllowDuplicates", EmitDefaultValue = false)]
		public bool? AllowDuplicates { get; set; }

		/// <summary>
		/// Gets or Sets IsAllowedOnRootAttribute
		/// </summary>
		[DataMember(Name = "IsAllowedOnRootAttribute", EmitDefaultValue = false)]
		public bool? IsAllowedOnRootAttribute { get; set; }

		/// <summary>
		/// Gets or Sets IsTypeInherited
		/// </summary>
		[DataMember(Name = "IsTypeInherited", EmitDefaultValue = false)]
		public bool? IsTypeInherited { get; set; }

		/// <summary>
		/// Gets or Sets IsUOMInherited
		/// </summary>
		[DataMember(Name = "IsUOMInherited", EmitDefaultValue = false)]
		public bool? IsUOMInherited { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAAttributeTraitLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets RequireNumeric
		/// </summary>
		[DataMember(Name = "RequireNumeric", EmitDefaultValue = false)]
		public bool? RequireNumeric { get; set; }

		/// <summary>
		/// Gets or Sets RequireString
		/// </summary>
		[DataMember(Name = "RequireString", EmitDefaultValue = false)]
		public bool? RequireString { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
