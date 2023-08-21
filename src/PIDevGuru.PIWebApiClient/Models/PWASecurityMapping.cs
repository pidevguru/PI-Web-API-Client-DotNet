using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// SecurityMapping
	/// </summary>
	[DataContract]
	public class PWASecurityMapping
	{
		public PWASecurityMapping(string Account = null, string Description = null, string Id = null, PWASecurityMappingLinks Links = null, string Name = null, string Path = null, string SecurityIdentityWebId = null, PWAWebException WebException = null, string WebId = null)
		{
			this.Account = Account;
			this.Description = Description;
			this.Id = Id;
			this.Links = Links;
			this.Name = Name;
			this.Path = Path;
			this.SecurityIdentityWebId = SecurityIdentityWebId;
			this.WebException = WebException;
			this.WebId = WebId;
		}
		/// <summary>
		/// Gets or Sets Account
		/// </summary>
		[DataMember(Name = "Account", EmitDefaultValue = false)]
		public string Account { get; set; }

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
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWASecurityMappingLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets Path
		/// </summary>
		[DataMember(Name = "Path", EmitDefaultValue = false)]
		public string Path { get; set; }

		/// <summary>
		/// Gets or Sets SecurityIdentityWebId
		/// </summary>
		[DataMember(Name = "SecurityIdentityWebId", EmitDefaultValue = false)]
		public string SecurityIdentityWebId { get; set; }

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
