using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Substatus
	/// </summary>
	[DataContract]
	public class PWASubstatus
	{
		public PWASubstatus(string Message = null, int? Substatus = null, PWAWebException WebException = null)
		{
			this.Message = Message;
			this.Substatus = Substatus;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets Message
		/// </summary>
		[DataMember(Name = "Message", EmitDefaultValue = false)]
		public string Message { get; set; }

		/// <summary>
		/// Gets or Sets Substatus
		/// </summary>
		[DataMember(Name = "Substatus", EmitDefaultValue = false)]
		public int? Substatus { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
