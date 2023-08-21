using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// ValueQuery
	/// </summary>
	[DataContract]
	public class PWAValueQuery
	{
		public PWAValueQuery(string AttributeName = null, string AttributeUOM = null, object AttributeValue = null, string SearchOperator = null, PWAWebException WebException = null)
		{
			this.AttributeName = AttributeName;
			this.AttributeUOM = AttributeUOM;
			this.AttributeValue = AttributeValue;
			this.SearchOperator = SearchOperator;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets AttributeName
		/// </summary>
		[DataMember(Name = "AttributeName", EmitDefaultValue = false)]
		public string AttributeName { get; set; }

		/// <summary>
		/// Gets or Sets AttributeUOM
		/// </summary>
		[DataMember(Name = "AttributeUOM", EmitDefaultValue = false)]
		public string AttributeUOM { get; set; }

		/// <summary>
		/// Gets or Sets AttributeValue
		/// </summary>
		[DataMember(Name = "AttributeValue", EmitDefaultValue = false)]
		public object AttributeValue { get; set; }

		/// <summary>
		/// Gets or Sets SearchOperator
		/// </summary>
		[DataMember(Name = "SearchOperator", EmitDefaultValue = false)]
		public string SearchOperator { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
