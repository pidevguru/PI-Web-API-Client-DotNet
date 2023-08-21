using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// CacheInstance
	/// </summary>
	[DataContract]
	public class PWACacheInstance
	{
		public PWACacheInstance(string Id = null, string LastRefreshTime = null, string ScheduledExpirationTime = null, string User = null, PWAWebException WebException = null, string WillRefreshAfter = null)
		{
			this.Id = Id;
			this.LastRefreshTime = LastRefreshTime;
			this.ScheduledExpirationTime = ScheduledExpirationTime;
			this.User = User;
			this.WebException = WebException;
			this.WillRefreshAfter = WillRefreshAfter;
		}
		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets LastRefreshTime
		/// </summary>
		[DataMember(Name = "LastRefreshTime", EmitDefaultValue = false)]
		public string LastRefreshTime { get; set; }

		/// <summary>
		/// Gets or Sets ScheduledExpirationTime
		/// </summary>
		[DataMember(Name = "ScheduledExpirationTime", EmitDefaultValue = false)]
		public string ScheduledExpirationTime { get; set; }

		/// <summary>
		/// Gets or Sets User
		/// </summary>
		[DataMember(Name = "User", EmitDefaultValue = false)]
		public string User { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

		/// <summary>
		/// Gets or Sets WillRefreshAfter
		/// </summary>
		[DataMember(Name = "WillRefreshAfter", EmitDefaultValue = false)]
		public string WillRefreshAfter { get; set; }

	}
}
