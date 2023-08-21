using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AnalysisTemplateLinks
	/// </summary>
	[DataContract]
	public class PWAAnalysisTemplateLinks
	{
		public PWAAnalysisTemplateLinks(string AnalysisRule = null, string AnalysisRulePlugIn = null, string Categories = null, string Database = null, string Security = null, string SecurityEntries = null, string Self = null, string Target = null, string TimeRule = null, string TimeRulePlugIn = null)
		{
			this.AnalysisRule = AnalysisRule;
			this.AnalysisRulePlugIn = AnalysisRulePlugIn;
			this.Categories = Categories;
			this.Database = Database;
			this.Security = Security;
			this.SecurityEntries = SecurityEntries;
			this.Self = Self;
			this.Target = Target;
			this.TimeRule = TimeRule;
			this.TimeRulePlugIn = TimeRulePlugIn;
		}
		/// <summary>
		/// Gets or Sets AnalysisRule
		/// </summary>
		[DataMember(Name = "AnalysisRule", EmitDefaultValue = false)]
		public string AnalysisRule { get; set; }

		/// <summary>
		/// Gets or Sets AnalysisRulePlugIn
		/// </summary>
		[DataMember(Name = "AnalysisRulePlugIn", EmitDefaultValue = false)]
		public string AnalysisRulePlugIn { get; set; }

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

		/// <summary>
		/// Gets or Sets Target
		/// </summary>
		[DataMember(Name = "Target", EmitDefaultValue = false)]
		public string Target { get; set; }

		/// <summary>
		/// Gets or Sets TimeRule
		/// </summary>
		[DataMember(Name = "TimeRule", EmitDefaultValue = false)]
		public string TimeRule { get; set; }

		/// <summary>
		/// Gets or Sets TimeRulePlugIn
		/// </summary>
		[DataMember(Name = "TimeRulePlugIn", EmitDefaultValue = false)]
		public string TimeRulePlugIn { get; set; }

	}
}
