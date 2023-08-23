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
	public class StreamSetControllerClient
	{
		private HttpApiClient httpApiClient;
		public StreamSetControllerClient(HttpApiClient httpApiClient)
		{
			this.httpApiClient = httpApiClient;
		}
		/// <summary>
		/// Opens a channel that will send messages about any value changes for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="heartbeatRate">Specifies the maximum number of consecutive empty messages that can be elapsed with no new data updates from the PI System, after which the client receives an empty payload. It helps to check if the connection is still alive. Zero/negative values correspond to no heartbeat, and the default value is no heartbeat.</param>
		/// <param name="includeInitialValues">Specified if the channel should send a message with the current values of all the streams after the connection is opened. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValue>> GetChannelAdHocWithHttpAsync(List<string> webId, int? heartbeatRate = null, bool? includeInitialValues = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/channel";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("heartbeatRate", heartbeatRate);
			urlBuilder.AddQueryParameter("includeInitialValues", includeInitialValues);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Opens a channel that will send messages about any value changes for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="heartbeatRate">Specifies the maximum number of consecutive empty messages that can be elapsed with no new data updates from the PI System, after which the client receives an empty payload. It helps to check if the connection is still alive. Zero/negative values correspond to no heartbeat, and the default value is no heartbeat.</param>
		/// <param name="includeInitialValues">Specified if the channel should send a message with the current values of all the streams after the connection is opened. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public async Task<PWAItemsStreamValue> GetChannelAdHocAsync(List<string> webId, int? heartbeatRate = null, bool? includeInitialValues = null, string webIdType = null)
		{
			return (await this.GetChannelAdHocWithHttpAsync(webId, heartbeatRate, includeInitialValues, webIdType)).Data;
		}

		/// <summary>
		/// Opens a channel that will send messages about any value changes for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="heartbeatRate">Specifies the maximum number of consecutive empty messages that can be elapsed with no new data updates from the PI System, after which the client receives an empty payload. It helps to check if the connection is still alive. Zero/negative values correspond to no heartbeat, and the default value is no heartbeat.</param>
		/// <param name="includeInitialValues">Specified if the channel should send a message with the current values of all the streams after the connection is opened. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public HttpApiResponse<PWAItemsStreamValue> GetChannelAdHocWithHttp(List<string> webId, int? heartbeatRate = null, bool? includeInitialValues = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/channel";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("heartbeatRate", heartbeatRate);
			urlBuilder.AddQueryParameter("includeInitialValues", includeInitialValues);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Opens a channel that will send messages about any value changes for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="heartbeatRate">Specifies the maximum number of consecutive empty messages that can be elapsed with no new data updates from the PI System, after which the client receives an empty payload. It helps to check if the connection is still alive. Zero/negative values correspond to no heartbeat, and the default value is no heartbeat.</param>
		/// <param name="includeInitialValues">Specified if the channel should send a message with the current values of all the streams after the connection is opened. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public PWAItemsStreamValue GetChannelAdHoc(List<string> webId, int? heartbeatRate = null, bool? includeInitialValues = null, string webIdType = null)
		{
			return (this.GetChannelAdHocWithHttp(webId, heartbeatRate, includeInitialValues, webIdType)).Data;
		}

		/// <summary>
		/// Returns End Of Stream values for attributes of the specified streams
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetEndAdHocWithHttpAsync(List<string> webId, string selectedFields = null, string sortField = null, string sortOrder = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/end";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns End Of Stream values for attributes of the specified streams
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetEndAdHocAsync(List<string> webId, string selectedFields = null, string sortField = null, string sortOrder = null, string webIdType = null)
		{
			return (await this.GetEndAdHocWithHttpAsync(webId, selectedFields, sortField, sortOrder, webIdType)).Data;
		}

		/// <summary>
		/// Returns End Of Stream values for attributes of the specified streams
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetEndAdHocWithHttp(List<string> webId, string selectedFields = null, string sortField = null, string sortOrder = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/end";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns End Of Stream values for attributes of the specified streams
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetEndAdHoc(List<string> webId, string selectedFields = null, string sortField = null, string sortOrder = null, string webIdType = null)
		{
			return (this.GetEndAdHocWithHttp(webId, selectedFields, sortField, sortOrder, webIdType)).Data;
		}

		/// <summary>
		/// Returns interpolated values of the specified streams over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="interval">The sampling interval, in AFTimeSpan format.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="syncTime">An optional start time anchor, in AFTime format. When specified, interpolated data retrieval will use the sync time as the origin for calculating the interval times.</param>
		/// <param name="syncTimeBoundaryType">An optional string specifying the boundary type to use when applying a syncTime. The allowed values are 'Inside' and 'Outside'. The default is 'Inside'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetInterpolatedAdHocWithHttpAsync(List<string> webId, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, string interval = null, string selectedFields = null, string sortField = null, string sortOrder = null, string startTime = null, string syncTime = null, string syncTimeBoundaryType = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/interpolated";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("interval", interval);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("syncTime", syncTime);
			urlBuilder.AddQueryParameter("syncTimeBoundaryType", syncTimeBoundaryType);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns interpolated values of the specified streams over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="interval">The sampling interval, in AFTimeSpan format.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="syncTime">An optional start time anchor, in AFTime format. When specified, interpolated data retrieval will use the sync time as the origin for calculating the interval times.</param>
		/// <param name="syncTimeBoundaryType">An optional string specifying the boundary type to use when applying a syncTime. The allowed values are 'Inside' and 'Outside'. The default is 'Inside'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetInterpolatedAdHocAsync(List<string> webId, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, string interval = null, string selectedFields = null, string sortField = null, string sortOrder = null, string startTime = null, string syncTime = null, string syncTimeBoundaryType = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetInterpolatedAdHocWithHttpAsync(webId, endTime, filterExpression, includeFilteredValues, interval, selectedFields, sortField, sortOrder, startTime, syncTime, syncTimeBoundaryType, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns interpolated values of the specified streams over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="interval">The sampling interval, in AFTimeSpan format.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="syncTime">An optional start time anchor, in AFTime format. When specified, interpolated data retrieval will use the sync time as the origin for calculating the interval times.</param>
		/// <param name="syncTimeBoundaryType">An optional string specifying the boundary type to use when applying a syncTime. The allowed values are 'Inside' and 'Outside'. The default is 'Inside'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetInterpolatedAdHocWithHttp(List<string> webId, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, string interval = null, string selectedFields = null, string sortField = null, string sortOrder = null, string startTime = null, string syncTime = null, string syncTimeBoundaryType = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/interpolated";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("interval", interval);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("syncTime", syncTime);
			urlBuilder.AddQueryParameter("syncTimeBoundaryType", syncTimeBoundaryType);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns interpolated values of the specified streams over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="interval">The sampling interval, in AFTimeSpan format.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="syncTime">An optional start time anchor, in AFTime format. When specified, interpolated data retrieval will use the sync time as the origin for calculating the interval times.</param>
		/// <param name="syncTimeBoundaryType">An optional string specifying the boundary type to use when applying a syncTime. The allowed values are 'Inside' and 'Outside'. The default is 'Inside'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetInterpolatedAdHoc(List<string> webId, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, string interval = null, string selectedFields = null, string sortField = null, string sortOrder = null, string startTime = null, string syncTime = null, string syncTimeBoundaryType = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetInterpolatedAdHocWithHttp(webId, endTime, filterExpression, includeFilteredValues, interval, selectedFields, sortField, sortOrder, startTime, syncTime, syncTimeBoundaryType, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns interpolated values of the specified streams at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="time">The timestamp at which to retrieve a interpolated value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetInterpolatedAtTimesAdHocWithHttpAsync(List<string> time, List<string> webId, string filterExpression = null, bool? includeFilteredValues = null, string selectedFields = null, string sortOrder = null, string timeZone = null, string webIdType = null)
		{
			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/interpolatedattimes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns interpolated values of the specified streams at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="time">The timestamp at which to retrieve a interpolated value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetInterpolatedAtTimesAdHocAsync(List<string> time, List<string> webId, string filterExpression = null, bool? includeFilteredValues = null, string selectedFields = null, string sortOrder = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetInterpolatedAtTimesAdHocWithHttpAsync(time, webId, filterExpression, includeFilteredValues, selectedFields, sortOrder, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns interpolated values of the specified streams at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="time">The timestamp at which to retrieve a interpolated value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetInterpolatedAtTimesAdHocWithHttp(List<string> time, List<string> webId, string filterExpression = null, bool? includeFilteredValues = null, string selectedFields = null, string sortOrder = null, string timeZone = null, string webIdType = null)
		{
			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/interpolatedattimes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns interpolated values of the specified streams at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="time">The timestamp at which to retrieve a interpolated value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetInterpolatedAtTimesAdHoc(List<string> time, List<string> webId, string filterExpression = null, bool? includeFilteredValues = null, string selectedFields = null, string sortOrder = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetInterpolatedAtTimesAdHocWithHttp(time, webId, filterExpression, includeFilteredValues, selectedFields, sortOrder, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns the base stream's recorded values and subordinate streams' interpolated values at times matching the recorded values' timestamps.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream. The first stream in the response is always the X-Axis.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="baseWebId">The ID of the base stream which is used for retrieving the recorded values.</param>
		/// <param name="subordinateWebId">The ID of a stream whose values will be joined on the times with the values of the base stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either place, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetJoinedWithHttpAsync(string baseWebId, List<string> subordinateWebId, string boundaryType = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string selectedFields = null, string startTime = null, string timeZone = null, string webIdType = null)
		{
			if (baseWebId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'baseWebId'");
			}

			if (subordinateWebId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'subordinateWebId'");
			}

			string serviceUrl = "/streamsets/joined";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("baseWebId", baseWebId);
			urlBuilder.AddQueryParameter("subordinateWebId", subordinateWebId);
			urlBuilder.AddQueryParameter("boundaryType", boundaryType);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns the base stream's recorded values and subordinate streams' interpolated values at times matching the recorded values' timestamps.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream. The first stream in the response is always the X-Axis.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="baseWebId">The ID of the base stream which is used for retrieving the recorded values.</param>
		/// <param name="subordinateWebId">The ID of a stream whose values will be joined on the times with the values of the base stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either place, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetJoinedAsync(string baseWebId, List<string> subordinateWebId, string boundaryType = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string selectedFields = null, string startTime = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetJoinedWithHttpAsync(baseWebId, subordinateWebId, boundaryType, endTime, filterExpression, includeFilteredValues, maxCount, selectedFields, startTime, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns the base stream's recorded values and subordinate streams' interpolated values at times matching the recorded values' timestamps.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream. The first stream in the response is always the X-Axis.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="baseWebId">The ID of the base stream which is used for retrieving the recorded values.</param>
		/// <param name="subordinateWebId">The ID of a stream whose values will be joined on the times with the values of the base stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either place, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetJoinedWithHttp(string baseWebId, List<string> subordinateWebId, string boundaryType = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string selectedFields = null, string startTime = null, string timeZone = null, string webIdType = null)
		{
			if (baseWebId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'baseWebId'");
			}

			if (subordinateWebId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'subordinateWebId'");
			}

			string serviceUrl = "/streamsets/joined";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("baseWebId", baseWebId);
			urlBuilder.AddQueryParameter("subordinateWebId", subordinateWebId);
			urlBuilder.AddQueryParameter("boundaryType", boundaryType);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns the base stream's recorded values and subordinate streams' interpolated values at times matching the recorded values' timestamps.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream. The first stream in the response is always the X-Axis.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="baseWebId">The ID of the base stream which is used for retrieving the recorded values.</param>
		/// <param name="subordinateWebId">The ID of a stream whose values will be joined on the times with the values of the base stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either place, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetJoined(string baseWebId, List<string> subordinateWebId, string boundaryType = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string selectedFields = null, string startTime = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetJoinedWithHttp(baseWebId, subordinateWebId, boundaryType, endTime, filterExpression, includeFilteredValues, maxCount, selectedFields, startTime, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns values of attributes for the specified streams over the specified time range suitable for plotting over the number of intervals (typically represents pixels).
		/// </summary>
		/// <remarks>
		/// For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state). Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="intervals">The number of intervals to plot over. Typically, this would be the number of horizontal pixels in the trend. The default is '24'. For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state).</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetPlotAdHocWithHttpAsync(List<string> webId, string endTime = null, int? intervals = null, string selectedFields = null, string sortField = null, string sortOrder = null, string startTime = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/plot";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("intervals", intervals);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns values of attributes for the specified streams over the specified time range suitable for plotting over the number of intervals (typically represents pixels).
		/// </summary>
		/// <remarks>
		/// For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state). Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="intervals">The number of intervals to plot over. Typically, this would be the number of horizontal pixels in the trend. The default is '24'. For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state).</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetPlotAdHocAsync(List<string> webId, string endTime = null, int? intervals = null, string selectedFields = null, string sortField = null, string sortOrder = null, string startTime = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetPlotAdHocWithHttpAsync(webId, endTime, intervals, selectedFields, sortField, sortOrder, startTime, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns values of attributes for the specified streams over the specified time range suitable for plotting over the number of intervals (typically represents pixels).
		/// </summary>
		/// <remarks>
		/// For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state). Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="intervals">The number of intervals to plot over. Typically, this would be the number of horizontal pixels in the trend. The default is '24'. For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state).</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetPlotAdHocWithHttp(List<string> webId, string endTime = null, int? intervals = null, string selectedFields = null, string sortField = null, string sortOrder = null, string startTime = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/plot";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("intervals", intervals);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns values of attributes for the specified streams over the specified time range suitable for plotting over the number of intervals (typically represents pixels).
		/// </summary>
		/// <remarks>
		/// For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state). Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="intervals">The number of intervals to plot over. Typically, this would be the number of horizontal pixels in the trend. The default is '24'. For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state).</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetPlotAdHoc(List<string> webId, string endTime = null, int? intervals = null, string selectedFields = null, string sortField = null, string sortOrder = null, string startTime = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetPlotAdHocWithHttp(webId, endTime, intervals, selectedFields, sortField, sortOrder, startTime, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns recorded values of the specified streams.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetRecordedAdHocWithHttpAsync(List<string> webId, string boundaryType = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string selectedFields = null, string sortField = null, string sortOrder = null, string startTime = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/recorded";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("boundaryType", boundaryType);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns recorded values of the specified streams.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetRecordedAdHocAsync(List<string> webId, string boundaryType = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string selectedFields = null, string sortField = null, string sortOrder = null, string startTime = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetRecordedAdHocWithHttpAsync(webId, boundaryType, endTime, filterExpression, includeFilteredValues, maxCount, selectedFields, sortField, sortOrder, startTime, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns recorded values of the specified streams.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetRecordedAdHocWithHttp(List<string> webId, string boundaryType = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string selectedFields = null, string sortField = null, string sortOrder = null, string startTime = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/recorded";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("boundaryType", boundaryType);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns recorded values of the specified streams.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetRecordedAdHoc(List<string> webId, string boundaryType = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string selectedFields = null, string sortField = null, string sortOrder = null, string startTime = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetRecordedAdHocWithHttp(webId, boundaryType, endTime, filterExpression, includeFilteredValues, maxCount, selectedFields, sortField, sortOrder, startTime, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Updates multiple values for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>HttpApiResponse<PWAItemsItemsSubstatus></returns>
		public async Task<HttpApiResponse<PWAItemsItemsSubstatus>> UpdateValuesAdHocWithHttpAsync(List<PWAStreamValues> values, string bufferOption = null, string updateOption = null)
		{
			if (values == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'values'");
			}

			string serviceUrl = "/streamsets/recorded";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddBody(values);
			urlBuilder.AddQueryParameter("bufferOption", bufferOption);
			urlBuilder.AddQueryParameter("updateOption", updateOption);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsItemsSubstatus response = JsonConvert.DeserializeObject<PWAItemsItemsSubstatus>(httpContent);
			return new HttpApiResponse<PWAItemsItemsSubstatus>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Updates multiple values for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>PWAItemsItemsSubstatus</returns>
		public async Task<PWAItemsItemsSubstatus> UpdateValuesAdHocAsync(List<PWAStreamValues> values, string bufferOption = null, string updateOption = null)
		{
			return (await this.UpdateValuesAdHocWithHttpAsync(values, bufferOption, updateOption)).Data;
		}

		/// <summary>
		/// Updates multiple values for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>HttpApiResponse<PWAItemsItemsSubstatus></returns>
		public HttpApiResponse<PWAItemsItemsSubstatus> UpdateValuesAdHocWithHttp(List<PWAStreamValues> values, string bufferOption = null, string updateOption = null)
		{
			if (values == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'values'");
			}

			string serviceUrl = "/streamsets/recorded";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddBody(values);
			urlBuilder.AddQueryParameter("bufferOption", bufferOption);
			urlBuilder.AddQueryParameter("updateOption", updateOption);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsItemsSubstatus response = JsonConvert.DeserializeObject<PWAItemsItemsSubstatus>(httpContent);
			return new HttpApiResponse<PWAItemsItemsSubstatus>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Updates multiple values for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>PWAItemsItemsSubstatus</returns>
		public PWAItemsItemsSubstatus UpdateValuesAdHoc(List<PWAStreamValues> values, string bufferOption = null, string updateOption = null)
		{
			return (this.UpdateValuesAdHocWithHttp(values, bufferOption, updateOption)).Data;
		}

		/// <summary>
		/// Returns recorded values based on the passed time and retrieval mode.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="time">The timestamp at which the values are desired.</param>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValue>> GetRecordedAtTimeAdHocWithHttpAsync(string time, List<string> webId, string retrievalMode = null, string selectedFields = null, string timeZone = null, string webIdType = null)
		{
			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/recordedattime";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("retrievalMode", retrievalMode);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns recorded values based on the passed time and retrieval mode.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="time">The timestamp at which the values are desired.</param>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public async Task<PWAItemsStreamValue> GetRecordedAtTimeAdHocAsync(string time, List<string> webId, string retrievalMode = null, string selectedFields = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetRecordedAtTimeAdHocWithHttpAsync(time, webId, retrievalMode, selectedFields, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns recorded values based on the passed time and retrieval mode.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="time">The timestamp at which the values are desired.</param>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public HttpApiResponse<PWAItemsStreamValue> GetRecordedAtTimeAdHocWithHttp(string time, List<string> webId, string retrievalMode = null, string selectedFields = null, string timeZone = null, string webIdType = null)
		{
			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/recordedattime";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("retrievalMode", retrievalMode);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns recorded values based on the passed time and retrieval mode.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="time">The timestamp at which the values are desired.</param>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public PWAItemsStreamValue GetRecordedAtTimeAdHoc(string time, List<string> webId, string retrievalMode = null, string selectedFields = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetRecordedAtTimeAdHocWithHttp(time, webId, retrievalMode, selectedFields, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns recorded values of the specified streams at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="time">The timestamp at which to retrieve a recorded value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetRecordedAtTimesAdHocWithHttpAsync(List<string> time, List<string> webId, string retrievalMode = null, string selectedFields = null, string sortOrder = null, string timeZone = null, string webIdType = null)
		{
			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/recordedattimes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("retrievalMode", retrievalMode);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns recorded values of the specified streams at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="time">The timestamp at which to retrieve a recorded value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetRecordedAtTimesAdHocAsync(List<string> time, List<string> webId, string retrievalMode = null, string selectedFields = null, string sortOrder = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetRecordedAtTimesAdHocWithHttpAsync(time, webId, retrievalMode, selectedFields, sortOrder, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns recorded values of the specified streams at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="time">The timestamp at which to retrieve a recorded value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetRecordedAtTimesAdHocWithHttp(List<string> time, List<string> webId, string retrievalMode = null, string selectedFields = null, string sortOrder = null, string timeZone = null, string webIdType = null)
		{
			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/recordedattimes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("retrievalMode", retrievalMode);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns recorded values of the specified streams at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="time">The timestamp at which to retrieve a recorded value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetRecordedAtTimesAdHoc(List<string> time, List<string> webId, string retrievalMode = null, string selectedFields = null, string sortOrder = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetRecordedAtTimesAdHocWithHttp(time, webId, retrievalMode, selectedFields, sortOrder, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns summary values of the specified streams.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="calculationBasis">Specifies the method of evaluating the data over the time range. The default is 'TimeWeighted'.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">A string containing a filter expression. Expression variables are relative to the attribute. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="sampleInterval">A time span specifies how often the filter expression is evaluated when computing the summary for an interval, if the sampleType is 'Interval'.</param>
		/// <param name="sampleType">A flag which specifies one or more summaries to compute for each interval over the time range. The default is 'ExpressionRecordedValues'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="summaryDuration">The duration of each summary interval.</param>
		/// <param name="summaryType">Specifies the kinds of summaries to produce over the range. The default is 'Total'. Multiple summary types may be specified by using multiple instances of summaryType.</param>
		/// <param name="timeType">Specifies how to calculate the timestamp for each interval. The default is 'Auto'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamSummaries></returns>
		public async Task<HttpApiResponse<PWAItemsStreamSummaries>> GetSummariesAdHocWithHttpAsync(List<string> webId, string calculationBasis = null, string endTime = null, string filterExpression = null, string sampleInterval = null, string sampleType = null, string selectedFields = null, string startTime = null, string summaryDuration = null, List<string> summaryType = null, string timeType = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/summary";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("calculationBasis", calculationBasis);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("sampleInterval", sampleInterval);
			urlBuilder.AddQueryParameter("sampleType", sampleType);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("summaryDuration", summaryDuration);
			urlBuilder.AddQueryParameter("summaryType", summaryType);
			urlBuilder.AddQueryParameter("timeType", timeType);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamSummaries response = JsonConvert.DeserializeObject<PWAItemsStreamSummaries>(httpContent);
			return new HttpApiResponse<PWAItemsStreamSummaries>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns summary values of the specified streams.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="calculationBasis">Specifies the method of evaluating the data over the time range. The default is 'TimeWeighted'.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">A string containing a filter expression. Expression variables are relative to the attribute. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="sampleInterval">A time span specifies how often the filter expression is evaluated when computing the summary for an interval, if the sampleType is 'Interval'.</param>
		/// <param name="sampleType">A flag which specifies one or more summaries to compute for each interval over the time range. The default is 'ExpressionRecordedValues'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="summaryDuration">The duration of each summary interval.</param>
		/// <param name="summaryType">Specifies the kinds of summaries to produce over the range. The default is 'Total'. Multiple summary types may be specified by using multiple instances of summaryType.</param>
		/// <param name="timeType">Specifies how to calculate the timestamp for each interval. The default is 'Auto'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamSummaries</returns>
		public async Task<PWAItemsStreamSummaries> GetSummariesAdHocAsync(List<string> webId, string calculationBasis = null, string endTime = null, string filterExpression = null, string sampleInterval = null, string sampleType = null, string selectedFields = null, string startTime = null, string summaryDuration = null, List<string> summaryType = null, string timeType = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetSummariesAdHocWithHttpAsync(webId, calculationBasis, endTime, filterExpression, sampleInterval, sampleType, selectedFields, startTime, summaryDuration, summaryType, timeType, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns summary values of the specified streams.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="calculationBasis">Specifies the method of evaluating the data over the time range. The default is 'TimeWeighted'.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">A string containing a filter expression. Expression variables are relative to the attribute. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="sampleInterval">A time span specifies how often the filter expression is evaluated when computing the summary for an interval, if the sampleType is 'Interval'.</param>
		/// <param name="sampleType">A flag which specifies one or more summaries to compute for each interval over the time range. The default is 'ExpressionRecordedValues'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="summaryDuration">The duration of each summary interval.</param>
		/// <param name="summaryType">Specifies the kinds of summaries to produce over the range. The default is 'Total'. Multiple summary types may be specified by using multiple instances of summaryType.</param>
		/// <param name="timeType">Specifies how to calculate the timestamp for each interval. The default is 'Auto'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamSummaries></returns>
		public HttpApiResponse<PWAItemsStreamSummaries> GetSummariesAdHocWithHttp(List<string> webId, string calculationBasis = null, string endTime = null, string filterExpression = null, string sampleInterval = null, string sampleType = null, string selectedFields = null, string startTime = null, string summaryDuration = null, List<string> summaryType = null, string timeType = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/summary";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("calculationBasis", calculationBasis);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("sampleInterval", sampleInterval);
			urlBuilder.AddQueryParameter("sampleType", sampleType);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("summaryDuration", summaryDuration);
			urlBuilder.AddQueryParameter("summaryType", summaryType);
			urlBuilder.AddQueryParameter("timeType", timeType);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamSummaries response = JsonConvert.DeserializeObject<PWAItemsStreamSummaries>(httpContent);
			return new HttpApiResponse<PWAItemsStreamSummaries>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns summary values of the specified streams.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="calculationBasis">Specifies the method of evaluating the data over the time range. The default is 'TimeWeighted'.</param>
		/// <param name="endTime">An optional end time. The default is '*'. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">A string containing a filter expression. Expression variables are relative to the attribute. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="sampleInterval">A time span specifies how often the filter expression is evaluated when computing the summary for an interval, if the sampleType is 'Interval'.</param>
		/// <param name="sampleType">A flag which specifies one or more summaries to compute for each interval over the time range. The default is 'ExpressionRecordedValues'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d'.</param>
		/// <param name="summaryDuration">The duration of each summary interval.</param>
		/// <param name="summaryType">Specifies the kinds of summaries to produce over the range. The default is 'Total'. Multiple summary types may be specified by using multiple instances of summaryType.</param>
		/// <param name="timeType">Specifies how to calculate the timestamp for each interval. The default is 'Auto'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamSummaries</returns>
		public PWAItemsStreamSummaries GetSummariesAdHoc(List<string> webId, string calculationBasis = null, string endTime = null, string filterExpression = null, string sampleInterval = null, string sampleType = null, string selectedFields = null, string startTime = null, string summaryDuration = null, List<string> summaryType = null, string timeType = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetSummariesAdHocWithHttp(webId, calculationBasis, endTime, filterExpression, sampleInterval, sampleType, selectedFields, startTime, summaryDuration, summaryType, timeType, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Receive stream updates
		/// </summary>
		/// <remarks>
		/// The supplied markers will identify the set of stream updates to retrieve. For a 200 response, the returned location header will contain the url for retrieving the stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="marker">Identifier of stream source and current position. Multiple markers may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamUpdatesRetrieve></returns>
		public async Task<HttpApiResponse<PWAItemsStreamUpdatesRetrieve>> RetrieveStreamSetUpdatesWithHttpAsync(List<string> marker, string selectedFields = null, string webIdType = null)
		{
			if (marker == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'marker'");
			}

			string serviceUrl = "/streamsets/updates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("marker", marker);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamUpdatesRetrieve response = JsonConvert.DeserializeObject<PWAItemsStreamUpdatesRetrieve>(httpContent);
			return new HttpApiResponse<PWAItemsStreamUpdatesRetrieve>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Receive stream updates
		/// </summary>
		/// <remarks>
		/// The supplied markers will identify the set of stream updates to retrieve. For a 200 response, the returned location header will contain the url for retrieving the stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="marker">Identifier of stream source and current position. Multiple markers may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamUpdatesRetrieve</returns>
		public async Task<PWAItemsStreamUpdatesRetrieve> RetrieveStreamSetUpdatesAsync(List<string> marker, string selectedFields = null, string webIdType = null)
		{
			return (await this.RetrieveStreamSetUpdatesWithHttpAsync(marker, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Receive stream updates
		/// </summary>
		/// <remarks>
		/// The supplied markers will identify the set of stream updates to retrieve. For a 200 response, the returned location header will contain the url for retrieving the stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="marker">Identifier of stream source and current position. Multiple markers may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamUpdatesRetrieve></returns>
		public HttpApiResponse<PWAItemsStreamUpdatesRetrieve> RetrieveStreamSetUpdatesWithHttp(List<string> marker, string selectedFields = null, string webIdType = null)
		{
			if (marker == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'marker'");
			}

			string serviceUrl = "/streamsets/updates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("marker", marker);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamUpdatesRetrieve response = JsonConvert.DeserializeObject<PWAItemsStreamUpdatesRetrieve>(httpContent);
			return new HttpApiResponse<PWAItemsStreamUpdatesRetrieve>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Receive stream updates
		/// </summary>
		/// <remarks>
		/// The supplied markers will identify the set of stream updates to retrieve. For a 200 response, the returned location header will contain the url for retrieving the stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="marker">Identifier of stream source and current position. Multiple markers may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamUpdatesRetrieve</returns>
		public PWAItemsStreamUpdatesRetrieve RetrieveStreamSetUpdates(List<string> marker, string selectedFields = null, string webIdType = null)
		{
			return (this.RetrieveStreamSetUpdatesWithHttp(marker, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Register for stream updates
		/// </summary>
		/// <remarks>
		/// The supplied webIds will register for stream updates. For a 200 response, the returned location header will contain the url for retrieving the next set of stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamUpdatesRegister></returns>
		public async Task<HttpApiResponse<PWAItemsStreamUpdatesRegister>> RegisterStreamSetUpdatesWithHttpAsync(List<string> webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/updates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamUpdatesRegister response = JsonConvert.DeserializeObject<PWAItemsStreamUpdatesRegister>(httpContent);
			return new HttpApiResponse<PWAItemsStreamUpdatesRegister>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Register for stream updates
		/// </summary>
		/// <remarks>
		/// The supplied webIds will register for stream updates. For a 200 response, the returned location header will contain the url for retrieving the next set of stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamUpdatesRegister</returns>
		public async Task<PWAItemsStreamUpdatesRegister> RegisterStreamSetUpdatesAsync(List<string> webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.RegisterStreamSetUpdatesWithHttpAsync(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Register for stream updates
		/// </summary>
		/// <remarks>
		/// The supplied webIds will register for stream updates. For a 200 response, the returned location header will contain the url for retrieving the next set of stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamUpdatesRegister></returns>
		public HttpApiResponse<PWAItemsStreamUpdatesRegister> RegisterStreamSetUpdatesWithHttp(List<string> webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/updates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamUpdatesRegister response = JsonConvert.DeserializeObject<PWAItemsStreamUpdatesRegister>(httpContent);
			return new HttpApiResponse<PWAItemsStreamUpdatesRegister>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Register for stream updates
		/// </summary>
		/// <remarks>
		/// The supplied webIds will register for stream updates. For a 200 response, the returned location header will contain the url for retrieving the next set of stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamUpdatesRegister</returns>
		public PWAItemsStreamUpdatesRegister RegisterStreamSetUpdates(List<string> webId, string selectedFields = null, string webIdType = null)
		{
			return (this.RegisterStreamSetUpdatesWithHttp(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Returns values of the specified streams.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="time">An AF time string, which is used as the time context to get stream values if it is provided. By default, it is not specified, and the default time context of the AF object will be used.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValue>> GetValuesAdHocWithHttpAsync(List<string> webId, string selectedFields = null, string sortField = null, string sortOrder = null, string time = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/value";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns values of the specified streams.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="time">An AF time string, which is used as the time context to get stream values if it is provided. By default, it is not specified, and the default time context of the AF object will be used.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public async Task<PWAItemsStreamValue> GetValuesAdHocAsync(List<string> webId, string selectedFields = null, string sortField = null, string sortOrder = null, string time = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetValuesAdHocWithHttpAsync(webId, selectedFields, sortField, sortOrder, time, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns values of the specified streams.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="time">An AF time string, which is used as the time context to get stream values if it is provided. By default, it is not specified, and the default time context of the AF object will be used.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public HttpApiResponse<PWAItemsStreamValue> GetValuesAdHocWithHttp(List<string> webId, string selectedFields = null, string sortField = null, string sortOrder = null, string time = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/value";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddQueryParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns values of the specified streams.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of a stream. Multiple streams may be specified with multiple instances of the parameter.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="time">An AF time string, which is used as the time context to get stream values if it is provided. By default, it is not specified, and the default time context of the AF object will be used.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public PWAItemsStreamValue GetValuesAdHoc(List<string> webId, string selectedFields = null, string sortField = null, string sortOrder = null, string time = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetValuesAdHocWithHttp(webId, selectedFields, sortField, sortOrder, time, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Updates a single value for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>HttpApiResponse<PWAItemsSubstatus></returns>
		public async Task<HttpApiResponse<PWAItemsSubstatus>> UpdateValueAdHocWithHttpAsync(List<PWAStreamValue> values, string bufferOption = null, string updateOption = null)
		{
			if (values == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'values'");
			}

			string serviceUrl = "/streamsets/value";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddBody(values);
			urlBuilder.AddQueryParameter("bufferOption", bufferOption);
			urlBuilder.AddQueryParameter("updateOption", updateOption);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsSubstatus response = JsonConvert.DeserializeObject<PWAItemsSubstatus>(httpContent);
			return new HttpApiResponse<PWAItemsSubstatus>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Updates a single value for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>PWAItemsSubstatus</returns>
		public async Task<PWAItemsSubstatus> UpdateValueAdHocAsync(List<PWAStreamValue> values, string bufferOption = null, string updateOption = null)
		{
			return (await this.UpdateValueAdHocWithHttpAsync(values, bufferOption, updateOption)).Data;
		}

		/// <summary>
		/// Updates a single value for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>HttpApiResponse<PWAItemsSubstatus></returns>
		public HttpApiResponse<PWAItemsSubstatus> UpdateValueAdHocWithHttp(List<PWAStreamValue> values, string bufferOption = null, string updateOption = null)
		{
			if (values == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'values'");
			}

			string serviceUrl = "/streamsets/value";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddBody(values);
			urlBuilder.AddQueryParameter("bufferOption", bufferOption);
			urlBuilder.AddQueryParameter("updateOption", updateOption);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsSubstatus response = JsonConvert.DeserializeObject<PWAItemsSubstatus>(httpContent);
			return new HttpApiResponse<PWAItemsSubstatus>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Updates a single value for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>PWAItemsSubstatus</returns>
		public PWAItemsSubstatus UpdateValueAdHoc(List<PWAStreamValue> values, string bufferOption = null, string updateOption = null)
		{
			return (this.UpdateValueAdHocWithHttp(values, bufferOption, updateOption)).Data;
		}

		/// <summary>
		/// Opens a channel that will send messages about any value changes for the attributes of an Element, Event Frame, or Attribute.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an Element, Event Frame or Attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="heartbeatRate">Specifies the maximum number of consecutive empty messages that can be elapsed with no new data updates from the PI System, after which the client receives an empty payload. It helps to check if the connection is still alive. Zero/negative values correspond to no heartbeat, and the default value is no heartbeat.</param>
		/// <param name="includeInitialValues">Specified if the channel should send a message with the current values of all the streams after the connection is opened. The default is 'false'.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValue>> GetChannelWithHttpAsync(string webId, string categoryName = null, int? heartbeatRate = null, bool? includeInitialValues = null, string nameFilter = null, bool? searchFullHierarchy = null, bool? showExcluded = null, bool? showHidden = null, string templateName = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/channel";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("heartbeatRate", heartbeatRate);
			urlBuilder.AddQueryParameter("includeInitialValues", includeInitialValues);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Opens a channel that will send messages about any value changes for the attributes of an Element, Event Frame, or Attribute.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an Element, Event Frame or Attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="heartbeatRate">Specifies the maximum number of consecutive empty messages that can be elapsed with no new data updates from the PI System, after which the client receives an empty payload. It helps to check if the connection is still alive. Zero/negative values correspond to no heartbeat, and the default value is no heartbeat.</param>
		/// <param name="includeInitialValues">Specified if the channel should send a message with the current values of all the streams after the connection is opened. The default is 'false'.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public async Task<PWAItemsStreamValue> GetChannelAsync(string webId, string categoryName = null, int? heartbeatRate = null, bool? includeInitialValues = null, string nameFilter = null, bool? searchFullHierarchy = null, bool? showExcluded = null, bool? showHidden = null, string templateName = null, string webIdType = null)
		{
			return (await this.GetChannelWithHttpAsync(webId, categoryName, heartbeatRate, includeInitialValues, nameFilter, searchFullHierarchy, showExcluded, showHidden, templateName, webIdType)).Data;
		}

		/// <summary>
		/// Opens a channel that will send messages about any value changes for the attributes of an Element, Event Frame, or Attribute.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an Element, Event Frame or Attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="heartbeatRate">Specifies the maximum number of consecutive empty messages that can be elapsed with no new data updates from the PI System, after which the client receives an empty payload. It helps to check if the connection is still alive. Zero/negative values correspond to no heartbeat, and the default value is no heartbeat.</param>
		/// <param name="includeInitialValues">Specified if the channel should send a message with the current values of all the streams after the connection is opened. The default is 'false'.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public HttpApiResponse<PWAItemsStreamValue> GetChannelWithHttp(string webId, string categoryName = null, int? heartbeatRate = null, bool? includeInitialValues = null, string nameFilter = null, bool? searchFullHierarchy = null, bool? showExcluded = null, bool? showHidden = null, string templateName = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/channel";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("heartbeatRate", heartbeatRate);
			urlBuilder.AddQueryParameter("includeInitialValues", includeInitialValues);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Opens a channel that will send messages about any value changes for the attributes of an Element, Event Frame, or Attribute.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an Element, Event Frame or Attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="heartbeatRate">Specifies the maximum number of consecutive empty messages that can be elapsed with no new data updates from the PI System, after which the client receives an empty payload. It helps to check if the connection is still alive. Zero/negative values correspond to no heartbeat, and the default value is no heartbeat.</param>
		/// <param name="includeInitialValues">Specified if the channel should send a message with the current values of all the streams after the connection is opened. The default is 'false'.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public PWAItemsStreamValue GetChannel(string webId, string categoryName = null, int? heartbeatRate = null, bool? includeInitialValues = null, string nameFilter = null, bool? searchFullHierarchy = null, bool? showExcluded = null, bool? showHidden = null, string templateName = null, string webIdType = null)
		{
			return (this.GetChannelWithHttp(webId, categoryName, heartbeatRate, includeInitialValues, nameFilter, searchFullHierarchy, showExcluded, showHidden, templateName, webIdType)).Data;
		}

		/// <summary>
		/// Returns End of stream values of the attributes for an Element, Event Frame or Attribute
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an Element, Event Frame or Attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValue>> GetEndWithHttpAsync(string webId, string categoryName = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string templateName = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/end";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns End of stream values of the attributes for an Element, Event Frame or Attribute
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an Element, Event Frame or Attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public async Task<PWAItemsStreamValue> GetEndAsync(string webId, string categoryName = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string templateName = null, string webIdType = null)
		{
			return (await this.GetEndWithHttpAsync(webId, categoryName, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortField, sortOrder, templateName, webIdType)).Data;
		}

		/// <summary>
		/// Returns End of stream values of the attributes for an Element, Event Frame or Attribute
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an Element, Event Frame or Attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public HttpApiResponse<PWAItemsStreamValue> GetEndWithHttp(string webId, string categoryName = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string templateName = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/end";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns End of stream values of the attributes for an Element, Event Frame or Attribute
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an Element, Event Frame or Attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public PWAItemsStreamValue GetEnd(string webId, string categoryName = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string templateName = null, string webIdType = null)
		{
			return (this.GetEndWithHttp(webId, categoryName, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortField, sortOrder, templateName, webIdType)).Data;
		}

		/// <summary>
		/// Returns interpolated values of attributes for an element, event frame or attribute over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="interval">The sampling interval, in AFTimeSpan format.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="syncTime">An optional start time anchor, in AFTime format. When specified, interpolated data retrieval will use the sync time as the origin for calculating the interval times.</param>
		/// <param name="syncTimeBoundaryType">An optional string specifying the boundary type to use when applying a syncTime. The allowed values are 'Inside' and 'Outside'. The default is 'Inside'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetInterpolatedWithHttpAsync(string webId, string categoryName = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, string interval = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string startTime = null, string syncTime = null, string syncTimeBoundaryType = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/interpolated";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("interval", interval);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("syncTime", syncTime);
			urlBuilder.AddQueryParameter("syncTimeBoundaryType", syncTimeBoundaryType);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns interpolated values of attributes for an element, event frame or attribute over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="interval">The sampling interval, in AFTimeSpan format.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="syncTime">An optional start time anchor, in AFTime format. When specified, interpolated data retrieval will use the sync time as the origin for calculating the interval times.</param>
		/// <param name="syncTimeBoundaryType">An optional string specifying the boundary type to use when applying a syncTime. The allowed values are 'Inside' and 'Outside'. The default is 'Inside'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetInterpolatedAsync(string webId, string categoryName = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, string interval = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string startTime = null, string syncTime = null, string syncTimeBoundaryType = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetInterpolatedWithHttpAsync(webId, categoryName, endTime, filterExpression, includeFilteredValues, interval, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortField, sortOrder, startTime, syncTime, syncTimeBoundaryType, templateName, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns interpolated values of attributes for an element, event frame or attribute over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="interval">The sampling interval, in AFTimeSpan format.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="syncTime">An optional start time anchor, in AFTime format. When specified, interpolated data retrieval will use the sync time as the origin for calculating the interval times.</param>
		/// <param name="syncTimeBoundaryType">An optional string specifying the boundary type to use when applying a syncTime. The allowed values are 'Inside' and 'Outside'. The default is 'Inside'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetInterpolatedWithHttp(string webId, string categoryName = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, string interval = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string startTime = null, string syncTime = null, string syncTimeBoundaryType = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/interpolated";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("interval", interval);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("syncTime", syncTime);
			urlBuilder.AddQueryParameter("syncTimeBoundaryType", syncTimeBoundaryType);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns interpolated values of attributes for an element, event frame or attribute over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="interval">The sampling interval, in AFTimeSpan format.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="syncTime">An optional start time anchor, in AFTime format. When specified, interpolated data retrieval will use the sync time as the origin for calculating the interval times.</param>
		/// <param name="syncTimeBoundaryType">An optional string specifying the boundary type to use when applying a syncTime. The allowed values are 'Inside' and 'Outside'. The default is 'Inside'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetInterpolated(string webId, string categoryName = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, string interval = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string startTime = null, string syncTime = null, string syncTimeBoundaryType = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetInterpolatedWithHttp(webId, categoryName, endTime, filterExpression, includeFilteredValues, interval, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortField, sortOrder, startTime, syncTime, syncTimeBoundaryType, templateName, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns interpolated values of attributes for an element, event frame or attribute at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="time">The timestamp at which to retrieve a interpolated value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetInterpolatedAtTimesWithHttpAsync(string webId, List<string> time, string categoryName = null, string filterExpression = null, bool? includeFilteredValues = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortOrder = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			string serviceUrl = "/streamsets/{webId}/interpolatedattimes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns interpolated values of attributes for an element, event frame or attribute at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="time">The timestamp at which to retrieve a interpolated value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetInterpolatedAtTimesAsync(string webId, List<string> time, string categoryName = null, string filterExpression = null, bool? includeFilteredValues = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortOrder = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetInterpolatedAtTimesWithHttpAsync(webId, time, categoryName, filterExpression, includeFilteredValues, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortOrder, templateName, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns interpolated values of attributes for an element, event frame or attribute at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="time">The timestamp at which to retrieve a interpolated value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetInterpolatedAtTimesWithHttp(string webId, List<string> time, string categoryName = null, string filterExpression = null, bool? includeFilteredValues = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortOrder = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			string serviceUrl = "/streamsets/{webId}/interpolatedattimes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns interpolated values of attributes for an element, event frame or attribute at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="time">The timestamp at which to retrieve a interpolated value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetInterpolatedAtTimes(string webId, List<string> time, string categoryName = null, string filterExpression = null, bool? includeFilteredValues = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortOrder = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetInterpolatedAtTimesWithHttp(webId, time, categoryName, filterExpression, includeFilteredValues, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortOrder, templateName, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns values of attributes for an element, event frame or attribute over the specified time range suitable for plotting over the number of intervals (typically represents pixels).
		/// </summary>
		/// <remarks>
		/// For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state). Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="intervals">The number of intervals to plot over. Typically, this would be the number of horizontal pixels in the trend. The default is '24'. For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state).</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetPlotWithHttpAsync(string webId, string categoryName = null, string endTime = null, int? intervals = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string startTime = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/plot";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("intervals", intervals);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns values of attributes for an element, event frame or attribute over the specified time range suitable for plotting over the number of intervals (typically represents pixels).
		/// </summary>
		/// <remarks>
		/// For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state). Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="intervals">The number of intervals to plot over. Typically, this would be the number of horizontal pixels in the trend. The default is '24'. For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state).</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetPlotAsync(string webId, string categoryName = null, string endTime = null, int? intervals = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string startTime = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetPlotWithHttpAsync(webId, categoryName, endTime, intervals, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortField, sortOrder, startTime, templateName, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns values of attributes for an element, event frame or attribute over the specified time range suitable for plotting over the number of intervals (typically represents pixels).
		/// </summary>
		/// <remarks>
		/// For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state). Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="intervals">The number of intervals to plot over. Typically, this would be the number of horizontal pixels in the trend. The default is '24'. For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state).</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetPlotWithHttp(string webId, string categoryName = null, string endTime = null, int? intervals = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string startTime = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/plot";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("intervals", intervals);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns values of attributes for an element, event frame or attribute over the specified time range suitable for plotting over the number of intervals (typically represents pixels).
		/// </summary>
		/// <remarks>
		/// For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state). Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="intervals">The number of intervals to plot over. Typically, this would be the number of horizontal pixels in the trend. The default is '24'. For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state).</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetPlot(string webId, string categoryName = null, string endTime = null, int? intervals = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string startTime = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetPlotWithHttp(webId, categoryName, endTime, intervals, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortField, sortOrder, startTime, templateName, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns recorded values of the attributes for an element, event frame, or attribute.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetRecordedWithHttpAsync(string webId, string boundaryType = null, string categoryName = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string startTime = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/recorded";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("boundaryType", boundaryType);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns recorded values of the attributes for an element, event frame, or attribute.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetRecordedAsync(string webId, string boundaryType = null, string categoryName = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string startTime = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetRecordedWithHttpAsync(webId, boundaryType, categoryName, endTime, filterExpression, includeFilteredValues, maxCount, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortField, sortOrder, startTime, templateName, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns recorded values of the attributes for an element, event frame, or attribute.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetRecordedWithHttp(string webId, string boundaryType = null, string categoryName = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string startTime = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/recorded";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("boundaryType", boundaryType);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns recorded values of the attributes for an element, event frame, or attribute.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetRecorded(string webId, string boundaryType = null, string categoryName = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string startTime = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetRecordedWithHttp(webId, boundaryType, categoryName, endTime, filterExpression, includeFilteredValues, maxCount, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortField, sortOrder, startTime, templateName, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Updates multiple values for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the parent element, event frame, or attribute. Attributes specified in the body must be descendants of the specified object.</param>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>HttpApiResponse<PWAItemsItemsSubstatus></returns>
		public async Task<HttpApiResponse<PWAItemsItemsSubstatus>> UpdateValuesWithHttpAsync(string webId, List<PWAStreamValues> values, string bufferOption = null, string updateOption = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (values == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'values'");
			}

			string serviceUrl = "/streamsets/{webId}/recorded";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(values);
			urlBuilder.AddQueryParameter("bufferOption", bufferOption);
			urlBuilder.AddQueryParameter("updateOption", updateOption);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsItemsSubstatus response = JsonConvert.DeserializeObject<PWAItemsItemsSubstatus>(httpContent);
			return new HttpApiResponse<PWAItemsItemsSubstatus>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Updates multiple values for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the parent element, event frame, or attribute. Attributes specified in the body must be descendants of the specified object.</param>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>PWAItemsItemsSubstatus</returns>
		public async Task<PWAItemsItemsSubstatus> UpdateValuesAsync(string webId, List<PWAStreamValues> values, string bufferOption = null, string updateOption = null)
		{
			return (await this.UpdateValuesWithHttpAsync(webId, values, bufferOption, updateOption)).Data;
		}

		/// <summary>
		/// Updates multiple values for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the parent element, event frame, or attribute. Attributes specified in the body must be descendants of the specified object.</param>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>HttpApiResponse<PWAItemsItemsSubstatus></returns>
		public HttpApiResponse<PWAItemsItemsSubstatus> UpdateValuesWithHttp(string webId, List<PWAStreamValues> values, string bufferOption = null, string updateOption = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (values == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'values'");
			}

			string serviceUrl = "/streamsets/{webId}/recorded";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(values);
			urlBuilder.AddQueryParameter("bufferOption", bufferOption);
			urlBuilder.AddQueryParameter("updateOption", updateOption);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsItemsSubstatus response = JsonConvert.DeserializeObject<PWAItemsItemsSubstatus>(httpContent);
			return new HttpApiResponse<PWAItemsItemsSubstatus>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Updates multiple values for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the parent element, event frame, or attribute. Attributes specified in the body must be descendants of the specified object.</param>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>PWAItemsItemsSubstatus</returns>
		public PWAItemsItemsSubstatus UpdateValues(string webId, List<PWAStreamValues> values, string bufferOption = null, string updateOption = null)
		{
			return (this.UpdateValuesWithHttp(webId, values, bufferOption, updateOption)).Data;
		}

		/// <summary>
		/// Returns recorded values of the attributes for an element, event frame, or attribute.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="time">The timestamp at which the values are desired.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValue>> GetRecordedAtTimeWithHttpAsync(string webId, string time, string categoryName = null, string nameFilter = null, string retrievalMode = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			string serviceUrl = "/streamsets/{webId}/recordedattime";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("retrievalMode", retrievalMode);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns recorded values of the attributes for an element, event frame, or attribute.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="time">The timestamp at which the values are desired.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public async Task<PWAItemsStreamValue> GetRecordedAtTimeAsync(string webId, string time, string categoryName = null, string nameFilter = null, string retrievalMode = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetRecordedAtTimeWithHttpAsync(webId, time, categoryName, nameFilter, retrievalMode, searchFullHierarchy, selectedFields, showExcluded, showHidden, templateName, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns recorded values of the attributes for an element, event frame, or attribute.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="time">The timestamp at which the values are desired.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public HttpApiResponse<PWAItemsStreamValue> GetRecordedAtTimeWithHttp(string webId, string time, string categoryName = null, string nameFilter = null, string retrievalMode = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			string serviceUrl = "/streamsets/{webId}/recordedattime";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("retrievalMode", retrievalMode);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns recorded values of the attributes for an element, event frame, or attribute.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="time">The timestamp at which the values are desired.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public PWAItemsStreamValue GetRecordedAtTime(string webId, string time, string categoryName = null, string nameFilter = null, string retrievalMode = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetRecordedAtTimeWithHttp(webId, time, categoryName, nameFilter, retrievalMode, searchFullHierarchy, selectedFields, showExcluded, showHidden, templateName, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns recorded values of attributes for an element, event frame or attribute at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="time">The timestamp at which to retrieve a recorded value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetRecordedAtTimesWithHttpAsync(string webId, List<string> time, string categoryName = null, string nameFilter = null, string retrievalMode = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortOrder = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			string serviceUrl = "/streamsets/{webId}/recordedattimes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("retrievalMode", retrievalMode);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns recorded values of attributes for an element, event frame or attribute at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="time">The timestamp at which to retrieve a recorded value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetRecordedAtTimesAsync(string webId, List<string> time, string categoryName = null, string nameFilter = null, string retrievalMode = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortOrder = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetRecordedAtTimesWithHttpAsync(webId, time, categoryName, nameFilter, retrievalMode, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortOrder, templateName, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns recorded values of attributes for an element, event frame or attribute at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="time">The timestamp at which to retrieve a recorded value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetRecordedAtTimesWithHttp(string webId, List<string> time, string categoryName = null, string nameFilter = null, string retrievalMode = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortOrder = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			string serviceUrl = "/streamsets/{webId}/recordedattimes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("retrievalMode", retrievalMode);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValues response = JsonConvert.DeserializeObject<PWAItemsStreamValues>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns recorded values of attributes for an element, event frame or attribute at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="time">The timestamp at which to retrieve a recorded value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="retrievalMode">An optional value that determines the values to return when values don't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetRecordedAtTimes(string webId, List<string> time, string categoryName = null, string nameFilter = null, string retrievalMode = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortOrder = null, string templateName = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetRecordedAtTimesWithHttp(webId, time, categoryName, nameFilter, retrievalMode, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortOrder, templateName, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns summary values of the attributes for an element, event frame or attribute.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="calculationBasis">Specifies the method of evaluating the data over the time range. The default is 'TimeWeighted'.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">A string containing a filter expression. Expression variables are relative to the attribute. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="sampleInterval">A time span specifies how often the filter expression is evaluated when computing the summary for an interval, if the sampleType is 'Interval'.</param>
		/// <param name="sampleType">A flag which specifies one or more summaries to compute for each interval over the time range. The default is 'ExpressionRecordedValues'.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="summaryDuration">The duration of each summary interval.</param>
		/// <param name="summaryType">Specifies the kinds of summaries to produce over the range. The default is 'Total'. Multiple summary types may be specified by using multiple instances of summaryType.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeType">Specifies how to calculate the timestamp for each interval. The default is 'Auto'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamSummaries></returns>
		public async Task<HttpApiResponse<PWAItemsStreamSummaries>> GetSummariesWithHttpAsync(string webId, string calculationBasis = null, string categoryName = null, string endTime = null, string filterExpression = null, string nameFilter = null, string sampleInterval = null, string sampleType = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string startTime = null, string summaryDuration = null, List<string> summaryType = null, string templateName = null, string timeType = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/summary";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("calculationBasis", calculationBasis);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("sampleInterval", sampleInterval);
			urlBuilder.AddQueryParameter("sampleType", sampleType);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("summaryDuration", summaryDuration);
			urlBuilder.AddQueryParameter("summaryType", summaryType);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeType", timeType);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamSummaries response = JsonConvert.DeserializeObject<PWAItemsStreamSummaries>(httpContent);
			return new HttpApiResponse<PWAItemsStreamSummaries>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns summary values of the attributes for an element, event frame or attribute.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="calculationBasis">Specifies the method of evaluating the data over the time range. The default is 'TimeWeighted'.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">A string containing a filter expression. Expression variables are relative to the attribute. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="sampleInterval">A time span specifies how often the filter expression is evaluated when computing the summary for an interval, if the sampleType is 'Interval'.</param>
		/// <param name="sampleType">A flag which specifies one or more summaries to compute for each interval over the time range. The default is 'ExpressionRecordedValues'.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="summaryDuration">The duration of each summary interval.</param>
		/// <param name="summaryType">Specifies the kinds of summaries to produce over the range. The default is 'Total'. Multiple summary types may be specified by using multiple instances of summaryType.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeType">Specifies how to calculate the timestamp for each interval. The default is 'Auto'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamSummaries</returns>
		public async Task<PWAItemsStreamSummaries> GetSummariesAsync(string webId, string calculationBasis = null, string categoryName = null, string endTime = null, string filterExpression = null, string nameFilter = null, string sampleInterval = null, string sampleType = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string startTime = null, string summaryDuration = null, List<string> summaryType = null, string templateName = null, string timeType = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetSummariesWithHttpAsync(webId, calculationBasis, categoryName, endTime, filterExpression, nameFilter, sampleInterval, sampleType, searchFullHierarchy, selectedFields, showExcluded, showHidden, startTime, summaryDuration, summaryType, templateName, timeType, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns summary values of the attributes for an element, event frame or attribute.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="calculationBasis">Specifies the method of evaluating the data over the time range. The default is 'TimeWeighted'.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">A string containing a filter expression. Expression variables are relative to the attribute. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="sampleInterval">A time span specifies how often the filter expression is evaluated when computing the summary for an interval, if the sampleType is 'Interval'.</param>
		/// <param name="sampleType">A flag which specifies one or more summaries to compute for each interval over the time range. The default is 'ExpressionRecordedValues'.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="summaryDuration">The duration of each summary interval.</param>
		/// <param name="summaryType">Specifies the kinds of summaries to produce over the range. The default is 'Total'. Multiple summary types may be specified by using multiple instances of summaryType.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeType">Specifies how to calculate the timestamp for each interval. The default is 'Auto'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamSummaries></returns>
		public HttpApiResponse<PWAItemsStreamSummaries> GetSummariesWithHttp(string webId, string calculationBasis = null, string categoryName = null, string endTime = null, string filterExpression = null, string nameFilter = null, string sampleInterval = null, string sampleType = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string startTime = null, string summaryDuration = null, List<string> summaryType = null, string templateName = null, string timeType = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/summary";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("calculationBasis", calculationBasis);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("sampleInterval", sampleInterval);
			urlBuilder.AddQueryParameter("sampleType", sampleType);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("summaryDuration", summaryDuration);
			urlBuilder.AddQueryParameter("summaryType", summaryType);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("timeType", timeType);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamSummaries response = JsonConvert.DeserializeObject<PWAItemsStreamSummaries>(httpContent);
			return new HttpApiResponse<PWAItemsStreamSummaries>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns summary values of the attributes for an element, event frame or attribute.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an element, event frame or attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="calculationBasis">Specifies the method of evaluating the data over the time range. The default is 'TimeWeighted'.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">A string containing a filter expression. Expression variables are relative to the attribute. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="sampleInterval">A time span specifies how often the filter expression is evaluated when computing the summary for an interval, if the sampleType is 'Interval'.</param>
		/// <param name="sampleType">A flag which specifies one or more summaries to compute for each interval over the time range. The default is 'ExpressionRecordedValues'.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="summaryDuration">The duration of each summary interval.</param>
		/// <param name="summaryType">Specifies the kinds of summaries to produce over the range. The default is 'Total'. Multiple summary types may be specified by using multiple instances of summaryType.</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="timeType">Specifies how to calculate the timestamp for each interval. The default is 'Auto'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamSummaries</returns>
		public PWAItemsStreamSummaries GetSummaries(string webId, string calculationBasis = null, string categoryName = null, string endTime = null, string filterExpression = null, string nameFilter = null, string sampleInterval = null, string sampleType = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string startTime = null, string summaryDuration = null, List<string> summaryType = null, string templateName = null, string timeType = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetSummariesWithHttp(webId, calculationBasis, categoryName, endTime, filterExpression, nameFilter, sampleInterval, sampleType, searchFullHierarchy, selectedFields, showExcluded, showHidden, startTime, summaryDuration, summaryType, templateName, timeType, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns values of the attributes for an Element, Event Frame or Attribute at the specified time.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an Element, Event Frame or Attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="time">An AF time string, which is used as the time context to get stream values if it is provided. By default, it is not specified, and the default time context of the AF object will be used.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValue>> GetValuesWithHttpAsync(string webId, string categoryName = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string templateName = null, string time = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/value";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns values of the attributes for an Element, Event Frame or Attribute at the specified time.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an Element, Event Frame or Attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="time">An AF time string, which is used as the time context to get stream values if it is provided. By default, it is not specified, and the default time context of the AF object will be used.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public async Task<PWAItemsStreamValue> GetValuesAsync(string webId, string categoryName = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string templateName = null, string time = null, string timeZone = null, string webIdType = null)
		{
			return (await this.GetValuesWithHttpAsync(webId, categoryName, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortField, sortOrder, templateName, time, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Returns values of the attributes for an Element, Event Frame or Attribute at the specified time.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an Element, Event Frame or Attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="time">An AF time string, which is used as the time context to get stream values if it is provided. By default, it is not specified, and the default time context of the AF object will be used.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValue></returns>
		public HttpApiResponse<PWAItemsStreamValue> GetValuesWithHttp(string webId, string categoryName = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string templateName = null, string time = null, string timeZone = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streamsets/{webId}/value";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("categoryName", categoryName);
			urlBuilder.AddQueryParameter("nameFilter", nameFilter);
			urlBuilder.AddQueryParameter("searchFullHierarchy", searchFullHierarchy);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("showExcluded", showExcluded);
			urlBuilder.AddQueryParameter("showHidden", showHidden);
			urlBuilder.AddQueryParameter("sortField", sortField);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("templateName", templateName);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsStreamValue response = JsonConvert.DeserializeObject<PWAItemsStreamValue>(httpContent);
			return new HttpApiResponse<PWAItemsStreamValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns values of the attributes for an Element, Event Frame or Attribute at the specified time.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of an Element, Event Frame or Attribute, which is the base element or parent of all the stream attributes.</param>
		/// <param name="categoryName">Specify that included attributes must have this category. The default is no category filter.</param>
		/// <param name="nameFilter">The name query string used for filtering attributes. The default is no filter.</param>
		/// <param name="searchFullHierarchy">Specifies if the search should include attributes nested further than the immediate attributes of the searchRoot. The default is 'false'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="showExcluded">Specified if the search should include attributes with the Excluded property set. The default is 'false'.</param>
		/// <param name="showHidden">Specified if the search should include attributes with the Hidden property set. The default is 'false'.</param>
		/// <param name="sortField">The field or property of the object used to sort the returned collection. For better performance, by default no sorting is applied. 'Name' is the only supported field by which to sort.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'</param>
		/// <param name="templateName">Specify that included attributes must be members of this template. The default is no template filter.</param>
		/// <param name="time">An AF time string, which is used as the time context to get stream values if it is provided. By default, it is not specified, and the default time context of the AF object will be used.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValue</returns>
		public PWAItemsStreamValue GetValues(string webId, string categoryName = null, string nameFilter = null, bool? searchFullHierarchy = null, string selectedFields = null, bool? showExcluded = null, bool? showHidden = null, string sortField = null, string sortOrder = null, string templateName = null, string time = null, string timeZone = null, string webIdType = null)
		{
			return (this.GetValuesWithHttp(webId, categoryName, nameFilter, searchFullHierarchy, selectedFields, showExcluded, showHidden, sortField, sortOrder, templateName, time, timeZone, webIdType)).Data;
		}

		/// <summary>
		/// Updates a single value for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the parent element, event frame, or attribute. Attributes specified in the body must be descendants of the specified object.</param>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>HttpApiResponse<PWAItemsSubstatus></returns>
		public async Task<HttpApiResponse<PWAItemsSubstatus>> UpdateValueWithHttpAsync(string webId, List<PWAStreamValue> values, string bufferOption = null, string updateOption = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (values == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'values'");
			}

			string serviceUrl = "/streamsets/{webId}/value";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(values);
			urlBuilder.AddQueryParameter("bufferOption", bufferOption);
			urlBuilder.AddQueryParameter("updateOption", updateOption);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsSubstatus response = JsonConvert.DeserializeObject<PWAItemsSubstatus>(httpContent);
			return new HttpApiResponse<PWAItemsSubstatus>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Updates a single value for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the parent element, event frame, or attribute. Attributes specified in the body must be descendants of the specified object.</param>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>PWAItemsSubstatus</returns>
		public async Task<PWAItemsSubstatus> UpdateValueAsync(string webId, List<PWAStreamValue> values, string bufferOption = null, string updateOption = null)
		{
			return (await this.UpdateValueWithHttpAsync(webId, values, bufferOption, updateOption)).Data;
		}

		/// <summary>
		/// Updates a single value for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the parent element, event frame, or attribute. Attributes specified in the body must be descendants of the specified object.</param>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>HttpApiResponse<PWAItemsSubstatus></returns>
		public HttpApiResponse<PWAItemsSubstatus> UpdateValueWithHttp(string webId, List<PWAStreamValue> values, string bufferOption = null, string updateOption = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (values == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'values'");
			}

			string serviceUrl = "/streamsets/{webId}/value";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(values);
			urlBuilder.AddQueryParameter("bufferOption", bufferOption);
			urlBuilder.AddQueryParameter("updateOption", updateOption);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsSubstatus response = JsonConvert.DeserializeObject<PWAItemsSubstatus>(httpContent);
			return new HttpApiResponse<PWAItemsSubstatus>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Updates a single value for the specified streams.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the parent element, event frame, or attribute. Attributes specified in the body must be descendants of the specified object.</param>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>PWAItemsSubstatus</returns>
		public PWAItemsSubstatus UpdateValue(string webId, List<PWAStreamValue> values, string bufferOption = null, string updateOption = null)
		{
			return (this.UpdateValueWithHttp(webId, values, bufferOption, updateOption)).Data;
		}

	}
}
