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
	public class ChannelControllerClient
	{
		private HttpApiClient httpApiClient;
		public ChannelControllerClient(HttpApiClient httpApiClient)
		{
			this.httpApiClient = httpApiClient;
		}
		/// <summary>
		/// Retrieves a list of currently running channel instances.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<PWAItemsChannelInstance></returns>
		public async Task<HttpApiResponse<PWAItemsChannelInstance>> InstancesWithHttpAsync()
		{
			string serviceUrl = "/channels/instances";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsChannelInstance response = JsonConvert.DeserializeObject<PWAItemsChannelInstance>(httpContent);
			return new HttpApiResponse<PWAItemsChannelInstance>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves a list of currently running channel instances.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>PWAItemsChannelInstance</returns>
		public async Task<PWAItemsChannelInstance> InstancesAsync()
		{
			return (await this.InstancesWithHttpAsync()).Data;
		}

		/// <summary>
		/// Retrieves a list of currently running channel instances.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<PWAItemsChannelInstance></returns>
		public HttpApiResponse<PWAItemsChannelInstance> InstancesWithHttp()
		{
			string serviceUrl = "/channels/instances";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsChannelInstance response = JsonConvert.DeserializeObject<PWAItemsChannelInstance>(httpContent);
			return new HttpApiResponse<PWAItemsChannelInstance>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves a list of currently running channel instances.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>PWAItemsChannelInstance</returns>
		public PWAItemsChannelInstance Instances()
		{
			return (this.InstancesWithHttp()).Data;
		}

	}
}
