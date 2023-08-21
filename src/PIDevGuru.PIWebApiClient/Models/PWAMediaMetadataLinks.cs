using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// MediaMetadataLinks
	/// </summary>
	[DataContract]
	public class PWAMediaMetadataLinks
	{
		public PWAMediaMetadataLinks(string MediaData = null, string Owner = null, string Self = null)
		{
			this.MediaData = MediaData;
			this.Owner = Owner;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets MediaData
		/// </summary>
		[DataMember(Name = "MediaData", EmitDefaultValue = false)]
		public string MediaData { get; set; }

		/// <summary>
		/// Gets or Sets Owner
		/// </summary>
		[DataMember(Name = "Owner", EmitDefaultValue = false)]
		public string Owner { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

	}
}
