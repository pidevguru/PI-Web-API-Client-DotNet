using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// TimedValue
	/// </summary>
	[DataContract]
	public class PWATimedValue
	{
		public PWATimedValue(bool? Annotated = null, List<PWAPropertyError> Errors = null, bool? Good = null, bool? Questionable = null, bool? Substituted = null, string Timestamp = null, string UnitsAbbreviation = null, object Value = null, PWAWebException WebException = null)
		{
			this.Annotated = Annotated;
			this.Errors = Errors;
			this.Good = Good;
			this.Questionable = Questionable;
			this.Substituted = Substituted;
			this.Timestamp = Timestamp;
			this.UnitsAbbreviation = UnitsAbbreviation;
			this.Value = Value;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets Annotated
		/// </summary>
		[DataMember(Name = "Annotated", EmitDefaultValue = false)]
		public bool? Annotated { get; set; }

		/// <summary>
		/// Gets or Sets Errors
		/// </summary>
		[DataMember(Name = "Errors", EmitDefaultValue = false)]
		public List<PWAPropertyError> Errors { get; set; }

		/// <summary>
		/// Gets or Sets Good
		/// </summary>
		[DataMember(Name = "Good", EmitDefaultValue = false)]
		public bool? Good { get; set; }

		/// <summary>
		/// Gets or Sets Questionable
		/// </summary>
		[DataMember(Name = "Questionable", EmitDefaultValue = false)]
		public bool? Questionable { get; set; }

		/// <summary>
		/// Gets or Sets Substituted
		/// </summary>
		[DataMember(Name = "Substituted", EmitDefaultValue = false)]
		public bool? Substituted { get; set; }

		/// <summary>
		/// Gets or Sets Timestamp
		/// </summary>
		[DataMember(Name = "Timestamp", EmitDefaultValue = false)]
		public string Timestamp { get; set; }

		/// <summary>
		/// Gets or Sets UnitsAbbreviation
		/// </summary>
		[DataMember(Name = "UnitsAbbreviation", EmitDefaultValue = false)]
		public string UnitsAbbreviation { get; set; }

		/// <summary>
		/// Gets or Sets Value
		/// </summary>
		[DataMember(Name = "Value", EmitDefaultValue = false)]
		public object Value { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
