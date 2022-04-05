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
            return callUrl(new Uri(url));
        }

        public static string callUrl(Uri uri)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    RequestUri = uri,
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

        public static List<Uri> sanitizeUrl(string url)
        {
            url = url.ToLower().Trim();

            List<Uri> urlToTest = new List<Uri>();
            if (Uri.CheckHostName(url) == UriHostNameType.Unknown){
                return urlToTest;  // return empty list as there is no valid host name
            }

            Uri address = new Uri(url);
            if (!Uri.CheckSchemeName(address.Scheme))
            {
                urlToTest.Add(new UriBuilder(Uri.UriSchemeHttp, url).Uri);
                urlToTest.Add(new UriBuilder(Uri.UriSchemeHttps, url).Uri);
            }
            else
            {
                urlToTest.Add(address);
            }
            return urlToTest;
        }
    }
}
