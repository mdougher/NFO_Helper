using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace NFO_Helper.TMDb
{
    class TMDbApi
    {
        static public async Task<Configuration> getConfigurationAsync(string apikey)
        {
            string base_url = "https://api.themoviedb.org/3/configuration";

            string url = base_url + "?api_key=" + apikey;
            string result = await HttpHelpers.getHttpUrlResultAsStringAsync(url);
            if (result != null)
            {
                Configuration config = new Configuration();
                config = JsonConvert.DeserializeObject<Configuration>(result);
                return config;
            }
            return null;
        }
        static public async Task<Search> getMovieSearchAsync(string apikey, string query, string year = "")
        {
            string baseUrl = "https://api.themoviedb.org/3/search/movie";
            string url = baseUrl + "?api_key=" + apikey + "&language=en-US&query=" + query + "&page=1";
            if (String.IsNullOrEmpty(year) == false)
            {
                url += "&year=" + year;
            }
            string result = await HttpHelpers.getHttpUrlResultAsStringAsync(url);
            if (result != null)
            {
                Search s = new Search();
                s = JsonConvert.DeserializeObject<Search>(result);
                return s;
            }
            return null;
        }
        static public async Task<Videos> getMovieVideosAsync(string apikey, string id)
        {
            string base_url = "https://api.themoviedb.org/3/movie/";
            string url = base_url + id + "/videos?api_key=" + apikey + "&language=en-US";
            string result = await HttpHelpers.getHttpUrlResultAsStringAsync(url);
            if (result != null)
            {
                Videos v = new Videos();
                v = JsonConvert.DeserializeObject<Videos>(result);
                return v;
            }
            return null;
        }
        static public async Task<Images> getMovieImagesAsync(string apikey, string id)
        {
            string base_url = "https://api.themoviedb.org/3/movie/";
            string url = base_url + id + "/images?api_key=" + apikey + "&language=en-US&include_image_language=en";
            string result = await HttpHelpers.getHttpUrlResultAsStringAsync(url);
            if (result != null)
            {
                Images i = new Images();
                i = JsonConvert.DeserializeObject<Images>(result);
                return i;
            }
            return null;
        }
        static public async Task<Credits> getMovieCreditsAsync(string apikey, string id)
        {
            string base_url = "https://api.themoviedb.org/3/movie/";
            string url = base_url + id + "/credits?api_key=" + apikey;
            string result = await HttpHelpers.getHttpUrlResultAsStringAsync(url);
            if (result != null)
            {
                Credits c = new Credits();
                c = JsonConvert.DeserializeObject<Credits>(result);
                return c;
            }
            return null;
        }
        static public async Task<Movie> getMovieAsync(string apikey, string id)
        {
            string base_url = "https://api.themoviedb.org/3/movie/";
            string url = base_url + id + "?api_key=" + apikey + "&language=en-US";
            string result = await HttpHelpers.getHttpUrlResultAsStringAsync(url);
            if (result != null)
            {
                Movie m = new Movie();
                m = JsonConvert.DeserializeObject<Movie>(result);
                return m;
            }
            return null;
        }
    }
}
