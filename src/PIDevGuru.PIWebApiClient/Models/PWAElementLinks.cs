using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// ElementLinks
	/// </summary>
	[DataContract]
	public class PWAElementLinks
	{
		public PWAElementLinks(string Analyses = null, string Attributes = null, string Categories = null, string Database = null, string DefaultAttribute = null, string Elements = null, string EndValue = null, string EventFrames = null, string InterpolatedData = null, string NotificationRules = null, string Parent = null, string PlotData = null, string RecordedData = null, string Security = null, string SecurityEntries = null, string Self = null, string SummaryData = null, string Template = null, string Value = null)
		{
			this.Analyses = Analyses;
			this.Attributes = Attributes;
			this.Categories = Categories;
			this.Database = Database;
			this.DefaultAttribute = DefaultAttribute;
			this.Elements = Elements;
			this.EndValue = EndValue;
			this.EventFrames = EventFrames;
			this.InterpolatedData = InterpolatedData;
			this.NotificationRules = NotificationRules;
			this.Parent = Parent;
			this.PlotData = PlotData;
			this.RecordedData = RecordedData;
			this.Security = Security;
			this.SecurityEntries = SecurityEntries;
			this.Self = Self;
			this.SummaryData = SummaryData;
			this.Template = Template;
			this.Value = Value;
		}
		/// <summary>
		/// Gets or Sets Analyses
		/// </summary>
		[DataMember(Name = "Analyses", EmitDefaultValue = false)]
		public string Analyses { get; set; }

		/// <summary>
		/// Gets or Sets Attributes
		/// </summary>
		[DataMember(Name = "Attributes", EmitDefaultValue = false)]
		public string Attributes { get; set; }

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
		/// Gets or Sets Elements
		/// </summary>
		[DataMember(Name = "Elements", EmitDefaultValue = false)]
		public string Elements { get; set; }

		/// <summary>
		/// Gets or Sets EndValue
		/// </summary>
		[DataMember(Name = "EndValue", EmitDefaultValue = false)]
		public string EndValue { get; set; }

		/// <summary>
		/// Gets or Sets EventFrames
		/// </summary>
		[DataMember(Name = "EventFrames", EmitDefaultValue = false)]
		public string EventFrames { get; set; }

		/// <summary>
		/// Gets or Sets InterpolatedData
		/// </summary>
		[DataMember(Name = "InterpolatedData", EmitDefaultValue = false)]
		public string InterpolatedData { get; set; }

		/// <summary>
		/// Gets or Sets NotificationRules
		/// </summary>
		[DataMember(Name = "NotificationRules", EmitDefaultValue = false)]
		public string NotificationRules { get; set; }

		/// <summary>
		/// Gets or Sets Parent
		/// </summary>
		[DataMember(Name = "Parent", EmitDefaultValue = false)]
		public string Parent { get; set; }

		/// <summary>
		/// Gets or Sets PlotData
		/// </summary>
		[DataMember(Name = "PlotData", EmitDefaultValue = false)]
		public string PlotData { get; set; }

		/// <summary>
		/// Gets or Sets RecordedData
		/// </summary>
		[DataMember(Name = "RecordedData", EmitDefaultValue = false)]
		public string RecordedData { get; set; }

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
		/// Gets or Sets SummaryData
		/// </summary>
		[DataMember(Name = "SummaryData", EmitDefaultValue = false)]
		public string SummaryData { get; set; }

		/// <summary>
		/// Gets or Sets Template
		/// </summary>
		[DataMember(Name = "Template", EmitDefaultValue = false)]
		public string Template { get; set; }

		/// <summary>
		/// Gets or Sets Value
		/// </summary>
		[DataMember(Name = "Value", EmitDefaultValue = false)]
		public string Value { get; set; }

	}
}
