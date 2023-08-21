using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// ChannelInstance
	/// </summary>
	[DataContract]
	public class PWAChannelInstance
	{
		public PWAChannelInstance(string Id = null, string LastMessageSentTime = null, int? SentMessageCount = null, string StartTime = null, PWAWebException WebException = null)
		{
			this.Id = Id;
			this.LastMessageSentTime = LastMessageSentTime;
			this.SentMessageCount = SentMessageCount;
			this.StartTime = StartTime;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets LastMessageSentTime
		/// </summary>
		[DataMember(Name = "LastMessageSentTime", EmitDefaultValue = false)]
		public string LastMessageSentTime { get; set; }

		/// <summary>
		/// Gets or Sets SentMessageCount
		/// </summary>
		[DataMember(Name = "SentMessageCount", EmitDefaultValue = false)]
		public int? SentMessageCount { get; set; }

		/// <summary>
		/// Gets or Sets StartTime
		/// </summary>
		[DataMember(Name = "StartTime", EmitDefaultValue = false)]
		public string StartTime { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
