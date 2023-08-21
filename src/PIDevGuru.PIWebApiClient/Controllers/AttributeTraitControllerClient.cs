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
	public class AttributeTraitControllerClient
	{
		private HttpApiClient httpApiClient;
		public AttributeTraitControllerClient(HttpApiClient httpApiClient)
		{
			this.httpApiClient = httpApiClient;
		}
		/// <summary>
		/// Retrieve all attribute traits of the specified category/categories.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="category">The category of the attribute traits. Multiple categories may be specified with multiple instances of the parameter. If the parameter is not specified, or if its value is "all", then all attribute traits of all categories will be returned.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <returns>HttpApiResponse<PWAItemsAttributeTrait></returns>
		public async Task<HttpApiResponse<PWAItemsAttributeTrait>> GetByCategoryWithHttpAsync(List<string> category, string selectedFields = null)
		{
			if (category == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'category'");
			}

			string serviceUrl = "/attributetraits";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("category", category);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsAttributeTrait response = JsonConvert.DeserializeObject<PWAItemsAttributeTrait>(httpContent);
			return new HttpApiResponse<PWAItemsAttributeTrait>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve all attribute traits of the specified category/categories.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="category">The category of the attribute traits. Multiple categories may be specified with multiple instances of the parameter. If the parameter is not specified, or if its value is "all", then all attribute traits of all categories will be returned.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <returns>PWAItemsAttributeTrait</returns>
		public async Task<PWAItemsAttributeTrait> GetByCategoryAsync(List<string> category, string selectedFields = null)
		{
			return (await this.GetByCategoryWithHttpAsync(category, selectedFields)).Data;
		}

		/// <summary>
		/// Retrieve all attribute traits of the specified category/categories.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="category">The category of the attribute traits. Multiple categories may be specified with multiple instances of the parameter. If the parameter is not specified, or if its value is "all", then all attribute traits of all categories will be returned.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <returns>HttpApiResponse<PWAItemsAttributeTrait></returns>
		public HttpApiResponse<PWAItemsAttributeTrait> GetByCategoryWithHttp(List<string> category, string selectedFields = null)
		{
			if (category == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'category'");
			}

			string serviceUrl = "/attributetraits";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("category", category);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsAttributeTrait response = JsonConvert.DeserializeObject<PWAItemsAttributeTrait>(httpContent);
			return new HttpApiResponse<PWAItemsAttributeTrait>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve all attribute traits of the specified category/categories.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="category">The category of the attribute traits. Multiple categories may be specified with multiple instances of the parameter. If the parameter is not specified, or if its value is "all", then all attribute traits of all categories will be returned.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <returns>PWAItemsAttributeTrait</returns>
		public PWAItemsAttributeTrait GetByCategory(List<string> category, string selectedFields = null)
		{
			return (this.GetByCategoryWithHttp(category, selectedFields)).Data;
		}

		/// <summary>
		/// Retrieve an attribute trait.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name or abbreviation of the attribute trait.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <returns>HttpApiResponse<PWAAttributeTrait></returns>
		public async Task<HttpApiResponse<PWAAttributeTrait>> GetWithHttpAsync(string name, string selectedFields = null)
		{
			if (name == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'name'");
			}

			string serviceUrl = "/attributetraits/{name}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("name", name);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAAttributeTrait response = JsonConvert.DeserializeObject<PWAAttributeTrait>(httpContent);
			return new HttpApiResponse<PWAAttributeTrait>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve an attribute trait.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name or abbreviation of the attribute trait.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <returns>PWAAttributeTrait</returns>
		public async Task<PWAAttributeTrait> GetAsync(string name, string selectedFields = null)
		{
			return (await this.GetWithHttpAsync(name, selectedFields)).Data;
		}

		/// <summary>
		/// Retrieve an attribute trait.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name or abbreviation of the attribute trait.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <returns>HttpApiResponse<PWAAttributeTrait></returns>
		public HttpApiResponse<PWAAttributeTrait> GetWithHttp(string name, string selectedFields = null)
		{
			if (name == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'name'");
			}

			string serviceUrl = "/attributetraits/{name}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("name", name);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAAttributeTrait response = JsonConvert.DeserializeObject<PWAAttributeTrait>(httpContent);
			return new HttpApiResponse<PWAAttributeTrait>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieve an attribute trait.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="name">The name or abbreviation of the attribute trait.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <returns>PWAAttributeTrait</returns>
		public PWAAttributeTrait Get(string name, string selectedFields = null)
		{
			return (this.GetWithHttp(name, selectedFields)).Data;
		}

	}
}
