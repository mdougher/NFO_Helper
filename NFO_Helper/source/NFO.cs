using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper
{
    public class NFO 
    {
        public string title { get; set; }
        public string rating { get; set; }
        public string year { get; set; }
        public string outline { get; set; }
        public string runtime { get; set; }
        public string id { get; set; }
        public string trailer { get; set; }
        public IList<string> genres { get; set; }
        public string director { get; set; }
        public IList<string> actors { get; set; }
        public IList<string> posterUrls { get; set; }

        public void reset()
        {
            title = "";
            rating = "";
            year = "";
            outline = "";
            runtime = "";
            id = "";
            genres.Clear();
            director = "";
            actors.Clear();
            posterUrls.Clear();
        }

        public void setProperty(string propName, object typeValue)
        {
            if( propName == "title" ) { title = typeValue.ToString(); }
            else if( propName == "genres" ) { genres = (List<string>)typeValue; }
            else if ( propName == "rating" ) { rating = typeValue.ToString(); }
            else if ( propName == "outline" ) { outline = typeValue.ToString(); }
            else if (propName == "runtime" ) { runtime = typeValue.ToString(); }
            else if (propName == "year" ) { year = typeValue.ToString(); }
            else if (propName == "id" ) { id = typeValue.ToString(); }
            else if (propName == "trailer" ) { trailer = typeValue.ToString(); }
            else if (propName == "director" ) { director = typeValue.ToString(); }
            else if (propName == "actors" ) { actors = (List<string>)typeValue; }
            else if (propName == "posters" ) { posterUrls = (List<string>)typeValue; }
        }
        
        public string toXML(bool pretty)
        {
            string output = "";
            string newline = (pretty ? "\r\n" : "");
            string tab = (pretty ? "\t" : "");
            // start with the movie tag.
            output += "<movie>" + newline;
            // title
            if (String.IsNullOrEmpty(title) == false) { output += tab + "<title>" + title + "</title>" + newline; }
            // rating
            if (String.IsNullOrEmpty(rating) == false) { output += tab + "<rating>" + rating + "</rating>" + newline; }
            // year
            if (String.IsNullOrEmpty(year) == false) { output += tab + "<year>" + year + "</year>" + newline; }
            // outline
            if (String.IsNullOrEmpty(outline) == false) { output += tab + "<outline>" + outline + "</outline>" + newline; }
            // runtime
            if (String.IsNullOrEmpty(runtime) == false) { output += tab + "<runtime>" + runtime + "</runtime>" + newline; }
            // id
            if (String.IsNullOrEmpty(id) == false) { output += tab + "<id>" + id + "</id>" + newline; }
            // trailer
            if (String.IsNullOrEmpty(trailer) == false) { output += tab + "<trailer>" + trailer + "</trailer>" + newline; }
            // genre
            if (genres != null && genres.Any() == true)
            {
                output += tab + "<genre>";
                string genrelist = "";
                foreach (string g in genres)
                {
                    if (String.IsNullOrEmpty(genrelist) == false)
                    {
                        genrelist += ",";
                    }
                    genrelist += g;
                }
                output += genrelist + "</genre>" + newline;
            }
            // director
            if (String.IsNullOrEmpty(director) == false) { output += tab + "<director>" + director + "</director>" + newline; }
            // actor list
            if (actors != null && actors.Any() == true)
            {
                foreach (String s in actors)
                {
                    output += tab + "<actor>" + newline;
                    output += tab + tab + "<name>" + s + "</name>" + newline;
                    output += tab + "</actor>" + newline;
                }
            }
            // close movie tag
            output += "</movie>" + newline;
            return output;
        }
    }
}
