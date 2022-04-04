using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SiteTester.Core.Application
{
    internal class SiteRequest
    {
        public static string callUrl(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Head,
                };
                Task<HttpResponseMessage> task = client.SendAsync(request);
                task.Wait();

                if (task.Result == null)
                {
                    return "ConnectionError";
                }
                else
                {
                    HttpStatusCode httpStatusCode = task.Result.StatusCode;
                    return ((int)httpStatusCode).ToString(); // int because httpStatusCode is an enum 200 = OK
                }
            }
            catch (WebException)
            {
                return "WebException";
            }
            catch (Exception)
            {
                return "Other Exception";
            }
        }
    }
}
