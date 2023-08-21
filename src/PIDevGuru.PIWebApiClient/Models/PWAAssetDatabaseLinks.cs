using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PIDevGuru.PIWebApiClient.Models
{
	/// <summary>
	/// AssetDatabaseLinks
	/// </summary>
	[DataContract]
	public class PWAAssetDatabaseLinks
	{
		public PWAAssetDatabaseLinks(string AnalysisCategories = null, string AnalysisTemplates = null, string AssetServer = null, string AttributeCategories = null, string ElementCategories = null, string ElementTemplates = null, string Elements = null, string EnumerationSets = null, string EventFrames = null, string Security = null, string SecurityEntries = null, string Self = null, string TableCategories = null, string Tables = null)
		{
			this.AnalysisCategories = AnalysisCategories;
			this.AnalysisTemplates = AnalysisTemplates;
			this.AssetServer = AssetServer;
			this.AttributeCategories = AttributeCategories;
			this.ElementCategories = ElementCategories;
			this.ElementTemplates = ElementTemplates;
			this.Elements = Elements;
			this.EnumerationSets = EnumerationSets;
			this.EventFrames = EventFrames;
			this.Security = Security;
			this.SecurityEntries = SecurityEntries;
			this.Self = Self;
			this.TableCategories = TableCategories;
			this.Tables = Tables;
		}
		/// <summary>
		/// Gets or Sets AnalysisCategories
		/// </summary>
		[DataMember(Name = "AnalysisCategories", EmitDefaultValue = false)]
		public string AnalysisCategories { get; set; }

		/// <summary>
		/// Gets or Sets AnalysisTemplates
		/// </summary>
		[DataMember(Name = "AnalysisTemplates", EmitDefaultValue = false)]
		public string AnalysisTemplates { get; set; }

		/// <summary>
		/// Gets or Sets AssetServer
		/// </summary>
		[DataMember(Name = "AssetServer", EmitDefaultValue = false)]
		public string AssetServer { get; set; }

		/// <summary>
		/// Gets or Sets AttributeCategories
		/// </summary>
		[DataMember(Name = "AttributeCategories", EmitDefaultValue = false)]
		public string AttributeCategories { get; set; }

		/// <summary>
		/// Gets or Sets ElementCategories
		/// </summary>
		[DataMember(Name = "ElementCategories", EmitDefaultValue = false)]
		public string ElementCategories { get; set; }

		/// <summary>
		/// Gets or Sets ElementTemplates
		/// </summary>
		[DataMember(Name = "ElementTemplates", EmitDefaultValue = false)]
		public string ElementTemplates { get; set; }

		/// <summary>
		/// Gets or Sets Elements
		/// </summary>
		[DataMember(Name = "Elements", EmitDefaultValue = false)]
		public string Elements { get; set; }

		/// <summary>
		/// Gets or Sets EnumerationSets
		/// </summary>
		[DataMember(Name = "EnumerationSets", EmitDefaultValue = false)]
		public string EnumerationSets { get; set; }

		/// <summary>
		/// Gets or Sets EventFrames
		/// </summary>
		[DataMember(Name = "EventFrames", EmitDefaultValue = false)]
		public string EventFrames { get; set; }

		/// <summary>
		/// Gets or Sets Security
		/// </summary>
		[DataMember(Name = "Security", EmitDefaultValue = false)]
		public string Security { get; set; }

		/// <summary>
		/// Gets or Sets SecurityEntries
		/// </summary>
		[DataMember(Name = "SecurityEntries", EmitDefaultValue = false)]
		public string SecurityEntries { get; set; }

		/// <summary>
		/// Gets or Sets Self
		/// </summary>
		[DataMember(Name = "Self", EmitDefaultValue = false)]
		public string Self { get; set; }

		/// <summary>
		/// Gets or Sets TableCategories
		/// </summary>
		[DataMember(Name = "TableCategories", EmitDefaultValue = false)]
		public string TableCategories { get; set; }

		/// <summary>
		/// Gets or Sets Tables
		/// </summary>
		[DataMember(Name = "Tables", EmitDefaultValue = false)]
		public string Tables { get; set; }

	}
}
