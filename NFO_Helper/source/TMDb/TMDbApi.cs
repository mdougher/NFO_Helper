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
        static public async Task<TMDb.Configuration> getConfigurationAsync(string apikey)
        {
            string base_url = "https://api.themoviedb.org/3/configuration";

            string url = base_url + "?api_key=" + apikey;
            string result = await HttpHelpers.getHttpUrlResultAsStringAsync(url);
            if (result != null)
            {
                TMDb.Configuration config = new TMDb.Configuration();
                try
                {
                    config = JsonConvert.DeserializeObject<TMDb.Configuration>(result);
                }
                catch( JsonException ex )
                {
                    throw new DataProviderException("Json Exception while deserializing Configuration: " + ex.Message);
                }
                return config;
            }
            return null;
        }
        static public async Task<TMDb.Search> getMovieSearchAsync(string apikey, string query, string year = "")
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
                TMDb.Search s = new TMDb.Search();
                try
                {
                    s = JsonConvert.DeserializeObject<TMDb.Search>(result);
                }
                catch (JsonException ex)
                {
                    throw new DataProviderException("Json Exception while deserializing Search: " + ex.Message);
                }
                return s;
            }
            return null;
        }
        static public async Task<TMDb.Videos> getMovieVideosAsync(string apikey, string id)
        {
            string base_url = "https://api.themoviedb.org/3/movie/";
            string url = base_url + id + "/videos?api_key=" + apikey + "&language=en-US";
            string result = await HttpHelpers.getHttpUrlResultAsStringAsync(url);
            if (result != null)
            {
                TMDb.Videos v = new TMDb.Videos();
                try
                {
                    v = JsonConvert.DeserializeObject<TMDb.Videos>(result);
                }
                catch (JsonException ex)
                {
                    throw new DataProviderException("Json Exception while deserializing Videos: " + ex.Message);
                }
                return v;
            }
            return null;
        }
        static public async Task<TMDb.Images> getMovieImagesAsync(string apikey, string id)
        {
            string base_url = "https://api.themoviedb.org/3/movie/";
            string url = base_url + id + "/images?api_key=" + apikey + "&language=en-US&include_image_language=en";
            string result = await HttpHelpers.getHttpUrlResultAsStringAsync(url);
            if (result != null)
            {
                TMDb.Images i = new TMDb.Images();
                try
                {
                    i = JsonConvert.DeserializeObject<TMDb.Images>(result);
                }
                catch (JsonException ex)
                {
                    throw new DataProviderException("Json Exception while deserializing Images: " + ex.Message);
                }
                return i;
            }
            return null;
        }
        static public async Task<TMDb.Credits> getMovieCreditsAsync(string apikey, string id)
        {
            string base_url = "https://api.themoviedb.org/3/movie/";
            string url = base_url + id + "/credits?api_key=" + apikey;
            string result = await HttpHelpers.getHttpUrlResultAsStringAsync(url);
            if (result != null)
            {
                TMDb.Credits c = new TMDb.Credits();
                try
                {
                    c = JsonConvert.DeserializeObject<TMDb.Credits>(result);
                }
                catch (JsonException ex)
                {
                    throw new DataProviderException("Json Exception while deserializing Credits: " + ex.Message);
                }
                return c;
            }
            return null;
        }
        static public async Task<TMDb.Movie> getMovieAsync(string apikey, string id)
        {
            string base_url = "https://api.themoviedb.org/3/movie/";
            string url = base_url + id + "?api_key=" + apikey + "&language=en-US";
            string result = await HttpHelpers.getHttpUrlResultAsStringAsync(url);
            if (result != null)
            {
                TMDb.Movie m = new TMDb.Movie();
                try
                {
                    m = JsonConvert.DeserializeObject<TMDb.Movie>(result);
                }
                catch (JsonException ex)
                {
                    throw new DataProviderException("Json Exception while deserializing Movie: " + ex.Message);
                }
                return m;
            }
            return null;
        }
    }
}
