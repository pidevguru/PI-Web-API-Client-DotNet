using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AnalysisRuleLinks
	/// </summary>
	[DataContract]
	public class PWAAnalysisRuleLinks
	{
		public PWAAnalysisRuleLinks(string Analysis = null, string AnalysisRules = null, string AnalysisTemplate = null, string Parent = null, string PlugIn = null, string Self = null)
		{
			this.Analysis = Analysis;
			this.AnalysisRules = AnalysisRules;
			this.AnalysisTemplate = AnalysisTemplate;
			this.Parent = Parent;
			this.PlugIn = PlugIn;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets Analysis
		/// </summary>
		[DataMember(Name = "Analysis", EmitDefaultValue = false)]
		public string Analysis { get; set; }

		/// <summary>
		/// Gets or Sets AnalysisRules
		/// </summary>
		[DataMember(Name = "AnalysisRules", EmitDefaultValue = false)]
		public string AnalysisRules { get; set; }

		/// <summary>
		/// Gets or Sets AnalysisTemplate
		/// </summary>
		[DataMember(Name = "AnalysisTemplate", EmitDefaultValue = false)]
		public string AnalysisTemplate { get; set; }

		/// <summary>
		/// Gets or Sets Parent
		/// </summary>
		[DataMember(Name = "Parent", EmitDefaultValue = false)]
		public string Parent { get; set; }

		/// <summary>
		/// Gets or Sets PlugIn
		/// </summary>
		[DataMember(Name = "PlugIn", EmitDefaultValue = false)]
		public string PlugIn { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
