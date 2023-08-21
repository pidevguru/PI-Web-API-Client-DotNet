using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// NotificationContactTemplate
	/// </summary>
	[DataContract]
	public class PWANotificationContactTemplate
	{
		public PWANotificationContactTemplate(bool? Available = null, string ConfigString = null, string ContactType = null, string Description = null, string EscalationTimeout = null, bool? HasChildren = null, string Id = null, PWANotificationContactTemplateLinks Links = null, int? MaximumRetries = null, int? MinimumAcknowledgements = null, string Name = null, bool? NotifyWhenInstanceEnded = null, string Path = null, string PlugInName = null, string RetryInterval = null, PWAWebException WebException = null, string WebId = null)
		{
			this.Available = Available;
			this.ConfigString = ConfigString;
			this.ContactType = ContactType;
			this.Description = Description;
			this.EscalationTimeout = EscalationTimeout;
			this.HasChildren = HasChildren;
			this.Id = Id;
			this.Links = Links;
			this.MaximumRetries = MaximumRetries;
			this.MinimumAcknowledgements = MinimumAcknowledgements;
			this.Name = Name;
			this.NotifyWhenInstanceEnded = NotifyWhenInstanceEnded;
			this.Path = Path;
			this.PlugInName = PlugInName;
			this.RetryInterval = RetryInterval;
			this.WebException = WebException;
			this.WebId = WebId;
		}
		/// <summary>
		/// Gets or Sets Available
		/// </summary>
		[DataMember(Name = "Available", EmitDefaultValue = false)]
		public bool? Available { get; set; }

		/// <summary>
		/// Gets or Sets ConfigString
		/// </summary>
		[DataMember(Name = "ConfigString", EmitDefaultValue = false)]
		public string ConfigString { get; set; }

		/// <summary>
		/// Gets or Sets ContactType
		/// </summary>
		[DataMember(Name = "ContactType", EmitDefaultValue = false)]
		public string ContactType { get; set; }

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
		/// Gets or Sets HasChildren
		/// </summary>
		[DataMember(Name = "HasChildren", EmitDefaultValue = false)]
		public bool? HasChildren { get; set; }

		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWANotificationContactTemplateLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets MaximumRetries
		/// </summary>
		[DataMember(Name = "MaximumRetries", EmitDefaultValue = false)]
		public int? MaximumRetries { get; set; }

		/// <summary>
		/// Gets or Sets MinimumAcknowledgements
		/// </summary>
		[DataMember(Name = "MinimumAcknowledgements", EmitDefaultValue = false)]
		public int? MinimumAcknowledgements { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets NotifyWhenInstanceEnded
		/// </summary>
		[DataMember(Name = "NotifyWhenInstanceEnded", EmitDefaultValue = false)]
		public bool? NotifyWhenInstanceEnded { get; set; }

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
