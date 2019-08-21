using QbtWebAPI.Enums;
using QbtWebAPI.JSON;
using System;

namespace QbtWebAPI.Data
{
	/// <summary>
	/// Transfer info.
	/// </summary>
	public class TransferInfo
    {
		/// <summary>
		/// Global download rate (bytes/s).
		/// </summary>
		public long Dl_Info_Speed { get; set; }
		/// <summary>
		/// Data downloaded this session (bytes).
		/// </summary>
		public long Dl_Info_Data { get; set; }
		/// <summary>
		/// Global upload rate (bytes/s).
		/// </summary>
		public long Up_Info_Speed { get; set; }
		/// <summary>
		/// Data uploaded this session (bytes).
		/// </summary>
		public long Up_Info_Data { get; set; }
		/// <summary>
		/// Download rate limit (bytes/s).
		/// </summary>
		public long Dl_Rate_Limit { get; set; }
		/// <summary>
		/// Upload rate limit (bytes/s).
		/// </summary>
		public long Up_Rate_Limit { get; set; }
		/// <summary>
		/// DHT nodes connected to.
		/// </summary>
		public int Dht_Nodes { get; set; }
		/// <summary>
		/// Connection status.
		/// </summary>
		public ConnectionStatus Connection_Status { get; set; }
		/// <summary>
		/// True if torrent queueing is enabled.
		/// </summary>
		public bool Queueing { get; set; }
		/// <summary>
		/// True if alternative speed limits are enabled.
		/// </summary>
		public bool Use_Alt_Speed_Limits { get; set; }
		/// <summary>
		/// Transfer list refresh interval (milliseconds)
		/// </summary>
		public long Refresh_Interval { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TransferInfo"/> class.
		/// </summary>
		public TransferInfo() { }

		internal TransferInfo(TransferInfoJSON t)
		{
			Dl_Info_Speed = t.dl_info_speed;
			Dl_Info_Data = t.dl_info_data;
			Up_Info_Speed = t.up_info_speed;
			Up_Info_Data = t.up_info_data;
			Dl_Rate_Limit = t.dl_rate_limit;
			Up_Rate_Limit = t.up_rate_limit;
			Dht_Nodes = t.dht_nodes;
			Connection_Status = (ConnectionStatus)Enum.Parse(typeof(ConnectionStatus), t.connection_status, true);
			Queueing = t.queueing;
			Use_Alt_Speed_Limits = t.use_alt_speed_limits;
			Refresh_Interval = t.refresh_interval;
		}
	}
}
