using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper
{
    public class NFO 
    {
        private List<Tuple<string,object>> properties { get; set; }

        public NFO()
        {
            properties = new List<Tuple<string, object>>();
            reset();
        }

        public void reset()
        {
            properties.Clear();
        }

        public void setProperty(string propName, object typeValue)
        {
            properties.Add(new Tuple<string, object>(propName, typeValue));
        }

        public object getProperty(string propName)
        {
            foreach (Tuple<string, object> property in properties)
            {
                if (String.Compare(property.Item1, propName) == 0)
                {
                    return property.Item2;
                }
            }
            return null;
        }
        
        public string toXML(bool pretty)
        {
            string output = "";
            string newline = (pretty ? "\r\n" : "");
            string tab = (pretty ? "\t" : "");
            // start with the movie tag.
            output += "<movie>" + newline;
            foreach (Tuple<string,object> property in properties)
            {
                // posters are not printed to XML, skip that property!
                if (String.Compare(property.Item1, NFOConstants.Posters) == 0)
                    continue;
                // title
                else if (String.Compare(property.Item1, NFOConstants.Title) == 0) { output += tab + "<title>" + property.Item2.ToString() + "</title>" + newline; }
                // original title
                else if (String.Compare(property.Item1, NFOConstants.OriginalTitle) == 0) { output += tab + "<original_title>" + property.Item2.ToString() + "</original_title>" + newline; }
                // set
                else if (String.Compare(property.Item1, NFOConstants.Set) == 0) { output += tab + "<set>" + property.Item2.ToString() + "</set>" + newline; }
                // rating
                else if (String.Compare(property.Item1, NFOConstants.Rating) == 0) { output += tab + "<rating>" + property.Item2.ToString() + "</rating>" + newline; }
                // votes
                else if (String.Compare(property.Item1, NFOConstants.Votes) == 0) { output += tab + "<votes>" + property.Item2.ToString() + "</votes>" + newline; }
                // year
                else if (String.Compare(property.Item1, NFOConstants.Year) == 0) { output += tab + "<year>" + property.Item2.ToString() + "</year>" + newline; }
                // tagline
                else if (String.Compare(property.Item1, NFOConstants.Tagline) == 0) { output += tab + "<tagline>" + property.Item2.ToString() + "</tagline>" + newline; }
                // outline
                else if (String.Compare(property.Item1, NFOConstants.Outline) == 0) { output += tab + "<outline>" + property.Item2.ToString() + "</outline>" + newline; }
                // runtime
                else if (String.Compare(property.Item1, NFOConstants.Runtime) == 0) { output += tab + "<runtime>" + property.Item2.ToString() + "</runtime>" + newline; }
                // id
                else if (String.Compare(property.Item1, NFOConstants.Id) == 0) { output += tab + "<id>" + property.Item2.ToString() + "</id>" + newline; }
                // trailer
                else if (String.Compare(property.Item1, NFOConstants.Trailer) == 0) { output += tab + "<trailer>" + property.Item2.ToString() + "</trailer>" + newline; }
                // thumb
                else if (String.Compare(property.Item1, NFOConstants.Thumb) == 0) { output += tab + "<thumb>" + property.Item2.ToString() + "</thumb>" + newline; }
                // director
                else if (String.Compare(property.Item1, NFOConstants.Director) == 0) { output += tab + "<director>" + property.Item2.ToString() + "</director>" + newline; }
                // genre
                else if (String.Compare(property.Item1, NFOConstants.Genres) == 0)
                {
                    List<String> genres = (List<String>)property.Item2;
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
                }
                // actor list
                else if( String.Compare(property.Item1, NFOConstants.Actors) == 0)
                {
                    List<String> actors = (List<String>)property.Item2;
                    if(actors != null && actors.Any() == true )
                    {
                        foreach (String s in actors)
                        {
                            output += tab + "<actor>" + newline;
                            output += tab + tab + "<name>" + s + "</name>" + newline;
                            output += tab + "</actor>" + newline;
                        }
                    }
                }
            } // end of foreach property
            // close movie tag
            output += "</movie>" + newline;
            return output;
        }
    }
}
