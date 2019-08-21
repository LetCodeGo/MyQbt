namespace QbtWebAPI.Enums
{
	/// <summary>
	/// Torrent key.
	/// </summary>
    public enum Key
    {
		/// <summary>
		/// Torrent hash.
		/// </summary>
		Hash,
		/// <summary>
		/// Torrent name.
		/// </summary>
		Name,
		/// <summary>
		/// Total size of files selected for download.
		/// </summary>
		Size,
		/// <summary>
		/// Torrent progress.
		/// </summary>
		Progress,
		/// <summary>
		/// Torrent download speed.
		/// </summary>
		DlSpeed,
		/// <summary>
		/// Torrent upload speed.
		/// </summary>
		UpSpeed,
		/// <summary>
		/// Torrent priority.
		/// </summary>
		Priority,
		/// <summary>
		/// Number of seeds connected to.
		/// </summary>
		Num_Seeds,
		/// <summary>
		/// Number of seeds in the swarm.
		/// </summary>
		Num_Complete,
		/// <summary>
		/// Number of leechers connected to.
		/// </summary>
		Num_Leechs,
		/// <summary>
		/// Number of leechers in the swarm.
		/// </summary>
		Num_Incomplete,
		/// <summary>
		/// Torrent share ratio.
		/// </summary>
		Ratio,
		/// <summary>
		/// Torrent ETA.
		/// </summary>
		Eta,
		/// <summary>
		/// Torrent state.
		/// </summary>
		State,
		/// <summary>
		/// Sequential download.
		/// </summary>
		Seq_Dl,
		/// <summary>
		/// First last piece prioritized.
		/// </summary>
		F_L_Piece_Prio,
		/// <summary>
		/// Category of the torrent.
		/// </summary>
		Category,
		/// <summary>
		/// Super seeding.
		/// </summary>
		Super_Seeding,
		/// <summary>
		/// Force start.
		/// </summary>
		Force_Start
	}
}
