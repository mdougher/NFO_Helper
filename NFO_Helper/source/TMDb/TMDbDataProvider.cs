using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NFO_Helper.TMDb
{
    class TMDbDataProvider : IDataProvider
    {
        private IList<INfoDataSource> mySources;
        Configuration config;
        public TMDbDataProvider()
        {
            mySources = new List<INfoDataSource>();
        }

        // implement from IDataProvider
        override public async Task<NFO> getNFOAsync(string movieId, NFO_Filter propertiesFilter)
        {
            // get configuration before we do anything else.
            if (await updateConfigurationAsync() == false)
                return null;

            mySources.Clear();
            mySources.Add(new TMDbMovieSource(movieId));
            mySources.Add(new TMDbCreditsSource(movieId));
            mySources.Add(new TMDbImagesSource(movieId, config));
            mySources.Add(new TMDbVideosSource(movieId));

            NFO nfo = new NFO(); // NFO to populate.
            List<String> properties = propertiesFilter.getPropertyList();
            foreach( string nfoProp in properties )
            {
                // get this property from one of the sources.
                foreach (INfoDataSource source in mySources)
                {
                    object obj = await source.getProperty(nfoProp);
                    if (obj != null)
                    {
                        nfo.setProperty(nfoProp, obj);
                        break; // got it from this source, stop looking for this prop.
                    }
                }
            }
            return nfo;
        }
        
        private async Task<bool> updateConfigurationAsync()
        {
            if (config != null)
            {
                // already have configuration.
                return true;
            }
            // don't have configuration, call API to get it.
            config = await TMDbApi.getConfigurationAsync(global::NFO_Helper.Settings.Default.TMDb_Api_Key);
            return (config != null);
        }

        override public async Task<SearchResults> getSearchResultsAsync(string searchData)
        {
            // make sure we have our configuration.
            if (await updateConfigurationAsync() == false)
                return null;

            // see if the user included a year in the search data.
            var regex = new Regex(@"(?<title>.*) \((?<year>\d{4})\)");
            var regexMatch = regex.Matches(searchData);
            string inputYear = "";
            string inputTitle = searchData;
            foreach (Match match in regexMatch)
            {
                inputYear = match.Groups["year"].Value;
                inputTitle = match.Groups["title"].Value;
                break; // take the first.
            }

            SearchResults res = new SearchResults();
            Search srch = await TMDbApi.getMovieSearchAsync(global::NFO_Helper.Settings.Default.TMDb_Api_Key, inputTitle, inputYear);

            if (srch != null)
            {
                // translate TMDb.Search to SearchResults.
                foreach( SearchResult s in srch.results )
                {
                    string year = (String.IsNullOrEmpty(s.release_date) == false ? s.release_date.Substring(0, 4) : "");
                    string posterUrl = (String.IsNullOrEmpty(s.poster_path) == false ? config.images.base_url + config.images.poster_sizes[0] + s.poster_path : "");
                    res.Add(s.id.ToString(), s.title, year, s.overview, posterUrl);
                }
            }
            return res;
        }
    }
}
