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
	public class NotificationRuleControllerClient
	{
		private HttpApiClient httpApiClient;
		public NotificationRuleControllerClient(HttpApiClient httpApiClient)
		{
			this.httpApiClient = httpApiClient;
		}
		/// <summary>
		/// Retrieve a notification rule by path.
		/// </summary>
		/// <remarks>
		/// This method returns a Notification Rule based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the notification rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWANotificationRule></returns>
		public async Task<HttpApiResponse<PWANotificationRule>> GetByPathWithHttpAsync(string path, string selectedFields = null, string webIdType = null)
		{
			if (path == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'path'");
			}

			string serviceUrl = "/notificationrules";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("path", path);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWANotificationRule response = JsonConvert.DeserializeObject<PWANotificationRule>(httpContent);
			return new HttpApiResponse<PWANotificationRule>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a notification rule by path.
		/// </summary>
		/// <remarks>
		/// This method returns a Notification Rule based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the notification rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWANotificationRule</returns>
		public async Task<PWANotificationRule> GetByPathAsync(string path, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetByPathWithHttpAsync(path, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a notification rule by path.
		/// </summary>
		/// <remarks>
		/// This method returns a Notification Rule based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the notification rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWANotificationRule></returns>
		public HttpApiResponse<PWANotificationRule> GetByPathWithHttp(string path, string selectedFields = null, string webIdType = null)
		{
			if (path == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'path'");
			}

			string serviceUrl = "/notificationrules";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("path", path);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWANotificationRule response = JsonConvert.DeserializeObject<PWANotificationRule>(httpContent);
			return new HttpApiResponse<PWANotificationRule>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a notification rule by path.
		/// </summary>
		/// <remarks>
		/// This method returns a Notification Rule based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the notification rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWANotificationRule</returns>
		public PWANotificationRule GetByPath(string path, string selectedFields = null, string webIdType = null)
		{
			return (this.GetByPathWithHttp(path, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve notification rules based on the specified conditions. Returns notification rules using the specified search query string.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="databaseWebId">The ID of the asset database to use as the root of the query.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="query">The query string is a list of filters used to perform an AFSearch for the Notification rules in the asset database. An example would be: "query=Name:=MyNotificationRule* Template:=NoteRuleTemplate".</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsNotificationRule></returns>
		public async Task<HttpApiResponse<PWAItemsNotificationRule>> GetNotificationRulesQueryWithHttpAsync(string databaseWebId = null, int? maxCount = null, string query = null, string selectedFields = null, int? startIndex = null, string webIdType = null)
		{
			string serviceUrl = "/notificationrules/search";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("databaseWebId", databaseWebId);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("query", query);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
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
		/// Retrieve notification rules based on the specified conditions. Returns notification rules using the specified search query string.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="databaseWebId">The ID of the asset database to use as the root of the query.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="query">The query string is a list of filters used to perform an AFSearch for the Notification rules in the asset database. An example would be: "query=Name:=MyNotificationRule* Template:=NoteRuleTemplate".</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsNotificationRule</returns>
		public async Task<PWAItemsNotificationRule> GetNotificationRulesQueryAsync(string databaseWebId = null, int? maxCount = null, string query = null, string selectedFields = null, int? startIndex = null, string webIdType = null)
		{
			return (await this.GetNotificationRulesQueryWithHttpAsync(databaseWebId, maxCount, query, selectedFields, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve notification rules based on the specified conditions. Returns notification rules using the specified search query string.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="databaseWebId">The ID of the asset database to use as the root of the query.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="query">The query string is a list of filters used to perform an AFSearch for the Notification rules in the asset database. An example would be: "query=Name:=MyNotificationRule* Template:=NoteRuleTemplate".</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsNotificationRule></returns>
		public HttpApiResponse<PWAItemsNotificationRule> GetNotificationRulesQueryWithHttp(string databaseWebId = null, int? maxCount = null, string query = null, string selectedFields = null, int? startIndex = null, string webIdType = null)
		{
			string serviceUrl = "/notificationrules/search";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("databaseWebId", databaseWebId);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("query", query);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
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
		/// Retrieve notification rules based on the specified conditions. Returns notification rules using the specified search query string.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="databaseWebId">The ID of the asset database to use as the root of the query.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="query">The query string is a list of filters used to perform an AFSearch for the Notification rules in the asset database. An example would be: "query=Name:=MyNotificationRule* Template:=NoteRuleTemplate".</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsNotificationRule</returns>
		public PWAItemsNotificationRule GetNotificationRulesQuery(string databaseWebId = null, int? maxCount = null, string query = null, string selectedFields = null, int? startIndex = null, string webIdType = null)
		{
			return (this.GetNotificationRulesQueryWithHttp(databaseWebId, maxCount, query, selectedFields, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Delete a notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> DeleteWithHttpAsync(string webId)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/notificationrules/{webId}";
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
		/// Delete a notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule.</param>
		/// <returns>object</returns>
		public async Task<object> DeleteAsync(string webId)
		{
			return (await this.DeleteWithHttpAsync(webId)).Data;
		}

		/// <summary>
		/// Delete a notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> DeleteWithHttp(string webId)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/notificationrules/{webId}";
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
		/// Delete a notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule.</param>
		/// <returns>object</returns>
		public object Delete(string webId)
		{
			return (this.DeleteWithHttp(webId)).Data;
		}

		/// <summary>
		/// Retrieve a notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWANotificationRule></returns>
		public async Task<HttpApiResponse<PWANotificationRule>> GetWithHttpAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/notificationrules/{webId}";
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

			PWANotificationRule response = JsonConvert.DeserializeObject<PWANotificationRule>(httpContent);
			return new HttpApiResponse<PWANotificationRule>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWANotificationRule</returns>
		public async Task<PWANotificationRule> GetAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetWithHttpAsync(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWANotificationRule></returns>
		public HttpApiResponse<PWANotificationRule> GetWithHttp(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/notificationrules/{webId}";
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

			PWANotificationRule response = JsonConvert.DeserializeObject<PWANotificationRule>(httpContent);
			return new HttpApiResponse<PWANotificationRule>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWANotificationRule</returns>
		public PWANotificationRule Get(string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetWithHttp(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Update a notification rule by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule to update.</param>
		/// <param name="notificationRule">A partial notification rule containing the desired changes.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> UpdateWithHttpAsync(string webId, PWANotificationRule notificationRule)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (notificationRule == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'notificationRule'");
			}

			string serviceUrl = "/notificationrules/{webId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(notificationRule);
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
		/// Update a notification rule by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule to update.</param>
		/// <param name="notificationRule">A partial notification rule containing the desired changes.</param>
		/// <returns>object</returns>
		public async Task<object> UpdateAsync(string webId, PWANotificationRule notificationRule)
		{
			return (await this.UpdateWithHttpAsync(webId, notificationRule)).Data;
		}

		/// <summary>
		/// Update a notification rule by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule to update.</param>
		/// <param name="notificationRule">A partial notification rule containing the desired changes.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> UpdateWithHttp(string webId, PWANotificationRule notificationRule)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (notificationRule == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'notificationRule'");
			}

			string serviceUrl = "/notificationrules/{webId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(notificationRule);
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
		/// Update a notification rule by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule to update.</param>
		/// <param name="notificationRule">A partial notification rule containing the desired changes.</param>
		/// <returns>object</returns>
		public object Update(string webId, PWANotificationRule notificationRule)
		{
			return (this.UpdateWithHttp(webId, notificationRule)).Data;
		}

		/// <summary>
		/// Retrieve notification rule subscribers.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsNotificationRuleSubscriber></returns>
		public async Task<HttpApiResponse<PWAItemsNotificationRuleSubscriber>> GetNotificationRuleSubscribersWithHttpAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/notificationrules/{webId}/notificationrulesubscribers";
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

			PWAItemsNotificationRuleSubscriber response = JsonConvert.DeserializeObject<PWAItemsNotificationRuleSubscriber>(httpContent);
			return new HttpApiResponse<PWAItemsNotificationRuleSubscriber>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve notification rule subscribers.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsNotificationRuleSubscriber</returns>
		public async Task<PWAItemsNotificationRuleSubscriber> GetNotificationRuleSubscribersAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetNotificationRuleSubscribersWithHttpAsync(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve notification rule subscribers.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsNotificationRuleSubscriber></returns>
		public HttpApiResponse<PWAItemsNotificationRuleSubscriber> GetNotificationRuleSubscribersWithHttp(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/notificationrules/{webId}/notificationrulesubscribers";
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

			PWAItemsNotificationRuleSubscriber response = JsonConvert.DeserializeObject<PWAItemsNotificationRuleSubscriber>(httpContent);
			return new HttpApiResponse<PWAItemsNotificationRuleSubscriber>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve notification rule subscribers.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the resource to use as the root of the search.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsNotificationRuleSubscriber</returns>
		public PWAItemsNotificationRuleSubscriber GetNotificationRuleSubscribers(string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetNotificationRuleSubscribersWithHttp(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Create a notification rule subscriber.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule on which to create the notification rule subscriber.</param>
		/// <param name="notificationRuleSubscriber">The new notification rule subscriber definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> CreateNotificationRuleSubscriberWithHttpAsync(string webId, PWANotificationRuleSubscriber notificationRuleSubscriber, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (notificationRuleSubscriber == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'notificationRuleSubscriber'");
			}

			string serviceUrl = "/notificationrules/{webId}/notificationrulesubscribers";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(notificationRuleSubscriber);
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
		/// Create a notification rule subscriber.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule on which to create the notification rule subscriber.</param>
		/// <param name="notificationRuleSubscriber">The new notification rule subscriber definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> CreateNotificationRuleSubscriberAsync(string webId, PWANotificationRuleSubscriber notificationRuleSubscriber, string webIdType = null)
		{
			return (await this.CreateNotificationRuleSubscriberWithHttpAsync(webId, notificationRuleSubscriber, webIdType)).Data;
		}

		/// <summary>
		/// Create a notification rule subscriber.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule on which to create the notification rule subscriber.</param>
		/// <param name="notificationRuleSubscriber">The new notification rule subscriber definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> CreateNotificationRuleSubscriberWithHttp(string webId, PWANotificationRuleSubscriber notificationRuleSubscriber, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (notificationRuleSubscriber == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'notificationRuleSubscriber'");
			}

			string serviceUrl = "/notificationrules/{webId}/notificationrulesubscribers";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(notificationRuleSubscriber);
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
		/// Create a notification rule subscriber.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule on which to create the notification rule subscriber.</param>
		/// <param name="notificationRuleSubscriber">The new notification rule subscriber definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object CreateNotificationRuleSubscriber(string webId, PWANotificationRuleSubscriber notificationRuleSubscriber, string webIdType = null)
		{
			return (this.CreateNotificationRuleSubscriberWithHttp(webId, notificationRuleSubscriber, webIdType)).Data;
		}

		/// <summary>
		/// Get the security information of the specified security item associated with the notification rule for a specified user.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule for the security to be checked.</param>
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

			string serviceUrl = "/notificationrules/{webId}/security";
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
		/// Get the security information of the specified security item associated with the notification rule for a specified user.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule for the security to be checked.</param>
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
		/// Get the security information of the specified security item associated with the notification rule for a specified user.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule for the security to be checked.</param>
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

			string serviceUrl = "/notificationrules/{webId}/security";
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
		/// Get the security information of the specified security item associated with the notification rule for a specified user.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule for the security to be checked.</param>
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
		/// Retrieve the security entries associated with the notification rule based on the specified criteria. By default, all security entries for this notification rule are returned.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule.</param>
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

			string serviceUrl = "/notificationrules/{webId}/securityentries";
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
		/// Retrieve the security entries associated with the notification rule based on the specified criteria. By default, all security entries for this notification rule are returned.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule.</param>
		/// <param name="nameFilter">The name query string used for filtering security entries. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsSecurityEntry</returns>
		public async Task<PWAItemsSecurityEntry> GetSecurityEntriesAsync(string webId, string nameFilter = null, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetSecurityEntriesWithHttpAsync(webId, nameFilter, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve the security entries associated with the notification rule based on the specified criteria. By default, all security entries for this notification rule are returned.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule.</param>
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

			string serviceUrl = "/notificationrules/{webId}/securityentries";
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
		/// Retrieve the security entries associated with the notification rule based on the specified criteria. By default, all security entries for this notification rule are returned.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule.</param>
		/// <param name="nameFilter">The name query string used for filtering security entries. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsSecurityEntry</returns>
		public PWAItemsSecurityEntry GetSecurityEntries(string webId, string nameFilter = null, string selectedFields = null, string webIdType = null)
		{
			return (this.GetSecurityEntriesWithHttp(webId, nameFilter, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Create a security entry owned by the notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule, where the security entry will be created.</param>
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

			string serviceUrl = "/notificationrules/{webId}/securityentries";
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
		/// Create a security entry owned by the notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule, where the security entry will be created.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> CreateSecurityEntryAsync(string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null, string webIdType = null)
		{
			return (await this.CreateSecurityEntryWithHttpAsync(webId, securityEntry, applyToChildren, webIdType)).Data;
		}

		/// <summary>
		/// Create a security entry owned by the notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule, where the security entry will be created.</param>
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

			string serviceUrl = "/notificationrules/{webId}/securityentries";
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
		/// Create a security entry owned by the notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the notification rule, where the security entry will be created.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object CreateSecurityEntry(string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null, string webIdType = null)
		{
			return (this.CreateSecurityEntryWithHttp(webId, securityEntry, applyToChildren, webIdType)).Data;
		}

		/// <summary>
		/// Delete a security entry owned by the notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the notification rule, where the security entry will be deleted.</param>
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

			string serviceUrl = "/notificationrules/{webId}/securityentries/{name}";
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
		/// Delete a security entry owned by the notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the notification rule, where the security entry will be deleted.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>object</returns>
		public async Task<object> DeleteSecurityEntryAsync(string name, string webId, bool? applyToChildren = null)
		{
			return (await this.DeleteSecurityEntryWithHttpAsync(name, webId, applyToChildren)).Data;
		}

		/// <summary>
		/// Delete a security entry owned by the notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the notification rule, where the security entry will be deleted.</param>
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

			string serviceUrl = "/notificationrules/{webId}/securityentries/{name}";
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
		/// Delete a security entry owned by the notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the notification rule, where the security entry will be deleted.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>object</returns>
		public object DeleteSecurityEntry(string name, string webId, bool? applyToChildren = null)
		{
			return (this.DeleteSecurityEntryWithHttp(name, webId, applyToChildren)).Data;
		}

		/// <summary>
		/// Retrieve the security entry associated with the notification rule with the specified name.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the notification rule.</param>
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

			string serviceUrl = "/notificationrules/{webId}/securityentries/{name}";
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
		/// Retrieve the security entry associated with the notification rule with the specified name.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the notification rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWASecurityEntry</returns>
		public async Task<PWASecurityEntry> GetSecurityEntryByNameAsync(string name, string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetSecurityEntryByNameWithHttpAsync(name, webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve the security entry associated with the notification rule with the specified name.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the notification rule.</param>
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

			string serviceUrl = "/notificationrules/{webId}/securityentries/{name}";
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
		/// Retrieve the security entry associated with the notification rule with the specified name.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the notification rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWASecurityEntry</returns>
		public PWASecurityEntry GetSecurityEntryByName(string name, string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetSecurityEntryByNameWithHttp(name, webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Update a security entry owned by the notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry.</param>
		/// <param name="webId">The ID of the notification rule, where the security entry will be updated.</param>
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

			string serviceUrl = "/notificationrules/{webId}/securityentries/{name}";
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
		/// Update a security entry owned by the notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry.</param>
		/// <param name="webId">The ID of the notification rule, where the security entry will be updated.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied or they will be removed.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>object</returns>
		public async Task<object> UpdateSecurityEntryAsync(string name, string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null)
		{
			return (await this.UpdateSecurityEntryWithHttpAsync(name, webId, securityEntry, applyToChildren)).Data;
		}

		/// <summary>
		/// Update a security entry owned by the notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry.</param>
		/// <param name="webId">The ID of the notification rule, where the security entry will be updated.</param>
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

			string serviceUrl = "/notificationrules/{webId}/securityentries/{name}";
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
		/// Update a security entry owned by the notification rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry.</param>
		/// <param name="webId">The ID of the notification rule, where the security entry will be updated.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied or they will be removed.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>object</returns>
		public object UpdateSecurityEntry(string name, string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null)
		{
			return (this.UpdateSecurityEntryWithHttp(name, webId, securityEntry, applyToChildren)).Data;
		}

	}
}
