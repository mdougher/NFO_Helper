using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper.TMDb
{
    class Image_Base
    {
        public float aspect_ratio { get; set; }
        public string file_path { get; set; }
        public uint height { get; set; }
        public string iso_639_1 { get; set; }
        public float vote_average { get; set; }
        public uint vote_count { get; set; }
        public uint width { get; set; }
    }
    class Backdrop : Image_Base { }
    class Poster : Image_Base { }

    class Images
    {
        public uint id { get; set; }
        public IList<Backdrop> backdrops { get; set; }
        public IList<Poster> posters { get; set; }
    }
}
