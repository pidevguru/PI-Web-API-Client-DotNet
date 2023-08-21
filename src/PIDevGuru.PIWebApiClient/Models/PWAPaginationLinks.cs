using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// PaginationLinks
	/// </summary>
	[DataContract]
	public class PWAPaginationLinks
	{
		public PWAPaginationLinks(string First = null, string Last = null, string Next = null, string Previous = null)
		{
			this.First = First;
			this.Last = Last;
			this.Next = Next;
			this.Previous = Previous;
		}
		/// <summary>
		/// Gets or Sets First
		/// </summary>
		[DataMember(Name = "First", EmitDefaultValue = false)]
		public string First { get; set; }

		/// <summary>
		/// Gets or Sets Last
		/// </summary>
		[DataMember(Name = "Last", EmitDefaultValue = false)]
		public string Last { get; set; }

		/// <summary>
		/// Gets or Sets Next
		/// </summary>
		[DataMember(Name = "Next", EmitDefaultValue = false)]
		public string Next { get; set; }

		/// <summary>
		/// Gets or Sets Previous
		/// </summary>
		[DataMember(Name = "Previous", EmitDefaultValue = false)]
		public string Previous { get; set; }

	}
}
