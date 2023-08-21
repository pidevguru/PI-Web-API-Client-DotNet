using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// NotificationRuleSubscriber
	/// </summary>
	[DataContract]
	public class PWANotificationRuleSubscriber
	{
		public PWANotificationRuleSubscriber(string ConfigString = null, string ContactTemplateName = null, string ContactType = null, string DeliveryFormatName = null, string Description = null, string EscalationTimeout = null, string Id = null, int? MaximumRetries = null, string Name = null, string NotifyOption = null, string Path = null, string PlugInName = null, string RetryInterval = null, PWAWebException WebException = null, string WebId = null)
		{
			this.ConfigString = ConfigString;
			this.ContactTemplateName = ContactTemplateName;
			this.ContactType = ContactType;
			this.DeliveryFormatName = DeliveryFormatName;
			this.Description = Description;
			this.EscalationTimeout = EscalationTimeout;
			this.Id = Id;
			this.MaximumRetries = MaximumRetries;
			this.Name = Name;
			this.NotifyOption = NotifyOption;
			this.Path = Path;
			this.PlugInName = PlugInName;
			this.RetryInterval = RetryInterval;
			this.WebException = WebException;
			this.WebId = WebId;
		}
		/// <summary>
		/// Gets or Sets ConfigString
		/// </summary>
		[DataMember(Name = "ConfigString", EmitDefaultValue = false)]
		public string ConfigString { get; set; }

		/// <summary>
		/// Gets or Sets ContactTemplateName
		/// </summary>
		[DataMember(Name = "ContactTemplateName", EmitDefaultValue = false)]
		public string ContactTemplateName { get; set; }

		/// <summary>
		/// Gets or Sets ContactType
		/// </summary>
		[DataMember(Name = "ContactType", EmitDefaultValue = false)]
		public string ContactType { get; set; }

		/// <summary>
		/// Gets or Sets DeliveryFormatName
		/// </summary>
		[DataMember(Name = "DeliveryFormatName", EmitDefaultValue = false)]
		public string DeliveryFormatName { get; set; }

		/// <summary>
		/// Gets or Sets Description
		/// </summary>
		[DataMember(Name = "Description", EmitDefaultValue = false)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or Sets EscalationTimeout
		/// </summary>
		[DataMember(Name = "EscalationTimeout", EmitDefaultValue = false)]
		public string EscalationTimeout { get; set; }

		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets MaximumRetries
		/// </summary>
		[DataMember(Name = "MaximumRetries", EmitDefaultValue = false)]
		public int? MaximumRetries { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets NotifyOption
		/// </summary>
		[DataMember(Name = "NotifyOption", EmitDefaultValue = false)]
		public string NotifyOption { get; set; }

		/// <summary>
		/// Gets or Sets Path
		/// </summary>
		[DataMember(Name = "Path", EmitDefaultValue = false)]
		public string Path { get; set; }

		/// <summary>
		/// Gets or Sets PlugInName
		/// </summary>
		[DataMember(Name = "PlugInName", EmitDefaultValue = false)]
		public string PlugInName { get; set; }

		/// <summary>
		/// Gets or Sets RetryInterval
		/// </summary>
		[DataMember(Name = "RetryInterval", EmitDefaultValue = false)]
		public string RetryInterval { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

		/// <summary>
		/// Gets or Sets WebId
		/// </summary>
		[DataMember(Name = "WebId", EmitDefaultValue = false)]
		public string WebId { get; set; }

	}
}
