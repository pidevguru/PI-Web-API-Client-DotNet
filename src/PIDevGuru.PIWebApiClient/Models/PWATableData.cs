using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// TableData
	/// </summary>
	[DataContract]
	public class PWATableData
	{
		public PWATableData(Dictionary<string, string> Columns = null, List<Dictionary<string, object>> Rows = null, PWAWebException WebException = null)
		{
			this.Columns = Columns;
			this.Rows = Rows;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets Columns
		/// </summary>
		[DataMember(Name = "Columns", EmitDefaultValue = false)]
		public Dictionary<string, string> Columns { get; set; }

		/// <summary>
		/// Gets or Sets Rows
		/// </summary>
		[DataMember(Name = "Rows", EmitDefaultValue = false)]
		public List<Dictionary<string, object>> Rows { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
