using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper
{
    interface INfoDataSource
    {
        Task<object> getProperty(string propName);
        Task<bool> refreshData();
    }
}
