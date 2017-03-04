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
        public CacheObject( HttpContent content)
        {
            Content = content;
            watch = System.Diagnostics.Stopwatch.StartNew();
        }
    }

    class UrlCache
    {
        private Dictionary<string, CacheObject> cache { get; set; }
        private uint CacheLifetimeSec { get; set; }

        public UrlCache( uint lifetimeInSeconds = 300 ) // default is 5 min.
        {
            CacheLifetimeSec = lifetimeInSeconds;
            cache = new Dictionary<string, CacheObject>();

            // TBD: periodically check to see if any of the cached items are 'dead' and should be removed.


            // TBD: rename
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(onTimerExpire);
            aTimer.Interval = lifetimeInSeconds*1000;
            aTimer.Enabled = true;
        }
        private void onTimerExpire(object source, ElapsedEventArgs e)
        {
            lock(cache)
            {
                // iterate through dictionary, remove anything that has been there more than the max time allowed.
                foreach(KeyValuePair<string,CacheObject> entry in cache )
                {
                    entry.Value.watch.Stop();
                    if( entry.Value.watch.ElapsedMilliseconds > CacheLifetimeSec * 1000 )
                    {
                        // TBD: remove stale entry! will this corrupt the map iteration?
                        // maybe just mark the value with a 'stale' member variable, and let the user of the cache decide what to do?
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
                    content = temp.Content;
                }
            }
            return content;
        }
    }
}
