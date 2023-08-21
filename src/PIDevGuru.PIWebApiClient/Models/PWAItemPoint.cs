using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// ItemPoint
	/// </summary>
	[DataContract]
	public class PWAItemPoint
	{
		public PWAItemPoint(PWAErrors Exception = null, string Identifier = null, string IdentifierType = null, PWAPoint Object = null)
		{
			this.Exception = Exception;
			this.Identifier = Identifier;
			this.IdentifierType = IdentifierType;
			this.Object = Object;
		}
		/// <summary>
		/// Gets or Sets Exception
		/// </summary>
		[DataMember(Name = "Exception", EmitDefaultValue = false)]
		public PWAErrors Exception { get; set; }

		/// <summary>
		/// Gets or Sets Identifier
		/// </summary>
		[DataMember(Name = "Identifier", EmitDefaultValue = false)]
		public string Identifier { get; set; }

		/// <summary>
		/// Gets or Sets IdentifierType
		/// </summary>
		[DataMember(Name = "IdentifierType", EmitDefaultValue = false)]
		public string IdentifierType { get; set; }

		/// <summary>
		/// Gets or Sets Object
		/// </summary>
		[DataMember(Name = "Object", EmitDefaultValue = false)]
		public PWAPoint Object { get; set; }

	}
}
