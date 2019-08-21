using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QbtWebAPI.Data
{
    public class BuildInfo
    {
        public string qt { get; set; }
        public string libtorrent { get; set; }
        public string boost { get; set; }
        public string openssl { get; set; }
        public string bitness { get; set; }

        public BuildInfo() { }

        internal BuildInfo(JSON.BuildInfoJSON b)
        {
            qt = b.qt;
            libtorrent = b.libtorrent;
            boost = b.boost;
            openssl = b.openssl;
            bitness = b.bitness;
        }
    }
}
