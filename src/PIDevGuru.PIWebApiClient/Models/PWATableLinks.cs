using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// TableLinks
	/// </summary>
	[DataContract]
	public class PWATableLinks
	{
		public PWATableLinks(string Categories = null, string Data = null, string Database = null, string Security = null, string SecurityEntries = null, string Self = null)
		{
			this.Categories = Categories;
			this.Data = Data;
			this.Database = Database;
			this.Security = Security;
			this.SecurityEntries = SecurityEntries;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets Categories
		/// </summary>
		[DataMember(Name = "Categories", EmitDefaultValue = false)]
		public string Categories { get; set; }

		/// <summary>
		/// Gets or Sets Data
		/// </summary>
		[DataMember(Name = "Data", EmitDefaultValue = false)]
		public string Data { get; set; }

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

	}
}
