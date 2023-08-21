using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// TimeRuleLinks
	/// </summary>
	[DataContract]
	public class PWATimeRuleLinks
	{
		public PWATimeRuleLinks(string Analysis = null, string AnalysisTemplate = null, string PlugIn = null, string Self = null)
		{
			this.Analysis = Analysis;
			this.AnalysisTemplate = AnalysisTemplate;
			this.PlugIn = PlugIn;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets Analysis
		/// </summary>
		[DataMember(Name = "Analysis", EmitDefaultValue = false)]
		public string Analysis { get; set; }

		/// <summary>
		/// Gets or Sets AnalysisTemplate
		/// </summary>
		[DataMember(Name = "AnalysisTemplate", EmitDefaultValue = false)]
		public string AnalysisTemplate { get; set; }

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
