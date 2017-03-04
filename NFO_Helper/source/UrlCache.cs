using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Timers;

namespace NFO_Helper
{
    class CacheObject
    {
        public HttpContent Content { get; set; }
        public System.Diagnostics.Stopwatch watch { get; set; }
        public bool isStale { get; set; }
        public CacheObject( HttpContent content)
        {
            Content = content;
            watch = System.Diagnostics.Stopwatch.StartNew();
            isStale = false;
        }
    }

    class UrlCache
    {
        private Dictionary<string, CacheObject> cache { get; set; }
        private uint CacheLifetimeSec { get; set; }
        private uint CacheStaleTimerSec { get; set; }

        public UrlCache( uint lifetimeInSeconds = 300 ) // default is 5 min.
        {
            CacheLifetimeSec = lifetimeInSeconds;
            cache = new Dictionary<string, CacheObject>();
            CacheStaleTimerSec = 15; // somewhat arbitrary number.

            // use a timer to periodically check for stale items in the cache.
            System.Timers.Timer staleTimer = new System.Timers.Timer();
            staleTimer.Elapsed += new ElapsedEventHandler(onTimerExpire);
            staleTimer.Interval = CacheStaleTimerSec * 1000;
            staleTimer.Enabled = true;
        }
        private void onTimerExpire(object source, ElapsedEventArgs e)
        {
            lock(cache)
            {
                // iterate through dictionary, remove anything that has been there more than the max time allowed.
                foreach(KeyValuePair<string,CacheObject> entry in cache )
                {
                    if (entry.Value.isStale == true)
                        continue;

                    entry.Value.watch.Stop();
                    if( entry.Value.watch.ElapsedMilliseconds > CacheLifetimeSec * 1000 )
                    {
                        entry.Value.isStale = true;
                        // no need to re-start the stopwatch...its stale.
                    }
                    else
                    {
                        // start the stopwatch again.
                        entry.Value.watch.Start();
                    }
                }
            }
        }
        public void toCache(string url, HttpContent content )
        {
            lock (cache)
            {
                cache.Add(url, new CacheObject(content));
            }
        }
        public HttpContent isCached(string url )
        {
            HttpContent content = null;
            lock (cache)
            {
                CacheObject temp;
                if (cache.TryGetValue(url, out temp) == true)
                {
                    if (temp.isStale == false)
                    {
                        content = temp.Content;
                    }
                }
            }
            return content;
        }
    }
}
