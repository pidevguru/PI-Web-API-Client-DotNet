using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// DataServerLicense
	/// </summary>
	[DataContract]
	public class PWADataServerLicense
	{
		public PWADataServerLicense(string AmountLeft = null, string AmountUsed = null, PWADataServerLicenseLinks Links = null, string Name = null, string TotalAmount = null, PWAWebException WebException = null)
		{
			this.AmountLeft = AmountLeft;
			this.AmountUsed = AmountUsed;
			this.Links = Links;
			this.Name = Name;
			this.TotalAmount = TotalAmount;
			this.WebException = WebException;
		}
		/// <summary>
		/// Gets or Sets AmountLeft
		/// </summary>
		[DataMember(Name = "AmountLeft", EmitDefaultValue = false)]
		public string AmountLeft { get; set; }

		/// <summary>
		/// Gets or Sets AmountUsed
		/// </summary>
		[DataMember(Name = "AmountUsed", EmitDefaultValue = false)]
		public string AmountUsed { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWADataServerLicenseLinks Links { get; set; }

		/// <summary>
		/// Gets or Sets Name
		/// </summary>
		[DataMember(Name = "Name", EmitDefaultValue = false)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or Sets TotalAmount
		/// </summary>
		[DataMember(Name = "TotalAmount", EmitDefaultValue = false)]
		public string TotalAmount { get; set; }

		/// <summary>
		/// Gets or Sets WebException
		/// </summary>
		[DataMember(Name = "WebException", EmitDefaultValue = false)]
		public PWAWebException WebException { get; set; }

	}
}
