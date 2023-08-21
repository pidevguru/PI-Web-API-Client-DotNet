using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// SystemStatus
	/// </summary>
	[DataContract]
	public class PWASystemStatus
	{
		public PWASystemStatus(int? CacheInstances = null, string ServerTime = null, string State = null, double? UpTimeInMinutes = null, PWAWebException WebException = null)
		{
			this.CacheInstances = CacheInstances;
			this.ServerTime = ServerTime;
			this.State = State;
			this.UpTimeInMinutes = UpTimeInMinutes;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets CacheInstances
		/// </summary>
		[DataMember(Name = "CacheInstances", EmitDefaultValue = false)]
		public int? CacheInstances { get; set; }

		/// <summary>
		/// Gets or Sets ServerTime
		/// </summary>
		[DataMember(Name = "ServerTime", EmitDefaultValue = false)]
		public string ServerTime { get; set; }

		/// <summary>
		/// Gets or Sets State
		/// </summary>
		[DataMember(Name = "State", EmitDefaultValue = false)]
		public string State { get; set; }

		/// <summary>
		/// Gets or Sets UpTimeInMinutes
		/// </summary>
		[DataMember(Name = "UpTimeInMinutes", EmitDefaultValue = false)]
		public double? UpTimeInMinutes { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
