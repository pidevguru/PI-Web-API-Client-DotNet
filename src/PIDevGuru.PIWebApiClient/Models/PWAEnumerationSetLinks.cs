using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// EnumerationSetLinks
	/// </summary>
	[DataContract]
	public class PWAEnumerationSetLinks
	{
		public PWAEnumerationSetLinks(string DataServer = null, string Database = null, string Security = null, string SecurityEntries = null, string Self = null, string Values = null)
		{
			this.DataServer = DataServer;
			this.Database = Database;
			this.Security = Security;
			this.SecurityEntries = SecurityEntries;
			this.Self = Self;
			this.Values = Values;
		}
		/// <summary>
		/// Gets or Sets DataServer
		/// </summary>
		[DataMember(Name = "DataServer", EmitDefaultValue = false)]
		public string DataServer { get; set; }

		/// <summary>
		/// Gets or Sets Database
		/// </summary>
		[DataMember(Name = "Database", EmitDefaultValue = false)]
		public string Database { get; set; }

		/// <summary>
		/// Gets or Sets Security
		/// </summary>
		[DataMember(Name = "Security", EmitDefaultValue = false)]
		public string Security { get; set; }

		/// <summary>
		/// Gets or Sets SecurityEntries
		/// </summary>
		[DataMember(Name = "SecurityEntries", EmitDefaultValue = false)]
		public string SecurityEntries { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

		/// <summary>
		/// Gets or Sets Values
		/// </summary>
		[DataMember(Name = "Values", EmitDefaultValue = false)]
		public string Values { get; set; }

	}
}
