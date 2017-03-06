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
        public IList<string> NFO_PropertyList;
        public NFO_Filter()
        {
            NFO_PropertyList = new List<string>();
        }
    }

    public class DefaultNfoFilter : NFO_Filter
    {
        public DefaultNfoFilter()
        {
            NFO_PropertyList.Add("title");
            NFO_PropertyList.Add("rating");
            NFO_PropertyList.Add("year");
            NFO_PropertyList.Add("outline");
            NFO_PropertyList.Add("runtime");
            NFO_PropertyList.Add("id");
            NFO_PropertyList.Add("trailer");
            NFO_PropertyList.Add("genres");
            NFO_PropertyList.Add("director");
            NFO_PropertyList.Add("actors");
            NFO_PropertyList.Add("posters");
            NFO_PropertyList.Add("tagline");
        }
    }
}
