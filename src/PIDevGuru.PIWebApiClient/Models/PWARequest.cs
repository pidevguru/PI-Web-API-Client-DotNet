using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// Request
	/// </summary>
	[DataContract]
	public class PWARequest
	{
		public PWARequest(string Content = null, Dictionary<string, string> Headers = null, string Method = null, List<string> Parameters = null, List<string> ParentIds = null, PWARequestTemplate RequestTemplate = null, string Resource = null)
		{
			this.Content = Content;
			this.Headers = Headers;
			this.Method = Method;
			this.Parameters = Parameters;
			this.ParentIds = ParentIds;
			this.RequestTemplate = RequestTemplate;
			this.Resource = Resource;
		}
		/// <summary>
		/// Gets or Sets Content
		/// </summary>
		[DataMember(Name = "Content", EmitDefaultValue = false)]
		public string Content { get; set; }

		/// <summary>
		/// Gets or Sets Headers
		/// </summary>
		[DataMember(Name = "Headers", EmitDefaultValue = false)]
		public Dictionary<string, string> Headers { get; set; }

		/// <summary>
		/// Gets or Sets Method
		/// </summary>
		[DataMember(Name = "Method", EmitDefaultValue = false)]
		public string Method { get; set; }

		/// <summary>
		/// Gets or Sets Parameters
		/// </summary>
		[DataMember(Name = "Parameters", EmitDefaultValue = false)]
		public List<string> Parameters { get; set; }

		/// <summary>
		/// Gets or Sets ParentIds
		/// </summary>
		[DataMember(Name = "ParentIds", EmitDefaultValue = false)]
		public List<string> ParentIds { get; set; }

		/// <summary>
		/// Gets or Sets RequestTemplate
		/// </summary>
		[DataMember(Name = "RequestTemplate", EmitDefaultValue = false)]
		public PWARequestTemplate RequestTemplate { get; set; }

		/// <summary>
		/// Gets or Sets Resource
		/// </summary>
		[DataMember(Name = "Resource", EmitDefaultValue = false)]
		public string Resource { get; set; }

	}
}
