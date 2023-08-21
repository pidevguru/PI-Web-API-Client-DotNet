using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// PointLinks
	/// </summary>
	[DataContract]
	public class PWAPointLinks
	{
		public PWAPointLinks(string Attributes = null, string DataServer = null, string EndValue = null, string InterpolatedData = null, string PlotData = null, string RecordedData = null, string Self = null, string SummaryData = null, string Value = null)
		{
			this.Attributes = Attributes;
			this.DataServer = DataServer;
			this.EndValue = EndValue;
			this.InterpolatedData = InterpolatedData;
			this.PlotData = PlotData;
			this.RecordedData = RecordedData;
			this.Self = Self;
			this.SummaryData = SummaryData;
			this.Value = Value;
		}
		/// <summary>
		/// Gets or Sets Attributes
		/// </summary>
		[DataMember(Name = "Attributes", EmitDefaultValue = false)]
		public string Attributes { get; set; }

		/// <summary>
		/// Gets or Sets DataServer
		/// </summary>
		[DataMember(Name = "DataServer", EmitDefaultValue = false)]
		public string DataServer { get; set; }

		/// <summary>
		/// Gets or Sets EndValue
		/// </summary>
		[DataMember(Name = "EndValue", EmitDefaultValue = false)]
		public string EndValue { get; set; }

		/// <summary>
		/// Gets or Sets InterpolatedData
		/// </summary>
		[DataMember(Name = "InterpolatedData", EmitDefaultValue = false)]
		public string InterpolatedData { get; set; }

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
		/// Gets or Sets Value
		/// </summary>
		[DataMember(Name = "Value", EmitDefaultValue = false)]
		public string Value { get; set; }

	}
}
