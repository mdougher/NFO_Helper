using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper
{
    class NFO_Filter_File
    {
        public string fileName { get; set; }
        public string filterName { get; set; }
        public List<string> filterProperties { get; set; }

        public bool parseFile(string filename)
        {
            // TBD: open file at this location
            // TBD: parse filename for 'name' & 'properties'.
            return true;
        }
        public bool writeFile(string filename)
        {
            return true;
        }
    }
}
