using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper.TMDb
{
    class TMDbMovieSource : INfoDataSource
    {
        private Movie myMovie;
        private string myMovieId { get; set; }

        public TMDbMovieSource(string movieId)
        {
            myMovieId = movieId;
        }
        public async Task<object> getProperty(string propName)
        {
            if (propName == "title") { return (await refreshData() == false ? null : myMovie.title); }
            else if (propName == "id") { return (await refreshData() == false ? null : myMovie.imdb_id); } // NFO property ID is asking for the IMDB ID, not the TMDB ID, which is just called "ID".
            else if (propName == "outline") { return (await refreshData() == false ? null : myMovie.overview); } // NFO property OUTLINE is the TMDB OVERVIEW.
            else if (propName == "genres")
            {
                if (await refreshData() == false)
                    return null;
                // convert from list of Genre to list of string.
                List<string> list = new List<string>();
                foreach (Genre g in myMovie.genres)
                { list.Add(g.name); }
                return list;
            }
            else if (propName == "year") { return (await refreshData() == false ? null : myMovie.release_date.Substring(0, 4)); } // take the year from the release_date.
            else if (propName == "runtime") { return (await refreshData() == false ? null : myMovie.runtime + " min"); } // append minute label to runtime.
            else if (propName == "rating") { return (await refreshData() == false ? 0 : myMovie.vote_average); } // rating is TMDB VOTE_AVERAGE.

            // did not find a property we want, return null!
            return null;
        }
        public async Task<bool> refreshData()
        {
            // if we have not already called this API, do so now!
            if (myMovie != null)
            {
                return true; // up to date
            }
            myMovie = await TMDbApi.getMovieAsync(global::NFO_Helper.Settings.Default.TMDb_Api_Key, myMovieId);
            return (myMovie != null);
        }

    }
    class TMDbCreditsSource : INfoDataSource
    {
        private string myMovieId { get; set; }
        private Credits myCredits { get; set; }

        public TMDbCreditsSource(string movieId)
        {
            myMovieId = movieId;
        }
        public async Task<object> getProperty(string propName)
        {
            if (propName == "director")
            {
                if (await refreshData() == false)
                    return null;
                IList<Crew> crew = myCredits.crew;
                foreach (Crew member in crew)
                {
                    if (String.Equals(member.job, "director", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        return member.name;
                    }
                }
                // could not find the director
                return null;
            }
            else if (propName == "actors")
            {
                if (await refreshData() == false)
                    return null;
                // get all cast, sort by 'order' field of each member.
                List<string> actors = new List<string>();
                if (myCredits.cast.Any() == true)
                {
                    IList<Cast> castlist = myCredits.cast.OrderBy(cast => cast.order).ToList();
                    foreach (Cast member in castlist)
                    {
                        actors.Add(member.name);
                    }
                }
                return actors;
            }
            return null;
        }
        public async Task<bool> refreshData()
        {
            if (myCredits != null)
            {
                return true; // already up to date.
            }
            myCredits = await TMDbApi.getMovieCreditsAsync(global::NFO_Helper.Settings.Default.TMDb_Api_Key, myMovieId);
            return (myCredits != null);
        }
    }
    class TMDbImagesSource : INfoDataSource
    {
        private string myMovieId { get; set; }
        private Images myImages { get; set; }
        private string imageSize { get; set; }
        private string myImageBaseUrl { get; set; }

        public TMDbImagesSource(string movieId, Configuration cfg)
        {
            myMovieId = movieId;
            myImageBaseUrl = cfg.images.base_url;

            // get an image that is at least [minimum] pixels in width.
            foreach ( string s in cfg.images.poster_sizes )
            {
                if( s.StartsWith("w"))
                {
                    string width = s.Substring(1);
                    int w = 0;
                    if( Int32.TryParse(width, out w) == true )
                    {
                        if (w >= global::NFO_Helper.Settings.Default.DesiredMinimumImageWidth)
                        {
                            imageSize = s;
                            break;
                        }
                    }
                }
            }
            // if we couldn't get an image that is our minimum size, just take the largest size available.
            if( String.IsNullOrEmpty(imageSize) == true )
            {
                int max = 0;
                foreach (string s in cfg.images.poster_sizes)
                {
                    if (s.StartsWith("w"))
                    {
                        string width = s.Substring(1);
                        int w = 0;
                        if (Int32.TryParse(width, out w) == true)
                        {
                            if (w > max)
                            {
                                imageSize = s;
                            }
                        }
                    }
                }
            }
            // if we STILL can't get an image, take whatever is in the list.
            if (String.IsNullOrEmpty(imageSize) == true)
            {
                imageSize = cfg.images.poster_sizes.FirstOrDefault();
            }
        } 
        public async Task<object> getProperty(string propName)
        {
            if (propName == "posters")
            {
                if (await refreshData() == false)
                    return null;
                // take the full list of posters, ordered by rating (?). update the string to use the complete url!
                List<string> posters = new List<string>();
                if (myImages.posters.Any() == true)
                {
                    foreach (Poster p in myImages.posters.OrderByDescending(poster => poster.vote_average).ToList())
                    {
                        // URL = base url + size + path.
                        posters.Add(myImageBaseUrl + imageSize + p.file_path);
                    }
                }
                return posters;
            }
            return null;
        }
        public async Task<bool> refreshData()
        {
            if (myImages != null)
            {
                return true; // already up to date.
            }
            myImages = await TMDbApi.getMovieImagesAsync(global::NFO_Helper.Settings.Default.TMDb_Api_Key, myMovieId);
            return (myImages != null);
        }
    }
    class TMDbVideosSource : INfoDataSource
    {
        private string myMovieId { get; set; }
        private Videos myVideos { get; set; }

        public TMDbVideosSource(string movieId)
        {
            myMovieId = movieId;
        }
        public async Task<object> getProperty(string propName)
        {
            if( propName == "trailer" )
            {
                if (await refreshData() == false)
                    return null;
                // take the first result which 'type' == trailer and 'site' == youtube.
                foreach (VideoResult video in myVideos.results)
                {
                    if (String.Equals(video.type, "trailer", StringComparison.OrdinalIgnoreCase) == true && video.site.IndexOf("youtube", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return "www.youtube.com/watch?v=" + video.key;
                    }
                }
            }
            return null;
        }
        public async Task<bool> refreshData()
        {
            if (myVideos != null)
            {
                return true; // already up to date.
            }
            myVideos = await TMDbApi.getMovieVideosAsync(global::NFO_Helper.Settings.Default.TMDb_Api_Key, myMovieId);
            return (myVideos != null);
        }
    }
}
