using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// NotificationContactTemplateLinks
	/// </summary>
	[DataContract]
	public class PWANotificationContactTemplateLinks
	{
		public PWANotificationContactTemplateLinks(string AssetServer = null, string NotificationContactTemplates = null, string NotificationPlugIn = null, string Security = null, string SecurityEntries = null, string Self = null)
		{
			this.AssetServer = AssetServer;
			this.NotificationContactTemplates = NotificationContactTemplates;
			this.NotificationPlugIn = NotificationPlugIn;
			this.Security = Security;
			this.SecurityEntries = SecurityEntries;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets AssetServer
		/// </summary>
		[DataMember(Name = "AssetServer", EmitDefaultValue = false)]
		public string AssetServer { get; set; }

		/// <summary>
		/// Gets or Sets NotificationContactTemplates
		/// </summary>
		[DataMember(Name = "NotificationContactTemplates", EmitDefaultValue = false)]
		public string NotificationContactTemplates { get; set; }

		/// <summary>
		/// Gets or Sets NotificationPlugIn
		/// </summary>
		[DataMember(Name = "NotificationPlugIn", EmitDefaultValue = false)]
		public string NotificationPlugIn { get; set; }

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
