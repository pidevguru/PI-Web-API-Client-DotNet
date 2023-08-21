using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// NotificationRule
	/// </summary>
	[DataContract]
	public class PWANotificationRule
	{
		public PWANotificationRule(bool? AutoCreated = null, List<string> CategoryNames = null, string Criteria = null, string Description = null, string Id = null, string MultiTriggerEventOption = null, string Name = null, string NonrepetitionInterval = null, string Path = null, string ResendInterval = null, string Status = null, string TemplateName = null, PWAWebException WebException = null, string WebId = null)
		{
			this.AutoCreated = AutoCreated;
			this.CategoryNames = CategoryNames;
			this.Criteria = Criteria;
			this.Description = Description;
			this.Id = Id;
			this.MultiTriggerEventOption = MultiTriggerEventOption;
			this.Name = Name;
			this.NonrepetitionInterval = NonrepetitionInterval;
			this.Path = Path;
			this.ResendInterval = ResendInterval;
			this.Status = Status;
			this.TemplateName = TemplateName;
			this.WebException = WebException;
			this.WebId = WebId;
		}
		/// <summary>
		/// Gets or Sets AutoCreated
		/// </summary>
		[DataMember(Name = "AutoCreated", EmitDefaultValue = false)]
		public bool? AutoCreated { get; set; }

		/// <summary>
		/// Gets or Sets CategoryNames
		/// </summary>
		[DataMember(Name = "CategoryNames", EmitDefaultValue = false)]
		public List<string> CategoryNames { get; set; }

		/// <summary>
		/// Gets or Sets Criteria
		/// </summary>
		[DataMember(Name = "Criteria", EmitDefaultValue = false)]
		public string Criteria { get; set; }

		/// <summary>
		/// Gets or Sets Description
		/// </summary>
		[DataMember(Name = "Description", EmitDefaultValue = false)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets MultiTriggerEventOption
		/// </summary>
		[DataMember(Name = "MultiTriggerEventOption", EmitDefaultValue = false)]
		public string MultiTriggerEventOption { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets NonrepetitionInterval
		/// </summary>
		[DataMember(Name = "NonrepetitionInterval", EmitDefaultValue = false)]
		public string NonrepetitionInterval { get; set; }

		/// <summary>
		/// Gets or Sets Path
		/// </summary>
		[DataMember(Name = "Path", EmitDefaultValue = false)]
		public string Path { get; set; }

		/// <summary>
		/// Gets or Sets ResendInterval
		/// </summary>
		[DataMember(Name = "ResendInterval", EmitDefaultValue = false)]
		public string ResendInterval { get; set; }

		/// <summary>
		/// Gets or Sets Status
		/// </summary>
		[DataMember(Name = "Status", EmitDefaultValue = false)]
		public string Status { get; set; }

		/// <summary>
		/// Gets or Sets TemplateName
		/// </summary>
		[DataMember(Name = "TemplateName", EmitDefaultValue = false)]
		public string TemplateName { get; set; }

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
