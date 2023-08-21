using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// PIPointDataReference
	/// </summary>
	[DataContract]
	public class PWAPIPointDataReference
	{
		public PWAPIPointDataReference(string Descriptor = null, string DigitalSetName = null, int? DisplayDigits = null, string EngineeringUnits = null, bool? Future = null, int? Id = null, string Name = null, string Path = null, string PointClass = null, string PointType = null, double? Span = null, bool? Step = null, string WebId = null, double? Zero = null)
		{
			this.Descriptor = Descriptor;
			this.DigitalSetName = DigitalSetName;
			this.DisplayDigits = DisplayDigits;
			this.EngineeringUnits = EngineeringUnits;
			this.Future = Future;
			this.Id = Id;
			this.Name = Name;
			this.Path = Path;
			this.PointClass = PointClass;
			this.PointType = PointType;
			this.Span = Span;
			this.Step = Step;
			this.WebId = WebId;
			this.Zero = Zero;
		}
		/// <summary>
		/// Gets or Sets Descriptor
		/// </summary>
		[DataMember(Name = "Descriptor", EmitDefaultValue = false)]
		public string Descriptor { get; set; }

		/// <summary>
		/// Gets or Sets DigitalSetName
		/// </summary>
		[DataMember(Name = "DigitalSetName", EmitDefaultValue = false)]
		public string DigitalSetName { get; set; }

		/// <summary>
		/// Gets or Sets DisplayDigits
		/// </summary>
		[DataMember(Name = "DisplayDigits", EmitDefaultValue = false)]
		public int? DisplayDigits { get; set; }

		/// <summary>
		/// Gets or Sets EngineeringUnits
		/// </summary>
		[DataMember(Name = "EngineeringUnits", EmitDefaultValue = false)]
		public string EngineeringUnits { get; set; }

		/// <summary>
		/// Gets or Sets Future
		/// </summary>
		[DataMember(Name = "Future", EmitDefaultValue = false)]
		public bool? Future { get; set; }

		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public int? Id { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets Path
		/// </summary>
		[DataMember(Name = "Path", EmitDefaultValue = false)]
		public string Path { get; set; }

		/// <summary>
		/// Gets or Sets PointClass
		/// </summary>
		[DataMember(Name = "PointClass", EmitDefaultValue = false)]
		public string PointClass { get; set; }

		/// <summary>
		/// Gets or Sets PointType
		/// </summary>
		[DataMember(Name = "PointType", EmitDefaultValue = false)]
		public string PointType { get; set; }

		/// <summary>
		/// Gets or Sets Span
		/// </summary>
		[DataMember(Name = "Span", EmitDefaultValue = false)]
		public double? Span { get; set; }

		/// <summary>
		/// Gets or Sets Step
		/// </summary>
		[DataMember(Name = "Step", EmitDefaultValue = false)]
		public bool? Step { get; set; }

		/// <summary>
		/// Gets or Sets WebId
		/// </summary>
		[DataMember(Name = "WebId", EmitDefaultValue = false)]
		public string WebId { get; set; }

		/// <summary>
		/// Gets or Sets Zero
		/// </summary>
		[DataMember(Name = "Zero", EmitDefaultValue = false)]
		public double? Zero { get; set; }

	}
}
