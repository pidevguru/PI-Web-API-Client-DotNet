using PIDevGuru.PIWebApiClient.Exceptions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PIDevGuru.PIWebApiClient.Client
{
    public class ExceptionFactory
    {
        public static async Task<Exception> DefaultExceptionFactory(string methodName, HttpResponseMessage response)
        {
            string httpContent = await response.Content.ReadAsStringAsync();
            int status = (int)response.StatusCode;
            if (status >= 400)
            {
                return new HttpApiException(status, String.Format("Error calling {0}: {1}", methodName, httpContent));
            }
            if (status == 0)
            {
                return new HttpApiException(status, String.Format("Error calling {0}: {1}", methodName, httpContent));
            }
            return null;
        }
    }
}
