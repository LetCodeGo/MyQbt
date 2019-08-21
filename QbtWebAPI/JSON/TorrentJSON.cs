namespace QbtWebAPI.JSON
{
	internal class TorrentJSON
	{
		public int added_on { get; set; }
		public long amount_left { get; set; }
		public string category { get; set; }
		public long completed { get; set; }
		public long completion_on { get; set; }
		public long dl_limit { get; set; }
		public long dlspeed { get; set; }
		public long downloaded { get; set; }
		public long downloaded_session { get; set; }
		public long eta { get; set; }
		public bool f_l_piece_prio { get; set; }
		public bool force_start { get; set; }
		public string hash { get; set; }
		public int last_activity { get; set; }
		public string name { get; set; }
		public int num_complete { get; set; }
		public int num_incomplete { get; set; }
		public int num_leechs { get; set; }
		public int num_seeds { get; set; }
		public int priority { get; set; }
		public float progress { get; set; }
		public float ratio { get; set; }
		public float ratio_limit { get; set; }
		public string save_path { get; set; }
		public long seen_complete { get; set; }
		public bool seq_dl { get; set; }
		public long size { get; set; }
		public string state { get; set; }
		public bool super_seeding { get; set; }
		public long total_size { get; set; }
		public string tracker { get; set; }
		public long up_limit { get; set; }
		public long uploaded { get; set; }
		public long uploaded_session { get; set; }
		public long upspeed { get; set; }
	}
}
