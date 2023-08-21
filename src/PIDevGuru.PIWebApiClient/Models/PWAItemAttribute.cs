using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// ItemAttribute
	/// </summary>
	[DataContract]
	public class PWAItemAttribute
	{
		public PWAItemAttribute(PWAErrors Exception = null, string Identifier = null, string IdentifierType = null, PWAAttribute Object = null)
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
		public PWAAttribute Object { get; set; }

	}
}
