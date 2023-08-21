using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// PointAttribute
	/// </summary>
	[DataContract]
	public class PWAPointAttribute
	{
		public PWAPointAttribute(PWAPointAttributeLinks Links = null, string Name = null, object Value = null, PWAWebException WebException = null)
		{
			this.Links = Links;
			this.Name = Name;
			this.Value = Value;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAPointAttributeLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

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
