using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Response
	/// </summary>
	[DataContract]
	public class PWAResponse
	{
		public PWAResponse(object Content = null, Dictionary<string, string> Headers = null, int? Status = null)
		{
			this.Content = Content;
			this.Headers = Headers;
			this.Status = Status;
		}
		/// <summary>
		/// Gets or Sets Content
		/// </summary>
		[DataMember(Name = "Content", EmitDefaultValue = false)]
		public object Content { get; set; }

		/// <summary>
		/// Gets or Sets Headers
		/// </summary>
		[DataMember(Name = "Headers", EmitDefaultValue = false)]
		public Dictionary<string, string> Headers { get; set; }

		/// <summary>
		/// Gets or Sets Status
		/// </summary>
		[DataMember(Name = "Status", EmitDefaultValue = false)]
		public int? Status { get; set; }

	}
}
