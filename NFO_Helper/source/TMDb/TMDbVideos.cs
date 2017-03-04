using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper.TMDb
{
    class VideoResult
    {
        public string id { get; set; }
        public string iso_639_1 { get; set; }
        public string iso_3166_1 { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string site { get; set; }
        public string size { get; set; }
        public string type { get; set; }
    }
    class Videos
    {
        public uint id { get; set; }
        public IList<VideoResult> results { get; set; }
    }
}
