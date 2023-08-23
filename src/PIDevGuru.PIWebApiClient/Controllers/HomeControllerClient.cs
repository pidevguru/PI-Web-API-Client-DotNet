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
	public class HomeControllerClient
	{
		private HttpApiClient httpApiClient;
		public HomeControllerClient(HttpApiClient httpApiClient)
		{
			this.httpApiClient = httpApiClient;
		}
		/// <summary>
		/// Get top level links for this PI System Web API instance.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<PWALanding></returns>
		public async Task<HttpApiResponse<PWALanding>> GetWithHttpAsync()
		{
			string serviceUrl = "/";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWALanding response = JsonConvert.DeserializeObject<PWALanding>(httpContent);
			return new HttpApiResponse<PWALanding>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get top level links for this PI System Web API instance.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>PWALanding</returns>
		public async Task<PWALanding> GetAsync()
		{
			return (await this.GetWithHttpAsync()).Data;
		}

		/// <summary>
		/// Get top level links for this PI System Web API instance.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<PWALanding></returns>
		public HttpApiResponse<PWALanding> GetWithHttp()
		{
			string serviceUrl = "/";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWALanding response = JsonConvert.DeserializeObject<PWALanding>(httpContent);
			return new HttpApiResponse<PWALanding>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get top level links for this PI System Web API instance.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>PWALanding</returns>
		public PWALanding Get()
		{
			return (this.GetWithHttp()).Data;
		}

	}
}
