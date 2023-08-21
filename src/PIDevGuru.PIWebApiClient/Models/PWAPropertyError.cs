using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// PropertyError
	/// </summary>
	[DataContract]
	public class PWAPropertyError
	{
		public PWAPropertyError(string FieldName = null, List<string> Message = null)
		{
			this.FieldName = FieldName;
			this.Message = Message;
		}
		/// <summary>
		/// Gets or Sets FieldName
		/// </summary>
		[DataMember(Name = "FieldName", EmitDefaultValue = false)]
		public string FieldName { get; set; }

		/// <summary>
		/// Gets or Sets Message
		/// </summary>
		[DataMember(Name = "Message", EmitDefaultValue = false)]
		public List<string> Message { get; set; }

	}
}
