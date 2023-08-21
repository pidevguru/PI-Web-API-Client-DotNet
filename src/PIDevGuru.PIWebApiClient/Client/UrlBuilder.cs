using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace PIDevGuru.PIWebApiClient.Client
{
    public class UrlBuilder
    {
        public UrlBuilder(string serviceUrl)
        {
            this.ServiceUrl = serviceUrl;
            this.QueryRepository = new Dictionary<string, string>();
            this.PathRepository = new Dictionary<string, string>();
            this.QueryListRepository = new Dictionary<string, List<string>>();
        }

        private JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public string Body { get; internal set; }

        public HttpMethod HttpMethod { get; internal set; }
        public string ServiceUrl { get; private set; }

        public IDictionary<string, string> QueryRepository { get; private set; }

        public IDictionary<string, List<string>> QueryListRepository { get; private set; }

        public IDictionary<string, string> PathRepository { get; private set; }

        internal void AddQueryParameter(string key, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }
            QueryRepository.Add(key, value);
        }

        internal void AddQueryParameter(string key, List<string> value)
        {
            if (value == null)
            {
                return;
            }
            QueryListRepository.Add(key, value);
        }

        internal void AddQueryParameter(string key, int? value)
        {
            if (value == null)
            {
                return;
            }
            QueryRepository.Add(key, value.ToString());
        }

        internal void AddQueryParameter(string key, bool? value)
        {
            if (value == null)
            {
                return;
            }
            QueryRepository.Add(key, value.ToString());
        }

        internal void AddPathParameter(string key, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }
            PathRepository.Add(key, value);
        }

        internal void AddBody(object value)
        {   
            this.Body = JsonConvert.SerializeObject(value, Formatting.Indented, jsonSerializerSettings);
        }
    }
}