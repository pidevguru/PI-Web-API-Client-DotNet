using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AttributeLinks
	/// </summary>
	[DataContract]
	public class PWAAttributeLinks
	{
		public PWAAttributeLinks(string Attributes = null, string Categories = null, string Element = null, string EndValue = null, string EnumerationSet = null, string EnumerationValues = null, string EventFrame = null, string InterpolatedData = null, string Parent = null, string PlotData = null, string Point = null, string RecordedData = null, string Self = null, string SummaryData = null, string Template = null, string Trait = null, string Value = null)
		{
			this.Attributes = Attributes;
			this.Categories = Categories;
			this.Element = Element;
			this.EndValue = EndValue;
			this.EnumerationSet = EnumerationSet;
			this.EnumerationValues = EnumerationValues;
			this.EventFrame = EventFrame;
			this.InterpolatedData = InterpolatedData;
			this.Parent = Parent;
			this.PlotData = PlotData;
			this.Point = Point;
			this.RecordedData = RecordedData;
			this.Self = Self;
			this.SummaryData = SummaryData;
			this.Template = Template;
			this.Trait = Trait;
			this.Value = Value;
		}
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
		/// Gets or Sets Element
		/// </summary>
		[DataMember(Name = "Element", EmitDefaultValue = false)]
		public string Element { get; set; }

		/// <summary>
		/// Gets or Sets EndValue
		/// </summary>
		[DataMember(Name = "EndValue", EmitDefaultValue = false)]
		public string EndValue { get; set; }

		/// <summary>
		/// Gets or Sets EnumerationSet
		/// </summary>
		[DataMember(Name = "EnumerationSet", EmitDefaultValue = false)]
		public string EnumerationSet { get; set; }

		/// <summary>
		/// Gets or Sets EnumerationValues
		/// </summary>
		[DataMember(Name = "EnumerationValues", EmitDefaultValue = false)]
		public string EnumerationValues { get; set; }

		/// <summary>
		/// Gets or Sets EventFrame
		/// </summary>
		[DataMember(Name = "EventFrame", EmitDefaultValue = false)]
		public string EventFrame { get; set; }

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
		/// Gets or Sets Point
		/// </summary>
		[DataMember(Name = "Point", EmitDefaultValue = false)]
		public string Point { get; set; }

		/// <summary>
		/// Gets or Sets RecordedData
		/// </summary>
		[DataMember(Name = "RecordedData", EmitDefaultValue = false)]
		public string RecordedData { get; set; }

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
		/// Gets or Sets Trait
		/// </summary>
		[DataMember(Name = "Trait", EmitDefaultValue = false)]
		public string Trait { get; set; }

		/// <summary>
		/// Gets or Sets Value
		/// </summary>
		[DataMember(Name = "Value", EmitDefaultValue = false)]
		public string Value { get; set; }

	}
}
