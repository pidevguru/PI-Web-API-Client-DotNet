using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// SecurityRights
	/// </summary>
	[DataContract]
	public class PWASecurityRights
	{
		public PWASecurityRights(bool? CanAnnotate = null, bool? CanDelete = null, bool? CanExecute = null, bool? CanRead = null, bool? CanReadData = null, bool? CanSubscribe = null, bool? CanSubscribeOthers = null, bool? CanWrite = null, bool? CanWriteData = null, bool? HasAdmin = null, PWASecurityRightsLinks Links = null, string OwnerWebId = null, List<string> Rights = null, string SecurityItem = null, string UserIdentity = null, PWAWebException WebException = null)
		{
			this.CanAnnotate = CanAnnotate;
			this.CanDelete = CanDelete;
			this.CanExecute = CanExecute;
			this.CanRead = CanRead;
			this.CanReadData = CanReadData;
			this.CanSubscribe = CanSubscribe;
			this.CanSubscribeOthers = CanSubscribeOthers;
			this.CanWrite = CanWrite;
			this.CanWriteData = CanWriteData;
			this.HasAdmin = HasAdmin;
			this.Links = Links;
			this.OwnerWebId = OwnerWebId;
			this.Rights = Rights;
			this.SecurityItem = SecurityItem;
			this.UserIdentity = UserIdentity;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets CanAnnotate
		/// </summary>
		[DataMember(Name = "CanAnnotate", EmitDefaultValue = false)]
		public bool? CanAnnotate { get; set; }

		/// <summary>
		/// Gets or Sets CanDelete
		/// </summary>
		[DataMember(Name = "CanDelete", EmitDefaultValue = false)]
		public bool? CanDelete { get; set; }

		/// <summary>
		/// Gets or Sets CanExecute
		/// </summary>
		[DataMember(Name = "CanExecute", EmitDefaultValue = false)]
		public bool? CanExecute { get; set; }

		/// <summary>
		/// Gets or Sets CanRead
		/// </summary>
		[DataMember(Name = "CanRead", EmitDefaultValue = false)]
		public bool? CanRead { get; set; }

		/// <summary>
		/// Gets or Sets CanReadData
		/// </summary>
		[DataMember(Name = "CanReadData", EmitDefaultValue = false)]
		public bool? CanReadData { get; set; }

		/// <summary>
		/// Gets or Sets CanSubscribe
		/// </summary>
		[DataMember(Name = "CanSubscribe", EmitDefaultValue = false)]
		public bool? CanSubscribe { get; set; }

		/// <summary>
		/// Gets or Sets CanSubscribeOthers
		/// </summary>
		[DataMember(Name = "CanSubscribeOthers", EmitDefaultValue = false)]
		public bool? CanSubscribeOthers { get; set; }

		/// <summary>
		/// Gets or Sets CanWrite
		/// </summary>
		[DataMember(Name = "CanWrite", EmitDefaultValue = false)]
		public bool? CanWrite { get; set; }

		/// <summary>
		/// Gets or Sets CanWriteData
		/// </summary>
		[DataMember(Name = "CanWriteData", EmitDefaultValue = false)]
		public bool? CanWriteData { get; set; }

		/// <summary>
		/// Gets or Sets HasAdmin
		/// </summary>
		[DataMember(Name = "HasAdmin", EmitDefaultValue = false)]
		public bool? HasAdmin { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWASecurityRightsLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets OwnerWebId
		/// </summary>
		[DataMember(Name = "OwnerWebId", EmitDefaultValue = false)]
		public string OwnerWebId { get; set; }

		/// <summary>
		/// Gets or Sets Rights
		/// </summary>
		[DataMember(Name = "Rights", EmitDefaultValue = false)]
		public List<string> Rights { get; set; }

		/// <summary>
		/// Gets or Sets SecurityItem
		/// </summary>
		[DataMember(Name = "SecurityItem", EmitDefaultValue = false)]
		public string SecurityItem { get; set; }

		/// <summary>
		/// Gets or Sets UserIdentity
		/// </summary>
		[DataMember(Name = "UserIdentity", EmitDefaultValue = false)]
		public string UserIdentity { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
