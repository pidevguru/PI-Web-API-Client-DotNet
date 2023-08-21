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
	public class DataServerControllerClient
	{
		private HttpApiClient httpApiClient;
		public DataServerControllerClient(HttpApiClient httpApiClient)
		{
			this.httpApiClient = httpApiClient;
		}
		/// <summary>
		/// Retrieve a list of Data Servers known to this service.
		/// </summary>
		/// <remarks>
		/// This method returns a list of all available known Data Servers that the user can connect to. Even though a server may be returned in the list, the user may not have permission to access it.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsDataServer></returns>
		public async Task<HttpApiResponse<PWAItemsDataServer>> ListWithHttpAsync(string selectedFields = null, string webIdType = null)
		{
			string serviceUrl = "/dataservers";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsDataServer response = JsonConvert.DeserializeObject<PWAItemsDataServer>(httpContent);
			return new HttpApiResponse<PWAItemsDataServer>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a list of Data Servers known to this service.
		/// </summary>
		/// <remarks>
		/// This method returns a list of all available known Data Servers that the user can connect to. Even though a server may be returned in the list, the user may not have permission to access it.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsDataServer</returns>
		public async Task<PWAItemsDataServer> ListAsync(string selectedFields = null, string webIdType = null)
		{
			return (await this.ListWithHttpAsync(selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a list of Data Servers known to this service.
		/// </summary>
		/// <remarks>
		/// This method returns a list of all available known Data Servers that the user can connect to. Even though a server may be returned in the list, the user may not have permission to access it.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsDataServer></returns>
		public HttpApiResponse<PWAItemsDataServer> ListWithHttp(string selectedFields = null, string webIdType = null)
		{
			string serviceUrl = "/dataservers";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsDataServer response = JsonConvert.DeserializeObject<PWAItemsDataServer>(httpContent);
			return new HttpApiResponse<PWAItemsDataServer>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a list of Data Servers known to this service.
		/// </summary>
		/// <remarks>
		/// This method returns a list of all available known Data Servers that the user can connect to. Even though a server may be returned in the list, the user may not have permission to access it.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsDataServer</returns>
		public PWAItemsDataServer List(string selectedFields = null, string webIdType = null)
		{
			return (this.ListWithHttp(selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a Data Server by name.
		/// </summary>
		/// <remarks>
		/// This method returns a data server based on the name. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the server.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWADataServer></returns>
		public async Task<HttpApiResponse<PWADataServer>> GetByNameWithHttpAsync(string name, string selectedFields = null, string webIdType = null)
		{
			if (name == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'name'");
			}

			string serviceUrl = "/dataservers";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("name", name);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWADataServer response = JsonConvert.DeserializeObject<PWADataServer>(httpContent);
			return new HttpApiResponse<PWADataServer>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a Data Server by name.
		/// </summary>
		/// <remarks>
		/// This method returns a data server based on the name. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the server.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWADataServer</returns>
		public async Task<PWADataServer> GetByNameAsync(string name, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetByNameWithHttpAsync(name, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a Data Server by name.
		/// </summary>
		/// <remarks>
		/// This method returns a data server based on the name. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the server.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWADataServer></returns>
		public HttpApiResponse<PWADataServer> GetByNameWithHttp(string name, string selectedFields = null, string webIdType = null)
		{
			if (name == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'name'");
			}

			string serviceUrl = "/dataservers";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("name", name);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWADataServer response = JsonConvert.DeserializeObject<PWADataServer>(httpContent);
			return new HttpApiResponse<PWADataServer>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a Data Server by name.
		/// </summary>
		/// <remarks>
		/// This method returns a data server based on the name. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the server.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWADataServer</returns>
		public PWADataServer GetByName(string name, string selectedFields = null, string webIdType = null)
		{
			return (this.GetByNameWithHttp(name, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a Data Server by path.
		/// </summary>
		/// <remarks>
		/// This method returns a data server based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the server. Note that the path supplied to this method must be of the form '\\servername'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWADataServer></returns>
		public async Task<HttpApiResponse<PWADataServer>> GetByPathWithHttpAsync(string path, string selectedFields = null, string webIdType = null)
		{
			if (path == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'path'");
			}

			string serviceUrl = "/dataservers";
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

			PWADataServer response = JsonConvert.DeserializeObject<PWADataServer>(httpContent);
			return new HttpApiResponse<PWADataServer>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a Data Server by path.
		/// </summary>
		/// <remarks>
		/// This method returns a data server based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the server. Note that the path supplied to this method must be of the form '\\servername'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWADataServer</returns>
		public async Task<PWADataServer> GetByPathAsync(string path, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetByPathWithHttpAsync(path, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a Data Server by path.
		/// </summary>
		/// <remarks>
		/// This method returns a data server based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the server. Note that the path supplied to this method must be of the form '\\servername'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWADataServer></returns>
		public HttpApiResponse<PWADataServer> GetByPathWithHttp(string path, string selectedFields = null, string webIdType = null)
		{
			if (path == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'path'");
			}

			string serviceUrl = "/dataservers";
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

			PWADataServer response = JsonConvert.DeserializeObject<PWADataServer>(httpContent);
			return new HttpApiResponse<PWADataServer>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a Data Server by path.
		/// </summary>
		/// <remarks>
		/// This method returns a data server based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the server. Note that the path supplied to this method must be of the form '\\servername'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWADataServer</returns>
		public PWADataServer GetByPath(string path, string selectedFields = null, string webIdType = null)
		{
			return (this.GetByPathWithHttp(path, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWADataServer></returns>
		public async Task<HttpApiResponse<PWADataServer>> GetWithHttpAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/dataservers/{webId}";
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

			PWADataServer response = JsonConvert.DeserializeObject<PWADataServer>(httpContent);
			return new HttpApiResponse<PWADataServer>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWADataServer</returns>
		public async Task<PWADataServer> GetAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetWithHttpAsync(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWADataServer></returns>
		public HttpApiResponse<PWADataServer> GetWithHttp(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/dataservers/{webId}";
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

			PWADataServer response = JsonConvert.DeserializeObject<PWADataServer>(httpContent);
			return new HttpApiResponse<PWADataServer>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWADataServer</returns>
		public PWADataServer Get(string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetWithHttp(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve enumeration sets for given Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsEnumerationSet></returns>
		public async Task<HttpApiResponse<PWAItemsEnumerationSet>> GetEnumerationSetsWithHttpAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/dataservers/{webId}/enumerationsets";
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

			PWAItemsEnumerationSet response = JsonConvert.DeserializeObject<PWAItemsEnumerationSet>(httpContent);
			return new HttpApiResponse<PWAItemsEnumerationSet>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve enumeration sets for given Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsEnumerationSet</returns>
		public async Task<PWAItemsEnumerationSet> GetEnumerationSetsAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetEnumerationSetsWithHttpAsync(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve enumeration sets for given Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsEnumerationSet></returns>
		public HttpApiResponse<PWAItemsEnumerationSet> GetEnumerationSetsWithHttp(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/dataservers/{webId}/enumerationsets";
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

			PWAItemsEnumerationSet response = JsonConvert.DeserializeObject<PWAItemsEnumerationSet>(httpContent);
			return new HttpApiResponse<PWAItemsEnumerationSet>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve enumeration sets for given Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsEnumerationSet</returns>
		public PWAItemsEnumerationSet GetEnumerationSets(string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetEnumerationSetsWithHttp(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Create an enumeration set on the Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server on which to create the enumeration set.</param>
		/// <param name="enumerationSet">The new enumeration set definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> CreateEnumerationSetWithHttpAsync(string webId, PWAEnumerationSet enumerationSet, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (enumerationSet == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'enumerationSet'");
			}

			string serviceUrl = "/dataservers/{webId}/enumerationsets";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(enumerationSet);
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
		/// Create an enumeration set on the Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server on which to create the enumeration set.</param>
		/// <param name="enumerationSet">The new enumeration set definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> CreateEnumerationSetAsync(string webId, PWAEnumerationSet enumerationSet, string webIdType = null)
		{
			return (await this.CreateEnumerationSetWithHttpAsync(webId, enumerationSet, webIdType)).Data;
		}

		/// <summary>
		/// Create an enumeration set on the Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server on which to create the enumeration set.</param>
		/// <param name="enumerationSet">The new enumeration set definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> CreateEnumerationSetWithHttp(string webId, PWAEnumerationSet enumerationSet, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (enumerationSet == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'enumerationSet'");
			}

			string serviceUrl = "/dataservers/{webId}/enumerationsets";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(enumerationSet);
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
		/// Create an enumeration set on the Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server on which to create the enumeration set.</param>
		/// <param name="enumerationSet">The new enumeration set definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object CreateEnumerationSet(string webId, PWAEnumerationSet enumerationSet, string webIdType = null)
		{
			return (this.CreateEnumerationSetWithHttp(webId, enumerationSet, webIdType)).Data;
		}

		/// <summary>
		/// Retrieves the specified license for the given Data Server. The fields of the response object are string representations of the numerical values reported by the Data Server, with "Infinity" representing a license field with no limit.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="module">The case-sensitive name of the module.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWADataServerLicense></returns>
		public async Task<HttpApiResponse<PWADataServerLicense>> GetLicenseWithHttpAsync(string webId, string module, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (module == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'module'");
			}

			string serviceUrl = "/dataservers/{webId}/license";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("module", module);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWADataServerLicense response = JsonConvert.DeserializeObject<PWADataServerLicense>(httpContent);
			return new HttpApiResponse<PWADataServerLicense>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves the specified license for the given Data Server. The fields of the response object are string representations of the numerical values reported by the Data Server, with "Infinity" representing a license field with no limit.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="module">The case-sensitive name of the module.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWADataServerLicense</returns>
		public async Task<PWADataServerLicense> GetLicenseAsync(string webId, string module, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetLicenseWithHttpAsync(webId, module, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieves the specified license for the given Data Server. The fields of the response object are string representations of the numerical values reported by the Data Server, with "Infinity" representing a license field with no limit.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="module">The case-sensitive name of the module.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWADataServerLicense></returns>
		public HttpApiResponse<PWADataServerLicense> GetLicenseWithHttp(string webId, string module, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (module == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'module'");
			}

			string serviceUrl = "/dataservers/{webId}/license";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("module", module);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWADataServerLicense response = JsonConvert.DeserializeObject<PWADataServerLicense>(httpContent);
			return new HttpApiResponse<PWADataServerLicense>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves the specified license for the given Data Server. The fields of the response object are string representations of the numerical values reported by the Data Server, with "Infinity" representing a license field with no limit.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="module">The case-sensitive name of the module.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWADataServerLicense</returns>
		public PWADataServerLicense GetLicense(string webId, string module, string selectedFields = null, string webIdType = null)
		{
			return (this.GetLicenseWithHttp(webId, module, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a list of points on a specified Data Server.
		/// </summary>
		/// <remarks>
		/// Users can search for the data servers based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the data servers that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">A query string for filtering by point name. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is '0'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsPoint></returns>
		public async Task<HttpApiResponse<PWAItemsPoint>> GetPointsWithHttpAsync(string webId, int? maxCount = null, string nameFilter = null, string selectedFields = null, int? startIndex = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/dataservers/{webId}/points";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsPoint response = JsonConvert.DeserializeObject<PWAItemsPoint>(httpContent);
			return new HttpApiResponse<PWAItemsPoint>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a list of points on a specified Data Server.
		/// </summary>
		/// <remarks>
		/// Users can search for the data servers based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the data servers that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">A query string for filtering by point name. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is '0'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsPoint</returns>
		public async Task<PWAItemsPoint> GetPointsAsync(string webId, int? maxCount = null, string nameFilter = null, string selectedFields = null, int? startIndex = null, string webIdType = null)
		{
			return (await this.GetPointsWithHttpAsync(webId, maxCount, nameFilter, selectedFields, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a list of points on a specified Data Server.
		/// </summary>
		/// <remarks>
		/// Users can search for the data servers based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the data servers that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">A query string for filtering by point name. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is '0'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsPoint></returns>
		public HttpApiResponse<PWAItemsPoint> GetPointsWithHttp(string webId, int? maxCount = null, string nameFilter = null, string selectedFields = null, int? startIndex = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/dataservers/{webId}/points";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsPoint response = JsonConvert.DeserializeObject<PWAItemsPoint>(httpContent);
			return new HttpApiResponse<PWAItemsPoint>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a list of points on a specified Data Server.
		/// </summary>
		/// <remarks>
		/// Users can search for the data servers based on specific search parameters. If no parameters are specified in the search, the default values for each parameter will be used and will return the data servers that match the default search.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="maxCount">The maximum number of objects to be returned per call (page size). The default is 1000.</param>
		/// <param name="nameFilter">A query string for filtering by point name. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is '0'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsPoint</returns>
		public PWAItemsPoint GetPoints(string webId, int? maxCount = null, string nameFilter = null, string selectedFields = null, int? startIndex = null, string webIdType = null)
		{
			return (this.GetPointsWithHttp(webId, maxCount, nameFilter, selectedFields, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Create a point in the specified Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="pointDTO">The new point definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> CreatePointWithHttpAsync(string webId, PWAPoint pointDTO, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (pointDTO == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'pointDTO'");
			}

			string serviceUrl = "/dataservers/{webId}/points";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(pointDTO);
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
		/// Create a point in the specified Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="pointDTO">The new point definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> CreatePointAsync(string webId, PWAPoint pointDTO, string webIdType = null)
		{
			return (await this.CreatePointWithHttpAsync(webId, pointDTO, webIdType)).Data;
		}

		/// <summary>
		/// Create a point in the specified Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="pointDTO">The new point definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> CreatePointWithHttp(string webId, PWAPoint pointDTO, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (pointDTO == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'pointDTO'");
			}

			string serviceUrl = "/dataservers/{webId}/points";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(pointDTO);
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
		/// Create a point in the specified Data Server.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the server.</param>
		/// <param name="pointDTO">The new point definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object CreatePoint(string webId, PWAPoint pointDTO, string webIdType = null)
		{
			return (this.CreatePointWithHttp(webId, pointDTO, webIdType)).Data;
		}

	}
}
