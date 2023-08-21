using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AssetServerLinks
	/// </summary>
	[DataContract]
	public class PWAAssetServerLinks
	{
		public PWAAssetServerLinks(string AnalysisRulePlugIns = null, string Databases = null, string NotificationContactTemplates = null, string NotificationPlugIns = null, string Security = null, string SecurityEntries = null, string SecurityIdentities = null, string SecurityMappings = null, string Self = null, string TimeRulePlugIns = null, string UnitClasses = null)
		{
			this.AnalysisRulePlugIns = AnalysisRulePlugIns;
			this.Databases = Databases;
			this.NotificationContactTemplates = NotificationContactTemplates;
			this.NotificationPlugIns = NotificationPlugIns;
			this.Security = Security;
			this.SecurityEntries = SecurityEntries;
			this.SecurityIdentities = SecurityIdentities;
			this.SecurityMappings = SecurityMappings;
			this.Self = Self;
			this.TimeRulePlugIns = TimeRulePlugIns;
			this.UnitClasses = UnitClasses;
		}
		/// <summary>
		/// Gets or Sets AnalysisRulePlugIns
		/// </summary>
		[DataMember(Name = "AnalysisRulePlugIns", EmitDefaultValue = false)]
		public string AnalysisRulePlugIns { get; set; }

		/// <summary>
		/// Gets or Sets Databases
		/// </summary>
		[DataMember(Name = "Databases", EmitDefaultValue = false)]
		public string Databases { get; set; }

		/// <summary>
		/// Gets or Sets NotificationContactTemplates
		/// </summary>
		[DataMember(Name = "NotificationContactTemplates", EmitDefaultValue = false)]
		public string NotificationContactTemplates { get; set; }

		/// <summary>
		/// Gets or Sets NotificationPlugIns
		/// </summary>
		[DataMember(Name = "NotificationPlugIns", EmitDefaultValue = false)]
		public string NotificationPlugIns { get; set; }

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
		/// Gets or Sets SecurityIdentities
		/// </summary>
		[DataMember(Name = "SecurityIdentities", EmitDefaultValue = false)]
		public string SecurityIdentities { get; set; }

		/// <summary>
		/// Gets or Sets SecurityMappings
		/// </summary>
		[DataMember(Name = "SecurityMappings", EmitDefaultValue = false)]
		public string SecurityMappings { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

		/// <summary>
		/// Gets or Sets TimeRulePlugIns
		/// </summary>
		[DataMember(Name = "TimeRulePlugIns", EmitDefaultValue = false)]
		public string TimeRulePlugIns { get; set; }

		/// <summary>
		/// Gets or Sets UnitClasses
		/// </summary>
		[DataMember(Name = "UnitClasses", EmitDefaultValue = false)]
		public string UnitClasses { get; set; }

	}
}
