using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// EventFrameLinks
	/// </summary>
	[DataContract]
	public class PWAEventFrameLinks
	{
		public PWAEventFrameLinks(string Annotations = null, string Attributes = null, string Categories = null, string Database = null, string DefaultAttribute = null, string EndValue = null, string EventFrames = null, string InterpolatedData = null, string Parent = null, string PlotData = null, string PrimaryReferencedElement = null, string RecordedData = null, string ReferencedElements = null, string Security = null, string SecurityEntries = null, string Self = null, string SummaryData = null, string Template = null, string Value = null)
		{
			this.Annotations = Annotations;
			this.Attributes = Attributes;
			this.Categories = Categories;
			this.Database = Database;
			this.DefaultAttribute = DefaultAttribute;
			this.EndValue = EndValue;
			this.EventFrames = EventFrames;
			this.InterpolatedData = InterpolatedData;
			this.Parent = Parent;
			this.PlotData = PlotData;
			this.PrimaryReferencedElement = PrimaryReferencedElement;
			this.RecordedData = RecordedData;
			this.ReferencedElements = ReferencedElements;
			this.Security = Security;
			this.SecurityEntries = SecurityEntries;
			this.Self = Self;
			this.SummaryData = SummaryData;
			this.Template = Template;
			this.Value = Value;
		}
		/// <summary>
		/// Gets or Sets Annotations
		/// </summary>
		[DataMember(Name = "Annotations", EmitDefaultValue = false)]
		public string Annotations { get; set; }

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
		/// Gets or Sets PrimaryReferencedElement
		/// </summary>
		[DataMember(Name = "PrimaryReferencedElement", EmitDefaultValue = false)]
		public string PrimaryReferencedElement { get; set; }

		/// <summary>
		/// Gets or Sets RecordedData
		/// </summary>
		[DataMember(Name = "RecordedData", EmitDefaultValue = false)]
		public string RecordedData { get; set; }

		/// <summary>
		/// Gets or Sets ReferencedElements
		/// </summary>
		[DataMember(Name = "ReferencedElements", EmitDefaultValue = false)]
		public string ReferencedElements { get; set; }

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
