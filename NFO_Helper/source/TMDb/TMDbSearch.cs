using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper.TMDb
{
    class SearchResult
    {
        public string poster_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public IList<uint> genre_ids { get; set; }
        public uint id { get; set; }
        public string original_title { get; set; }
        public string original_language { get; set; }
        public string title { get; set; }
        public string backdrop_path { get; set; }
        public float popularity { get; set; }
        public uint vote_count { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
    }
    class Search
    {
        public string page { get; set; }
        public string total_results { get; set; }
        public string total_pages { get; set; }
        public IList<SearchResult> results { get; set; }
    }
}
