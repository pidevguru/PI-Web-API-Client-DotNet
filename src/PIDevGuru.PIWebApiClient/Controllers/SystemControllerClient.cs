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
	public class SystemControllerClient
	{
		private HttpApiClient httpApiClient;
		public SystemControllerClient(HttpApiClient httpApiClient)
		{
			this.httpApiClient = httpApiClient;
		}
		/// <summary>
		/// Get system links for this PI System Web API instance.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<PWASystemLanding></returns>
		public async Task<HttpApiResponse<PWASystemLanding>> LandingWithHttpAsync()
		{
			string serviceUrl = "/system";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWASystemLanding response = JsonConvert.DeserializeObject<PWASystemLanding>(httpContent);
			return new HttpApiResponse<PWASystemLanding>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get system links for this PI System Web API instance.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>PWASystemLanding</returns>
		public async Task<PWASystemLanding> LandingAsync()
		{
			return (await this.LandingWithHttpAsync()).Data;
		}

		/// <summary>
		/// Get system links for this PI System Web API instance.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<PWASystemLanding></returns>
		public HttpApiResponse<PWASystemLanding> LandingWithHttp()
		{
			string serviceUrl = "/system";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWASystemLanding response = JsonConvert.DeserializeObject<PWASystemLanding>(httpContent);
			return new HttpApiResponse<PWASystemLanding>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get system links for this PI System Web API instance.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>PWASystemLanding</returns>
		public PWASystemLanding Landing()
		{
			return (this.LandingWithHttp()).Data;
		}

		/// <summary>
		/// Get AF cache instances currently in use by the system. These are caches from which user requests are serviced. The number of instances depends on the number of users connected to the service, the service's authentication method, and the cache instance configuration.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<PWAItemsCacheInstance></returns>
		public async Task<HttpApiResponse<PWAItemsCacheInstance>> CacheInstancesWithHttpAsync()
		{
			string serviceUrl = "/system/cacheinstances";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsCacheInstance response = JsonConvert.DeserializeObject<PWAItemsCacheInstance>(httpContent);
			return new HttpApiResponse<PWAItemsCacheInstance>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get AF cache instances currently in use by the system. These are caches from which user requests are serviced. The number of instances depends on the number of users connected to the service, the service's authentication method, and the cache instance configuration.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>PWAItemsCacheInstance</returns>
		public async Task<PWAItemsCacheInstance> CacheInstancesAsync()
		{
			return (await this.CacheInstancesWithHttpAsync()).Data;
		}

		/// <summary>
		/// Get AF cache instances currently in use by the system. These are caches from which user requests are serviced. The number of instances depends on the number of users connected to the service, the service's authentication method, and the cache instance configuration.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<PWAItemsCacheInstance></returns>
		public HttpApiResponse<PWAItemsCacheInstance> CacheInstancesWithHttp()
		{
			string serviceUrl = "/system/cacheinstances";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsCacheInstance response = JsonConvert.DeserializeObject<PWAItemsCacheInstance>(httpContent);
			return new HttpApiResponse<PWAItemsCacheInstance>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get AF cache instances currently in use by the system. These are caches from which user requests are serviced. The number of instances depends on the number of users connected to the service, the service's authentication method, and the cache instance configuration.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>PWAItemsCacheInstance</returns>
		public PWAItemsCacheInstance CacheInstances()
		{
			return (this.CacheInstancesWithHttp()).Data;
		}

		/// <summary>
		/// Get information about this PI Web API instance. Examples of information returned include the system uptime, the number of cache instances for this PI System Web API instance, and the system run state.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<PWASystemStatus></returns>
		public async Task<HttpApiResponse<PWASystemStatus>> StatusWithHttpAsync()
		{
			string serviceUrl = "/system/status";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWASystemStatus response = JsonConvert.DeserializeObject<PWASystemStatus>(httpContent);
			return new HttpApiResponse<PWASystemStatus>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get information about this PI Web API instance. Examples of information returned include the system uptime, the number of cache instances for this PI System Web API instance, and the system run state.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>PWASystemStatus</returns>
		public async Task<PWASystemStatus> StatusAsync()
		{
			return (await this.StatusWithHttpAsync()).Data;
		}

		/// <summary>
		/// Get information about this PI Web API instance. Examples of information returned include the system uptime, the number of cache instances for this PI System Web API instance, and the system run state.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<PWASystemStatus></returns>
		public HttpApiResponse<PWASystemStatus> StatusWithHttp()
		{
			string serviceUrl = "/system/status";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWASystemStatus response = JsonConvert.DeserializeObject<PWASystemStatus>(httpContent);
			return new HttpApiResponse<PWASystemStatus>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get information about this PI Web API instance. Examples of information returned include the system uptime, the number of cache instances for this PI System Web API instance, and the system run state.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>PWASystemStatus</returns>
		public PWASystemStatus Status()
		{
			return (this.StatusWithHttp()).Data;
		}

		/// <summary>
		/// Get information about the Windows identity used to fulfill the request. This depends on the service's authentication method and the credentials passed by the client. The impersonation level of the Windows identity is included.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<PWAUserInfo></returns>
		public async Task<HttpApiResponse<PWAUserInfo>> UserInfoWithHttpAsync()
		{
			string serviceUrl = "/system/userinfo";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAUserInfo response = JsonConvert.DeserializeObject<PWAUserInfo>(httpContent);
			return new HttpApiResponse<PWAUserInfo>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get information about the Windows identity used to fulfill the request. This depends on the service's authentication method and the credentials passed by the client. The impersonation level of the Windows identity is included.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>PWAUserInfo</returns>
		public async Task<PWAUserInfo> UserInfoAsync()
		{
			return (await this.UserInfoWithHttpAsync()).Data;
		}

		/// <summary>
		/// Get information about the Windows identity used to fulfill the request. This depends on the service's authentication method and the credentials passed by the client. The impersonation level of the Windows identity is included.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<PWAUserInfo></returns>
		public HttpApiResponse<PWAUserInfo> UserInfoWithHttp()
		{
			string serviceUrl = "/system/userinfo";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAUserInfo response = JsonConvert.DeserializeObject<PWAUserInfo>(httpContent);
			return new HttpApiResponse<PWAUserInfo>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get information about the Windows identity used to fulfill the request. This depends on the service's authentication method and the credentials passed by the client. The impersonation level of the Windows identity is included.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>PWAUserInfo</returns>
		public PWAUserInfo UserInfo()
		{
			return (this.UserInfoWithHttp()).Data;
		}

		/// <summary>
		/// Get the current versions of the PI Web API instance and all external plugins.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<Dictionary<string, PWAVersion>></returns>
		public async Task<HttpApiResponse<Dictionary<string, PWAVersion>>> VersionsWithHttpAsync()
		{
			string serviceUrl = "/system/versions";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			Dictionary<string, PWAVersion> response = JsonConvert.DeserializeObject<Dictionary<string, PWAVersion>>(httpContent);
			return new HttpApiResponse<Dictionary<string, PWAVersion>>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get the current versions of the PI Web API instance and all external plugins.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>Dictionary<string, PWAVersion></returns>
		public async Task<Dictionary<string, PWAVersion>> VersionsAsync()
		{
			return (await this.VersionsWithHttpAsync()).Data;
		}

		/// <summary>
		/// Get the current versions of the PI Web API instance and all external plugins.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>HttpApiResponse<Dictionary<string, PWAVersion>></returns>
		public HttpApiResponse<Dictionary<string, PWAVersion>> VersionsWithHttp()
		{
			string serviceUrl = "/system/versions";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			Dictionary<string, PWAVersion> response = JsonConvert.DeserializeObject<Dictionary<string, PWAVersion>>(httpContent);
			return new HttpApiResponse<Dictionary<string, PWAVersion>>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Get the current versions of the PI Web API instance and all external plugins.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="TimeLordGeek.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <returns>Dictionary<string, PWAVersion></returns>
		public Dictionary<string, PWAVersion> Versions()
		{
			return (this.VersionsWithHttp()).Data;
		}

	}
}
