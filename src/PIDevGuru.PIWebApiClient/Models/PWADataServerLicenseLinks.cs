using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// DataServerLicenseLinks
	/// </summary>
	[DataContract]
	public class PWADataServerLicenseLinks
	{
		public PWADataServerLicenseLinks(string Parent = null, string Self = null)
		{
			this.Parent = Parent;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets Parent
		/// </summary>
		[DataMember(Name = "Parent", EmitDefaultValue = false)]
		public string Parent { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
