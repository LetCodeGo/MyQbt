using QbtWebAPI.JSON;
using System;

namespace QbtWebAPI.Data
{
	/// <summary>
	/// Torrent properties.
	/// </summary>
    public class TorrentProperties
    {
		/// <summary>
		/// Torrent save path.
		/// </summary>
		public string Save_Path { get; set; }
		/// <summary>
		/// Torrent creation date.
		/// </summary>
		public DateTime Creation_Date { get; set; }
		/// <summary>
		/// Torrent piece size (bytes).
		/// </summary>
		public long Piece_Size { get; set; }
		/// <summary>
		/// Torrent comment.
		/// </summary>
		public string Comment { get; set; }
		/// <summary>
		/// Total data wasted for torrent (bytes).
		/// </summary>
		public long Total_Wasted { get; set; }
		/// <summary>
		/// Total data uploaded for torrent (bytes).
		/// </summary>
		public long Total_Uploaded { get; set; }
		/// <summary>
		/// Total data uploaded this session (bytes).
		/// </summary>
		public long Total_Uploaded_Session { get; set; }
		/// <summary>
		/// Total data uploaded for torrent (bytes).
		/// </summary>
		public long Total_Downloaded { get; set; }
		/// <summary>
		/// Total data downloaded this session (bytes).
		/// </summary>
		public long Total_Downloaded_Session { get; set; }
		/// <summary>
		/// Torrent upload limit (bytes/s).
		/// </summary>
		public long Up_Limit { get; set; }
		/// <summary>
		/// Torrent download limit (bytes/s).
		/// </summary>
		public long Dl_Limit { get; set; }
		/// <summary>
		/// Torrent elapsed time.
		/// </summary>
		public TimeSpan Time_Elapsed { get; set; }
		/// <summary>
		/// Torrent elapsed time while complete.
		/// </summary>
		public TimeSpan Seeding_Time { get; set; }
		/// <summary>
		/// Torrent connection count.
		/// </summary>
		public int Nb_Connections { get; set; }
		/// <summary>
		/// Torrent connection count limit.
		/// </summary>
		public int Nb_Connections_Limit { get; set; }
		/// <summary>
		/// Torrent share ratio.
		/// </summary>
		public float Share_Ratio { get; set; }
		/// <summary>
		/// When this torrent was added.
		/// </summary>
		public DateTime Addition_Date { get; set; }
		/// <summary>
		/// Torrent completion date.
		/// </summary>
		public DateTime Completion_Date { get; set; }
		/// <summary>
		/// Torrent creator.
		/// </summary>
		public string Created_By { get; set; }
		/// <summary>
		/// Torrent average download speed (bytes/second).
		/// </summary>
		public long Dl_Speed_Avg { get; set; }
		/// <summary>
		/// Torrent download speed (bytes/second).
		/// </summary>
		public long Dl_Speed { get; set; }
		/// <summary>
		/// Torrent ETA.
		/// </summary>
		public TimeSpan Eta { get; set; }
		/// <summary>
		/// Last seen complete date.
		/// </summary>
		public DateTime Last_Seen { get; set; }
		/// <summary>
		/// Number of peers connected to.
		/// </summary>
		public int Peers { get; set; }
		/// <summary>
		/// Number of peers in the swarm.
		/// </summary>
		public int Peers_Total { get; set; }
		/// <summary>
		/// Number of pieces owned.
		/// </summary>
		public int Pieces_Have { get; set; }
		/// <summary>
		/// Number of pieces of the torrent.
		/// </summary>
		public int Pieces_Num { get; set; }
		/// <summary>
		/// Time until the next announce.
		/// </summary>
		public TimeSpan Reannounce { get; set; }
		/// <summary>
		/// Number of seeds connected to.
		/// </summary>
		public int Seeds { get; set; }
		/// <summary>
		/// Number of seeds in the swarm.
		/// </summary>
		public int Seeds_Total { get; set; }
		/// <summary>
		/// Torrent total size (bytes).
		/// </summary>
		public long Total_Size { get; set; }
		/// <summary>
		/// Torrent average upload speed (bytes/second).
		/// </summary>
		public long Up_Speed_Avg { get; set; }
		/// <summary>
		/// Torrent upload speed (bytes/second).
		/// </summary>
		public long Up_Speed { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TorrentProperties"/> class.
		/// </summary>
		public TorrentProperties() { }

		internal TorrentProperties(TorrentPropertiesJSON t)
		{
			Save_Path = t.Save_Path;
			Creation_Date = DateTimeOffset.FromUnixTimeSeconds(t.Creation_Date).DateTime.ToLocalTime();
			Piece_Size = t.Piece_Size;
			Comment = t.Comment;
			Total_Wasted = t.Total_Wasted;
			Total_Uploaded = t.Total_Uploaded;
			Total_Uploaded_Session = t.Total_Uploaded_Session;
			Total_Downloaded = t.Total_Downloaded;
			Total_Downloaded_Session = t.Total_Downloaded_Session;
			Up_Limit = t.Up_Limit;
			Dl_Limit = t.Dl_Limit;
			Time_Elapsed = TimeSpan.FromSeconds(t.Time_Elapsed);
			Seeding_Time = TimeSpan.FromSeconds(t.Seeding_Time);
			Nb_Connections = Nb_Connections;
			Nb_Connections_Limit = Nb_Connections_Limit;
			Share_Ratio = Share_Ratio;
			Addition_Date = DateTimeOffset.FromUnixTimeSeconds(t.Addition_Date).DateTime.ToLocalTime();
			Completion_Date = DateTimeOffset.FromUnixTimeSeconds(t.Completion_Date).DateTime.ToLocalTime();
			Created_By = Created_By;
			Dl_Speed_Avg = Dl_Speed_Avg;
			Dl_Speed = Dl_Speed;
			Eta = TimeSpan.FromSeconds(t.Eta);
			Last_Seen = DateTimeOffset.FromUnixTimeSeconds(t.Last_Seen).DateTime.ToLocalTime();
			Peers = Peers;
			Peers_Total = Peers_Total;
			Pieces_Have = Pieces_Have;
			Pieces_Num = Pieces_Num;
			Reannounce = TimeSpan.FromSeconds(t.Reannounce);
			Seeds = Seeds;
			Seeds_Total = Seeds_Total;
			Total_Size = Total_Size;
			Up_Speed_Avg = Up_Speed_Avg;
			Up_Speed = Up_Speed;
		}
	}
}
