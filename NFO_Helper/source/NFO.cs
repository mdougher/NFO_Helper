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
        public string original_title { get; set; }
        public string set { get; set; }
        public string votes { get; set; }
        public string tagline { get; set; }
        public string thumb { get; set; }

        // NFO_Helper extensions to the NFO format.
        public IList<string> posterUrls { get; set; }

        public NFO()
        {
            genres = new List<string>();
            actors = new List<string>();
            posterUrls = new List<string>();
            reset();
        }

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
            original_title = "";
            set = "";
            votes = "";
            tagline = "";
            thumb = "";
        }

        public void setProperty(string propName, object typeValue)
        {
            if (propName == NFOConstants.Title) { title = typeValue.ToString(); }
            else if (propName == NFOConstants.Genres) { genres = (List<string>)typeValue; }
            else if (propName == NFOConstants.Rating) { rating = typeValue.ToString(); }
            else if (propName == NFOConstants.Outline) { outline = typeValue.ToString(); }
            else if (propName == NFOConstants.Runtime) { runtime = typeValue.ToString(); }
            else if (propName == NFOConstants.Year) { year = typeValue.ToString(); }
            else if (propName == NFOConstants.Id) { id = typeValue.ToString(); }
            else if (propName == NFOConstants.Trailer) { trailer = typeValue.ToString(); }
            else if (propName == NFOConstants.Director) { director = typeValue.ToString(); }
            else if (propName == NFOConstants.Actors) { actors = (List<string>)typeValue; }
            else if (propName == NFOConstants.Posters) { posterUrls = (List<string>)typeValue; }
            else if (propName == NFOConstants.OriginalTitle) { original_title = typeValue.ToString(); }
            else if (propName == NFOConstants.Set) { set = typeValue.ToString(); }
            else if (propName == NFOConstants.Votes) { votes = typeValue.ToString(); }
            else if (propName == NFOConstants.Tagline) { tagline = typeValue.ToString(); }
            else if (propName == NFOConstants.Thumb) { thumb = typeValue.ToString(); }
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
            // original title
            if (String.IsNullOrEmpty(original_title) == false) { output += tab + "<original_title>" + original_title + "</original_title>" + newline; }
            // set
            if (String.IsNullOrEmpty(set) == false) { output += tab + "<set>" + set + "</set>" + newline; }
            // rating
            if (String.IsNullOrEmpty(rating) == false) { output += tab + "<rating>" + rating + "</rating>" + newline; }
            // votes
            if (String.IsNullOrEmpty(votes) == false) { output += tab + "<votes>" + votes + "</votes>" + newline; }
            // year
            if (String.IsNullOrEmpty(year) == false) { output += tab + "<year>" + year + "</year>" + newline; }
            // tagline
            if (String.IsNullOrEmpty(tagline) == false) { output += tab + "<tagline>" + tagline + "</tagline>" + newline; }
            // outline
            if (String.IsNullOrEmpty(outline) == false) { output += tab + "<outline>" + outline + "</outline>" + newline; }
            // runtime
            if (String.IsNullOrEmpty(runtime) == false) { output += tab + "<runtime>" + runtime + "</runtime>" + newline; }
            // id
            if (String.IsNullOrEmpty(id) == false) { output += tab + "<id>" + id + "</id>" + newline; }
            // trailer
            if (String.IsNullOrEmpty(trailer) == false) { output += tab + "<trailer>" + trailer + "</trailer>" + newline; }
            // thumb
            if (String.IsNullOrEmpty(thumb) == false) { output += tab + "<thumb>" + thumb + "</thumb>" + newline; }
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
