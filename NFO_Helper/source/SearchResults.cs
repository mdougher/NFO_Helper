using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper
{
    public class SearchResult
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Outline { get; set; }
        public string Poster { get; set; }

        public SearchResult()
        {
        }
        public SearchResult(string id, string name, string year, string outline, string poster_url)
        {
            ID = id;
            Title = name;
            Year = year;
            Outline = outline;
            Poster = poster_url;
        }
    }
    public class SearchResults
    {
        public IList<SearchResult> results { get; set; }

        public SearchResults()
        {
            results = new List<SearchResult>();
        }

        public void Add( string id, string name, string year, string outline, string poster_url )
        {
            results.Add(new SearchResult(id, name, year, outline, poster_url));
        }
    }
}
