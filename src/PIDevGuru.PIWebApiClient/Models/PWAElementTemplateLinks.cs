using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// ElementTemplateLinks
	/// </summary>
	[DataContract]
	public class PWAElementTemplateLinks
	{
		public PWAElementTemplateLinks(string AnalysisTemplates = null, string AttributeTemplates = null, string BaseTemplate = null, string BaseTemplates = null, string Categories = null, string Database = null, string DefaultAttribute = null, string DerivedTemplates = null, string NotificationRuleTemplates = null, string Security = null, string SecurityEntries = null, string Self = null)
		{
			this.AnalysisTemplates = AnalysisTemplates;
			this.AttributeTemplates = AttributeTemplates;
			this.BaseTemplate = BaseTemplate;
			this.BaseTemplates = BaseTemplates;
			this.Categories = Categories;
			this.Database = Database;
			this.DefaultAttribute = DefaultAttribute;
			this.DerivedTemplates = DerivedTemplates;
			this.NotificationRuleTemplates = NotificationRuleTemplates;
			this.Security = Security;
			this.SecurityEntries = SecurityEntries;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets AnalysisTemplates
		/// </summary>
		[DataMember(Name = "AnalysisTemplates", EmitDefaultValue = false)]
		public string AnalysisTemplates { get; set; }

		/// <summary>
		/// Gets or Sets AttributeTemplates
		/// </summary>
		[DataMember(Name = "AttributeTemplates", EmitDefaultValue = false)]
		public string AttributeTemplates { get; set; }

		/// <summary>
		/// Gets or Sets BaseTemplate
		/// </summary>
		[DataMember(Name = "BaseTemplate", EmitDefaultValue = false)]
		public string BaseTemplate { get; set; }

		/// <summary>
		/// Gets or Sets BaseTemplates
		/// </summary>
		[DataMember(Name = "BaseTemplates", EmitDefaultValue = false)]
		public string BaseTemplates { get; set; }

		/// <summary>
		/// Gets or Sets Categories
		/// </summary>
		[DataMember(Name = "Categories", EmitDefaultValue = false)]
		public string Categories { get; set; }

		/// <summary>
		/// Gets or Sets Database
		/// </summary>
		[DataMember(Name = "Database", EmitDefaultValue = false)]
		public string Database { get; set; }

		/// <summary>
		/// Gets or Sets DefaultAttribute
		/// </summary>
		[DataMember(Name = "DefaultAttribute", EmitDefaultValue = false)]
		public string DefaultAttribute { get; set; }

		/// <summary>
		/// Gets or Sets DerivedTemplates
		/// </summary>
		[DataMember(Name = "DerivedTemplates", EmitDefaultValue = false)]
		public string DerivedTemplates { get; set; }

		/// <summary>
		/// Gets or Sets NotificationRuleTemplates
		/// </summary>
		[DataMember(Name = "NotificationRuleTemplates", EmitDefaultValue = false)]
		public string NotificationRuleTemplates { get; set; }

		/// <summary>
		/// Gets or Sets Security
		/// </summary>
		[DataMember(Name = "Security", EmitDefaultValue = false)]
		public string Security { get; set; }

		/// <summary>
		/// Gets or Sets SecurityEntries
		/// </summary>
		[DataMember(Name = "SecurityEntries", EmitDefaultValue = false)]
		public string SecurityEntries { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
