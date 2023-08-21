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
	public class ConfigurationControllerClient
	{
		private HttpApiClient httpApiClient;
		public ConfigurationControllerClient(HttpApiClient httpApiClient)
		{
			this.httpApiClient = httpApiClient;
		}
		/// <summary>
		/// Get the current system configuration.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<Dictionary<string, object>></returns>
		public async Task<HttpApiResponse<Dictionary<string, object>>> ListWithHttpAsync()
		{
			string serviceUrl = "/system/configuration";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			Dictionary<string, object> response = JsonConvert.DeserializeObject<Dictionary<string, object>>(httpContent);
			return new HttpApiResponse<Dictionary<string, object>>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get the current system configuration.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>Dictionary<string, object></returns>
		public async Task<Dictionary<string, object>> ListAsync()
		{
			return (await this.ListWithHttpAsync()).Data;
		}

		/// <summary>
		/// Get the current system configuration.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<Dictionary<string, object>></returns>
		public HttpApiResponse<Dictionary<string, object>> ListWithHttp()
		{
			string serviceUrl = "/system/configuration";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			Dictionary<string, object> response = JsonConvert.DeserializeObject<Dictionary<string, object>>(httpContent);
			return new HttpApiResponse<Dictionary<string, object>>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get the current system configuration.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>Dictionary<string, object></returns>
		public Dictionary<string, object> List()
		{
			return (this.ListWithHttp()).Data;
		}

		/// <summary>
		/// Delete a configuration item.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="key">The key of the configuration item to remove.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> DeleteWithHttpAsync(string key)
		{
			if (key == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'key'");
			}

			string serviceUrl = "/system/configuration/{key}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("key", key);
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
		/// Delete a configuration item.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="key">The key of the configuration item to remove.</param>
		/// <returns>object</returns>
		public async Task<object> DeleteAsync(string key)
		{
			return (await this.DeleteWithHttpAsync(key)).Data;
		}

		/// <summary>
		/// Delete a configuration item.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="key">The key of the configuration item to remove.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> DeleteWithHttp(string key)
		{
			if (key == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'key'");
			}

			string serviceUrl = "/system/configuration/{key}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("key", key);
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
		/// Delete a configuration item.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="key">The key of the configuration item to remove.</param>
		/// <returns>object</returns>
		public object Delete(string key)
		{
			return (this.DeleteWithHttp(key)).Data;
		}

		/// <summary>
		/// Get the value of a configuration item.
		/// </summary>
		/// <remarks>
		/// The response content may vary based on the configuration item's data type.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="key">The key of the configuration item.</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> GetWithHttpAsync(string key)
		{
			if (key == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'key'");
			}

			string serviceUrl = "/system/configuration/{key}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("key", key);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get the value of a configuration item.
		/// </summary>
		/// <remarks>
		/// The response content may vary based on the configuration item's data type.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="key">The key of the configuration item.</param>
		/// <returns>object</returns>
		public async Task<object> GetAsync(string key)
		{
			return (await this.GetWithHttpAsync(key)).Data;
		}

		/// <summary>
		/// Get the value of a configuration item.
		/// </summary>
		/// <remarks>
		/// The response content may vary based on the configuration item's data type.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="key">The key of the configuration item.</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> GetWithHttp(string key)
		{
			if (key == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'key'");
			}

			string serviceUrl = "/system/configuration/{key}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("key", key);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			object response = JsonConvert.DeserializeObject<object>(httpContent);
			return new HttpApiResponse<object>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get the value of a configuration item.
		/// </summary>
		/// <remarks>
		/// The response content may vary based on the configuration item's data type.
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="key">The key of the configuration item.</param>
		/// <returns>object</returns>
		public object Get(string key)
		{
			return (this.GetWithHttp(key)).Data;
		}

	}
}
