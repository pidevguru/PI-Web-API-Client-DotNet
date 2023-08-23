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
	public class StreamControllerClient
	{
		private HttpApiClient httpApiClient;
		public StreamControllerClient(HttpApiClient httpApiClient)
		{
			this.httpApiClient = httpApiClient;
		}
		/// <summary>
		/// Receive stream updates
		/// </summary>
		/// <remarks>
		/// The supplied marker will identify the set of stream updates to retrieve. For a 200 response, the returned location header will contain the url for retrieving the stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="marker">Identifier of stream source and current position</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAStreamUpdatesRetrieve></returns>
		public async Task<HttpApiResponse<PWAStreamUpdatesRetrieve>> RetrieveStreamUpdateWithHttpAsync(string marker, string desiredUnits = null, string selectedFields = null, string webIdType = null)
		{
			if (marker == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'marker'");
			}

			string serviceUrl = "/streams/updates/{marker}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("marker", marker);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAStreamUpdatesRetrieve response = JsonConvert.DeserializeObject<PWAStreamUpdatesRetrieve>(httpContent);
			return new HttpApiResponse<PWAStreamUpdatesRetrieve>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Receive stream updates
		/// </summary>
		/// <remarks>
		/// The supplied marker will identify the set of stream updates to retrieve. For a 200 response, the returned location header will contain the url for retrieving the stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="marker">Identifier of stream source and current position</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAStreamUpdatesRetrieve</returns>
		public async Task<PWAStreamUpdatesRetrieve> RetrieveStreamUpdateAsync(string marker, string desiredUnits = null, string selectedFields = null, string webIdType = null)
		{
			return (await this.RetrieveStreamUpdateWithHttpAsync(marker, desiredUnits, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Receive stream updates
		/// </summary>
		/// <remarks>
		/// The supplied marker will identify the set of stream updates to retrieve. For a 200 response, the returned location header will contain the url for retrieving the stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="marker">Identifier of stream source and current position</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAStreamUpdatesRetrieve></returns>
		public HttpApiResponse<PWAStreamUpdatesRetrieve> RetrieveStreamUpdateWithHttp(string marker, string desiredUnits = null, string selectedFields = null, string webIdType = null)
		{
			if (marker == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'marker'");
			}

			string serviceUrl = "/streams/updates/{marker}";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("marker", marker);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAStreamUpdatesRetrieve response = JsonConvert.DeserializeObject<PWAStreamUpdatesRetrieve>(httpContent);
			return new HttpApiResponse<PWAStreamUpdatesRetrieve>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Receive stream updates
		/// </summary>
		/// <remarks>
		/// The supplied marker will identify the set of stream updates to retrieve. For a 200 response, the returned location header will contain the url for retrieving the stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="marker">Identifier of stream source and current position</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAStreamUpdatesRetrieve</returns>
		public PWAStreamUpdatesRetrieve RetrieveStreamUpdate(string marker, string desiredUnits = null, string selectedFields = null, string webIdType = null)
		{
			return (this.RetrieveStreamUpdateWithHttp(marker, desiredUnits, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Opens a channel that will send messages about any value changes for the specified stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="heartbeatRate">HeartbeatRate is an integer multiple of the Polling Interval. It specifies the rate at which a client will receive an empty message if there are no data updates. It can be used to check that the connection is still alive. Zero/negative values correspond to no heartbeat. By default, no empty messages will be sent to the user.</param>
		/// <param name="includeInitialValues">Specified if the channel should send a message with the current value of the stream after the connection is opened. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public async Task<HttpApiResponse<PWAItemsStreamValues>> GetChannelWithHttpAsync(string webId, int? heartbeatRate = null, bool? includeInitialValues = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/channel";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("heartbeatRate", heartbeatRate);
			urlBuilder.AddQueryParameter("includeInitialValues", includeInitialValues);
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
		/// Opens a channel that will send messages about any value changes for the specified stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="heartbeatRate">HeartbeatRate is an integer multiple of the Polling Interval. It specifies the rate at which a client will receive an empty message if there are no data updates. It can be used to check that the connection is still alive. Zero/negative values correspond to no heartbeat. By default, no empty messages will be sent to the user.</param>
		/// <param name="includeInitialValues">Specified if the channel should send a message with the current value of the stream after the connection is opened. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public async Task<PWAItemsStreamValues> GetChannelAsync(string webId, int? heartbeatRate = null, bool? includeInitialValues = null, string webIdType = null)
		{
			return (await this.GetChannelWithHttpAsync(webId, heartbeatRate, includeInitialValues, webIdType)).Data;
		}

		/// <summary>
		/// Opens a channel that will send messages about any value changes for the specified stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="heartbeatRate">HeartbeatRate is an integer multiple of the Polling Interval. It specifies the rate at which a client will receive an empty message if there are no data updates. It can be used to check that the connection is still alive. Zero/negative values correspond to no heartbeat. By default, no empty messages will be sent to the user.</param>
		/// <param name="includeInitialValues">Specified if the channel should send a message with the current value of the stream after the connection is opened. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAItemsStreamValues></returns>
		public HttpApiResponse<PWAItemsStreamValues> GetChannelWithHttp(string webId, int? heartbeatRate = null, bool? includeInitialValues = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/channel";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("heartbeatRate", heartbeatRate);
			urlBuilder.AddQueryParameter("includeInitialValues", includeInitialValues);
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
		/// Opens a channel that will send messages about any value changes for the specified stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="heartbeatRate">HeartbeatRate is an integer multiple of the Polling Interval. It specifies the rate at which a client will receive an empty message if there are no data updates. It can be used to check that the connection is still alive. Zero/negative values correspond to no heartbeat. By default, no empty messages will be sent to the user.</param>
		/// <param name="includeInitialValues">Specified if the channel should send a message with the current value of the stream after the connection is opened. The default is 'false'.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAItemsStreamValues</returns>
		public PWAItemsStreamValues GetChannel(string webId, int? heartbeatRate = null, bool? includeInitialValues = null, string webIdType = null)
		{
			return (this.GetChannelWithHttp(webId, heartbeatRate, includeInitialValues, webIdType)).Data;
		}

		/// <summary>
		/// Returns the end-of-stream value of the stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <returns>HttpApiResponse<PWATimedValue></returns>
		public async Task<HttpApiResponse<PWATimedValue>> GetEndWithHttpAsync(string webId, string desiredUnits = null, string selectedFields = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/end";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWATimedValue response = JsonConvert.DeserializeObject<PWATimedValue>(httpContent);
			return new HttpApiResponse<PWATimedValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns the end-of-stream value of the stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <returns>PWATimedValue</returns>
		public async Task<PWATimedValue> GetEndAsync(string webId, string desiredUnits = null, string selectedFields = null)
		{
			return (await this.GetEndWithHttpAsync(webId, desiredUnits, selectedFields)).Data;
		}

		/// <summary>
		/// Returns the end-of-stream value of the stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <returns>HttpApiResponse<PWATimedValue></returns>
		public HttpApiResponse<PWATimedValue> GetEndWithHttp(string webId, string desiredUnits = null, string selectedFields = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/end";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWATimedValue response = JsonConvert.DeserializeObject<PWATimedValue>(httpContent);
			return new HttpApiResponse<PWATimedValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns the end-of-stream value of the stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <returns>PWATimedValue</returns>
		public PWATimedValue GetEnd(string webId, string desiredUnits = null, string selectedFields = null)
		{
			return (this.GetEndWithHttp(webId, desiredUnits, selectedFields)).Data;
		}

		/// <summary>
		/// Retrieves interpolated values over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="interval">The sampling interval, in AFTimeSpan format.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="syncTime">An optional start time anchor, in AFTime format. When specified, interpolated data retrieval will use the sync time as the origin for calculating the interval times.</param>
		/// <param name="syncTimeBoundaryType">An optional string specifying the boundary type to use when applying a syncTime. The allowed values are 'Inside' and 'Outside'. The default is 'Inside'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWATimedValues></returns>
		public async Task<HttpApiResponse<PWATimedValues>> GetInterpolatedWithHttpAsync(string webId, string desiredUnits = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, string interval = null, string selectedFields = null, string startTime = null, string syncTime = null, string syncTimeBoundaryType = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/interpolated";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("interval", interval);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("syncTime", syncTime);
			urlBuilder.AddQueryParameter("syncTimeBoundaryType", syncTimeBoundaryType);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWATimedValues response = JsonConvert.DeserializeObject<PWATimedValues>(httpContent);
			return new HttpApiResponse<PWATimedValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves interpolated values over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="interval">The sampling interval, in AFTimeSpan format.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="syncTime">An optional start time anchor, in AFTime format. When specified, interpolated data retrieval will use the sync time as the origin for calculating the interval times.</param>
		/// <param name="syncTimeBoundaryType">An optional string specifying the boundary type to use when applying a syncTime. The allowed values are 'Inside' and 'Outside'. The default is 'Inside'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWATimedValues</returns>
		public async Task<PWATimedValues> GetInterpolatedAsync(string webId, string desiredUnits = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, string interval = null, string selectedFields = null, string startTime = null, string syncTime = null, string syncTimeBoundaryType = null, string timeZone = null)
		{
			return (await this.GetInterpolatedWithHttpAsync(webId, desiredUnits, endTime, filterExpression, includeFilteredValues, interval, selectedFields, startTime, syncTime, syncTimeBoundaryType, timeZone)).Data;
		}

		/// <summary>
		/// Retrieves interpolated values over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="interval">The sampling interval, in AFTimeSpan format.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="syncTime">An optional start time anchor, in AFTime format. When specified, interpolated data retrieval will use the sync time as the origin for calculating the interval times.</param>
		/// <param name="syncTimeBoundaryType">An optional string specifying the boundary type to use when applying a syncTime. The allowed values are 'Inside' and 'Outside'. The default is 'Inside'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWATimedValues></returns>
		public HttpApiResponse<PWATimedValues> GetInterpolatedWithHttp(string webId, string desiredUnits = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, string interval = null, string selectedFields = null, string startTime = null, string syncTime = null, string syncTimeBoundaryType = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/interpolated";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("interval", interval);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("syncTime", syncTime);
			urlBuilder.AddQueryParameter("syncTimeBoundaryType", syncTimeBoundaryType);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWATimedValues response = JsonConvert.DeserializeObject<PWATimedValues>(httpContent);
			return new HttpApiResponse<PWATimedValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves interpolated values over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="interval">The sampling interval, in AFTimeSpan format.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="syncTime">An optional start time anchor, in AFTime format. When specified, interpolated data retrieval will use the sync time as the origin for calculating the interval times.</param>
		/// <param name="syncTimeBoundaryType">An optional string specifying the boundary type to use when applying a syncTime. The allowed values are 'Inside' and 'Outside'. The default is 'Inside'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWATimedValues</returns>
		public PWATimedValues GetInterpolated(string webId, string desiredUnits = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, string interval = null, string selectedFields = null, string startTime = null, string syncTime = null, string syncTimeBoundaryType = null, string timeZone = null)
		{
			return (this.GetInterpolatedWithHttp(webId, desiredUnits, endTime, filterExpression, includeFilteredValues, interval, selectedFields, startTime, syncTime, syncTimeBoundaryType, timeZone)).Data;
		}

		/// <summary>
		/// Retrieves interpolated values over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="time">The timestamp at which to retrieve an interpolated value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWATimedValues></returns>
		public async Task<HttpApiResponse<PWATimedValues>> GetInterpolatedAtTimesWithHttpAsync(string webId, List<string> time, string desiredUnits = null, string filterExpression = null, bool? includeFilteredValues = null, string selectedFields = null, string sortOrder = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			string serviceUrl = "/streams/{webId}/interpolatedattimes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWATimedValues response = JsonConvert.DeserializeObject<PWATimedValues>(httpContent);
			return new HttpApiResponse<PWATimedValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves interpolated values over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="time">The timestamp at which to retrieve an interpolated value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWATimedValues</returns>
		public async Task<PWATimedValues> GetInterpolatedAtTimesAsync(string webId, List<string> time, string desiredUnits = null, string filterExpression = null, bool? includeFilteredValues = null, string selectedFields = null, string sortOrder = null, string timeZone = null)
		{
			return (await this.GetInterpolatedAtTimesWithHttpAsync(webId, time, desiredUnits, filterExpression, includeFilteredValues, selectedFields, sortOrder, timeZone)).Data;
		}

		/// <summary>
		/// Retrieves interpolated values over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="time">The timestamp at which to retrieve an interpolated value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWATimedValues></returns>
		public HttpApiResponse<PWATimedValues> GetInterpolatedAtTimesWithHttp(string webId, List<string> time, string desiredUnits = null, string filterExpression = null, bool? includeFilteredValues = null, string selectedFields = null, string sortOrder = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			string serviceUrl = "/streams/{webId}/interpolatedattimes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWATimedValues response = JsonConvert.DeserializeObject<PWATimedValues>(httpContent);
			return new HttpApiResponse<PWATimedValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves interpolated values over the specified time range at the specified sampling interval.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="time">The timestamp at which to retrieve an interpolated value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. If the attribute does not support filtering, the filter will be ignored. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWATimedValues</returns>
		public PWATimedValues GetInterpolatedAtTimes(string webId, List<string> time, string desiredUnits = null, string filterExpression = null, bool? includeFilteredValues = null, string selectedFields = null, string sortOrder = null, string timeZone = null)
		{
			return (this.GetInterpolatedAtTimesWithHttp(webId, time, desiredUnits, filterExpression, includeFilteredValues, selectedFields, sortOrder, timeZone)).Data;
		}

		/// <summary>
		/// Retrieves values over the specified time range suitable for plotting over the number of intervals (typically represents pixels).
		/// </summary>
		/// <remarks>
		/// For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state). Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="intervals">The number of intervals to plot over. Typically, this would be the number of horizontal pixels in the trend. The default is '24'. For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state).</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWATimedValues></returns>
		public async Task<HttpApiResponse<PWATimedValues>> GetPlotWithHttpAsync(string webId, string desiredUnits = null, string endTime = null, int? intervals = null, string selectedFields = null, string startTime = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/plot";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("intervals", intervals);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWATimedValues response = JsonConvert.DeserializeObject<PWATimedValues>(httpContent);
			return new HttpApiResponse<PWATimedValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves values over the specified time range suitable for plotting over the number of intervals (typically represents pixels).
		/// </summary>
		/// <remarks>
		/// For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state). Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="intervals">The number of intervals to plot over. Typically, this would be the number of horizontal pixels in the trend. The default is '24'. For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state).</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWATimedValues</returns>
		public async Task<PWATimedValues> GetPlotAsync(string webId, string desiredUnits = null, string endTime = null, int? intervals = null, string selectedFields = null, string startTime = null, string timeZone = null)
		{
			return (await this.GetPlotWithHttpAsync(webId, desiredUnits, endTime, intervals, selectedFields, startTime, timeZone)).Data;
		}

		/// <summary>
		/// Retrieves values over the specified time range suitable for plotting over the number of intervals (typically represents pixels).
		/// </summary>
		/// <remarks>
		/// For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state). Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="intervals">The number of intervals to plot over. Typically, this would be the number of horizontal pixels in the trend. The default is '24'. For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state).</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWATimedValues></returns>
		public HttpApiResponse<PWATimedValues> GetPlotWithHttp(string webId, string desiredUnits = null, string endTime = null, int? intervals = null, string selectedFields = null, string startTime = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/plot";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("intervals", intervals);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWATimedValues response = JsonConvert.DeserializeObject<PWATimedValues>(httpContent);
			return new HttpApiResponse<PWATimedValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves values over the specified time range suitable for plotting over the number of intervals (typically represents pixels).
		/// </summary>
		/// <remarks>
		/// For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state). Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="intervals">The number of intervals to plot over. Typically, this would be the number of horizontal pixels in the trend. The default is '24'. For each interval, the data available is examined and significant values are returned. Each interval can produce up to 5 values if they are unique, the first value in the interval, the last value, the highest value, the lowest value and at most one exceptional point (bad status or digital state).</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWATimedValues</returns>
		public PWATimedValues GetPlot(string webId, string desiredUnits = null, string endTime = null, int? intervals = null, string selectedFields = null, string startTime = null, string timeZone = null)
		{
			return (this.GetPlotWithHttp(webId, desiredUnits, endTime, intervals, selectedFields, startTime, timeZone)).Data;
		}

		/// <summary>
		/// Returns a list of compressed values for the requested time range from the source provider.
		/// </summary>
		/// <remarks>
		/// Returned times are affected by the specified boundary type. If no values are found for the time range and conditions specified then the HTTP response will be success, with a body containing an empty array of Items. When specifying true for the includeFilteredValues parameter, consecutive filtered events are not returned. The first value that would be filtered out is returned with its time and the enumeration value "Filtered". The next value in the collection will be the next compressed value in the specified direction that passes the filter criteria - if any. When both boundaryType and a filterExpression are specified, the events returned for the boundary condition specified are passed through the filter. If the includeFilteredValues parameter is true, the boundary values will be reported at the proper timestamps with the enumeration value "Filtered" when the filter conditions are not met at the boundary time. If the includeFilteredValues parameter is false for this case, no event is returned for the boundary time. Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.   If only recorded values with annotations are desired, the filterExpression parameter should include the filter IsSet('.', "a").
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Annotations to return events with annotation values. If this parameter is not specified, annotation values are not returned.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWAExtendedTimedValues></returns>
		public async Task<HttpApiResponse<PWAExtendedTimedValues>> GetRecordedWithHttpAsync(string webId, string associations = null, string boundaryType = null, string desiredUnits = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string selectedFields = null, string startTime = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/recorded";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("boundaryType", boundaryType);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAExtendedTimedValues response = JsonConvert.DeserializeObject<PWAExtendedTimedValues>(httpContent);
			return new HttpApiResponse<PWAExtendedTimedValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns a list of compressed values for the requested time range from the source provider.
		/// </summary>
		/// <remarks>
		/// Returned times are affected by the specified boundary type. If no values are found for the time range and conditions specified then the HTTP response will be success, with a body containing an empty array of Items. When specifying true for the includeFilteredValues parameter, consecutive filtered events are not returned. The first value that would be filtered out is returned with its time and the enumeration value "Filtered". The next value in the collection will be the next compressed value in the specified direction that passes the filter criteria - if any. When both boundaryType and a filterExpression are specified, the events returned for the boundary condition specified are passed through the filter. If the includeFilteredValues parameter is true, the boundary values will be reported at the proper timestamps with the enumeration value "Filtered" when the filter conditions are not met at the boundary time. If the includeFilteredValues parameter is false for this case, no event is returned for the boundary time. Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.   If only recorded values with annotations are desired, the filterExpression parameter should include the filter IsSet('.', "a").
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Annotations to return events with annotation values. If this parameter is not specified, annotation values are not returned.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWAExtendedTimedValues</returns>
		public async Task<PWAExtendedTimedValues> GetRecordedAsync(string webId, string associations = null, string boundaryType = null, string desiredUnits = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string selectedFields = null, string startTime = null, string timeZone = null)
		{
			return (await this.GetRecordedWithHttpAsync(webId, associations, boundaryType, desiredUnits, endTime, filterExpression, includeFilteredValues, maxCount, selectedFields, startTime, timeZone)).Data;
		}

		/// <summary>
		/// Returns a list of compressed values for the requested time range from the source provider.
		/// </summary>
		/// <remarks>
		/// Returned times are affected by the specified boundary type. If no values are found for the time range and conditions specified then the HTTP response will be success, with a body containing an empty array of Items. When specifying true for the includeFilteredValues parameter, consecutive filtered events are not returned. The first value that would be filtered out is returned with its time and the enumeration value "Filtered". The next value in the collection will be the next compressed value in the specified direction that passes the filter criteria - if any. When both boundaryType and a filterExpression are specified, the events returned for the boundary condition specified are passed through the filter. If the includeFilteredValues parameter is true, the boundary values will be reported at the proper timestamps with the enumeration value "Filtered" when the filter conditions are not met at the boundary time. If the includeFilteredValues parameter is false for this case, no event is returned for the boundary time. Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.   If only recorded values with annotations are desired, the filterExpression parameter should include the filter IsSet('.', "a").
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Annotations to return events with annotation values. If this parameter is not specified, annotation values are not returned.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWAExtendedTimedValues></returns>
		public HttpApiResponse<PWAExtendedTimedValues> GetRecordedWithHttp(string webId, string associations = null, string boundaryType = null, string desiredUnits = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string selectedFields = null, string startTime = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/recorded";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("boundaryType", boundaryType);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("endTime", endTime);
			urlBuilder.AddQueryParameter("filterExpression", filterExpression);
			urlBuilder.AddQueryParameter("includeFilteredValues", includeFilteredValues);
			urlBuilder.AddQueryParameter("maxCount", maxCount);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("startTime", startTime);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAExtendedTimedValues response = JsonConvert.DeserializeObject<PWAExtendedTimedValues>(httpContent);
			return new HttpApiResponse<PWAExtendedTimedValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns a list of compressed values for the requested time range from the source provider.
		/// </summary>
		/// <remarks>
		/// Returned times are affected by the specified boundary type. If no values are found for the time range and conditions specified then the HTTP response will be success, with a body containing an empty array of Items. When specifying true for the includeFilteredValues parameter, consecutive filtered events are not returned. The first value that would be filtered out is returned with its time and the enumeration value "Filtered". The next value in the collection will be the next compressed value in the specified direction that passes the filter criteria - if any. When both boundaryType and a filterExpression are specified, the events returned for the boundary condition specified are passed through the filter. If the includeFilteredValues parameter is true, the boundary values will be reported at the proper timestamps with the enumeration value "Filtered" when the filter conditions are not met at the boundary time. If the includeFilteredValues parameter is false for this case, no event is returned for the boundary time. Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.   If only recorded values with annotations are desired, the filterExpression parameter should include the filter IsSet('.', "a").
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Annotations to return events with annotation values. If this parameter is not specified, annotation values are not returned.</param>
		/// <param name="boundaryType">An optional value that determines how the times and values of the returned end points are determined. The default is 'Inside'.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">An optional string containing a filter expression. Expression variables are relative to the data point. Use '.' to reference the containing attribute. The default is no filtering.</param>
		/// <param name="includeFilteredValues">Specify 'true' to indicate that values which fail the filter criteria are present in the returned data at the times where they occurred with a value set to a 'Filtered' enumeration value with bad status. Repeated consecutive failures are omitted.</param>
		/// <param name="maxCount">The maximum number of values to be returned. The default is 1000.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWAExtendedTimedValues</returns>
		public PWAExtendedTimedValues GetRecorded(string webId, string associations = null, string boundaryType = null, string desiredUnits = null, string endTime = null, string filterExpression = null, bool? includeFilteredValues = null, int? maxCount = null, string selectedFields = null, string startTime = null, string timeZone = null)
		{
			return (this.GetRecordedWithHttp(webId, associations, boundaryType, desiredUnits, endTime, filterExpression, includeFilteredValues, maxCount, selectedFields, startTime, timeZone)).Data;
		}

		/// <summary>
		/// Updates multiple values for the specified stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>HttpApiResponse<PWAItemsSubstatus></returns>
		public async Task<HttpApiResponse<PWAItemsSubstatus>> UpdateValuesWithHttpAsync(string webId, List<PWATimedValue> values, string bufferOption = null, string updateOption = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (values == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'values'");
			}

			string serviceUrl = "/streams/{webId}/recorded";
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
		/// Updates multiple values for the specified stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>PWAItemsSubstatus</returns>
		public async Task<PWAItemsSubstatus> UpdateValuesAsync(string webId, List<PWATimedValue> values, string bufferOption = null, string updateOption = null)
		{
			return (await this.UpdateValuesWithHttpAsync(webId, values, bufferOption, updateOption)).Data;
		}

		/// <summary>
		/// Updates multiple values for the specified stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>HttpApiResponse<PWAItemsSubstatus></returns>
		public HttpApiResponse<PWAItemsSubstatus> UpdateValuesWithHttp(string webId, List<PWATimedValue> values, string bufferOption = null, string updateOption = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (values == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'values'");
			}

			string serviceUrl = "/streams/{webId}/recorded";
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
		/// Updates multiple values for the specified stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="values">The values to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'.</param>
		/// <returns>PWAItemsSubstatus</returns>
		public PWAItemsSubstatus UpdateValues(string webId, List<PWATimedValue> values, string bufferOption = null, string updateOption = null)
		{
			return (this.UpdateValuesWithHttp(webId, values, bufferOption, updateOption)).Data;
		}

		/// <summary>
		/// Returns a single recorded value based on the passed time and retrieval mode from the stream.
		/// </summary>
		/// <remarks>
		/// If only recorded values with annotations are desired, the filterExpression parameter should include the filter IsSet('.', "a").
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="time">The timestamp at which the value is desired.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Annotations to return events with annotation values. If this parameter is not specified, annotation values are not returned.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="retrievalMode">An optional value that determines the value to return when a value doesn't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWAExtendedTimedValue></returns>
		public async Task<HttpApiResponse<PWAExtendedTimedValue>> GetRecordedAtTimeWithHttpAsync(string webId, string time, string associations = null, string desiredUnits = null, string retrievalMode = null, string selectedFields = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			string serviceUrl = "/streams/{webId}/recordedattime";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("retrievalMode", retrievalMode);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAExtendedTimedValue response = JsonConvert.DeserializeObject<PWAExtendedTimedValue>(httpContent);
			return new HttpApiResponse<PWAExtendedTimedValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns a single recorded value based on the passed time and retrieval mode from the stream.
		/// </summary>
		/// <remarks>
		/// If only recorded values with annotations are desired, the filterExpression parameter should include the filter IsSet('.', "a").
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="time">The timestamp at which the value is desired.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Annotations to return events with annotation values. If this parameter is not specified, annotation values are not returned.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="retrievalMode">An optional value that determines the value to return when a value doesn't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWAExtendedTimedValue</returns>
		public async Task<PWAExtendedTimedValue> GetRecordedAtTimeAsync(string webId, string time, string associations = null, string desiredUnits = null, string retrievalMode = null, string selectedFields = null, string timeZone = null)
		{
			return (await this.GetRecordedAtTimeWithHttpAsync(webId, time, associations, desiredUnits, retrievalMode, selectedFields, timeZone)).Data;
		}

		/// <summary>
		/// Returns a single recorded value based on the passed time and retrieval mode from the stream.
		/// </summary>
		/// <remarks>
		/// If only recorded values with annotations are desired, the filterExpression parameter should include the filter IsSet('.', "a").
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="time">The timestamp at which the value is desired.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Annotations to return events with annotation values. If this parameter is not specified, annotation values are not returned.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="retrievalMode">An optional value that determines the value to return when a value doesn't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWAExtendedTimedValue></returns>
		public HttpApiResponse<PWAExtendedTimedValue> GetRecordedAtTimeWithHttp(string webId, string time, string associations = null, string desiredUnits = null, string retrievalMode = null, string selectedFields = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			string serviceUrl = "/streams/{webId}/recordedattime";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("retrievalMode", retrievalMode);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAExtendedTimedValue response = JsonConvert.DeserializeObject<PWAExtendedTimedValue>(httpContent);
			return new HttpApiResponse<PWAExtendedTimedValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns a single recorded value based on the passed time and retrieval mode from the stream.
		/// </summary>
		/// <remarks>
		/// If only recorded values with annotations are desired, the filterExpression parameter should include the filter IsSet('.', "a").
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="time">The timestamp at which the value is desired.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Annotations to return events with annotation values. If this parameter is not specified, annotation values are not returned.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="retrievalMode">An optional value that determines the value to return when a value doesn't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWAExtendedTimedValue</returns>
		public PWAExtendedTimedValue GetRecordedAtTime(string webId, string time, string associations = null, string desiredUnits = null, string retrievalMode = null, string selectedFields = null, string timeZone = null)
		{
			return (this.GetRecordedAtTimeWithHttp(webId, time, associations, desiredUnits, retrievalMode, selectedFields, timeZone)).Data;
		}

		/// <summary>
		/// Retrieves recorded values at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.   If only recorded values with annotations are desired, the filterExpression parameter should include the filter IsSet('.', "a").
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="time">The timestamp at which to retrieve a recorded value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Annotations to return events with annotation values. If this parameter is not specified, annotation values are not returned.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="retrievalMode">An optional value that determines the value to return when a value doesn't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWAExtendedTimedValues></returns>
		public async Task<HttpApiResponse<PWAExtendedTimedValues>> GetRecordedAtTimesWithHttpAsync(string webId, List<string> time, string associations = null, string desiredUnits = null, string retrievalMode = null, string selectedFields = null, string sortOrder = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			string serviceUrl = "/streams/{webId}/recordedattimes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("retrievalMode", retrievalMode);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAExtendedTimedValues response = JsonConvert.DeserializeObject<PWAExtendedTimedValues>(httpContent);
			return new HttpApiResponse<PWAExtendedTimedValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves recorded values at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.   If only recorded values with annotations are desired, the filterExpression parameter should include the filter IsSet('.', "a").
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="time">The timestamp at which to retrieve a recorded value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Annotations to return events with annotation values. If this parameter is not specified, annotation values are not returned.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="retrievalMode">An optional value that determines the value to return when a value doesn't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWAExtendedTimedValues</returns>
		public async Task<PWAExtendedTimedValues> GetRecordedAtTimesAsync(string webId, List<string> time, string associations = null, string desiredUnits = null, string retrievalMode = null, string selectedFields = null, string sortOrder = null, string timeZone = null)
		{
			return (await this.GetRecordedAtTimesWithHttpAsync(webId, time, associations, desiredUnits, retrievalMode, selectedFields, sortOrder, timeZone)).Data;
		}

		/// <summary>
		/// Retrieves recorded values at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.   If only recorded values with annotations are desired, the filterExpression parameter should include the filter IsSet('.', "a").
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="time">The timestamp at which to retrieve a recorded value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Annotations to return events with annotation values. If this parameter is not specified, annotation values are not returned.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="retrievalMode">An optional value that determines the value to return when a value doesn't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWAExtendedTimedValues></returns>
		public HttpApiResponse<PWAExtendedTimedValues> GetRecordedAtTimesWithHttp(string webId, List<string> time, string associations = null, string desiredUnits = null, string retrievalMode = null, string selectedFields = null, string sortOrder = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (time == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'time'");
			}

			string serviceUrl = "/streams/{webId}/recordedattimes";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("associations", associations);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("retrievalMode", retrievalMode);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("sortOrder", sortOrder);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAExtendedTimedValues response = JsonConvert.DeserializeObject<PWAExtendedTimedValues>(httpContent);
			return new HttpApiResponse<PWAExtendedTimedValues>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Retrieves recorded values at the specified times.
		/// </summary>
		/// <remarks>
		/// Any time series value in the response that contains an 'Errors' property indicates PI Web API encountered a handled error during the transfer of the response stream.   If only recorded values with annotations are desired, the filterExpression parameter should include the filter IsSet('.', "a").
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="time">The timestamp at which to retrieve a recorded value. Multiple timestamps may be specified with multiple instances of the parameter.</param>
		/// <param name="associations">Associated values to return in the response, separated by semicolons (;). This call supports Annotations to return events with annotation values. If this parameter is not specified, annotation values are not returned.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="retrievalMode">An optional value that determines the value to return when a value doesn't exist at the exact time specified. The default is 'Auto'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="sortOrder">The order that the returned collection is sorted. The default is 'Ascending'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWAExtendedTimedValues</returns>
		public PWAExtendedTimedValues GetRecordedAtTimes(string webId, List<string> time, string associations = null, string desiredUnits = null, string retrievalMode = null, string selectedFields = null, string sortOrder = null, string timeZone = null)
		{
			return (this.GetRecordedAtTimesWithHttp(webId, time, associations, desiredUnits, retrievalMode, selectedFields, sortOrder, timeZone)).Data;
		}

		/// <summary>
		/// Returns a summary over the specified time range for the stream.
		/// </summary>
		/// <remarks>
		/// Count is the only summary type supported on non-numeric streams. Requesting a summary for any other type will generate an error. Time-weighted totals are computed by integrating the rate tag values over the requested time range. If some of the data are bad in the time range, the calculated total is divided by the fraction of the time period for which there are good values. This approach is equivalent to assuming that during the period of bad data, the tag takes on the average values for the entire calculation time range. The PercentGood summary may be used to determine if the calculation results are suitable for the application's purposes. For time-weighted totals, if the time unit rate of the stream cannot be determined, then the value will be totaled assuming a unit of "per day" and no unit of measure will be assigned to the value. If the measured time component of the tag is not based on a day, the user of the data must convert the totalized value to the correct units.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="calculationBasis">Specifies the method of evaluating the data over the time range. The default is 'TimeWeighted'.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">A string containing a filter expression. Expression variables are relative to the attribute. Use '.' to reference the containing attribute.</param>
		/// <param name="sampleInterval">When the sampleType is Interval, sampleInterval specifies how often the filter expression is evaluated when computing the summary for an interval.</param>
		/// <param name="sampleType">Defines the evaluation of an expression over a time range. The default is 'ExpressionRecordedValues'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="summaryDuration">The duration of each summary interval. If specified in hours, minutes, seconds, or milliseconds, the summary durations will be evenly spaced UTC time intervals. Longer interval types are interpreted using wall clock rules and are time zone dependent.</param>
		/// <param name="summaryType">Specifies the kinds of summaries to produce over the range. The default is 'Total'. Multiple summary types may be specified by using multiple instances of summaryType.</param>
		/// <param name="timeType">Specifies how to calculate the timestamp for each interval. The default is 'Auto'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWAItemsSummaryValue></returns>
		public async Task<HttpApiResponse<PWAItemsSummaryValue>> GetSummaryWithHttpAsync(string webId, string calculationBasis = null, string endTime = null, string filterExpression = null, string sampleInterval = null, string sampleType = null, string selectedFields = null, string startTime = null, string summaryDuration = null, List<string> summaryType = null, string timeType = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/summary";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
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
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAItemsSummaryValue response = JsonConvert.DeserializeObject<PWAItemsSummaryValue>(httpContent);
			return new HttpApiResponse<PWAItemsSummaryValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns a summary over the specified time range for the stream.
		/// </summary>
		/// <remarks>
		/// Count is the only summary type supported on non-numeric streams. Requesting a summary for any other type will generate an error. Time-weighted totals are computed by integrating the rate tag values over the requested time range. If some of the data are bad in the time range, the calculated total is divided by the fraction of the time period for which there are good values. This approach is equivalent to assuming that during the period of bad data, the tag takes on the average values for the entire calculation time range. The PercentGood summary may be used to determine if the calculation results are suitable for the application's purposes. For time-weighted totals, if the time unit rate of the stream cannot be determined, then the value will be totaled assuming a unit of "per day" and no unit of measure will be assigned to the value. If the measured time component of the tag is not based on a day, the user of the data must convert the totalized value to the correct units.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="calculationBasis">Specifies the method of evaluating the data over the time range. The default is 'TimeWeighted'.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">A string containing a filter expression. Expression variables are relative to the attribute. Use '.' to reference the containing attribute.</param>
		/// <param name="sampleInterval">When the sampleType is Interval, sampleInterval specifies how often the filter expression is evaluated when computing the summary for an interval.</param>
		/// <param name="sampleType">Defines the evaluation of an expression over a time range. The default is 'ExpressionRecordedValues'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="summaryDuration">The duration of each summary interval. If specified in hours, minutes, seconds, or milliseconds, the summary durations will be evenly spaced UTC time intervals. Longer interval types are interpreted using wall clock rules and are time zone dependent.</param>
		/// <param name="summaryType">Specifies the kinds of summaries to produce over the range. The default is 'Total'. Multiple summary types may be specified by using multiple instances of summaryType.</param>
		/// <param name="timeType">Specifies how to calculate the timestamp for each interval. The default is 'Auto'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWAItemsSummaryValue</returns>
		public async Task<PWAItemsSummaryValue> GetSummaryAsync(string webId, string calculationBasis = null, string endTime = null, string filterExpression = null, string sampleInterval = null, string sampleType = null, string selectedFields = null, string startTime = null, string summaryDuration = null, List<string> summaryType = null, string timeType = null, string timeZone = null)
		{
			return (await this.GetSummaryWithHttpAsync(webId, calculationBasis, endTime, filterExpression, sampleInterval, sampleType, selectedFields, startTime, summaryDuration, summaryType, timeType, timeZone)).Data;
		}

		/// <summary>
		/// Returns a summary over the specified time range for the stream.
		/// </summary>
		/// <remarks>
		/// Count is the only summary type supported on non-numeric streams. Requesting a summary for any other type will generate an error. Time-weighted totals are computed by integrating the rate tag values over the requested time range. If some of the data are bad in the time range, the calculated total is divided by the fraction of the time period for which there are good values. This approach is equivalent to assuming that during the period of bad data, the tag takes on the average values for the entire calculation time range. The PercentGood summary may be used to determine if the calculation results are suitable for the application's purposes. For time-weighted totals, if the time unit rate of the stream cannot be determined, then the value will be totaled assuming a unit of "per day" and no unit of measure will be assigned to the value. If the measured time component of the tag is not based on a day, the user of the data must convert the totalized value to the correct units.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="calculationBasis">Specifies the method of evaluating the data over the time range. The default is 'TimeWeighted'.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">A string containing a filter expression. Expression variables are relative to the attribute. Use '.' to reference the containing attribute.</param>
		/// <param name="sampleInterval">When the sampleType is Interval, sampleInterval specifies how often the filter expression is evaluated when computing the summary for an interval.</param>
		/// <param name="sampleType">Defines the evaluation of an expression over a time range. The default is 'ExpressionRecordedValues'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="summaryDuration">The duration of each summary interval. If specified in hours, minutes, seconds, or milliseconds, the summary durations will be evenly spaced UTC time intervals. Longer interval types are interpreted using wall clock rules and are time zone dependent.</param>
		/// <param name="summaryType">Specifies the kinds of summaries to produce over the range. The default is 'Total'. Multiple summary types may be specified by using multiple instances of summaryType.</param>
		/// <param name="timeType">Specifies how to calculate the timestamp for each interval. The default is 'Auto'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWAItemsSummaryValue></returns>
		public HttpApiResponse<PWAItemsSummaryValue> GetSummaryWithHttp(string webId, string calculationBasis = null, string endTime = null, string filterExpression = null, string sampleInterval = null, string sampleType = null, string selectedFields = null, string startTime = null, string summaryDuration = null, List<string> summaryType = null, string timeType = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/summary";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
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
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAItemsSummaryValue response = JsonConvert.DeserializeObject<PWAItemsSummaryValue>(httpContent);
			return new HttpApiResponse<PWAItemsSummaryValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns a summary over the specified time range for the stream.
		/// </summary>
		/// <remarks>
		/// Count is the only summary type supported on non-numeric streams. Requesting a summary for any other type will generate an error. Time-weighted totals are computed by integrating the rate tag values over the requested time range. If some of the data are bad in the time range, the calculated total is divided by the fraction of the time period for which there are good values. This approach is equivalent to assuming that during the period of bad data, the tag takes on the average values for the entire calculation time range. The PercentGood summary may be used to determine if the calculation results are suitable for the application's purposes. For time-weighted totals, if the time unit rate of the stream cannot be determined, then the value will be totaled assuming a unit of "per day" and no unit of measure will be assigned to the value. If the measured time component of the tag is not based on a day, the user of the data must convert the totalized value to the correct units.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="calculationBasis">Specifies the method of evaluating the data over the time range. The default is 'TimeWeighted'.</param>
		/// <param name="endTime">An optional end time. The default is '*' for element attributes and points. For event frame attributes, the default is the event frame's end time, or '*' if that is not set. Note that if endTime is earlier than startTime, the resulting values will be in time-descending order.</param>
		/// <param name="filterExpression">A string containing a filter expression. Expression variables are relative to the attribute. Use '.' to reference the containing attribute.</param>
		/// <param name="sampleInterval">When the sampleType is Interval, sampleInterval specifies how often the filter expression is evaluated when computing the summary for an interval.</param>
		/// <param name="sampleType">Defines the evaluation of an expression over a time range. The default is 'ExpressionRecordedValues'.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="startTime">An optional start time. The default is '*-1d' for element attributes and points. For event frame attributes, the default is the event frame's start time, or '*-1d' if that is not set.</param>
		/// <param name="summaryDuration">The duration of each summary interval. If specified in hours, minutes, seconds, or milliseconds, the summary durations will be evenly spaced UTC time intervals. Longer interval types are interpreted using wall clock rules and are time zone dependent.</param>
		/// <param name="summaryType">Specifies the kinds of summaries to produce over the range. The default is 'Total'. Multiple summary types may be specified by using multiple instances of summaryType.</param>
		/// <param name="timeType">Specifies how to calculate the timestamp for each interval. The default is 'Auto'.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWAItemsSummaryValue</returns>
		public PWAItemsSummaryValue GetSummary(string webId, string calculationBasis = null, string endTime = null, string filterExpression = null, string sampleInterval = null, string sampleType = null, string selectedFields = null, string startTime = null, string summaryDuration = null, List<string> summaryType = null, string timeType = null, string timeZone = null)
		{
			return (this.GetSummaryWithHttp(webId, calculationBasis, endTime, filterExpression, sampleInterval, sampleType, selectedFields, startTime, summaryDuration, summaryType, timeType, timeZone)).Data;
		}

		/// <summary>
		/// Register for stream updates
		/// </summary>
		/// <remarks>
		/// The supplied webId will register for stream updates. For a 201 or 204 response, the returned location header will contain the url for retrieving the next set of stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAStreamUpdatesRegister></returns>
		public async Task<HttpApiResponse<PWAStreamUpdatesRegister>> RegisterStreamUpdateWithHttpAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/updates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWAStreamUpdatesRegister response = JsonConvert.DeserializeObject<PWAStreamUpdatesRegister>(httpContent);
			return new HttpApiResponse<PWAStreamUpdatesRegister>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Register for stream updates
		/// </summary>
		/// <remarks>
		/// The supplied webId will register for stream updates. For a 201 or 204 response, the returned location header will contain the url for retrieving the next set of stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAStreamUpdatesRegister</returns>
		public async Task<PWAStreamUpdatesRegister> RegisterStreamUpdateAsync(string webId, string selectedFields = null, string webIdType = null)
		{
			return (await this.RegisterStreamUpdateWithHttpAsync(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Register for stream updates
		/// </summary>
		/// <remarks>
		/// The supplied webId will register for stream updates. For a 201 or 204 response, the returned location header will contain the url for retrieving the next set of stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<PWAStreamUpdatesRegister></returns>
		public HttpApiResponse<PWAStreamUpdatesRegister> RegisterStreamUpdateWithHttp(string webId, string selectedFields = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/updates";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("webIdType", webIdType);
			urlBuilder.HttpMethod = new HttpMethod("POST");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWAStreamUpdatesRegister response = JsonConvert.DeserializeObject<PWAStreamUpdatesRegister>(httpContent);
			return new HttpApiResponse<PWAStreamUpdatesRegister>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Register for stream updates
		/// </summary>
		/// <remarks>
		/// The supplied webId will register for stream updates. For a 201 or 204 response, the returned location header will contain the url for retrieving the next set of stream updates.
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>PWAStreamUpdatesRegister</returns>
		public PWAStreamUpdatesRegister RegisterStreamUpdate(string webId, string selectedFields = null, string webIdType = null)
		{
			return (this.RegisterStreamUpdateWithHttp(webId, selectedFields, webIdType)).Data;
		}

		/// <summary>
		/// Returns the value of the stream at the specified time. By default, this is usually the current value.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="time">An optional time. The default time context is determined from the owning object - for example, the time range of the event frame or transfer which holds this attribute. Otherwise, the implementation of the Data Reference determines the meaning of no context. For Points or simply configured PI Point Data References, this means the snapshot value of the PI Point on the Data Server.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWATimedValue></returns>
		public async Task<HttpApiResponse<PWATimedValue>> GetValueWithHttpAsync(string webId, string desiredUnits = null, string selectedFields = null, string time = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/value";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = await this.httpApiClient.MakeHttpRequestAsync(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = await httpResponse.Content.ReadAsStringAsync();

			Exception exception = await ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse);
			if (exception != null) throw exception;

			PWATimedValue response = JsonConvert.DeserializeObject<PWATimedValue>(httpContent);
			return new HttpApiResponse<PWATimedValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns the value of the stream at the specified time. By default, this is usually the current value.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="time">An optional time. The default time context is determined from the owning object - for example, the time range of the event frame or transfer which holds this attribute. Otherwise, the implementation of the Data Reference determines the meaning of no context. For Points or simply configured PI Point Data References, this means the snapshot value of the PI Point on the Data Server.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWATimedValue</returns>
		public async Task<PWATimedValue> GetValueAsync(string webId, string desiredUnits = null, string selectedFields = null, string time = null, string timeZone = null)
		{
			return (await this.GetValueWithHttpAsync(webId, desiredUnits, selectedFields, time, timeZone)).Data;
		}

		/// <summary>
		/// Returns the value of the stream at the specified time. By default, this is usually the current value.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="time">An optional time. The default time context is determined from the owning object - for example, the time range of the event frame or transfer which holds this attribute. Otherwise, the implementation of the Data Reference determines the meaning of no context. For Points or simply configured PI Point Data References, this means the snapshot value of the PI Point on the Data Server.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>HttpApiResponse<PWATimedValue></returns>
		public HttpApiResponse<PWATimedValue> GetValueWithHttp(string webId, string desiredUnits = null, string selectedFields = null, string time = null, string timeZone = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			string serviceUrl = "/streams/{webId}/value";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddQueryParameter("desiredUnits", desiredUnits);
			urlBuilder.AddQueryParameter("selectedFields", selectedFields);
			urlBuilder.AddQueryParameter("time", time);
			urlBuilder.AddQueryParameter("timeZone", timeZone);
			urlBuilder.HttpMethod = new HttpMethod("GET");

			HttpResponseMessage httpResponse = this.httpApiClient.MakeHttpRequest(urlBuilder);

			int httpStatusCode = (int)httpResponse.StatusCode;
			string httpContent = httpResponse.Content.ReadAsStringAsync().Result;

			Exception exception = ExceptionFactory.DefaultExceptionFactory("AttributeGetCategories", httpResponse).Result;
			if (exception != null) throw exception;

			PWATimedValue response = JsonConvert.DeserializeObject<PWATimedValue>(httpContent);
			return new HttpApiResponse<PWATimedValue>(httpStatusCode, httpResponse.Headers.ToDictionary(x => x.Key, x => x.Value.First().ToString()), response);
		}

		/// <summary>
		/// Returns the value of the stream at the specified time. By default, this is usually the current value.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="desiredUnits">The name or abbreviation of the desired units of measure for the returned value, as found in the UOM database associated with the attribute. If not specified for an attribute, the attribute's default unit of measure is used. If the underlying stream is a point, this value may not be specified, as points are not associated with a unit of measure.</param>
		/// <param name="selectedFields">List of fields to be returned in the response, separated by semicolons (;). If this parameter is not specified, all available fields will be returned.</param>
		/// <param name="time">An optional time. The default time context is determined from the owning object - for example, the time range of the event frame or transfer which holds this attribute. Otherwise, the implementation of the Data Reference determines the meaning of no context. For Points or simply configured PI Point Data References, this means the snapshot value of the PI Point on the Data Server.</param>
		/// <param name="timeZone">The time zone in which the time string will be interpreted. This parameter will be ignored if a time zone is specified in the time string. If no time zone is specified in either places, the PI Web API server time zone will be used.</param>
		/// <returns>PWATimedValue</returns>
		public PWATimedValue GetValue(string webId, string desiredUnits = null, string selectedFields = null, string time = null, string timeZone = null)
		{
			return (this.GetValueWithHttp(webId, desiredUnits, selectedFields, time, timeZone)).Data;
		}

		/// <summary>
		/// Updates a value for the specified stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="value">The value to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'. This parameter is ignored if the attribute is a configuration item.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public async Task<HttpApiResponse<object>> UpdateValueWithHttpAsync(string webId, PWATimedValue value, string bufferOption = null, string updateOption = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (value == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'value'");
			}

			string serviceUrl = "/streams/{webId}/value";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(value);
			urlBuilder.AddQueryParameter("bufferOption", bufferOption);
			urlBuilder.AddQueryParameter("updateOption", updateOption);
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
		/// Updates a value for the specified stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="value">The value to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'. This parameter is ignored if the attribute is a configuration item.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public async Task<object> UpdateValueAsync(string webId, PWATimedValue value, string bufferOption = null, string updateOption = null, string webIdType = null)
		{
			return (await this.UpdateValueWithHttpAsync(webId, value, bufferOption, updateOption, webIdType)).Data;
		}

		/// <summary>
		/// Updates a value for the specified stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="value">The value to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'. This parameter is ignored if the attribute is a configuration item.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>HttpApiResponse<object></returns>
		public HttpApiResponse<object> UpdateValueWithHttp(string webId, PWATimedValue value, string bufferOption = null, string updateOption = null, string webIdType = null)
		{
			if (webId == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'webId'");
			}

			if (value == null)
			{
				throw new HttpApiException(400, "Missing required parameter 'value'");
			}

			string serviceUrl = "/streams/{webId}/value";
			UrlBuilder urlBuilder = new UrlBuilder(serviceUrl);
			urlBuilder.AddPathParameter("webId", webId);
			urlBuilder.AddBody(value);
			urlBuilder.AddQueryParameter("bufferOption", bufferOption);
			urlBuilder.AddQueryParameter("updateOption", updateOption);
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
		/// Updates a value for the specified stream.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <exception cref="PIDevGuru.PIWebApiClient.Exceptions.HttpApiException">Thrown when fails to make API call</exception>
		/// <param name="webId">The ID of the stream.</param>
		/// <param name="value">The value to add or update.</param>
		/// <param name="bufferOption">The desired AFBufferOption. The default is 'BufferIfPossible'.</param>
		/// <param name="updateOption">The desired AFUpdateOption. The default is 'Replace'. This parameter is ignored if the attribute is a configuration item.</param>
		/// <param name="webIdType">Optional parameter. Used to specify the type of WebID. Useful for URL brevity and other special cases. Default is the value of the configuration item "WebIDType".</param>
		/// <returns>object</returns>
		public object UpdateValue(string webId, PWATimedValue value, string bufferOption = null, string updateOption = null, string webIdType = null)
		{
			return (this.UpdateValueWithHttp(webId, value, bufferOption, updateOption, webIdType)).Data;
		}

	}
}
