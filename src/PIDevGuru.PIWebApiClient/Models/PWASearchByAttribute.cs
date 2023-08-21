using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// SearchByAttribute
	/// </summary>
	[DataContract]
	public class PWASearchByAttribute
	{
		public PWASearchByAttribute(string ElementTemplate = null, string SearchRoot = null, List<PWAValueQuery> ValueQueries = null, PWAWebException WebException = null)
		{
			this.ElementTemplate = ElementTemplate;
			this.SearchRoot = SearchRoot;
			this.ValueQueries = ValueQueries;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets ElementTemplate
		/// </summary>
		[DataMember(Name = "ElementTemplate", EmitDefaultValue = false)]
		public string ElementTemplate { get; set; }

		/// <summary>
		/// Gets or Sets SearchRoot
		/// </summary>
		[DataMember(Name = "SearchRoot", EmitDefaultValue = false)]
		public string SearchRoot { get; set; }

		/// <summary>
		/// Gets or Sets ValueQueries
		/// </summary>
		[DataMember(Name = "ValueQueries", EmitDefaultValue = false)]
		public List<PWAValueQuery> ValueQueries { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
