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
            {
                MessageBox.Show("HTTP Response Error. Invalid Response (null) from request: " + url, "NFO_Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("HTTP Error Code " + response.StatusCode + "(" + response.ReasonPhrase + ") in request: " + url, "NFO_Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            // add this to the cache.
            contentCache.toCache(url, response.Content);
            return response.Content;
        }

        static public async Task<string> getHttpUrlResultAsStringAsync( string url )
        {
            HttpContent c = await getHttpResponseContentAsync(url);
            if (c == null)
            {
                // do not give a message box, assume one has already been shown.
                return null;
            }
            string result = await c.ReadAsStringAsync();
            if (result == null)
            {
                MessageBox.Show("Failed to get stream contents for request: " + url, "NFO_Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return result;
        }

        static public async Task<Stream> getHttpUrlResultAsStreamAsync(string url)
        {
            HttpContent c = await getHttpResponseContentAsync(url);
            if (c == null)
            {
                // do not give a message box, assume one has already been shown.
                return null;
            }
            Stream result = await c.ReadAsStreamAsync();
            if (result == null)
            {
                MessageBox.Show("Failed to get stream contents for request: " + url, "NFO_Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return result;
        }
    }
}
