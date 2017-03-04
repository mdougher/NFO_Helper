using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFO_Helper.TMDb
{
    class Cast
    {
        public string cast_id { get; set; }
        public string character { get; set; }
        public string credit_id { get; set; }
        public uint id { get; set; }
        public string name { get; set; }
        public uint order { get; set; }
        public string profile_path { get; set; }
    }
    class Crew
    {
        public string credit_id { get; set; }
        public string department { get; set; }
        public uint id { get; set; }
        public string job { get; set; }
        public string name { get; set; }
        public string profile_path { get; set; }
    }
    class Credits
    {
        public uint id { get; set; }
        public IList<Cast> cast { get; set; }
        public IList<Crew> crew { get; set; }
    }
}
