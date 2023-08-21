using System.Collections.Generic;

namespace PIDevGuru.PIWebApiClient.Client
{
    public class HttpApiResponse<T>
    {
        public int StatusCode { get; private set; }
       
        public IDictionary<string, string> Headers { get; private set; }
      
        public T Data { get; private set; }
       
        public HttpApiResponse(int statusCode, IDictionary<string, string> headers, T data)
        {
            this.StatusCode = statusCode;
            this.Headers = headers;
            this.Data = data;
        }
    }
}

