using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QbtWebAPI.JSON
{
    internal class BuildInfoJSON
    {
        public string qt { get; set; }
        public string libtorrent { get; set; }
        public string boost { get; set; }
        public string openssl { get; set; }
        public string bitness { get; set; }
    }
}
