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
	public class TimeRuleControllerClient
	{
		private HttpApiClient httpApiClient;
		public TimeRuleControllerClient(HttpApiClient httpApiClient)
		{
			this.httpApiClient = httpApiClient;
		}
		/// <summary>
		/// Retrieve a Time Rule by path.
		/// </summary>
		/// <remarks>
		/// This method returns a Time Rule based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the Time Rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWATimeRule></returns>
		public async Task<HttpApiResponse<PWATimeRule>> GetByPathWithHttpAsync(string path, string selectedFields = null, string webIdType = null)
		{
			if (path == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'path'");
			}

			string serviceUrl = "/timerules";
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

			PWATimeRule response = JsonConvert.DeserializeObject<PWATimeRule>(httpContent);
			return new HttpApiResponse<PWATimeRule>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a Time Rule by path.
		/// </summary>
		/// <remarks>
		/// This method returns a Time Rule based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the Time Rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWATimeRule</returns>
		public async Task<PWATimeRule> GetByPathAsync(string path, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetByPathWithHttpAsync(path, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a Time Rule by path.
		/// </summary>
		/// <remarks>
		/// This method returns a Time Rule based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the Time Rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWATimeRule></returns>
		public HttpApiResponse<PWATimeRule> GetByPathWithHttp(string path, string selectedFields = null, string webIdType = null)
		{
			if (path == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'path'");
			}

			string serviceUrl = "/timerules";
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

			PWATimeRule response = JsonConvert.DeserializeObject<PWATimeRule>(httpContent);
			return new HttpApiResponse<PWATimeRule>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a Time Rule by path.
		/// </summary>
		/// <remarks>
		/// This method returns a Time Rule based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the Time Rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWATimeRule</returns>
		public PWATimeRule GetByPath(string path, string selectedFields = null, string webIdType = null)
		{
			return (this.GetByPathWithHttp(path, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Delete a Time Rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the Time Rule.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> DeleteWithHttpAsync(string webId)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/timerules/{webId}";
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
		/// Delete a Time Rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the Time Rule.</param>
		/// <returns>object</returns>
		public async Task<object> DeleteAsync(string webId)
		{
			return (await this.DeleteWithHttpAsync(webId)).Data;
		}

		/// <summary>
		/// Delete a Time Rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the Time Rule.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> DeleteWithHttp(string webId)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/timerules/{webId}";
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
		/// Delete a Time Rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the Time Rule.</param>
		/// <returns>object</returns>
		public object Delete(string webId)
		{
			return (this.DeleteWithHttp(webId)).Data;
		}

		/// <summary>
		/// Retrieve a Time Rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the Time Rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWATimeRule></returns>
		public async Task<HttpApiResponse<PWATimeRule>> GetWithHttpAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/timerules/{webId}";
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

			PWATimeRule response = JsonConvert.DeserializeObject<PWATimeRule>(httpContent);
			return new HttpApiResponse<PWATimeRule>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a Time Rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the Time Rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWATimeRule</returns>
		public async Task<PWATimeRule> GetAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetWithHttpAsync(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve a Time Rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the Time Rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWATimeRule></returns>
		public HttpApiResponse<PWATimeRule> GetWithHttp(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/timerules/{webId}";
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

			PWATimeRule response = JsonConvert.DeserializeObject<PWATimeRule>(httpContent);
			return new HttpApiResponse<PWATimeRule>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve a Time Rule.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the Time Rule.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWATimeRule</returns>
		public PWATimeRule Get(string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetWithHttp(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Update a Time Rule by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the Time Rule.</param>
		/// <param name="timeRule">A partial Time Rule containing the desired changes.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> UpdateWithHttpAsync(string webId, PWATimeRule timeRule)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (timeRule == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'timeRule'");
			}

			string serviceUrl = "/timerules/{webId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(timeRule);
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
		/// Update a Time Rule by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the Time Rule.</param>
		/// <param name="timeRule">A partial Time Rule containing the desired changes.</param>
		/// <returns>object</returns>
		public async Task<object> UpdateAsync(string webId, PWATimeRule timeRule)
		{
			return (await this.UpdateWithHttpAsync(webId, timeRule)).Data;
		}

		/// <summary>
		/// Update a Time Rule by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the Time Rule.</param>
		/// <param name="timeRule">A partial Time Rule containing the desired changes.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> UpdateWithHttp(string webId, PWATimeRule timeRule)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (timeRule == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'timeRule'");
			}

			string serviceUrl = "/timerules/{webId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(timeRule);
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
		/// Update a Time Rule by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the Time Rule.</param>
		/// <param name="timeRule">A partial Time Rule containing the desired changes.</param>
		/// <returns>object</returns>
		public object Update(string webId, PWATimeRule timeRule)
		{
			return (this.UpdateWithHttp(webId, timeRule)).Data;
		}

	}
}
