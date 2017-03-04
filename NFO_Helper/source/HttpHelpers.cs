using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Windows.Forms;
using System.IO;

namespace NFO_Helper
{
    class HttpHelpers
    {
        static private UrlCache contentCache = new UrlCache();

        static public async Task<HttpResponseMessage> getHttpResponseAsync(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return response;
        }

        static public async Task<HttpContent> getHttpResponseContentAsync(string url)
        {
            // first lookup in UrlCache. if found, return that.
            HttpContent cached = contentCache.isCached(url);
            if (cached != null)
                return cached;

            HttpResponseMessage response = await getHttpResponseAsync(url);
            if (response == null)
                throw new DataProviderException("HTTP Response Error. Invalid Response (null) from request: " + url);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new DataProviderException("HTTP Error Response: " + response.ReasonPhrase + " in request: " + url);

            // add this to the cache.
            contentCache.toCache(url, response.Content);
            return response.Content;
        }

        static public async Task<string> getHttpUrlResultAsStringAsync( string url )
        {
            HttpContent c = await getHttpResponseContentAsync(url);
            if (c == null)
                throw new DataProviderException("Failed to get HTTP Content for URL: " + url);

            string result = await c.ReadAsStringAsync();
            if (result == null)
                throw new DataProviderException("Failed to get String contents for URL: " + url);

            return result;
        }

        static public async Task<Stream> getHttpUrlResultAsStreamAsync(string url)
        {
            HttpContent c = await getHttpResponseContentAsync(url);
            if (c == null)
                throw new DataProviderException("Failed to get HTTP Content for URL: " + url);

            Stream result = await c.ReadAsStreamAsync();
            if (result == null)
                throw new DataProviderException("Failed to get Stream contents for URL: " + url);

            return result;
        }
    }
}
