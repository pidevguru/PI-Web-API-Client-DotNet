using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AssetServer
	/// </summary>
	[DataContract]
	public class PWAAssetServer
	{
		public PWAAssetServer(string Description = null, Dictionary<string, PWAValue> ExtendedProperties = null, string Id = null, bool? IsConnected = null, PWAAssetServerLinks Links = null, string Name = null, string Path = null, string ServerTime = null, string ServerVersion = null, PWAWebException WebException = null, string WebId = null)
		{
			this.Description = Description;
			this.ExtendedProperties = ExtendedProperties;
			this.Id = Id;
			this.IsConnected = IsConnected;
			this.Links = Links;
			this.Name = Name;
			this.Path = Path;
			this.ServerTime = ServerTime;
			this.ServerVersion = ServerVersion;
			this.WebException = WebException;
			this.WebId = WebId;
		}
		/// <summary>
		/// Gets or Sets Description
		/// </summary>
		[DataMember(Name = "Description", EmitDefaultValue = false)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or Sets ExtendedProperties
		/// </summary>
		[DataMember(Name = "ExtendedProperties", EmitDefaultValue = false)]
		public Dictionary<string, PWAValue> ExtendedProperties { get; set; }

		/// <summary>
		/// Gets or Sets Id
		/// </summary>
		[DataMember(Name = "Id", EmitDefaultValue = false)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or Sets IsConnected
		/// </summary>
		[DataMember(Name = "IsConnected", EmitDefaultValue = false)]
		public bool? IsConnected { get; set; }

		/// <summary>
		/// Gets or Sets Links
		/// </summary>
		[DataMember(Name = "Links", EmitDefaultValue = false)]
		public PWAAssetServerLinks Links { get; set; }

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
		/// Gets or Sets ServerTime
		/// </summary>
		[DataMember(Name = "ServerTime", EmitDefaultValue = false)]
		public string ServerTime { get; set; }

		/// <summary>
		/// Gets or Sets ServerVersion
		/// </summary>
		[DataMember(Name = "ServerVersion", EmitDefaultValue = false)]
		public string ServerVersion { get; set; }

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
