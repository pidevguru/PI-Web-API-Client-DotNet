using PIDevGuru.PIWebApiClient.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PIDevGuru.PIWebApiClient.Client
{
    public class HttpApiClient
    {
        private string baseUrl;
        private HttpClient httpClient;
        private bool noCacheHeaderCompatible;

        public HttpApiClient(HttpClient httpClient, string baseUrl, bool noCacheHeaderCompatible)
        {
            this.httpClient = httpClient;
            this.baseUrl = baseUrl;
            this.noCacheHeaderCompatible = noCacheHeaderCompatible;
        }

        public async Task<HttpResponseMessage> MakeHttpRequestAsync(UrlBuilder urlBuilder)
        {
            HttpRequestMessage request = PrepareRequest(urlBuilder);

            try
            {
                return await httpClient.SendAsync(request);
            }
            catch (TaskCanceledException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new HttpApiException(1, e.Message);
            }
        }

        public HttpResponseMessage MakeHttpRequest(UrlBuilder urlBuilder)
        {
            HttpRequestMessage request = PrepareRequest(urlBuilder);

            try
            {
                return httpClient.SendAsync(request).Result;
            }
            catch (TaskCanceledException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new HttpApiException(1, e.Message);
            }
        }

        private HttpRequestMessage PrepareRequest(UrlBuilder urlBuilder)
        {
            string serviceUrl = urlBuilder.ServiceUrl;
            foreach (var param in urlBuilder.PathRepository)
            {
                serviceUrl = serviceUrl.Replace("{" + param.Key + "}", param.Value);
            }
            string requestUri = string.Format("{0}{1}", this.baseUrl, serviceUrl);

            string queryString = string.Empty;
            if ((urlBuilder.QueryRepository != null) && (urlBuilder.QueryRepository.Count > 0))
            {
                foreach (var query in urlBuilder.QueryRepository)
                {
                    queryString += string.Format("{0}={1}&", query.Key, WebUtility.UrlEncode(query.Value));
                }
            }

            if ((urlBuilder.QueryListRepository != null) && (urlBuilder.QueryListRepository.Count > 0))
            {
                foreach (var query in urlBuilder.QueryListRepository)
                {
                    List<string> queryValueList = query.Value;
                    foreach (var queryValueItem in queryValueList)
                    {
                        queryString += string.Format("{0}={1}&", query.Key, WebUtility.UrlEncode(queryValueItem));
                    }
                }
            }
            if (queryString.Length > 0)
            {
                requestUri = string.Format("{0}?{1}", requestUri, queryString.Substring(0, queryString.Length - 1));
            }
            HttpRequestMessage request = new HttpRequestMessage(urlBuilder.HttpMethod, requestUri);
            if (noCacheHeaderCompatible == true)
            {
                request.Headers.Add("Cache-Control", "no-cache");
            }

            if ((urlBuilder.HttpMethod != HttpMethod.Get) && (urlBuilder.HttpMethod != HttpMethod.Delete) && string.IsNullOrEmpty(urlBuilder.Body) == false)
            {
                request.Content = new StringContent(urlBuilder.Body, Encoding.UTF8, "application/json");
            }
            return request;
        }
    }
}
