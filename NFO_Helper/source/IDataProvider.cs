using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper
{
    abstract public class IDataProvider
    {
        // given a filter of properties, return a populated NFO object.
        abstract public Task<NFO> getNFOAsync(string movieId, NFO_Filter propertiesFilter);

        abstract public Task<SearchResults> getSearchResultsAsync(string searchData);
    }
}
