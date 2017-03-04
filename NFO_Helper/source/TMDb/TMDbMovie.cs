using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper.TMDb
{
    class Collection
    {
        public uint id { get; set; }
        public string name { get; set; }
        public string poster_path { get; set; }
        public string backdrop_path { get; set; }
    }
    class Genre
    {
        public uint id { get; set; }
        public string name { get; set; }
    }
    class ProductionCompany
    {
        public string name { get; set; }
        public uint id { get; set; }
    }
    class ProductionCountry
    {
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }
    class SpokenLanguage
    {
        public string iso_639_1 { get; set; }
        public string name { get; set; }
    }
    class Movie
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public Collection belongs_to_collection { get; set; }
        public uint budget { get; set; }
        public IList<Genre> genres { get; set; }
        public string homepage { get; set; }
        public uint id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public IList<ProductionCompany> production_companies { get; set; }
        public IList<ProductionCountry> production_countries { get; set; }
        public string release_date { get; set; }
        public uint revenue { get; set; }
        public uint runtime { get; set; }
        public IList<SpokenLanguage> spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public uint vote_count { get; set; }
    }
}
