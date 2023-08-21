using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// UserInfo
	/// </summary>
	[DataContract]
	public class PWAUserInfo
	{
		public PWAUserInfo(string IdentityType = null, string ImpersonationLevel = null, bool? IsAuthenticated = null, string Name = null, string SID = null, PWAWebException WebException = null)
		{
			this.IdentityType = IdentityType;
			this.ImpersonationLevel = ImpersonationLevel;
			this.IsAuthenticated = IsAuthenticated;
			this.Name = Name;
			this.SID = SID;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets IdentityType
		/// </summary>
		[DataMember(Name = "IdentityType", EmitDefaultValue = false)]
		public string IdentityType { get; set; }

		/// <summary>
		/// Gets or Sets ImpersonationLevel
		/// </summary>
		[DataMember(Name = "ImpersonationLevel", EmitDefaultValue = false)]
		public string ImpersonationLevel { get; set; }

		/// <summary>
		/// Gets or Sets IsAuthenticated
		/// </summary>
		[DataMember(Name = "IsAuthenticated", EmitDefaultValue = false)]
		public bool? IsAuthenticated { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets SID
		/// </summary>
		[DataMember(Name = "SID", EmitDefaultValue = false)]
		public string SID { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
