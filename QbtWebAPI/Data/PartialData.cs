using QbtWebAPI.JSON;
using System.Collections.Generic;

namespace QbtWebAPI.Data
{
	/// <summary>
	/// Partial data. Changes since last request.
	/// </summary>
	public class PartialData
    {
		/// <summary>
		/// Response ID.
		/// </summary>
		public int Rid { get; set; }
		/// <summary>
		/// Whether the response contains all the data or partial data.
		/// </summary>
		public bool Full_Update { get; set; }
		/// <summary>
		/// Torrent list.
		/// </summary>
		public List<Torrent> Torrents { get; set; }
		/// <summary>
		/// List of hashes of torrent removed since last request.
		/// </summary>
		public List<string> Torrents_Removed { get; set; }
		/// <summary>
		/// List of categories added since last request.
		/// </summary>
		public List<string> Categories { get; set; }
		/// <summary>
		/// List of categories removed since last request.
		/// </summary>
		public List<string> Categories_Removed { get; set; }
		/// <summary>
		/// Priority system usage flag.
		/// </summary>
		public bool Queueing { get; set; }
		/// <summary>
		/// Server state.
		/// </summary>
		public TransferInfo Server_State { get; set; }

		/// <summary>
		///  Initializes a new instance of the <see cref="PartialData"/> class.
		/// </summary>
		public PartialData() { }

		internal PartialData(PartialDataJSON p)
		{
			Rid = p.rid;
			Full_Update = p.full_update;
			Torrents = new List<Torrent>();
			foreach(var e in p.torrents)
			{
				e.Value.hash = e.Key;
				Torrents.Add(new Torrent(e.Value));
			}
			if (p.torrents_removed != null)
				Torrents_Removed = new List<string>(p.torrents_removed);
			else
				Torrents_Removed = new List<string>();
			if (p.categories != null)
				Categories = new List<string>(p.categories);
			else
				Categories = new List<string>();
			if (p.categories_removed != null)
				Categories_Removed = new List<string>(p.categories_removed);
			else
				Categories_Removed = new List<string>();
			Queueing = p.queueing;
			Server_State = new TransferInfo(p.server_state);
		}
	}
}
