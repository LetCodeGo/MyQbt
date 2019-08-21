using QbtWebAPI.JSON;
using QbtWebAPI.Enums;
using System;
using System.Text.RegularExpressions;

namespace QbtWebAPI.Data
{
	/// <summary>
	/// Torrent tracker.
	/// </summary>
    public class Tracker
    {
		/// <summary>
		/// Tracker url
		/// </summary>
		public Uri Url { get; set; }
		/// <summary>
		/// Tracker status.
		/// </summary>
		public Trackerstatus Status { get; set; }
		/// <summary>
		/// Number of peers for current torrent reported by the tracker.
		/// </summary>
		public int Num_Peers { get; set; }
		/// <summary>
		/// Tracker message (there is no way of knowing what this message is - it's up to tracker admins).
		/// </summary>
		public string Msg { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Tracker"/> class.
		/// </summary>
		public Tracker() { }

		internal Tracker(TrackerJSON t)
		{
			Url = t.Url;
			Status = (Trackerstatus)Enum.Parse(typeof(Trackerstatus), new Regex(@"\s|[.]").Replace(t.Status, ""), true);
			Num_Peers = t.Num_Peers;
			Msg = t.Msg;
		}
	}
}
