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
	public class ElementTemplateControllerClient
	{
		private HttpApiClient httpApiClient;
		public ElementTemplateControllerClient(HttpApiClient httpApiClient)
		{
			this.httpApiClient = httpApiClient;
		}
		/// <summary>
		/// Retrieve an element template by path.
		/// </summary>
		/// <remarks>
		/// This method returns an element template based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAElementTemplate></returns>
		public async Task<HttpApiResponse<PWAElementTemplate>> GetByPathWithHttpAsync(string path, string selectedFields = null, string webIdType = null)
		{
			if (path == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'path'");
			}

			string serviceUrl = "/elementtemplates";
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

			PWAElementTemplate response = JsonConvert.DeserializeObject<PWAElementTemplate>(httpContent);
			return new HttpApiResponse<PWAElementTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve an element template by path.
		/// </summary>
		/// <remarks>
		/// This method returns an element template based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAElementTemplate</returns>
		public async Task<PWAElementTemplate> GetByPathAsync(string path, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetByPathWithHttpAsync(path, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve an element template by path.
		/// </summary>
		/// <remarks>
		/// This method returns an element template based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAElementTemplate></returns>
		public HttpApiResponse<PWAElementTemplate> GetByPathWithHttp(string path, string selectedFields = null, string webIdType = null)
		{
			if (path == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'path'");
			}

			string serviceUrl = "/elementtemplates";
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

			PWAElementTemplate response = JsonConvert.DeserializeObject<PWAElementTemplate>(httpContent);
			return new HttpApiResponse<PWAElementTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve an element template by path.
		/// </summary>
		/// <remarks>
		/// This method returns an element template based on the hierarchical path associated with it, and should be used when a path has been received from a separate part of the PI System for use in the PI Web API. Users should primarily search with the WebID when available.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="path">The path to the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAElementTemplate</returns>
		public PWAElementTemplate GetByPath(string path, string selectedFields = null, string webIdType = null)
		{
			return (this.GetByPathWithHttp(path, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Delete an element template.
		/// </summary>
		/// <remarks>
		/// Deleting an element template will delete all associated templated data from elements which were created from it.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template to update.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> DeleteWithHttpAsync(string webId)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}";
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
		/// Delete an element template.
		/// </summary>
		/// <remarks>
		/// Deleting an element template will delete all associated templated data from elements which were created from it.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template to update.</param>
		/// <returns>object</returns>
		public async Task<object> DeleteAsync(string webId)
		{
			return (await this.DeleteWithHttpAsync(webId)).Data;
		}

		/// <summary>
		/// Delete an element template.
		/// </summary>
		/// <remarks>
		/// Deleting an element template will delete all associated templated data from elements which were created from it.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template to update.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> DeleteWithHttp(string webId)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}";
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
		/// Delete an element template.
		/// </summary>
		/// <remarks>
		/// Deleting an element template will delete all associated templated data from elements which were created from it.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template to update.</param>
		/// <returns>object</returns>
		public object Delete(string webId)
		{
			return (this.DeleteWithHttp(webId)).Data;
		}

		/// <summary>
		/// Retrieve an element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAElementTemplate></returns>
		public async Task<HttpApiResponse<PWAElementTemplate>> GetWithHttpAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}";
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

			PWAElementTemplate response = JsonConvert.DeserializeObject<PWAElementTemplate>(httpContent);
			return new HttpApiResponse<PWAElementTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve an element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAElementTemplate</returns>
		public async Task<PWAElementTemplate> GetAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetWithHttpAsync(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve an element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAElementTemplate></returns>
		public HttpApiResponse<PWAElementTemplate> GetWithHttp(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}";
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

			PWAElementTemplate response = JsonConvert.DeserializeObject<PWAElementTemplate>(httpContent);
			return new HttpApiResponse<PWAElementTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve an element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAElementTemplate</returns>
		public PWAElementTemplate Get(string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetWithHttp(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Update an element template by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// Updating the InstanceType property of an element template will not affect any elements that have already been created from this template; it will only affect any future elements created from this template. All other changes will be propagated to elements based on this template.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template to update.</param>
		/// <param name="template">A partial element template containing the desired changes.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> UpdateWithHttpAsync(string webId, PWAElementTemplate template)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (template == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'template'");
			}

			string serviceUrl = "/elementtemplates/{webId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(template);
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
		/// Update an element template by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// Updating the InstanceType property of an element template will not affect any elements that have already been created from this template; it will only affect any future elements created from this template. All other changes will be propagated to elements based on this template.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template to update.</param>
		/// <param name="template">A partial element template containing the desired changes.</param>
		/// <returns>object</returns>
		public async Task<object> UpdateAsync(string webId, PWAElementTemplate template)
		{
			return (await this.UpdateWithHttpAsync(webId, template)).Data;
		}

		/// <summary>
		/// Update an element template by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// Updating the InstanceType property of an element template will not affect any elements that have already been created from this template; it will only affect any future elements created from this template. All other changes will be propagated to elements based on this template.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template to update.</param>
		/// <param name="template">A partial element template containing the desired changes.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> UpdateWithHttp(string webId, PWAElementTemplate template)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (template == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'template'");
			}

			string serviceUrl = "/elementtemplates/{webId}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(template);
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
		/// Update an element template by replacing items in its definition.
		/// </summary>
		/// <remarks>
		/// Updating the InstanceType property of an element template will not affect any elements that have already been created from this template; it will only affect any future elements created from this template. All other changes will be propagated to elements based on this template.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template to update.</param>
		/// <param name="template">A partial element template containing the desired changes.</param>
		/// <returns>object</returns>
		public object Update(string webId, PWAElementTemplate template)
		{
			return (this.UpdateWithHttp(webId, template)).Data;
		}

		/// <summary>
		/// Get analysis templates for an element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsAnalysisTemplate></returns>
		public async Task<HttpApiResponse<PWAItemsAnalysisTemplate>> GetAnalysisTemplatesWithHttpAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/analysistemplates";
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

			PWAItemsAnalysisTemplate response = JsonConvert.DeserializeObject<PWAItemsAnalysisTemplate>(httpContent);
			return new HttpApiResponse<PWAItemsAnalysisTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get analysis templates for an element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsAnalysisTemplate</returns>
		public async Task<PWAItemsAnalysisTemplate> GetAnalysisTemplatesAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetAnalysisTemplatesWithHttpAsync(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Get analysis templates for an element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsAnalysisTemplate></returns>
		public HttpApiResponse<PWAItemsAnalysisTemplate> GetAnalysisTemplatesWithHttp(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/analysistemplates";
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

			PWAItemsAnalysisTemplate response = JsonConvert.DeserializeObject<PWAItemsAnalysisTemplate>(httpContent);
			return new HttpApiResponse<PWAItemsAnalysisTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get analysis templates for an element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsAnalysisTemplate</returns>
		public PWAItemsAnalysisTemplate GetAnalysisTemplates(string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetAnalysisTemplatesWithHttp(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Get child attribute templates for an element template.
		/// </summary>
		/// <remarks>
		/// If 'showInherited' and 'showDescendants' are 'true', it returns all the attribute templates from current element template and the base template.  If 'showInherited' is 'false', it returns all the attribute templates from the current element template.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="depthFirstTraverse">When 'true', a Depth First traversal will be performed; this starts at the root and explores as far as possible along each branch before backtracking. When 'false', a Breadth First traversal will be performed; this starts at the tree root and explores the neighbor nodes first, then moves onto the next level of neighbors. The default is 'false' (Breadth First).</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showDescendants">Specifies if the result should include all descendant attribute templates from the current element template, even indirect ones. The default is 'false'.</param>
		/// <param name="showInherited">Specifies if the result should include attribute templates inherited from base element templates. The default is 'false'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsAttributeTemplate></returns>
		public async Task<HttpApiResponse<PWAItemsAttributeTemplate>> GetAttributeTemplatesWithHttpAsync(string webId, bool? depthFirstTraverse = null, int? maxCount = null, string selectedFields = null, bool? showDescendants = null, bool? showInherited = null, int? startIndex = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/attributetemplates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("depthFirstTraverse", depthFirstTraverse);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showDescendants", showDescendants);
			urlBuilder.AddQueryParameter("showInherited", showInherited);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsAttributeTemplate response = JsonConvert.DeserializeObject<PWAItemsAttributeTemplate>(httpContent);
			return new HttpApiResponse<PWAItemsAttributeTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get child attribute templates for an element template.
		/// </summary>
		/// <remarks>
		/// If 'showInherited' and 'showDescendants' are 'true', it returns all the attribute templates from current element template and the base template.  If 'showInherited' is 'false', it returns all the attribute templates from the current element template.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="depthFirstTraverse">When 'true', a Depth First traversal will be performed; this starts at the root and explores as far as possible along each branch before backtracking. When 'false', a Breadth First traversal will be performed; this starts at the tree root and explores the neighbor nodes first, then moves onto the next level of neighbors. The default is 'false' (Breadth First).</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showDescendants">Specifies if the result should include all descendant attribute templates from the current element template, even indirect ones. The default is 'false'.</param>
		/// <param name="showInherited">Specifies if the result should include attribute templates inherited from base element templates. The default is 'false'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsAttributeTemplate</returns>
		public async Task<PWAItemsAttributeTemplate> GetAttributeTemplatesAsync(string webId, bool? depthFirstTraverse = null, int? maxCount = null, string selectedFields = null, bool? showDescendants = null, bool? showInherited = null, int? startIndex = null, string webIdType = null)
		{
			return (await this.GetAttributeTemplatesWithHttpAsync(webId, depthFirstTraverse, maxCount, selectedFields, showDescendants, showInherited, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Get child attribute templates for an element template.
		/// </summary>
		/// <remarks>
		/// If 'showInherited' and 'showDescendants' are 'true', it returns all the attribute templates from current element template and the base template.  If 'showInherited' is 'false', it returns all the attribute templates from the current element template.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="depthFirstTraverse">When 'true', a Depth First traversal will be performed; this starts at the root and explores as far as possible along each branch before backtracking. When 'false', a Breadth First traversal will be performed; this starts at the tree root and explores the neighbor nodes first, then moves onto the next level of neighbors. The default is 'false' (Breadth First).</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showDescendants">Specifies if the result should include all descendant attribute templates from the current element template, even indirect ones. The default is 'false'.</param>
		/// <param name="showInherited">Specifies if the result should include attribute templates inherited from base element templates. The default is 'false'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsAttributeTemplate></returns>
		public HttpApiResponse<PWAItemsAttributeTemplate> GetAttributeTemplatesWithHttp(string webId, bool? depthFirstTraverse = null, int? maxCount = null, string selectedFields = null, bool? showDescendants = null, bool? showInherited = null, int? startIndex = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/attributetemplates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("depthFirstTraverse", depthFirstTraverse);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showDescendants", showDescendants);
			urlBuilder.AddQueryParameter("showInherited", showInherited);
			urlBuilder.AddQueryParameter("startIndex", startIndex);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsAttributeTemplate response = JsonConvert.DeserializeObject<PWAItemsAttributeTemplate>(httpContent);
			return new HttpApiResponse<PWAItemsAttributeTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get child attribute templates for an element template.
		/// </summary>
		/// <remarks>
		/// If 'showInherited' and 'showDescendants' are 'true', it returns all the attribute templates from current element template and the base template.  If 'showInherited' is 'false', it returns all the attribute templates from the current element template.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="depthFirstTraverse">When 'true', a Depth First traversal will be performed; this starts at the root and explores as far as possible along each branch before backtracking. When 'false', a Breadth First traversal will be performed; this starts at the tree root and explores the neighbor nodes first, then moves onto the next level of neighbors. The default is 'false' (Breadth First).</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showDescendants">Specifies if the result should include all descendant attribute templates from the current element template, even indirect ones. The default is 'false'.</param>
		/// <param name="showInherited">Specifies if the result should include attribute templates inherited from base element templates. The default is 'false'.</param>
		/// <param name="startIndex">The starting index (zero based) of the items to be returned. The default is 0.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsAttributeTemplate</returns>
		public PWAItemsAttributeTemplate GetAttributeTemplates(string webId, bool? depthFirstTraverse = null, int? maxCount = null, string selectedFields = null, bool? showDescendants = null, bool? showInherited = null, int? startIndex = null, string webIdType = null)
		{
			return (this.GetAttributeTemplatesWithHttp(webId, depthFirstTraverse, maxCount, selectedFields, showDescendants, showInherited, startIndex, webIdType)).Data;
		}

		/// <summary>
		/// Create an attribute template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template on which to create the attribute template.</param>
		/// <param name="template">The attribute template definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> CreateAttributeTemplateWithHttpAsync(string webId, PWAAttributeTemplate template, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (template == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'template'");
			}

			string serviceUrl = "/elementtemplates/{webId}/attributetemplates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(template);
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
		/// Create an attribute template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template on which to create the attribute template.</param>
		/// <param name="template">The attribute template definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> CreateAttributeTemplateAsync(string webId, PWAAttributeTemplate template, string webIdType = null)
		{
			return (await this.CreateAttributeTemplateWithHttpAsync(webId, template, webIdType)).Data;
		}

		/// <summary>
		/// Create an attribute template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template on which to create the attribute template.</param>
		/// <param name="template">The attribute template definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> CreateAttributeTemplateWithHttp(string webId, PWAAttributeTemplate template, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (template == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'template'");
			}

			string serviceUrl = "/elementtemplates/{webId}/attributetemplates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(template);
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
		/// Create an attribute template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template on which to create the attribute template.</param>
		/// <param name="template">The attribute template definition.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object CreateAttributeTemplate(string webId, PWAAttributeTemplate template, string webIdType = null)
		{
			return (this.CreateAttributeTemplateWithHttp(webId, template, webIdType)).Data;
		}

		/// <summary>
		/// Get base element templates for an element template.
		/// </summary>
		/// <remarks>
		/// The root template will be returned first, followed by successive templates in the inheritance chain.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElementTemplate></returns>
		public async Task<HttpApiResponse<PWAItemsElementTemplate>> GetBaseElementTemplatesWithHttpAsync(string webId, int? maxCount = null, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/baseelementtemplates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsElementTemplate response = JsonConvert.DeserializeObject<PWAItemsElementTemplate>(httpContent);
			return new HttpApiResponse<PWAItemsElementTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get base element templates for an element template.
		/// </summary>
		/// <remarks>
		/// The root template will be returned first, followed by successive templates in the inheritance chain.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElementTemplate</returns>
		public async Task<PWAItemsElementTemplate> GetBaseElementTemplatesAsync(string webId, int? maxCount = null, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetBaseElementTemplatesWithHttpAsync(webId, maxCount, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Get base element templates for an element template.
		/// </summary>
		/// <remarks>
		/// The root template will be returned first, followed by successive templates in the inheritance chain.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElementTemplate></returns>
		public HttpApiResponse<PWAItemsElementTemplate> GetBaseElementTemplatesWithHttp(string webId, int? maxCount = null, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/baseelementtemplates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsElementTemplate response = JsonConvert.DeserializeObject<PWAItemsElementTemplate>(httpContent);
			return new HttpApiResponse<PWAItemsElementTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get base element templates for an element template.
		/// </summary>
		/// <remarks>
		/// The root template will be returned first, followed by successive templates in the inheritance chain.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElementTemplate</returns>
		public PWAItemsElementTemplate GetBaseElementTemplates(string webId, int? maxCount = null, string selectedFields = null, string webIdType = null)
		{
			return (this.GetBaseElementTemplatesWithHttp(webId, maxCount, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Get an element template's categories.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showInherited">Specifies if the result should include categories inherited from base element templates. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElementCategory></returns>
		public async Task<HttpApiResponse<PWAItemsElementCategory>> GetCategoriesWithHttpAsync(string webId, string selectedFields = null, bool? showInherited = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/categories";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showInherited", showInherited);
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
		/// Get an element template's categories.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showInherited">Specifies if the result should include categories inherited from base element templates. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElementCategory</returns>
		public async Task<PWAItemsElementCategory> GetCategoriesAsync(string webId, string selectedFields = null, bool? showInherited = null, string webIdType = null)
		{
			return (await this.GetCategoriesWithHttpAsync(webId, selectedFields, showInherited, webIdType)).Data;
		}

		/// <summary>
		/// Get an element template's categories.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showInherited">Specifies if the result should include categories inherited from base element templates. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElementCategory></returns>
		public HttpApiResponse<PWAItemsElementCategory> GetCategoriesWithHttp(string webId, string selectedFields = null, bool? showInherited = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/categories";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showInherited", showInherited);
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
		/// Get an element template's categories.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showInherited">Specifies if the result should include categories inherited from base element templates. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElementCategory</returns>
		public PWAItemsElementCategory GetCategories(string webId, string selectedFields = null, bool? showInherited = null, string webIdType = null)
		{
			return (this.GetCategoriesWithHttp(webId, selectedFields, showInherited, webIdType)).Data;
		}

		/// <summary>
		/// Get derived element templates for an element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showDescendants">Specifies if the result should include all descendant element templates from the current element template, even indirect ones. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElementTemplate></returns>
		public async Task<HttpApiResponse<PWAItemsElementTemplate>> GetDerivedElementTemplatesWithHttpAsync(string webId, int? maxCount = null, string selectedFields = null, bool? showDescendants = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/derivedelementtemplates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showDescendants", showDescendants);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsElementTemplate response = JsonConvert.DeserializeObject<PWAItemsElementTemplate>(httpContent);
			return new HttpApiResponse<PWAItemsElementTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get derived element templates for an element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showDescendants">Specifies if the result should include all descendant element templates from the current element template, even indirect ones. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElementTemplate</returns>
		public async Task<PWAItemsElementTemplate> GetDerivedElementTemplatesAsync(string webId, int? maxCount = null, string selectedFields = null, bool? showDescendants = null, string webIdType = null)
		{
			return (await this.GetDerivedElementTemplatesWithHttpAsync(webId, maxCount, selectedFields, showDescendants, webIdType)).Data;
		}

		/// <summary>
		/// Get derived element templates for an element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showDescendants">Specifies if the result should include all descendant element templates from the current element template, even indirect ones. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsElementTemplate></returns>
		public HttpApiResponse<PWAItemsElementTemplate> GetDerivedElementTemplatesWithHttp(string webId, int? maxCount = null, string selectedFields = null, bool? showDescendants = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/derivedelementtemplates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showDescendants", showDescendants);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsElementTemplate response = JsonConvert.DeserializeObject<PWAItemsElementTemplate>(httpContent);
			return new HttpApiResponse<PWAItemsElementTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get derived element templates for an element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="maxCount">The maximum number of objects to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showDescendants">Specifies if the result should include all descendant element templates from the current element template, even indirect ones. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsElementTemplate</returns>
		public PWAItemsElementTemplate GetDerivedElementTemplates(string webId, int? maxCount = null, string selectedFields = null, bool? showDescendants = null, string webIdType = null)
		{
			return (this.GetDerivedElementTemplatesWithHttp(webId, maxCount, selectedFields, showDescendants, webIdType)).Data;
		}

		/// <summary>
		/// Get notification rule templates for an element template
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsNotificationRuleTemplate></returns>
		public async Task<HttpApiResponse<PWAItemsNotificationRuleTemplate>> GetNotificationRuleTemplatesWithHttpAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/notificationruletemplates";
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

			PWAItemsNotificationRuleTemplate response = JsonConvert.DeserializeObject<PWAItemsNotificationRuleTemplate>(httpContent);
			return new HttpApiResponse<PWAItemsNotificationRuleTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get notification rule templates for an element template
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsNotificationRuleTemplate</returns>
		public async Task<PWAItemsNotificationRuleTemplate> GetNotificationRuleTemplatesAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetNotificationRuleTemplatesWithHttpAsync(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Get notification rule templates for an element template
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsNotificationRuleTemplate></returns>
		public HttpApiResponse<PWAItemsNotificationRuleTemplate> GetNotificationRuleTemplatesWithHttp(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/notificationruletemplates";
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

			PWAItemsNotificationRuleTemplate response = JsonConvert.DeserializeObject<PWAItemsNotificationRuleTemplate>(httpContent);
			return new HttpApiResponse<PWAItemsNotificationRuleTemplate>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get notification rule templates for an element template
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsNotificationRuleTemplate</returns>
		public PWAItemsNotificationRuleTemplate GetNotificationRuleTemplates(string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetNotificationRuleTemplatesWithHttp(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Create a notification rule template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the notification rule template.</param>
		/// <param name="notificationRuleTemplate">The new notification rule template.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> CreateNotificationRuleTemplateWithHttpAsync(string webId, PWANotificationRuleTemplate notificationRuleTemplate, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (notificationRuleTemplate == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'notificationRuleTemplate'");
			}

			string serviceUrl = "/elementtemplates/{webId}/notificationruletemplates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(notificationRuleTemplate);
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
		/// Create a notification rule template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the notification rule template.</param>
		/// <param name="notificationRuleTemplate">The new notification rule template.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> CreateNotificationRuleTemplateAsync(string webId, PWANotificationRuleTemplate notificationRuleTemplate, string webIdType = null)
		{
			return (await this.CreateNotificationRuleTemplateWithHttpAsync(webId, notificationRuleTemplate, webIdType)).Data;
		}

		/// <summary>
		/// Create a notification rule template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the notification rule template.</param>
		/// <param name="notificationRuleTemplate">The new notification rule template.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> CreateNotificationRuleTemplateWithHttp(string webId, PWANotificationRuleTemplate notificationRuleTemplate, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (notificationRuleTemplate == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'notificationRuleTemplate'");
			}

			string serviceUrl = "/elementtemplates/{webId}/notificationruletemplates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(notificationRuleTemplate);
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
		/// Create a notification rule template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element on which to create the notification rule template.</param>
		/// <param name="notificationRuleTemplate">The new notification rule template.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object CreateNotificationRuleTemplate(string webId, PWANotificationRuleTemplate notificationRuleTemplate, string webIdType = null)
		{
			return (this.CreateNotificationRuleTemplateWithHttp(webId, notificationRuleTemplate, webIdType)).Data;
		}

		/// <summary>
		/// Get the security information of the specified security item associated with the element template for a specified user.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template for the security to be checked.</param>
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

			string serviceUrl = "/elementtemplates/{webId}/security";
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
		/// Get the security information of the specified security item associated with the element template for a specified user.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template for the security to be checked.</param>
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
		/// Get the security information of the specified security item associated with the element template for a specified user.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template for the security to be checked.</param>
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

			string serviceUrl = "/elementtemplates/{webId}/security";
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
		/// Get the security information of the specified security item associated with the element template for a specified user.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template for the security to be checked.</param>
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
		/// Retrieve the security entries associated with the element template based on the specified criteria. By default, all security entries for this element template are returned.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
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

			string serviceUrl = "/elementtemplates/{webId}/securityentries";
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
		/// Retrieve the security entries associated with the element template based on the specified criteria. By default, all security entries for this element template are returned.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="nameFilter">The name query string used for filtering security entries. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsSecurityEntry</returns>
		public async Task<PWAItemsSecurityEntry> GetSecurityEntriesAsync(string webId, string nameFilter = null, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetSecurityEntriesWithHttpAsync(webId, nameFilter, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve the security entries associated with the element template based on the specified criteria. By default, all security entries for this element template are returned.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
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

			string serviceUrl = "/elementtemplates/{webId}/securityentries";
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
		/// Retrieve the security entries associated with the element template based on the specified criteria. By default, all security entries for this element template are returned.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="nameFilter">The name query string used for filtering security entries. The default is no filter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsSecurityEntry</returns>
		public PWAItemsSecurityEntry GetSecurityEntries(string webId, string nameFilter = null, string selectedFields = null, string webIdType = null)
		{
			return (this.GetSecurityEntriesWithHttp(webId, nameFilter, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Create a security entry owned by the element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template where the security entry will be created.</param>
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

			string serviceUrl = "/elementtemplates/{webId}/securityentries";
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
		/// Create a security entry owned by the element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template where the security entry will be created.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> CreateSecurityEntryAsync(string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null, string webIdType = null)
		{
			return (await this.CreateSecurityEntryWithHttpAsync(webId, securityEntry, applyToChildren, webIdType)).Data;
		}

		/// <summary>
		/// Create a security entry owned by the element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template where the security entry will be created.</param>
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

			string serviceUrl = "/elementtemplates/{webId}/securityentries";
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
		/// Create a security entry owned by the element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the element template where the security entry will be created.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object CreateSecurityEntry(string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null, string webIdType = null)
		{
			return (this.CreateSecurityEntryWithHttp(webId, securityEntry, applyToChildren, webIdType)).Data;
		}

		/// <summary>
		/// Delete a security entry owned by the element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element template where the security entry will be deleted.</param>
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

			string serviceUrl = "/elementtemplates/{webId}/securityentries/{name}";
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
		/// Delete a security entry owned by the element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element template where the security entry will be deleted.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>object</returns>
		public async Task<object> DeleteSecurityEntryAsync(string name, string webId, bool? applyToChildren = null)
		{
			return (await this.DeleteSecurityEntryWithHttpAsync(name, webId, applyToChildren)).Data;
		}

		/// <summary>
		/// Delete a security entry owned by the element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element template where the security entry will be deleted.</param>
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

			string serviceUrl = "/elementtemplates/{webId}/securityentries/{name}";
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
		/// Delete a security entry owned by the element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element template where the security entry will be deleted.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>object</returns>
		public object DeleteSecurityEntry(string name, string webId, bool? applyToChildren = null)
		{
			return (this.DeleteSecurityEntryWithHttp(name, webId, applyToChildren)).Data;
		}

		/// <summary>
		/// Retrieve the security entry associated with the element template with the specified name.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsSecurityEntry></returns>
		public async Task<HttpApiResponse<PWAItemsSecurityEntry>> GetSecurityEntryByNameWithHttpAsync(string name, string webId, string selectedFields = null, string webIdType = null)
		{
			if (name == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'name'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/securityentries/{name}";
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

			PWAItemsSecurityEntry response = JsonConvert.DeserializeObject<PWAItemsSecurityEntry>(httpContent);
			return new HttpApiResponse<PWAItemsSecurityEntry>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve the security entry associated with the element template with the specified name.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsSecurityEntry</returns>
		public async Task<PWAItemsSecurityEntry> GetSecurityEntryByNameAsync(string name, string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.GetSecurityEntryByNameWithHttpAsync(name, webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Retrieve the security entry associated with the element template with the specified name.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsSecurityEntry></returns>
		public HttpApiResponse<PWAItemsSecurityEntry> GetSecurityEntryByNameWithHttp(string name, string webId, string selectedFields = null, string webIdType = null)
		{
			if (name == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'name'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/elementtemplates/{webId}/securityentries/{name}";
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

			PWAItemsSecurityEntry response = JsonConvert.DeserializeObject<PWAItemsSecurityEntry>(httpContent);
			return new HttpApiResponse<PWAItemsSecurityEntry>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve the security entry associated with the element template with the specified name.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry. For every backslash character (\) in the security entry name, replace with asterisk (*). As an example, use domain*username instead of domain\username.</param>
		/// <param name="webId">The ID of the element template.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsSecurityEntry</returns>
		public PWAItemsSecurityEntry GetSecurityEntryByName(string name, string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.GetSecurityEntryByNameWithHttp(name, webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Update a security entry owned by the element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry.</param>
		/// <param name="webId">The ID of the element template where the security entry will be updated.</param>
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

			string serviceUrl = "/elementtemplates/{webId}/securityentries/{name}";
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
		/// Update a security entry owned by the element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry.</param>
		/// <param name="webId">The ID of the element template where the security entry will be updated.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied or they will be removed.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>object</returns>
		public async Task<object> UpdateSecurityEntryAsync(string name, string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null)
		{
			return (await this.UpdateSecurityEntryWithHttpAsync(name, webId, securityEntry, applyToChildren)).Data;
		}

		/// <summary>
		/// Update a security entry owned by the element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry.</param>
		/// <param name="webId">The ID of the element template where the security entry will be updated.</param>
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

			string serviceUrl = "/elementtemplates/{webId}/securityentries/{name}";
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
		/// Update a security entry owned by the element template.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name of the security entry.</param>
		/// <param name="webId">The ID of the element template where the security entry will be updated.</param>
		/// <param name="securityEntry">The new security entry definition. The full list of allow and deny rights must be supplied or they will be removed.</param>
		/// <param name="applyToChildren">If false, the new access permissions are only applied to the associated object. If true, the access permissions of children with any parent-child reference types will change when the permissions on the primary parent change.</param>
		/// <returns>object</returns>
		public object UpdateSecurityEntry(string name, string webId, PWASecurityEntry securityEntry, bool? applyToChildren = null)
		{
			return (this.UpdateSecurityEntryWithHttp(name, webId, securityEntry, applyToChildren)).Data;
		}

	}
}
