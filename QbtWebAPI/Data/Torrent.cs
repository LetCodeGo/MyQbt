using QbtWebAPI.Enums;
using QbtWebAPI.JSON;
using System;

namespace QbtWebAPI.Data
{
	/// <summary>
	/// Torrent.
	/// </summary>
    public class Torrent
    {
		/// <summary>
		/// When torrent was addes.
		/// </summary>
		public DateTime Added_On { get; set; }
		/// <summary>
		/// Amount of bytes left before completion.
		/// </summary>
		public long Amount_Left { get; set; }
		/// <summary>
		/// Category of the torrent.
		/// </summary>
		public string Category { get; set; }
		/// <summary>
		/// Amount completed bytes.
		/// </summary>
		public long Completed { get; set; }
		/// <summary>
		/// Completetion time.
		/// </summary>
		public DateTime Completion_On { get; set; }
		/// <summary>
		/// Torrent download speed limit in (bytes/s).
		/// </summary>
		public long Dl_Limit { get; set; }
		/// <summary>
		/// Torrent download speed (bytes/s).
		/// </summary>
		public long Dl_Speed { get; set; }
		/// <summary>
		/// Total data downloaded for torrent (bytes).
		/// </summary>
		public long Downloaded { get; set; }
		/// <summary>
		/// Data downloaded this session (bytes).
		/// </summary>
		public long Downloaded_Session { get; set; }
		/// <summary>
		/// Torrent ETA.
		/// </summary>
		public TimeSpan Eta { get; set; }
		/// <summary>
		/// True if first last piece are prioritized.
		/// </summary>
		public bool First_Last_Piece_Prio { get; set; }
		/// <summary>
		/// True if force start is enabled for this torrent.
		/// </summary>
		public bool Force_Start { get; set; }
		/// <summary>
		/// Torrent hash.
		/// </summary>
		public string Hash { get; set; }
		/// <summary>
		/// When last activity was.
		/// </summary>
		public DateTime Last_Activity { get; set; }
		/// <summary>
		/// Torrent name.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Number of seeds in the swarm.
		/// </summary>
		public int Num_Complete { get; set; }
		/// <summary>
		/// Number of leechers in the swarm.
		/// </summary>
		public int Num_Incomplete { get; set; }
		/// <summary>
		/// Number of leechers connected to.
		/// </summary>
		public int Num_Leechs { get; set; }
		/// <summary>
		/// Number of seeds connected to.
		/// </summary>
		public int Num_Seeds { get; set; }
		/// <summary>
		/// Torrent priority.
		/// </summary>
		public Priority Priority { get; set; }
		/// <summary>
		/// Torrent progress.
		/// </summary>
		public float Progress { get; set; }
		/// <summary>
		/// Torrent share ratio.
		/// </summary>
		public float Ratio { get; set; }
		/// <summary>
		/// Torrent ratio limit.
		/// </summary>
		public float Ratio_Limit { get; set; }
		/// <summary>
		/// Torrent save path.
		/// </summary>
		public string Save_Path { get; set; }
		/// <summary>
		/// When seen complete.
		/// </summary>
		public DateTime Seen_Complete { get; set; }
		/// <summary>
		/// True if sequential download is enabled.
		/// </summary>
		public bool Seq_Dl { get; set; }
		/// <summary>
		/// Total size (bytes) of files selected for download.
		/// </summary>
		public long Size { get; set; }
		/// <summary>
		/// Torrent state.
		/// </summary>
		public TorrentState State { get; set; }
		/// <summary>
		/// True if super seeding is enabled.
		/// </summary>
		public bool Super_Seeding { get; set; }
		/// <summary>
		/// Torrent total size (bytes).
		/// </summary>
		public long Total_Size { get; set; }
		/// <summary>
		/// Torrent tracker.
		/// </summary>
		public Uri Tracker { get; set; }
		/// <summary>
		/// Torrent upload speed limit in (bytes/s).
		/// </summary>
		public long Up_Limit { get; set; }
		/// <summary>
		/// Total data uploaded for torrent (bytes).
		/// </summary>
		public long Uploaded { get; set; }
		/// <summary>
		/// Total data uploaded this session (bytes).
		/// </summary>
		public long Uploaded_Session { get; set; }
		/// <summary>
		/// Torrent upload speed (bytes/s).
		/// </summary>
		public long Up_Speed { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Torrent"/> class.
		/// </summary>
		public Torrent() { }

		internal Torrent(TorrentJSON t)
		{
			Added_On = DateTimeOffset.FromUnixTimeSeconds(t.added_on).DateTime.ToLocalTime();
			Amount_Left = t.amount_left;
			Category = t.category;
			Completed = t.completed;
			Completion_On = DateTimeOffset.FromUnixTimeSeconds(t.completion_on).DateTime.ToLocalTime();
			Dl_Limit = t.dlspeed;
			Dl_Speed = t.dl_limit;
			Downloaded = t.downloaded;
			Downloaded_Session = t.downloaded_session;
			Eta = TimeSpan.FromSeconds(t.eta);
			First_Last_Piece_Prio = t.f_l_piece_prio;
			Force_Start = t.force_start;
			Hash = t.hash;
			Last_Activity = DateTimeOffset.FromUnixTimeSeconds(t.last_activity).DateTime.ToLocalTime();
			Name = t.name;
			Num_Complete = t.num_complete;
			Num_Incomplete = t.num_incomplete;
			Num_Leechs = t.num_leechs;
			Num_Seeds = t.num_seeds;
			Priority = (Priority)t.priority;
			Progress = t.progress;
			Ratio = t.ratio;
			Ratio_Limit = t.ratio_limit;
			Save_Path = t.save_path;
			Seen_Complete = DateTimeOffset.FromUnixTimeSeconds(t.seen_complete).DateTime.ToLocalTime();
			Seq_Dl = t.seq_dl;
			Size = t.size;
			State = (TorrentState)Enum.Parse(typeof(TorrentState), t.state, true);
			Super_Seeding = t.super_seeding;
			Total_Size = t.total_size;
			if(t.tracker != "")
				Tracker = new Uri(t.tracker);
			Up_Limit = t.up_limit;
			Uploaded = t.uploaded;
			Uploaded_Session = t.uploaded_session;
			Up_Speed = t.upspeed;
	}
	}
}
