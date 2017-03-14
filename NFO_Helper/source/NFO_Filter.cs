using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper
{
    public class NFO_Filter
    {
        // filter will contain a list of 'properties' (string) that are requested for this NFO.
        protected List<string> NFO_PropertyList { get; set; }
        public string name { get; set; }
        public NFO_Filter()
        {
            name = AppConstants.TempNfoFilterName;
            NFO_PropertyList = new List<string>();
            // posters is required for all filters.
            // this is why we 'hide' the property list, so that this item doesn't accidentally get removed.
            NFO_PropertyList.Add(NFOConstants.Posters); 
        }

        public void setPropertyList( List<string> props )
        {
            foreach (string s in props)
            {
                NFO_PropertyList.Add(s);
            }
        }
        public List<String> getPropertyList()
        {
            return NFO_PropertyList;
        }
    }

    public class DefaultNfoFilter : NFO_Filter
    {
        public DefaultNfoFilter()
        {
            name = AppConstants.DefaultNfoFilterName;
            NFO_PropertyList.Add(NFOConstants.Title);
            NFO_PropertyList.Add(NFOConstants.Rating);
            NFO_PropertyList.Add(NFOConstants.Year);
            NFO_PropertyList.Add(NFOConstants.Outline);
            NFO_PropertyList.Add(NFOConstants.Runtime);
            NFO_PropertyList.Add(NFOConstants.Id);
            NFO_PropertyList.Add(NFOConstants.Trailer);
            NFO_PropertyList.Add(NFOConstants.Genres);
            NFO_PropertyList.Add(NFOConstants.Director);
            NFO_PropertyList.Add(NFOConstants.Actors);
            NFO_PropertyList.Add(NFOConstants.Tagline);
        }
    }
}
