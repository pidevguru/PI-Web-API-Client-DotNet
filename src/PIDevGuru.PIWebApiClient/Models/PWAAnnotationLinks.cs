using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AnnotationLinks
	/// </summary>
	[DataContract]
	public class PWAAnnotationLinks
	{
		public PWAAnnotationLinks(string MediaData = null, string MediaMetadata = null, string Owner = null, string Self = null)
		{
			this.MediaData = MediaData;
			this.MediaMetadata = MediaMetadata;
			this.Owner = Owner;
			this.Self = Self;
		}
		/// <summary>
		/// Gets or Sets MediaData
		/// </summary>
		[DataMember(Name = "MediaData", EmitDefaultValue = false)]
		public string MediaData { get; set; }

		/// <summary>
		/// Gets or Sets MediaMetadata
		/// </summary>
		[DataMember(Name = "MediaMetadata", EmitDefaultValue = false)]
		public string MediaMetadata { get; set; }

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
