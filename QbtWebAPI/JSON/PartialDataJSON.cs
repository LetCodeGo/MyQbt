using System.Collections.Generic;

namespace QbtWebAPI.JSON
{
	internal class PartialDataJSON
	{
		public int rid { get; set; }
		public bool full_update { get; set; }
		public Dictionary<string, TorrentJSON> torrents { get; set; }
		public string[] torrents_removed { get; set; }
		public string[] categories { get; set; }
		public string[] categories_removed { get; set; }
		public bool queueing { get; set; }
        public TransferInfoJSON server_state { get; set; }
	}
}
