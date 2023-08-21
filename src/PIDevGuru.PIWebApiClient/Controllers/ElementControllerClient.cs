using PIDevGuru.PIWebApiClient.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PIDevGuru.PIWebApiClient.Exceptions;
using PIDevGuru.PIWebApiClient.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;

namespace PIDevGuru.PIWebApiClient.Controllers
{
	public class ElementControllerClient
	{
		private HttpApiClient httpApiClient;
		public ElementControllerClient(HttpApiClient httpApiClient)
		{
			this.httpApiClient = httpApiClient;
		}
		/// <summary>
		/// Retrieve an element by path.
		/// </summary>
		/// <remarks>
		/// This method returns an element based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the element.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAElement></returns>
		public async Task<HttpApiResponse<PWAElement>> GetByPathWithHttpAsync(string path, string associations = null, string selectedFields = null, string webIdType = null)
		{
			if (path == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'path'");
			}

			string serviceUrl = "/elements";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("path", path);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAElement response = JsonConvert.DeserializeObject<PWAElement>(httpContent);
			return new HttpApiResponse<PWAElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve an element by path.
		/// </summary>
		/// <remarks>
		/// This method returns an element based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the element.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAElement</returns>
		public async Task<PWAElement> GetByPathAsync(string path, string associations = null, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetByPathWithHttpAsync(path, associations, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve an element by path.
		/// </summary>
		/// <remarks>
		/// This method returns an element based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the element.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAElement></returns>
		public HttpApiResponse<PWAElement> GetByPathWithHttp(string path, string associations = null, string selectedFields = null, string webIdType = null)
		{
			if (path == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'path'");
			}

			string serviceUrl = "/elements";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("path", path);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAElement response = JsonConvert.DeserializeObject<PWAElement>(httpContent);
			return new HttpApiResponse<PWAElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve an element by path.
		/// </summary>
		/// <remarks>
		/// This method returns an element based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the element.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAElement</returns>
		public PWAElement GetByPath(string path, string associations = null, string selectedFields = null, string webIdType = null)
		{
			return (this.GetByPathWithHttp(path, associations, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve multiple elements by web id or path.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="asParallel">Specifies if the retrieval processes should be run in parallel on the server. This may improve the response time for large amounts of requested attributes. The default is 'false'.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="includeMode">The include mode for the return list. The default is 'All'.</param>
		/// <param name="path">The path of an element. Multiple elements may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webId">The ID of an element. Multiple elements may be specified with multiple instances of the parameter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsItemElement></returns>
		public async Task<HttpApiResponse<PWAItemsItemElement>> GetMultipleWithHttpAsync(bool? asParallel = null, string associations = null, string includeMode = null, List<string> path = null, string selectedFields = null, List<string> webId = null, string webIdType = null)
		{
			string serviceUrl = "/elements/multiple";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("asParallel", asParallel);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("includeMode", includeMode);
			urlBuilder.AddQueryParameter("path", path);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsItemElement response = JsonConvert.DeserializeObject<PWAItemsItemElement>(httpContent);
			return new HttpApiResponse<PWAItemsItemElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve multiple elements by web id or path.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="asParallel">Specifies if the retrieval processes should be run in parallel on the server. This may improve the response time for large amounts of requested attributes. The default is 'false'.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="includeMode">The include mode for the return list. The default is 'All'.</param>
		/// <param name="path">The path of an element. Multiple elements may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webId">The ID of an element. Multiple elements may be specified with multiple instances of the parameter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsItemElement</returns>
		public async Task<PWAItemsItemElement> GetMultipleAsync(bool? asParallel = null, string associations = null, string includeMode = null, List<string> path = null, string selectedFields = null, List<string> webId = null, string webIdType = null)
		{
			return (await this.GetMultipleWithHttpAsync(asParallel, associations, includeMode, path, selectedFields, webId, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve multiple elements by web id or path.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="asParallel">Specifies if the retrieval processes should be run in parallel on the server. This may improve the response time for large amounts of requested attributes. The default is 'false'.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="includeMode">The include mode for the return list. The default is 'All'.</param>
		/// <param name="path">The path of an element. Multiple elements may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webId">The ID of an element. Multiple elements may be specified with multiple instances of the parameter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsItemElement></returns>
		public HttpApiResponse<PWAItemsItemElement> GetMultipleWithHttp(bool? asParallel = null, string associations = null, string includeMode = null, List<string> path = null, string selectedFields = null, List<string> webId = null, string webIdType = null)
		{
			string serviceUrl = "/elements/multiple";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("asParallel", asParallel);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("includeMode", includeMode);
			urlBuilder.AddQueryParameter("path", path);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsItemElement response = JsonConvert.DeserializeObject<PWAItemsItemElement>(httpContent);
			return new HttpApiResponse<PWAItemsItemElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve multiple elements by web id or path.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="asParallel">Specifies if the retrieval processes should be run in parallel on the server. This may improve the response time for large amounts of requested attributes. The default is 'false'.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="includeMode">The include mode for the return list. The default is 'All'.</param>
		/// <param name="path">The path of an element. Multiple elements may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webId">The ID of an element. Multiple elements may be specified with multiple instances of the parameter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsItemElement</returns>
		public PWAItemsItemElement GetMultiple(bool? asParallel = null, string associations = null, string includeMode = null, List<string> path = null, string selectedFields = null, List<string> webId = null, string webIdType = null)
		{
			return (this.GetMultipleWithHttp(asParallel, associations, includeMode, path, selectedFields, webId, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve elements based on the specified conditions. By default, returns all the elements.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="databaseWebId">The ID of the asset database to use as the root of the query.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="query">The query string is a list of filters used to perform an AFSearch for the elements in the asset database. An example would be: "query=Name:=MyElement* Template:=ElementTemplate".</param>
		/// <param name="queryDate">Optional parameter. Used to retrieve the relative the version of an object. A value of null or AFTime.MaxValue initializes the query date so the latest versions of sub-objects are retrieved. The value may be an AFTime, DateTime, PITime, String, or numeric. An integer numeric represents the number of ticks (100-nanosecond intervals) since January 1, 0001. A floating point numeric represents the number of seconds since January 1, 1970 UTC. A String is interpreted as local time, unless it contains a time zone indicator such as a trailing "Z" or "GMT".</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElement></returns>
		public async Task<HttpApiResponse<PWAItemsElement>> GetElementsQueryWithHttpAsync(string associations = null, string databaseWebId = null, int? maxCount = null, string query = null, string queryDate = null, string selectedFields = null, int? startIndex = null, string webIdType = null)
		{
			string serviceUrl = "/elements/search";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("databaseWebId", databaseWebId);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("query", query);
			urlBuilder.AddQueryParameter("queryDate", queryDate);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsElement response = JsonConvert.DeserializeObject<PWAItemsElement>(httpContent);
			return new HttpApiResponse<PWAItemsElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve elements based on the specified conditions. By default, returns all the elements.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="databaseWebId">The ID of the asset database to use as the root of the query.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="query">The query string is a list of filters used to perform an AFSearch for the elements in the asset database. An example would be: "query=Name:=MyElement* Template:=ElementTemplate".</param>
		/// <param name="queryDate">Optional parameter. Used to retrieve the relative the version of an object. A value of null or AFTime.MaxValue initializes the query date so the latest versions of sub-objects are retrieved. The value may be an AFTime, DateTime, PITime, String, or numeric. An integer numeric represents the number of ticks (100-nanosecond intervals) since January 1, 0001. A floating point numeric represents the number of seconds since January 1, 1970 UTC. A String is interpreted as local time, unless it contains a time zone indicator such as a trailing "Z" or "GMT".</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElement</returns>
		public async Task<PWAItemsElement> GetElementsQueryAsync(string associations = null, string databaseWebId = null, int? maxCount = null, string query = null, string queryDate = null, string selectedFields = null, int? startIndex = null, string webIdType = null)
		{
			return (await this.GetElementsQueryWithHttpAsync(associations, databaseWebId, maxCount, query, queryDate, selectedFields, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve elements based on the specified conditions. By default, returns all the elements.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="databaseWebId">The ID of the asset database to use as the root of the query.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="query">The query string is a list of filters used to perform an AFSearch for the elements in the asset database. An example would be: "query=Name:=MyElement* Template:=ElementTemplate".</param>
		/// <param name="queryDate">Optional parameter. Used to retrieve the relative the version of an object. A value of null or AFTime.MaxValue initializes the query date so the latest versions of sub-objects are retrieved. The value may be an AFTime, DateTime, PITime, String, or numeric. An integer numeric represents the number of ticks (100-nanosecond intervals) since January 1, 0001. A floating point numeric represents the number of seconds since January 1, 1970 UTC. A String is interpreted as local time, unless it contains a time zone indicator such as a trailing "Z" or "GMT".</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElement></returns>
		public HttpApiResponse<PWAItemsElement> GetElementsQueryWithHttp(string associations = null, string databaseWebId = null, int? maxCount = null, string query = null, string queryDate = null, string selectedFields = null, int? startIndex = null, string webIdType = null)
		{
			string serviceUrl = "/elements/search";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("databaseWebId", databaseWebId);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("query", query);
			urlBuilder.AddQueryParameter("queryDate", queryDate);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsElement response = JsonConvert.DeserializeObject<PWAItemsElement>(httpContent);
			return new HttpApiResponse<PWAItemsElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve elements based on the specified conditions. By default, returns all the elements.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="databaseWebId">The ID of the asset database to use as the root of the query.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="query">The query string is a list of filters used to perform an AFSearch for the elements in the asset database. An example would be: "query=Name:=MyElement* Template:=ElementTemplate".</param>
		/// <param name="queryDate">Optional parameter. Used to retrieve the relative the version of an object. A value of null or AFTime.MaxValue initializes the query date so the latest versions of sub-objects are retrieved. The value may be an AFTime, DateTime, PITime, String, or numeric. An integer numeric represents the number of ticks (100-nanosecond intervals) since January 1, 0001. A floating point numeric represents the number of seconds since January 1, 1970 UTC. A String is interpreted as local time, unless it contains a time zone indicator such as a trailing "Z" or "GMT".</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElement</returns>
		public PWAItemsElement GetElementsQuery(string associations = null, string databaseWebId = null, int? maxCount = null, string query = null, string queryDate = null, string selectedFields = null, int? startIndex = null, string webIdType = null)
		{
			return (this.GetElementsQueryWithHttp(associations, databaseWebId, maxCount, query, queryDate, selectedFields, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Create a link for a "Search Elements By Attribute Value" operation, whose queries are specified in the request content. The SearchRoot is specified by the Web Id of the root Element. If the SearchRoot is not specified, then the search starts at the Asset Database. ElementTemplate must be provided as the Web ID of the ElementTemplate, which are used to create the Elements. All the attributes in the queries must be defined as AttributeTemplates on the ElementTemplate. An array of attribute value queries are ANDed together to find the desired Element objects. At least one value query must be specified. There are limitations on SearchOperators.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="query">The query of search by attribute.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="noResults">If false, the response content will contain the first page of the search results. If true, the response content will be empty. The default is false.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElement></returns>
		public async Task<HttpApiResponse<PWAItemsElement>> CreateSearchByAttributeWithHttpAsync(PWASearchByAttribute query, string associations = null, bool? noResults = null, string webIdType = null)
		{
			if (query == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'query'");
			}

			string serviceUrl = "/elements/searchbyattribute";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddBody(query);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("noResults", noResults);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsElement response = JsonConvert.DeserializeObject<PWAItemsElement>(httpContent);
			return new HttpApiResponse<PWAItemsElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Create a link for a "Search Elements By Attribute Value" operation, whose queries are specified in the request content. The SearchRoot is specified by the Web Id of the root Element. If the SearchRoot is not specified, then the search starts at the Asset Database. ElementTemplate must be provided as the Web ID of the ElementTemplate, which are used to create the Elements. All the attributes in the queries must be defined as AttributeTemplates on the ElementTemplate. An array of attribute value queries are ANDed together to find the desired Element objects. At least one value query must be specified. There are limitations on SearchOperators.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="query">The query of search by attribute.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="noResults">If false, the response content will contain the first page of the search results. If true, the response content will be empty. The default is false.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElement</returns>
		public async Task<PWAItemsElement> CreateSearchByAttributeAsync(PWASearchByAttribute query, string associations = null, bool? noResults = null, string webIdType = null)
		{
			return (await this.CreateSearchByAttributeWithHttpAsync(query, associations, noResults, webIdType)).Data;
		}

		/// <summary>
		/// Create a link for a "Search Elements By Attribute Value" operation, whose queries are specified in the request content. The SearchRoot is specified by the Web Id of the root Element. If the SearchRoot is not specified, then the search starts at the Asset Database. ElementTemplate must be provided as the Web ID of the ElementTemplate, which are used to create the Elements. All the attributes in the queries must be defined as AttributeTemplates on the ElementTemplate. An array of attribute value queries are ANDed together to find the desired Element objects. At least one value query must be specified. There are limitations on SearchOperators.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="query">The query of search by attribute.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="noResults">If false, the response content will contain the first page of the search results. If true, the response content will be empty. The default is false.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElement></returns>
		public HttpApiResponse<PWAItemsElement> CreateSearchByAttributeWithHttp(PWASearchByAttribute query, string associations = null, bool? noResults = null, string webIdType = null)
		{
			if (query == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'query'");
			}

			string serviceUrl = "/elements/searchbyattribute";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddBody(query);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("noResults", noResults);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsElement response = JsonConvert.DeserializeObject<PWAItemsElement>(httpContent);
			return new HttpApiResponse<PWAItemsElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Create a link for a "Search Elements By Attribute Value" operation, whose queries are specified in the request content. The SearchRoot is specified by the Web Id of the root Element. If the SearchRoot is not specified, then the search starts at the Asset Database. ElementTemplate must be provided as the Web ID of the ElementTemplate, which are used to create the Elements. All the attributes in the queries must be defined as AttributeTemplates on the ElementTemplate. An array of attribute value queries are ANDed together to find the desired Element objects. At least one value query must be specified. There are limitations on SearchOperators.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="query">The query of search by attribute.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="noResults">If false, the response content will contain the first page of the search results. If true, the response content will be empty. The default is false.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElement</returns>
		public PWAItemsElement CreateSearchByAttribute(PWASearchByAttribute query, string associations = null, bool? noResults = null, string webIdType = null)
		{
			return (this.CreateSearchByAttributeWithHttp(query, associations, noResults, webIdType)).Data;
		}

		/// <summary>
		/// Execute a "Search Elements By Attribute Value" operation.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="searchId">The encoded search Id of the "Search Elements By Attribute Value" operation.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="categoryName">Specify that the owner of the returned attributes must have this category. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="descriptionFilter">The element description filter string used for finding objects. Only the first 440 characters of the description will be searched. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding objects. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include objects nested further than the immediate children of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElement></returns>
		public async Task<HttpApiResponse<PWAItemsElement>> ExecuteSearchByAttributeWithHttpAsync(string searchId, string associations = null, string categoryName = null, string descriptionFilter = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string webIdType = null)
		{
			if (searchId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'searchId'");
			}

			string serviceUrl = "/elements/searchbyattribute/{searchId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("searchId", searchId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("descriptionFilter", descriptionFilter);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsElement response = JsonConvert.DeserializeObject<PWAItemsElement>(httpContent);
			return new HttpApiResponse<PWAItemsElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Execute a "Search Elements By Attribute Value" operation.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="searchId">The encoded search Id of the "Search Elements By Attribute Value" operation.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="categoryName">Specify that the owner of the returned attributes must have this category. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="descriptionFilter">The element description filter string used for finding objects. Only the first 440 characters of the description will be searched. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding objects. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include objects nested further than the immediate children of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElement</returns>
		public async Task<PWAItemsElement> ExecuteSearchByAttributeAsync(string searchId, string associations = null, string categoryName = null, string descriptionFilter = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string webIdType = null)
		{
			return (await this.ExecuteSearchByAttributeWithHttpAsync(searchId, associations, categoryName, descriptionFilter, maxCount, nameFilter, searchFullHierarchy, selectedFields, sortField, sortOrder, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Execute a "Search Elements By Attribute Value" operation.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="searchId">The encoded search Id of the "Search Elements By Attribute Value" operation.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="categoryName">Specify that the owner of the returned attributes must have this category. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="descriptionFilter">The element description filter string used for finding objects. Only the first 440 characters of the description will be searched. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding objects. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include objects nested further than the immediate children of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElement></returns>
		public HttpApiResponse<PWAItemsElement> ExecuteSearchByAttributeWithHttp(string searchId, string associations = null, string categoryName = null, string descriptionFilter = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string webIdType = null)
		{
			if (searchId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'searchId'");
			}

			string serviceUrl = "/elements/searchbyattribute/{searchId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("searchId", searchId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("descriptionFilter", descriptionFilter);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsElement response = JsonConvert.DeserializeObject<PWAItemsElement>(httpContent);
			return new HttpApiResponse<PWAItemsElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Execute a "Search Elements By Attribute Value" operation.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="searchId">The encoded search Id of the "Search Elements By Attribute Value" operation.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="categoryName">Specify that the owner of the returned attributes must have this category. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="descriptionFilter">The element description filter string used for finding objects. Only the first 440 characters of the description will be searched. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding objects. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include objects nested further than the immediate children of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElement</returns>
		public PWAItemsElement ExecuteSearchByAttribute(string searchId, string associations = null, string categoryName = null, string descriptionFilter = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string webIdType = null)
		{
			return (this.ExecuteSearchByAttributeWithHttp(searchId, associations, categoryName, descriptionFilter, maxCount, nameFilter, searchFullHierarchy, selectedFields, sortField, sortOrder, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Delete an element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> DeleteWithHttpAsync(string webId)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.HttpMethod = new HttpMethod("DELETE");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Delete an element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <returns>object</returns>
		public async Task<object> DeleteAsync(string webId)
		{
			return (await this.DeleteWithHttpAsync(webId)).Data;
		}

		/// <summary>
		/// Delete an element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> DeleteWithHttp(string webId)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.HttpMethod = new HttpMethod("DELETE");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Delete an element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <returns>object</returns>
		public object Delete(string webId)
		{
			return (this.DeleteWithHttp(webId)).Data;
		}

		/// <summary>
		/// Retrieve an element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAElement></returns>
		public async Task<HttpApiResponse<PWAElement>> GetWithHttpAsync(string webId, string associations = null, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAElement response = JsonConvert.DeserializeObject<PWAElement>(httpContent);
			return new HttpApiResponse<PWAElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve an element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAElement</returns>
		public async Task<PWAElement> GetAsync(string webId, string associations = null, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetWithHttpAsync(webId, associations, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve an element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAElement></returns>
		public HttpApiResponse<PWAElement> GetWithHttp(string webId, string associations = null, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAElement response = JsonConvert.DeserializeObject<PWAElement>(httpContent);
			return new HttpApiResponse<PWAElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve an element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAElement</returns>
		public PWAElement Get(string webId, string associations = null, string selectedFields = null, string webIdType = null)
		{
			return (this.GetWithHttp(webId, associations, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Update an element by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="element">A partial element containing the desired changes.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> UpdateWithHttpAsync(string webId, PWAElement element)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (element == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'element'");
			}

			string serviceUrl = "/elements/{webId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(element);
			urlBuilder.HttpMethod = new HttpMethod("PATCH");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Update an element by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="element">A partial element containing the desired changes.</param>
		/// <returns>object</returns>
		public async Task<object> UpdateAsync(string webId, PWAElement element)
		{
			return (await this.UpdateWithHttpAsync(webId, element)).Data;
		}

		/// <summary>
		/// Update an element by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="element">A partial element containing the desired changes.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> UpdateWithHttp(string webId, PWAElement element)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (element == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'element'");
			}

			string serviceUrl = "/elements/{webId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(element);
			urlBuilder.HttpMethod = new HttpMethod("PATCH");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Update an element by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="element">A partial element containing the desired changes.</param>
		/// <returns>object</returns>
		public object Update(string webId, PWAElement element)
		{
			return (this.UpdateWithHttp(webId, element)).Data;
		}

		/// <summary>
		/// Retrieve analyses based on the specified conditions.
		/// </summary>
		/// <remarks>
		/// Users can search for the analyses based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the analyses that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element, which is the Target of the analyses.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsAnalysis></returns>
		public async Task<HttpApiResponse<PWAItemsAnalysis>> GetAnalysesWithHttpAsync(string webId, int? maxCount = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/analyses";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsAnalysis response = JsonConvert.DeserializeObject<PWAItemsAnalysis>(httpContent);
			return new HttpApiResponse<PWAItemsAnalysis>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve analyses based on the specified conditions.
		/// </summary>
		/// <remarks>
		/// Users can search for the analyses based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the analyses that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element, which is the Target of the analyses.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsAnalysis</returns>
		public async Task<PWAItemsAnalysis> GetAnalysesAsync(string webId, int? maxCount = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string webIdType = null)
		{
			return (await this.GetAnalysesWithHttpAsync(webId, maxCount, selectedFields, sortField, sortOrder, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve analyses based on the specified conditions.
		/// </summary>
		/// <remarks>
		/// Users can search for the analyses based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the analyses that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element, which is the Target of the analyses.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsAnalysis></returns>
		public HttpApiResponse<PWAItemsAnalysis> GetAnalysesWithHttp(string webId, int? maxCount = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/analyses";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsAnalysis response = JsonConvert.DeserializeObject<PWAItemsAnalysis>(httpContent);
			return new HttpApiResponse<PWAItemsAnalysis>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve analyses based on the specified conditions.
		/// </summary>
		/// <remarks>
		/// Users can search for the analyses based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the analyses that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element, which is the Target of the analyses.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsAnalysis</returns>
		public PWAItemsAnalysis GetAnalyses(string webId, int? maxCount = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string webIdType = null)
		{
			return (this.GetAnalysesWithHttp(webId, maxCount, selectedFields, sortField, sortOrder, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Create an Analysis.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the Analysis.</param>
		/// <param name="analysis">The new Analysis definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> CreateAnalysisWithHttpAsync(string webId, PWAAnalysis analysis, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (analysis == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'analysis'");
			}

			string serviceUrl = "/elements/{webId}/analyses";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(analysis);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Create an Analysis.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the Analysis.</param>
		/// <param name="analysis">The new Analysis definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> CreateAnalysisAsync(string webId, PWAAnalysis analysis, string webIdType = null)
		{
			return (await this.CreateAnalysisWithHttpAsync(webId, analysis, webIdType)).Data;
		}

		/// <summary>
		/// Create an Analysis.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the Analysis.</param>
		/// <param name="analysis">The new Analysis definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> CreateAnalysisWithHttp(string webId, PWAAnalysis analysis, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (analysis == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'analysis'");
			}

			string serviceUrl = "/elements/{webId}/analyses";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(analysis);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Create an Analysis.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the Analysis.</param>
		/// <param name="analysis">The new Analysis definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object CreateAnalysis(string webId, PWAAnalysis analysis, string webIdType = null)
		{
			return (this.CreateAnalysisWithHttp(webId, analysis, webIdType)).Data;
		}

		/// <summary>
		/// Get the attributes of the specified element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports DataReference to return attributes with data references. If this parameter is not specified, DataReference values are not returned.</param>
		/// <param name="categoryName">Specify that returned attributes must have this category. The default is no category filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="templateName">Specify that returned attributes must be members of this template. The default is no template filter.</param>
		/// <param name="trait">The name of the attribute trait. Multiple traits may be specified with multiple instances of the parameter.</param>
		/// <param name="traitCategory">The category of the attribute traits. Multiple categories may be specified with multiple instances of the parameter. If the parameter is not specified, or if its value is "all", then all attribute traits of all categories will be returned.</param>
		/// <param name="valueType">Specify that returned attributes' value type must be the given value type. The default is no value type filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsAttribute></returns>
		public async Task<HttpApiResponse<PWAItemsAttribute>> GetAttributesWithHttpAsync(string webId, string associations = null, string categoryName = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, int? startIndex = null, string templateName = null, List<string> trait = null, List<string> traitCategory = null, string valueType = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/attributes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("trait", trait);
			urlBuilder.AddQueryParameter("traitCategory", traitCategory);
			urlBuilder.AddQueryParameter("valueType", valueType);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsAttribute response = JsonConvert.DeserializeObject<PWAItemsAttribute>(httpContent);
			return new HttpApiResponse<PWAItemsAttribute>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get the attributes of the specified element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports DataReference to return attributes with data references. If this parameter is not specified, DataReference values are not returned.</param>
		/// <param name="categoryName">Specify that returned attributes must have this category. The default is no category filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="templateName">Specify that returned attributes must be members of this template. The default is no template filter.</param>
		/// <param name="trait">The name of the attribute trait. Multiple traits may be specified with multiple instances of the parameter.</param>
		/// <param name="traitCategory">The category of the attribute traits. Multiple categories may be specified with multiple instances of the parameter. If the parameter is not specified, or if its value is "all", then all attribute traits of all categories will be returned.</param>
		/// <param name="valueType">Specify that returned attributes' value type must be the given value type. The default is no value type filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsAttribute</returns>
		public async Task<PWAItemsAttribute> GetAttributesAsync(string webId, string associations = null, string categoryName = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, int? startIndex = null, string templateName = null, List<string> trait = null, List<string> traitCategory = null, string valueType = null, string webIdType = null)
		{
			return (await this.GetAttributesWithHttpAsync(webId, associations, categoryName, maxCount, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortField, sortOrder, startIndex, templateName, trait, traitCategory, valueType, webIdType)).Data;
		}

		/// <summary>
		/// Get the attributes of the specified element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports DataReference to return attributes with data references. If this parameter is not specified, DataReference values are not returned.</param>
		/// <param name="categoryName">Specify that returned attributes must have this category. The default is no category filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="templateName">Specify that returned attributes must be members of this template. The default is no template filter.</param>
		/// <param name="trait">The name of the attribute trait. Multiple traits may be specified with multiple instances of the parameter.</param>
		/// <param name="traitCategory">The category of the attribute traits. Multiple categories may be specified with multiple instances of the parameter. If the parameter is not specified, or if its value is "all", then all attribute traits of all categories will be returned.</param>
		/// <param name="valueType">Specify that returned attributes' value type must be the given value type. The default is no value type filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsAttribute></returns>
		public HttpApiResponse<PWAItemsAttribute> GetAttributesWithHttp(string webId, string associations = null, string categoryName = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, int? startIndex = null, string templateName = null, List<string> trait = null, List<string> traitCategory = null, string valueType = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/attributes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("trait", trait);
			urlBuilder.AddQueryParameter("traitCategory", traitCategory);
			urlBuilder.AddQueryParameter("valueType", valueType);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsAttribute response = JsonConvert.DeserializeObject<PWAItemsAttribute>(httpContent);
			return new HttpApiResponse<PWAItemsAttribute>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get the attributes of the specified element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports DataReference to return attributes with data references. If this parameter is not specified, DataReference values are not returned.</param>
		/// <param name="categoryName">Specify that returned attributes must have this category. The default is no category filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="templateName">Specify that returned attributes must be members of this template. The default is no template filter.</param>
		/// <param name="trait">The name of the attribute trait. Multiple traits may be specified with multiple instances of the parameter.</param>
		/// <param name="traitCategory">The category of the attribute traits. Multiple categories may be specified with multiple instances of the parameter. If the parameter is not specified, or if its value is "all", then all attribute traits of all categories will be returned.</param>
		/// <param name="valueType">Specify that returned attributes' value type must be the given value type. The default is no value type filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsAttribute</returns>
		public PWAItemsAttribute GetAttributes(string webId, string associations = null, string categoryName = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, int? startIndex = null, string templateName = null, List<string> trait = null, List<string> traitCategory = null, string valueType = null, string webIdType = null)
		{
			return (this.GetAttributesWithHttp(webId, associations, categoryName, maxCount, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortField, sortOrder, startIndex, templateName, trait, traitCategory, valueType, webIdType)).Data;
		}

		/// <summary>
		/// Create a new attribute of the specified element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the attribute.</param>
		/// <param name="attribute">The definition of the new attribute.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> CreateAttributeWithHttpAsync(string webId, PWAAttribute attribute, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (attribute == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'attribute'");
			}

			string serviceUrl = "/elements/{webId}/attributes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(attribute);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Create a new attribute of the specified element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the attribute.</param>
		/// <param name="attribute">The definition of the new attribute.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> CreateAttributeAsync(string webId, PWAAttribute attribute, string webIdType = null)
		{
			return (await this.CreateAttributeWithHttpAsync(webId, attribute, webIdType)).Data;
		}

		/// <summary>
		/// Create a new attribute of the specified element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the attribute.</param>
		/// <param name="attribute">The definition of the new attribute.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> CreateAttributeWithHttp(string webId, PWAAttribute attribute, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (attribute == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'attribute'");
			}

			string serviceUrl = "/elements/{webId}/attributes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(attribute);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Create a new attribute of the specified element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the attribute.</param>
		/// <param name="attribute">The definition of the new attribute.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object CreateAttribute(string webId, PWAAttribute attribute, string webIdType = null)
		{
			return (this.CreateAttributeWithHttp(webId, attribute, webIdType)).Data;
		}

		/// <summary>
		/// Get an element's categories.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElementCategory></returns>
		public async Task<HttpApiResponse<PWAItemsElementCategory>> GetCategoriesWithHttpAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/categories";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsElementCategory response = JsonConvert.DeserializeObject<PWAItemsElementCategory>(httpContent);
			return new HttpApiResponse<PWAItemsElementCategory>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get an element's categories.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElementCategory</returns>
		public async Task<PWAItemsElementCategory> GetCategoriesAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetCategoriesWithHttpAsync(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Get an element's categories.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElementCategory></returns>
		public HttpApiResponse<PWAItemsElementCategory> GetCategoriesWithHttp(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/categories";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsElementCategory response = JsonConvert.DeserializeObject<PWAItemsElementCategory>(httpContent);
			return new HttpApiResponse<PWAItemsElementCategory>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get an element's categories.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElementCategory</returns>
		public PWAItemsElementCategory GetCategories(string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetCategoriesWithHttp(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Executes the create configuration function of the data references found within the attributes of the element, and optionally, its children.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="includeChildElements">If true, includes the child elements of the specified element.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> CreateConfigWithHttpAsync(string webId, bool? includeChildElements = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/config";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("includeChildElements", includeChildElements);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Executes the create configuration function of the data references found within the attributes of the element, and optionally, its children.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="includeChildElements">If true, includes the child elements of the specified element.</param>
		/// <returns>object</returns>
		public async Task<object> CreateConfigAsync(string webId, bool? includeChildElements = null)
		{
			return (await this.CreateConfigWithHttpAsync(webId, includeChildElements)).Data;
		}

		/// <summary>
		/// Executes the create configuration function of the data references found within the attributes of the element, and optionally, its children.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="includeChildElements">If true, includes the child elements of the specified element.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> CreateConfigWithHttp(string webId, bool? includeChildElements = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/config";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("includeChildElements", includeChildElements);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Executes the create configuration function of the data references found within the attributes of the element, and optionally, its children.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="includeChildElements">If true, includes the child elements of the specified element.</param>
		/// <returns>object</returns>
		public object CreateConfig(string webId, bool? includeChildElements = null)
		{
			return (this.CreateConfigWithHttp(webId, includeChildElements)).Data;
		}

		/// <summary>
		/// Retrieves a list of element attributes matching the specified filters from the specified element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element to use as the root of the search.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports DataReference to return attributes with data references. If this parameter is not specified, DataReference values are not returned.</param>
		/// <param name="attributeCategory">Specify that returned attributes must have this category. The default is no filter.</param>
		/// <param name="attributeDescriptionFilter">The attribute description filter string used for finding objects. Only the first 440 characters of the description will be searched. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="attributeNameFilter">The attribute name filter string used for finding objects. The default is no filter.</param>
		/// <param name="attributeType">Specify that returned attributes' value type must be this value type. The default is no filter.</param>
		/// <param name="elementCategory">Specify that the owner of the returned attributes must have this category. The default is no filter.</param>
		/// <param name="elementDescriptionFilter">The element description filter string used for finding objects. Only the first 440 characters of the description will be searched. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="elementNameFilter">The element name filter string used for finding objects. The default is no filter.</param>
		/// <param name="elementTemplate">Specify that the owner of the returned attributes must have this template or a template derived from this template. The default is no filter.</param>
		/// <param name="elementType">Specify that the element of the returned attributes must have this AFElementType. The default is no filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned (the page size). The default is 1000.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include objects nested further than immediate children of the given resource. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsAttribute></returns>
		public async Task<HttpApiResponse<PWAItemsAttribute>> FindElementAttributesWithHttpAsync(string webId, string associations = null, string attributeCategory = null, string attributeDescriptionFilter = null, string attributeNameFilter = null, string attributeType = null, string elementCategory = null, string elementDescriptionFilter = null, string elementNameFilter = null, string elementTemplate = null, string elementType = null, int? maxCount = null, bool? searchFullHierarchy = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/elementattributes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("attributeCategory", attributeCategory);
			urlBuilder.AddQueryParameter("attributeDescriptionFilter", attributeDescriptionFilter);
			urlBuilder.AddQueryParameter("attributeNameFilter", attributeNameFilter);
			urlBuilder.AddQueryParameter("attributeType", attributeType);
			urlBuilder.AddQueryParameter("elementCategory", elementCategory);
			urlBuilder.AddQueryParameter("elementDescriptionFilter", elementDescriptionFilter);
			urlBuilder.AddQueryParameter("elementNameFilter", elementNameFilter);
			urlBuilder.AddQueryParameter("elementTemplate", elementTemplate);
			urlBuilder.AddQueryParameter("elementType", elementType);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsAttribute response = JsonConvert.DeserializeObject<PWAItemsAttribute>(httpContent);
			return new HttpApiResponse<PWAItemsAttribute>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves a list of element attributes matching the specified filters from the specified element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element to use as the root of the search.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports DataReference to return attributes with data references. If this parameter is not specified, DataReference values are not returned.</param>
		/// <param name="attributeCategory">Specify that returned attributes must have this category. The default is no filter.</param>
		/// <param name="attributeDescriptionFilter">The attribute description filter string used for finding objects. Only the first 440 characters of the description will be searched. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="attributeNameFilter">The attribute name filter string used for finding objects. The default is no filter.</param>
		/// <param name="attributeType">Specify that returned attributes' value type must be this value type. The default is no filter.</param>
		/// <param name="elementCategory">Specify that the owner of the returned attributes must have this category. The default is no filter.</param>
		/// <param name="elementDescriptionFilter">The element description filter string used for finding objects. Only the first 440 characters of the description will be searched. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="elementNameFilter">The element name filter string used for finding objects. The default is no filter.</param>
		/// <param name="elementTemplate">Specify that the owner of the returned attributes must have this template or a template derived from this template. The default is no filter.</param>
		/// <param name="elementType">Specify that the element of the returned attributes must have this AFElementType. The default is no filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned (the page size). The default is 1000.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include objects nested further than immediate children of the given resource. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsAttribute</returns>
		public async Task<PWAItemsAttribute> FindElementAttributesAsync(string webId, string associations = null, string attributeCategory = null, string attributeDescriptionFilter = null, string attributeNameFilter = null, string attributeType = null, string elementCategory = null, string elementDescriptionFilter = null, string elementNameFilter = null, string elementTemplate = null, string elementType = null, int? maxCount = null, bool? searchFullHierarchy = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string webIdType = null)
		{
			return (await this.FindElementAttributesWithHttpAsync(webId, associations, attributeCategory, attributeDescriptionFilter, attributeNameFilter, attributeType, elementCategory, elementDescriptionFilter, elementNameFilter, elementTemplate, elementType, maxCount, searchFullHierarchy, selectedFields, sortField, sortOrder, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Retrieves a list of element attributes matching the specified filters from the specified element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element to use as the root of the search.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports DataReference to return attributes with data references. If this parameter is not specified, DataReference values are not returned.</param>
		/// <param name="attributeCategory">Specify that returned attributes must have this category. The default is no filter.</param>
		/// <param name="attributeDescriptionFilter">The attribute description filter string used for finding objects. Only the first 440 characters of the description will be searched. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="attributeNameFilter">The attribute name filter string used for finding objects. The default is no filter.</param>
		/// <param name="attributeType">Specify that returned attributes' value type must be this value type. The default is no filter.</param>
		/// <param name="elementCategory">Specify that the owner of the returned attributes must have this category. The default is no filter.</param>
		/// <param name="elementDescriptionFilter">The element description filter string used for finding objects. Only the first 440 characters of the description will be searched. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="elementNameFilter">The element name filter string used for finding objects. The default is no filter.</param>
		/// <param name="elementTemplate">Specify that the owner of the returned attributes must have this template or a template derived from this template. The default is no filter.</param>
		/// <param name="elementType">Specify that the element of the returned attributes must have this AFElementType. The default is no filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned (the page size). The default is 1000.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include objects nested further than immediate children of the given resource. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsAttribute></returns>
		public HttpApiResponse<PWAItemsAttribute> FindElementAttributesWithHttp(string webId, string associations = null, string attributeCategory = null, string attributeDescriptionFilter = null, string attributeNameFilter = null, string attributeType = null, string elementCategory = null, string elementDescriptionFilter = null, string elementNameFilter = null, string elementTemplate = null, string elementType = null, int? maxCount = null, bool? searchFullHierarchy = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/elementattributes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("attributeCategory", attributeCategory);
			urlBuilder.AddQueryParameter("attributeDescriptionFilter", attributeDescriptionFilter);
			urlBuilder.AddQueryParameter("attributeNameFilter", attributeNameFilter);
			urlBuilder.AddQueryParameter("attributeType", attributeType);
			urlBuilder.AddQueryParameter("elementCategory", elementCategory);
			urlBuilder.AddQueryParameter("elementDescriptionFilter", elementDescriptionFilter);
			urlBuilder.AddQueryParameter("elementNameFilter", elementNameFilter);
			urlBuilder.AddQueryParameter("elementTemplate", elementTemplate);
			urlBuilder.AddQueryParameter("elementType", elementType);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsAttribute response = JsonConvert.DeserializeObject<PWAItemsAttribute>(httpContent);
			return new HttpApiResponse<PWAItemsAttribute>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves a list of element attributes matching the specified filters from the specified element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element to use as the root of the search.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports DataReference to return attributes with data references. If this parameter is not specified, DataReference values are not returned.</param>
		/// <param name="attributeCategory">Specify that returned attributes must have this category. The default is no filter.</param>
		/// <param name="attributeDescriptionFilter">The attribute description filter string used for finding objects. Only the first 440 characters of the description will be searched. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="attributeNameFilter">The attribute name filter string used for finding objects. The default is no filter.</param>
		/// <param name="attributeType">Specify that returned attributes' value type must be this value type. The default is no filter.</param>
		/// <param name="elementCategory">Specify that the owner of the returned attributes must have this category. The default is no filter.</param>
		/// <param name="elementDescriptionFilter">The element description filter string used for finding objects. Only the first 440 characters of the description will be searched. For Asset Servers older than 2.7, a 400 status code (Bad Request) will be returned if this parameter is specified. The default is no filter.</param>
		/// <param name="elementNameFilter">The element name filter string used for finding objects. The default is no filter.</param>
		/// <param name="elementTemplate">Specify that the owner of the returned attributes must have this template or a template derived from this template. The default is no filter.</param>
		/// <param name="elementType">Specify that the element of the returned attributes must have this AFElementType. The default is no filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned (the page size). The default is 1000.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include objects nested further than immediate children of the given resource. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsAttribute</returns>
		public PWAItemsAttribute FindElementAttributes(string webId, string associations = null, string attributeCategory = null, string attributeDescriptionFilter = null, string attributeNameFilter = null, string attributeType = null, string elementCategory = null, string elementDescriptionFilter = null, string elementNameFilter = null, string elementTemplate = null, string elementType = null, int? maxCount = null, bool? searchFullHierarchy = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string webIdType = null)
		{
			return (this.FindElementAttributesWithHttp(webId, associations, attributeCategory, attributeDescriptionFilter, attributeNameFilter, attributeType, elementCategory, elementDescriptionFilter, elementNameFilter, elementTemplate, elementType, maxCount, searchFullHierarchy, selectedFields, sortField, sortOrder, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve elements based on the specified conditions. By default, this method selects immediate children of the specified element.
		/// </summary>
		/// <remarks>
		/// Users can search for the elements based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the elements that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element to use as the root of the search.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="categoryName">Specify that returned elements must have this category. The default is no category filter.</param>
		/// <param name="descriptionFilter">Specify that returned elements must have this description. The default is no description filter.</param>
		/// <param name="elementType">Specify that returned elements must have this type. The default type is 'Any'.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding objects. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include objects nested further than the immediate children of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="templateName">Specify that returned elements must have this template or a template derived from this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElement></returns>
		public async Task<HttpApiResponse<PWAItemsElement>> GetElementsWithHttpAsync(string webId, string associations = null, string categoryName = null, string descriptionFilter = null, string elementType = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string templateName = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/elements";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("descriptionFilter", descriptionFilter);
			urlBuilder.AddQueryParameter("elementType", elementType);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsElement response = JsonConvert.DeserializeObject<PWAItemsElement>(httpContent);
			return new HttpApiResponse<PWAItemsElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve elements based on the specified conditions. By default, this method selects immediate children of the specified element.
		/// </summary>
		/// <remarks>
		/// Users can search for the elements based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the elements that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element to use as the root of the search.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="categoryName">Specify that returned elements must have this category. The default is no category filter.</param>
		/// <param name="descriptionFilter">Specify that returned elements must have this description. The default is no description filter.</param>
		/// <param name="elementType">Specify that returned elements must have this type. The default type is 'Any'.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding objects. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include objects nested further than the immediate children of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="templateName">Specify that returned elements must have this template or a template derived from this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElement</returns>
		public async Task<PWAItemsElement> GetElementsAsync(string webId, string associations = null, string categoryName = null, string descriptionFilter = null, string elementType = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string templateName = null, string webIdType = null)
		{
			return (await this.GetElementsWithHttpAsync(webId, associations, categoryName, descriptionFilter, elementType, maxCount, nameFilter, searchFullHierarchy, selectedFields, sortField, sortOrder, startIndex, templateName, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve elements based on the specified conditions. By default, this method selects immediate children of the specified element.
		/// </summary>
		/// <remarks>
		/// Users can search for the elements based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the elements that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element to use as the root of the search.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="categoryName">Specify that returned elements must have this category. The default is no category filter.</param>
		/// <param name="descriptionFilter">Specify that returned elements must have this description. The default is no description filter.</param>
		/// <param name="elementType">Specify that returned elements must have this type. The default type is 'Any'.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding objects. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include objects nested further than the immediate children of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="templateName">Specify that returned elements must have this template or a template derived from this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElement></returns>
		public HttpApiResponse<PWAItemsElement> GetElementsWithHttp(string webId, string associations = null, string categoryName = null, string descriptionFilter = null, string elementType = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string templateName = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/elements";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("descriptionFilter", descriptionFilter);
			urlBuilder.AddQueryParameter("elementType", elementType);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsElement response = JsonConvert.DeserializeObject<PWAItemsElement>(httpContent);
			return new HttpApiResponse<PWAItemsElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve elements based on the specified conditions. By default, this method selects immediate children of the specified element.
		/// </summary>
		/// <remarks>
		/// Users can search for the elements based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the elements that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element to use as the root of the search.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="categoryName">Specify that returned elements must have this category. The default is no category filter.</param>
		/// <param name="descriptionFilter">Specify that returned elements must have this description. The default is no description filter.</param>
		/// <param name="elementType">Specify that returned elements must have this type. The default type is 'Any'.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding objects. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include objects nested further than the immediate children of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="templateName">Specify that returned elements must have this template or a template derived from this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElement</returns>
		public PWAItemsElement GetElements(string webId, string associations = null, string categoryName = null, string descriptionFilter = null, string elementType = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string templateName = null, string webIdType = null)
		{
			return (this.GetElementsWithHttp(webId, associations, categoryName, descriptionFilter, elementType, maxCount, nameFilter, searchFullHierarchy, selectedFields, sortField, sortOrder, startIndex, templateName, webIdType)).Data;
		}

		/// <summary>
		/// Create a child element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the parent element on which to create the element.</param>
		/// <param name="element">The new element definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> CreateElementWithHttpAsync(string webId, PWAElement element, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (element == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'element'");
			}

			string serviceUrl = "/elements/{webId}/elements";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(element);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Create a child element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the parent element on which to create the element.</param>
		/// <param name="element">The new element definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> CreateElementAsync(string webId, PWAElement element, string webIdType = null)
		{
			return (await this.CreateElementWithHttpAsync(webId, element, webIdType)).Data;
		}

		/// <summary>
		/// Create a child element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the parent element on which to create the element.</param>
		/// <param name="element">The new element definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> CreateElementWithHttp(string webId, PWAElement element, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (element == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'element'");
			}

			string serviceUrl = "/elements/{webId}/elements";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(element);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Create a child element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the parent element on which to create the element.</param>
		/// <param name="element">The new element definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object CreateElement(string webId, PWAElement element, string webIdType = null)
		{
			return (this.CreateElementWithHttp(webId, element, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve event frames that reference this element based on the specified conditions. By default, returns all event frames that reference this element that have been active in the past 8 hours.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element whose related event frames are sought.</param>
		/// <param name="canBeAcknowledged">Specify the returned event frames' canBeAcknowledged property. The default is no canBeAcknowledged filter.</param>
		/// <param name="categoryName">Specify that returned event frames must have this category. The default is no category filter.</param>
		/// <param name="endTime">The ending time for the search. The endTime must be greater than or equal to the startTime. The searchMode parameter will control whether the comparison will be performed against the event frame's startTime or endTime. The default is '*' if searchMode is not one of the 'Backward*' or 'Forward*' values.</param>
		/// <param name="isAcknowledged">Specify the returned event frames' isAcknowledged property. The default no isAcknowledged filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding event frames. The default is no filter.</param>
		/// <param name="searchMode">Determines how the startTime and endTime parameters are treated when searching for event frame objects to be included in the returned collection. If this parameter is one of the 'Backward*' or 'Forward*' values, none of endTime, sortField, or sortOrder may be specified. The default is 'Overlapped'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="severity">Specify that returned event frames must have this severity. Multiple severity values may be specified with multiple instances of the parameter. The default is no severity filter.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name' if searchMode is not one of the 'Backward*' or 'Forward*' values.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending' if searchMode is not one of the 'Backward*' or 'Forward*' values.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="startTime">The starting time for the search. startTime must be less than or equal to the endTime. The searchMode parameter will control whether the comparison will be performed against the event frame's startTime or endTime. The default is '*-8h'.</param>
		/// <param name="templateName">Specify that returned event frames must have this template or a template derived from this template. The default is no template filter. Specify this parameter by name.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsEventFrame></returns>
		public async Task<HttpApiResponse<PWAItemsEventFrame>> GetEventFramesWithHttpAsync(string webId, bool? canBeAcknowledged = null, string categoryName = null, string endTime = null, bool? isAcknowledged = null, int? maxCount = null, string nameFilter = null, string searchMode = null, string selectedFields = null, List<string> severity = null, string sortField = null, string sortOrder = null, int? startIndex = null, string startTime = null, string templateName = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/eventframes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("canBeAcknowledged", canBeAcknowledged);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("isAcknowledged", isAcknowledged);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchMode", searchMode);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("severity", severity);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsEventFrame response = JsonConvert.DeserializeObject<PWAItemsEventFrame>(httpContent);
			return new HttpApiResponse<PWAItemsEventFrame>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve event frames that reference this element based on the specified conditions. By default, returns all event frames that reference this element that have been active in the past 8 hours.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element whose related event frames are sought.</param>
		/// <param name="canBeAcknowledged">Specify the returned event frames' canBeAcknowledged property. The default is no canBeAcknowledged filter.</param>
		/// <param name="categoryName">Specify that returned event frames must have this category. The default is no category filter.</param>
		/// <param name="endTime">The ending time for the search. The endTime must be greater than or equal to the startTime. The searchMode parameter will control whether the comparison will be performed against the event frame's startTime or endTime. The default is '*' if searchMode is not one of the 'Backward*' or 'Forward*' values.</param>
		/// <param name="isAcknowledged">Specify the returned event frames' isAcknowledged property. The default no isAcknowledged filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding event frames. The default is no filter.</param>
		/// <param name="searchMode">Determines how the startTime and endTime parameters are treated when searching for event frame objects to be included in the returned collection. If this parameter is one of the 'Backward*' or 'Forward*' values, none of endTime, sortField, or sortOrder may be specified. The default is 'Overlapped'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="severity">Specify that returned event frames must have this severity. Multiple severity values may be specified with multiple instances of the parameter. The default is no severity filter.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name' if searchMode is not one of the 'Backward*' or 'Forward*' values.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending' if searchMode is not one of the 'Backward*' or 'Forward*' values.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="startTime">The starting time for the search. startTime must be less than or equal to the endTime. The searchMode parameter will control whether the comparison will be performed against the event frame's startTime or endTime. The default is '*-8h'.</param>
		/// <param name="templateName">Specify that returned event frames must have this template or a template derived from this template. The default is no template filter. Specify this parameter by name.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsEventFrame</returns>
		public async Task<PWAItemsEventFrame> GetEventFramesAsync(string webId, bool? canBeAcknowledged = null, string categoryName = null, string endTime = null, bool? isAcknowledged = null, int? maxCount = null, string nameFilter = null, string searchMode = null, string selectedFields = null, List<string> severity = null, string sortField = null, string sortOrder = null, int? startIndex = null, string startTime = null, string templateName = null, string webIdType = null)
		{
			return (await this.GetEventFramesWithHttpAsync(webId, canBeAcknowledged, categoryName, endTime, isAcknowledged, maxCount, nameFilter, searchMode, selectedFields, severity, sortField, sortOrder, startIndex, startTime, templateName, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve event frames that reference this element based on the specified conditions. By default, returns all event frames that reference this element that have been active in the past 8 hours.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element whose related event frames are sought.</param>
		/// <param name="canBeAcknowledged">Specify the returned event frames' canBeAcknowledged property. The default is no canBeAcknowledged filter.</param>
		/// <param name="categoryName">Specify that returned event frames must have this category. The default is no category filter.</param>
		/// <param name="endTime">The ending time for the search. The endTime must be greater than or equal to the startTime. The searchMode parameter will control whether the comparison will be performed against the event frame's startTime or endTime. The default is '*' if searchMode is not one of the 'Backward*' or 'Forward*' values.</param>
		/// <param name="isAcknowledged">Specify the returned event frames' isAcknowledged property. The default no isAcknowledged filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding event frames. The default is no filter.</param>
		/// <param name="searchMode">Determines how the startTime and endTime parameters are treated when searching for event frame objects to be included in the returned collection. If this parameter is one of the 'Backward*' or 'Forward*' values, none of endTime, sortField, or sortOrder may be specified. The default is 'Overlapped'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="severity">Specify that returned event frames must have this severity. Multiple severity values may be specified with multiple instances of the parameter. The default is no severity filter.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name' if searchMode is not one of the 'Backward*' or 'Forward*' values.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending' if searchMode is not one of the 'Backward*' or 'Forward*' values.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="startTime">The starting time for the search. startTime must be less than or equal to the endTime. The searchMode parameter will control whether the comparison will be performed against the event frame's startTime or endTime. The default is '*-8h'.</param>
		/// <param name="templateName">Specify that returned event frames must have this template or a template derived from this template. The default is no template filter. Specify this parameter by name.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsEventFrame></returns>
		public HttpApiResponse<PWAItemsEventFrame> GetEventFramesWithHttp(string webId, bool? canBeAcknowledged = null, string categoryName = null, string endTime = null, bool? isAcknowledged = null, int? maxCount = null, string nameFilter = null, string searchMode = null, string selectedFields = null, List<string> severity = null, string sortField = null, string sortOrder = null, int? startIndex = null, string startTime = null, string templateName = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/eventframes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("canBeAcknowledged", canBeAcknowledged);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("isAcknowledged", isAcknowledged);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchMode", searchMode);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("severity", severity);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsEventFrame response = JsonConvert.DeserializeObject<PWAItemsEventFrame>(httpContent);
			return new HttpApiResponse<PWAItemsEventFrame>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve event frames that reference this element based on the specified conditions. By default, returns all event frames that reference this element that have been active in the past 8 hours.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element whose related event frames are sought.</param>
		/// <param name="canBeAcknowledged">Specify the returned event frames' canBeAcknowledged property. The default is no canBeAcknowledged filter.</param>
		/// <param name="categoryName">Specify that returned event frames must have this category. The default is no category filter.</param>
		/// <param name="endTime">The ending time for the search. The endTime must be greater than or equal to the startTime. The searchMode parameter will control whether the comparison will be performed against the event frame's startTime or endTime. The default is '*' if searchMode is not one of the 'Backward*' or 'Forward*' values.</param>
		/// <param name="isAcknowledged">Specify the returned event frames' isAcknowledged property. The default no isAcknowledged filter.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding event frames. The default is no filter.</param>
		/// <param name="searchMode">Determines how the startTime and endTime parameters are treated when searching for event frame objects to be included in the returned collection. If this parameter is one of the 'Backward*' or 'Forward*' values, none of endTime, sortField, or sortOrder may be specified. The default is 'Overlapped'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="severity">Specify that returned event frames must have this severity. Multiple severity values may be specified with multiple instances of the parameter. The default is no severity filter.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name' if searchMode is not one of the 'Backward*' or 'Forward*' values.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending' if searchMode is not one of the 'Backward*' or 'Forward*' values.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="startTime">The starting time for the search. startTime must be less than or equal to the endTime. The searchMode parameter will control whether the comparison will be performed against the event frame's startTime or endTime. The default is '*-8h'.</param>
		/// <param name="templateName">Specify that returned event frames must have this template or a template derived from this template. The default is no template filter. Specify this parameter by name.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsEventFrame</returns>
		public PWAItemsEventFrame GetEventFrames(string webId, bool? canBeAcknowledged = null, string categoryName = null, string endTime = null, bool? isAcknowledged = null, int? maxCount = null, string nameFilter = null, string searchMode = null, string selectedFields = null, List<string> severity = null, string sortField = null, string sortOrder = null, int? startIndex = null, string startTime = null, string templateName = null, string webIdType = null)
		{
			return (this.GetEventFramesWithHttp(webId, canBeAcknowledged, categoryName, endTime, isAcknowledged, maxCount, nameFilter, searchMode, selectedFields, severity, sortField, sortOrder, startIndex, startTime, templateName, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve notification rules for an element
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsNotificationRule></returns>
		public async Task<HttpApiResponse<PWAItemsNotificationRule>> GetNotificationRulesWithHttpAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/notificationrules";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsNotificationRule response = JsonConvert.DeserializeObject<PWAItemsNotificationRule>(httpContent);
			return new HttpApiResponse<PWAItemsNotificationRule>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve notification rules for an element
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsNotificationRule</returns>
		public async Task<PWAItemsNotificationRule> GetNotificationRulesAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetNotificationRulesWithHttpAsync(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve notification rules for an element
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsNotificationRule></returns>
		public HttpApiResponse<PWAItemsNotificationRule> GetNotificationRulesWithHttp(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/notificationrules";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsNotificationRule response = JsonConvert.DeserializeObject<PWAItemsNotificationRule>(httpContent);
			return new HttpApiResponse<PWAItemsNotificationRule>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve notification rules for an element
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsNotificationRule</returns>
		public PWAItemsNotificationRule GetNotificationRules(string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetNotificationRulesWithHttp(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Create a notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the notification rule.</param>
		/// <param name="notificationRule">The new notification rule.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> CreateNotificationRuleWithHttpAsync(string webId, PWANotificationRule notificationRule, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (notificationRule == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'notificationRule'");
			}

			string serviceUrl = "/elements/{webId}/notificationrules";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(notificationRule);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Create a notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the notification rule.</param>
		/// <param name="notificationRule">The new notification rule.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> CreateNotificationRuleAsync(string webId, PWANotificationRule notificationRule, string webIdType = null)
		{
			return (await this.CreateNotificationRuleWithHttpAsync(webId, notificationRule, webIdType)).Data;
		}

		/// <summary>
		/// Create a notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the notification rule.</param>
		/// <param name="notificationRule">The new notification rule.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> CreateNotificationRuleWithHttp(string webId, PWANotificationRule notificationRule, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (notificationRule == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'notificationRule'");
			}

			string serviceUrl = "/elements/{webId}/notificationrules";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(notificationRule);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Create a notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the notification rule.</param>
		/// <param name="notificationRule">The new notification rule.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object CreateNotificationRule(string webId, PWANotificationRule notificationRule, string webIdType = null)
		{
			return (this.CreateNotificationRuleWithHttp(webId, notificationRule, webIdType)).Data;
		}

		/// <summary>
		/// Get a list of the full or relative paths to this element.
		/// </summary>
		/// <remarks>
		/// This method will return paths with the primary path at the first index. If there is no primary path, then null will be at the first index. If relative path is specified but does not exist, null will be returned at the first index.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="relativePath">The full path in ShortName format to the parent object that the returned paths should be relative. For example, "\\Server1\Database2" would return all the paths to the element relative to the database. A path of "\\Server1\Database2\RootElement" would return all paths to the element relative to "RootElement". If null, then all the full paths to the element will be returned.</param>
		/// <returns>HttpApiResponse<PWAItemsstring></returns>
		public async Task<HttpApiResponse<PWAItemsstring>> GetPathsWithHttpAsync(string webId, string relativePath = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/paths";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("relativePath", relativePath);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsstring response = JsonConvert.DeserializeObject<PWAItemsstring>(httpContent);
			return new HttpApiResponse<PWAItemsstring>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get a list of the full or relative paths to this element.
		/// </summary>
		/// <remarks>
		/// This method will return paths with the primary path at the first index. If there is no primary path, then null will be at the first index. If relative path is specified but does not exist, null will be returned at the first index.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="relativePath">The full path in ShortName format to the parent object that the returned paths should be relative. For example, "\\Server1\Database2" would return all the paths to the element relative to the database. A path of "\\Server1\Database2\RootElement" would return all paths to the element relative to "RootElement". If null, then all the full paths to the element will be returned.</param>
		/// <returns>PWAItemsstring</returns>
		public async Task<PWAItemsstring> GetPathsAsync(string webId, string relativePath = null)
		{
			return (await this.GetPathsWithHttpAsync(webId, relativePath)).Data;
		}

		/// <summary>
		/// Get a list of the full or relative paths to this element.
		/// </summary>
		/// <remarks>
		/// This method will return paths with the primary path at the first index. If there is no primary path, then null will be at the first index. If relative path is specified but does not exist, null will be returned at the first index.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="relativePath">The full path in ShortName format to the parent object that the returned paths should be relative. For example, "\\Server1\Database2" would return all the paths to the element relative to the database. A path of "\\Server1\Database2\RootElement" would return all paths to the element relative to "RootElement". If null, then all the full paths to the element will be returned.</param>
		/// <returns>HttpApiResponse<PWAItemsstring></returns>
		public HttpApiResponse<PWAItemsstring> GetPathsWithHttp(string webId, string relativePath = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/paths";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("relativePath", relativePath);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsstring response = JsonConvert.DeserializeObject<PWAItemsstring>(httpContent);
			return new HttpApiResponse<PWAItemsstring>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get a list of the full or relative paths to this element.
		/// </summary>
		/// <remarks>
		/// This method will return paths with the primary path at the first index. If there is no primary path, then null will be at the first index. If relative path is specified but does not exist, null will be returned at the first index.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="relativePath">The full path in ShortName format to the parent object that the returned paths should be relative. For example, "\\Server1\Database2" would return all the paths to the element relative to the database. A path of "\\Server1\Database2\RootElement" would return all paths to the element relative to "RootElement". If null, then all the full paths to the element will be returned.</param>
		/// <returns>PWAItemsstring</returns>
		public PWAItemsstring GetPaths(string webId, string relativePath = null)
		{
			return (this.GetPathsWithHttp(webId, relativePath)).Data;
		}

		/// <summary>
		/// Remove a reference to an existing element from the child elements collection.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element which the referenced element will be removed from.</param>
		/// <param name="referencedElementWebId">The ID of the referenced element. Multiple referenced elements may be specified with multiple instances of the parameter.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> RemoveReferencedElementWithHttpAsync(string webId, List<string> referencedElementWebId)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (referencedElementWebId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'referencedElementWebId'");
			}

			string serviceUrl = "/elements/{webId}/referencedelements";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("referencedElementWebId", referencedElementWebId);
			urlBuilder.HttpMethod = new HttpMethod("DELETE");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Remove a reference to an existing element from the child elements collection.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element which the referenced element will be removed from.</param>
		/// <param name="referencedElementWebId">The ID of the referenced element. Multiple referenced elements may be specified with multiple instances of the parameter.</param>
		/// <returns>object</returns>
		public async Task<object> RemoveReferencedElementAsync(string webId, List<string> referencedElementWebId)
		{
			return (await this.RemoveReferencedElementWithHttpAsync(webId, referencedElementWebId)).Data;
		}

		/// <summary>
		/// Remove a reference to an existing element from the child elements collection.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element which the referenced element will be removed from.</param>
		/// <param name="referencedElementWebId">The ID of the referenced element. Multiple referenced elements may be specified with multiple instances of the parameter.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> RemoveReferencedElementWithHttp(string webId, List<string> referencedElementWebId)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (referencedElementWebId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'referencedElementWebId'");
			}

			string serviceUrl = "/elements/{webId}/referencedelements";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("referencedElementWebId", referencedElementWebId);
			urlBuilder.HttpMethod = new HttpMethod("DELETE");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Remove a reference to an existing element from the child elements collection.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element which the referenced element will be removed from.</param>
		/// <param name="referencedElementWebId">The ID of the referenced element. Multiple referenced elements may be specified with multiple instances of the parameter.</param>
		/// <returns>object</returns>
		public object RemoveReferencedElement(string webId, List<string> referencedElementWebId)
		{
			return (this.RemoveReferencedElementWithHttp(webId, referencedElementWebId)).Data;
		}

		/// <summary>
		/// Retrieve referenced elements based on the specified conditions. By default, this method selects all referenced elements of the current resource.
		/// </summary>
		/// <remarks>
		/// Users can search for the referenced elements based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the elements that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="categoryName">Specify that returned elements must have this category. The default is no category filter.</param>
		/// <param name="descriptionFilter">Specify that returned elements must have this description. The default is no description filter.</param>
		/// <param name="elementType">Specify that returned elements must have this type. The default type is 'Any'.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding objects. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="templateName">Specify that returned elements must have this template or a template derived from this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElement></returns>
		public async Task<HttpApiResponse<PWAItemsElement>> GetReferencedElementsWithHttpAsync(string webId, string associations = null, string categoryName = null, string descriptionFilter = null, string elementType = null, int? maxCount = null, string nameFilter = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string templateName = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/referencedelements";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("descriptionFilter", descriptionFilter);
			urlBuilder.AddQueryParameter("elementType", elementType);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsElement response = JsonConvert.DeserializeObject<PWAItemsElement>(httpContent);
			return new HttpApiResponse<PWAItemsElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve referenced elements based on the specified conditions. By default, this method selects all referenced elements of the current resource.
		/// </summary>
		/// <remarks>
		/// Users can search for the referenced elements based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the elements that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="categoryName">Specify that returned elements must have this category. The default is no category filter.</param>
		/// <param name="descriptionFilter">Specify that returned elements must have this description. The default is no description filter.</param>
		/// <param name="elementType">Specify that returned elements must have this type. The default type is 'Any'.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding objects. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="templateName">Specify that returned elements must have this template or a template derived from this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElement</returns>
		public async Task<PWAItemsElement> GetReferencedElementsAsync(string webId, string associations = null, string categoryName = null, string descriptionFilter = null, string elementType = null, int? maxCount = null, string nameFilter = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string templateName = null, string webIdType = null)
		{
			return (await this.GetReferencedElementsWithHttpAsync(webId, associations, categoryName, descriptionFilter, elementType, maxCount, nameFilter, selectedFields, sortField, sortOrder, startIndex, templateName, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve referenced elements based on the specified conditions. By default, this method selects all referenced elements of the current resource.
		/// </summary>
		/// <remarks>
		/// Users can search for the referenced elements based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the elements that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="categoryName">Specify that returned elements must have this category. The default is no category filter.</param>
		/// <param name="descriptionFilter">Specify that returned elements must have this description. The default is no description filter.</param>
		/// <param name="elementType">Specify that returned elements must have this type. The default type is 'Any'.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding objects. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="templateName">Specify that returned elements must have this template or a template derived from this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElement></returns>
		public HttpApiResponse<PWAItemsElement> GetReferencedElementsWithHttp(string webId, string associations = null, string categoryName = null, string descriptionFilter = null, string elementType = null, int? maxCount = null, string nameFilter = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string templateName = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/referencedelements";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("descriptionFilter", descriptionFilter);
			urlBuilder.AddQueryParameter("elementType", elementType);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsElement response = JsonConvert.DeserializeObject<PWAItemsElement>(httpContent);
			return new HttpApiResponse<PWAItemsElement>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve referenced elements based on the specified conditions. By default, this method selects all referenced elements of the current resource.
		/// </summary>
		/// <remarks>
		/// Users can search for the referenced elements based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the elements that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Paths to return all paths to the element. If this parameter is not specified, paths are not returned.</param>
		/// <param name="categoryName">Specify that returned elements must have this category. The default is no category filter.</param>
		/// <param name="descriptionFilter">Specify that returned elements must have this description. The default is no description filter.</param>
		/// <param name="elementType">Specify that returned elements must have this type. The default type is 'Any'.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for finding objects. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. The default is 'Name'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="templateName">Specify that returned elements must have this template or a template derived from this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElement</returns>
		public PWAItemsElement GetReferencedElements(string webId, string associations = null, string categoryName = null, string descriptionFilter = null, string elementType = null, int? maxCount = null, string nameFilter = null, string selectedFields = null, string sortField = null, string sortOrder = null, int? startIndex = null, string templateName = null, string webIdType = null)
		{
			return (this.GetReferencedElementsWithHttp(webId, associations, categoryName, descriptionFilter, elementType, maxCount, nameFilter, selectedFields, sortField, sortOrder, startIndex, templateName, webIdType)).Data;
		}

		/// <summary>
		/// Add a reference to an existing element to the child elements collection.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element which the referenced element will be added to.</param>
		/// <param name="referencedElementWebId">The ID of the referenced element. Multiple referenced elements may be specified with multiple instances of the parameter.</param>
		/// <param name="referenceType">The name of the reference type between the parent and the referenced element. The default is "parent-child".</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> AddReferencedElementWithHttpAsync(string webId, List<string> referencedElementWebId, string referenceType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (referencedElementWebId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'referencedElementWebId'");
			}

			string serviceUrl = "/elements/{webId}/referencedelements";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("referencedElementWebId", referencedElementWebId);
			urlBuilder.AddQueryParameter("referenceType", referenceType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Add a reference to an existing element to the child elements collection.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element which the referenced element will be added to.</param>
		/// <param name="referencedElementWebId">The ID of the referenced element. Multiple referenced elements may be specified with multiple instances of the parameter.</param>
		/// <param name="referenceType">The name of the reference type between the parent and the referenced element. The default is "parent-child".</param>
		/// <returns>object</returns>
		public async Task<object> AddReferencedElementAsync(string webId, List<string> referencedElementWebId, string referenceType = null)
		{
			return (await this.AddReferencedElementWithHttpAsync(webId, referencedElementWebId, referenceType)).Data;
		}

		/// <summary>
		/// Add a reference to an existing element to the child elements collection.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element which the referenced element will be added to.</param>
		/// <param name="referencedElementWebId">The ID of the referenced element. Multiple referenced elements may be specified with multiple instances of the parameter.</param>
		/// <param name="referenceType">The name of the reference type between the parent and the referenced element. The default is "parent-child".</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> AddReferencedElementWithHttp(string webId, List<string> referencedElementWebId, string referenceType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (referencedElementWebId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'referencedElementWebId'");
			}

			string serviceUrl = "/elements/{webId}/referencedelements";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("referencedElementWebId", referencedElementWebId);
			urlBuilder.AddQueryParameter("referenceType", referenceType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Add a reference to an existing element to the child elements collection.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element which the referenced element will be added to.</param>
		/// <param name="referencedElementWebId">The ID of the referenced element. Multiple referenced elements may be specified with multiple instances of the parameter.</param>
		/// <param name="referenceType">The name of the reference type between the parent and the referenced element. The default is "parent-child".</param>
		/// <returns>object</returns>
		public object AddReferencedElement(string webId, List<string> referencedElementWebId, string referenceType = null)
		{
			return (this.AddReferencedElementWithHttp(webId, referencedElementWebId, referenceType)).Data;
		}

		/// <summary>
		/// Get the security information of the specified security item associated with the element for a specified user.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element for the security to be checked.</param>
		/// <param name="userIdentity">The user identity for the security information to be checked. Multiple security identities may be specified with multiple instances of the parameter. If the parameter is not specified, only the current user's security rights will be returned.</param>
		/// <param name="forceRefresh">Indicates if the security cache should be refreshed before getting security information. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsSecurityRights></returns>
		public async Task<HttpApiResponse<PWAItemsSecurityRights>> GetSecurityWithHttpAsync(string webId, List<string> userIdentity, bool? forceRefresh = null, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (userIdentity == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'userIdentity'");
			}

			string serviceUrl = "/elements/{webId}/security";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("userIdentity", userIdentity);
			urlBuilder.AddQueryParameter("forceRefresh", forceRefresh);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsSecurityRights response = JsonConvert.DeserializeObject<PWAItemsSecurityRights>(httpContent);
			return new HttpApiResponse<PWAItemsSecurityRights>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get the security information of the specified security item associated with the element for a specified user.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element for the security to be checked.</param>
		/// <param name="userIdentity">The user identity for the security information to be checked. Multiple security identities may be specified with multiple instances of the parameter. If the parameter is not specified, only the current user's security rights will be returned.</param>
		/// <param name="forceRefresh">Indicates if the security cache should be refreshed before getting security information. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsSecurityRights</returns>
		public async Task<PWAItemsSecurityRights> GetSecurityAsync(string webId, List<string> userIdentity, bool? forceRefresh = null, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetSecurityWithHttpAsync(webId, userIdentity, forceRefresh, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Get the security information of the specified security item associated with the element for a specified user.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element for the security to be checked.</param>
		/// <param name="userIdentity">The user identity for the security information to be checked. Multiple security identities may be specified with multiple instances of the parameter. If the parameter is not specified, only the current user's security rights will be returned.</param>
		/// <param name="forceRefresh">Indicates if the security cache should be refreshed before getting security information. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsSecurityRights></returns>
		public HttpApiResponse<PWAItemsSecurityRights> GetSecurityWithHttp(string webId, List<string> userIdentity, bool? forceRefresh = null, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (userIdentity == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'userIdentity'");
			}

			string serviceUrl = "/elements/{webId}/security";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("userIdentity", userIdentity);
			urlBuilder.AddQueryParameter("forceRefresh", forceRefresh);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsSecurityRights response = JsonConvert.DeserializeObject<PWAItemsSecurityRights>(httpContent);
			return new HttpApiResponse<PWAItemsSecurityRights>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get the security information of the specified security item associated with the element for a specified user.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element for the security to be checked.</param>
		/// <param name="userIdentity">The user identity for the security information to be checked. Multiple security identities may be specified with multiple instances of the parameter. If the parameter is not specified, only the current user's security rights will be returned.</param>
		/// <param name="forceRefresh">Indicates if the security cache should be refreshed before getting security information. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsSecurityRights</returns>
		public PWAItemsSecurityRights GetSecurity(string webId, List<string> userIdentity, bool? forceRefresh = null, string selectedFields = null, string webIdType = null)
		{
			return (this.GetSecurityWithHttp(webId, userIdentity, forceRefresh, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve the security entries associated with the element based on the specified criteria. By default, all security entries for this element are returned.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="nameFilter">The name query string used for filtering security entries. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsSecurityEntry></returns>
		public async Task<HttpApiResponse<PWAItemsSecurityEntry>> GetSecurityEntriesWithHttpAsync(string webId, string nameFilter = null, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/securityentries";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsSecurityEntry response = JsonConvert.DeserializeObject<PWAItemsSecurityEntry>(httpContent);
			return new HttpApiResponse<PWAItemsSecurityEntry>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve the security entries associated with the element based on the specified criteria. By default, all security entries for this element are returned.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="nameFilter">The name query string used for filtering security entries. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsSecurityEntry</returns>
		public async Task<PWAItemsSecurityEntry> GetSecurityEntriesAsync(string webId, string nameFilter = null, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetSecurityEntriesWithHttpAsync(webId, nameFilter, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve the security entries associated with the element based on the specified criteria. By default, all security entries for this element are returned.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="nameFilter">The name query string used for filtering security entries. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsSecurityEntry></returns>
		public HttpApiResponse<PWAItemsSecurityEntry> GetSecurityEntriesWithHttp(string webId, string nameFilter = null, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/securityentries";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsSecurityEntry response = JsonConvert.DeserializeObject<PWAItemsSecurityEntry>(httpContent);
			return new HttpApiResponse<PWAItemsSecurityEntry>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve the security entries associated with the element based on the specified criteria. By default, all security entries for this element are returned.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="nameFilter">The name query string used for filtering security entries. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsSecurityEntry</returns>
		public PWAItemsSecurityEntry GetSecurityEntries(string webId, string nameFilter = null, string selectedFields = null, string webIdType = null)
		{
			return (this.GetSecurityEntriesWithHttp(webId, nameFilter, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Create a security entry owned by the element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element where the security entry will be created.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> CreateSecurityEntryWithHttpAsync(string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (securityEntry == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'securityEntry'");
			}

			string serviceUrl = "/elements/{webId}/securityentries";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(securityEntry);
			urlBuilder.AddQueryParameter("applyToChildren", applyToChildren);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Create a security entry owned by the element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element where the security entry will be created.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> CreateSecurityEntryAsync(string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null, string webIdType = null)
		{
			return (await this.CreateSecurityEntryWithHttpAsync(webId, securityEntry, applyToChildren, webIdType)).Data;
		}

		/// <summary>
		/// Create a security entry owned by the element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element where the security entry will be created.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> CreateSecurityEntryWithHttp(string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (securityEntry == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'securityEntry'");
			}

			string serviceUrl = "/elements/{webId}/securityentries";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(securityEntry);
			urlBuilder.AddQueryParameter("applyToChildren", applyToChildren);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Create a security entry owned by the element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element where the security entry will be created.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object CreateSecurityEntry(string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null, string webIdType = null)
		{
			return (this.CreateSecurityEntryWithHttp(webId, securityEntry, applyToChildren, webIdType)).Data;
		}

		/// <summary>
		/// Delete a security entry owned by the element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element where the security entry will be deleted.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> DeleteSecurityEntryWithHttpAsync(string name, string webId, bool? applyToChildren = null)
		{
			if (name == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'name'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/securityentries/{name}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("name", name);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("applyToChildren", applyToChildren);
			urlBuilder.HttpMethod = new HttpMethod("DELETE");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Delete a security entry owned by the element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element where the security entry will be deleted.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>object</returns>
		public async Task<object> DeleteSecurityEntryAsync(string name, string webId, bool? applyToChildren = null)
		{
			return (await this.DeleteSecurityEntryWithHttpAsync(name, webId, applyToChildren)).Data;
		}

		/// <summary>
		/// Delete a security entry owned by the element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element where the security entry will be deleted.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> DeleteSecurityEntryWithHttp(string name, string webId, bool? applyToChildren = null)
		{
			if (name == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'name'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/securityentries/{name}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("name", name);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("applyToChildren", applyToChildren);
			urlBuilder.HttpMethod = new HttpMethod("DELETE");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Delete a security entry owned by the element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element where the security entry will be deleted.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>object</returns>
		public object DeleteSecurityEntry(string name, string webId, bool? applyToChildren = null)
		{
			return (this.DeleteSecurityEntryWithHttp(name, webId, applyToChildren)).Data;
		}

		/// <summary>
		/// Retrieve the security entry associated with the element with the specified name.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWASecurityEntry></returns>
		public async Task<HttpApiResponse<PWASecurityEntry>> GetSecurityEntryByNameWithHttpAsync(string name, string webId, string selectedFields = null, string webIdType = null)
		{
			if (name == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'name'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/securityentries/{name}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("name", name);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWASecurityEntry response = JsonConvert.DeserializeObject<PWASecurityEntry>(httpContent);
			return new HttpApiResponse<PWASecurityEntry>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve the security entry associated with the element with the specified name.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWASecurityEntry</returns>
		public async Task<PWASecurityEntry> GetSecurityEntryByNameAsync(string name, string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetSecurityEntryByNameWithHttpAsync(name, webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve the security entry associated with the element with the specified name.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWASecurityEntry></returns>
		public HttpApiResponse<PWASecurityEntry> GetSecurityEntryByNameWithHttp(string name, string webId, string selectedFields = null, string webIdType = null)
		{
			if (name == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'name'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elements/{webId}/securityentries/{name}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("name", name);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWASecurityEntry response = JsonConvert.DeserializeObject<PWASecurityEntry>(httpContent);
			return new HttpApiResponse<PWASecurityEntry>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve the security entry associated with the element with the specified name.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWASecurityEntry</returns>
		public PWASecurityEntry GetSecurityEntryByName(string name, string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetSecurityEntryByNameWithHttp(name, webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Update a security entry owned by the element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry.</param>
		/// <param name="webId">The ID of the element where the security entry will be updated.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied or they will be removed.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> UpdateSecurityEntryWithHttpAsync(string name, string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null)
		{
			if (name == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'name'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (securityEntry == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'securityEntry'");
			}

			string serviceUrl = "/elements/{webId}/securityentries/{name}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("name", name);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(securityEntry);
			urlBuilder.AddQueryParameter("applyToChildren", applyToChildren);
			urlBuilder.HttpMethod = new HttpMethod("PUT");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Update a security entry owned by the element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry.</param>
		/// <param name="webId">The ID of the element where the security entry will be updated.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied or they will be removed.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>object</returns>
		public async Task<object> UpdateSecurityEntryAsync(string name, string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null)
		{
			return (await this.UpdateSecurityEntryWithHttpAsync(name, webId, securityEntry, applyToChildren)).Data;
		}

		/// <summary>
		/// Update a security entry owned by the element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry.</param>
		/// <param name="webId">The ID of the element where the security entry will be updated.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied or they will be removed.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> UpdateSecurityEntryWithHttp(string name, string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null)
		{
			if (name == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'name'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (securityEntry == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'securityEntry'");
			}

			string serviceUrl = "/elements/{webId}/securityentries/{name}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("name", name);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(securityEntry);
			urlBuilder.AddQueryParameter("applyToChildren", applyToChildren);
			urlBuilder.HttpMethod = new HttpMethod("PUT");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Update a security entry owned by the element.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry.</param>
		/// <param name="webId">The ID of the element where the security entry will be updated.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied or they will be removed.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>object</returns>
		public object UpdateSecurityEntry(string name, string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null)
		{
			return (this.UpdateSecurityEntryWithHttp(name, webId, securityEntry, applyToChildren)).Data;
		}

	}
}
