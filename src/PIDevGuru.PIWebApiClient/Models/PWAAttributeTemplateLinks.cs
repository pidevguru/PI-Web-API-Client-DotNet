using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AttributeTemplateLinks
	/// </summary>
	[DataContract]
	public class PWAAttributeTemplateLinks
	{
		public PWAAttributeTemplateLinks(string AttributeTemplates = null, string Categories = null, string ElementTemplate = null, string Parent = null, string Self = null, string Trait = null)
		{
			this.AttributeTemplates = AttributeTemplates;
			this.Categories = Categories;
			this.ElementTemplate = ElementTemplate;
			this.Parent = Parent;
			this.Self = Self;
			this.Trait = Trait;
		}
		/// <summary>
		/// Gets or Sets AttributeTemplates
		/// </summary>
		[DataMember(Name = "AttributeTemplates", EmitDefaultValue = false)]
		public string AttributeTemplates { get; set; }

		/// <summary>
		/// Gets or Sets Categories
		/// </summary>
		[DataMember(Name = "Categories", EmitDefaultValue = false)]
		public string Categories { get; set; }

		/// <summary>
		/// Gets or Sets ElementTemplate
		/// </summary>
		[DataMember(Name = "ElementTemplate", EmitDefaultValue = false)]
		public string ElementTemplate { get; set; }

		/// <summary>
		/// Gets or Sets Parent
		/// </summary>
		[DataMember(Name = "Parent", EmitDefaultValue = false)]
		public string Parent { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

		/// <summary>
		/// Gets or Sets Trait
		/// </summary>
		[DataMember(Name = "Trait", EmitDefaultValue = false)]
		public string Trait { get; set; }

	}
}
