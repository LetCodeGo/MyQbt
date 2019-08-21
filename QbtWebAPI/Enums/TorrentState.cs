namespace QbtWebAPI.Enums
{
	/// <summary>
	/// Torrent state.
	/// </summary>
    public enum TorrentState
    {
		/// <summary>
		/// Some error occurred, applies to paused torrents.
		/// </summary>
		Error,
		/// <summary>
		/// Torrent is paused and has finished downloading.
		/// </summary>
		PausedUP,
		/// <summary>
		/// Torrent is paused and has NOT finished downloading.
		/// </summary>
		PausedDL,
		/// <summary>
		/// Queuing is enabled and torrent is queued for upload.
		/// </summary>
		QueuedUP,
		/// <summary>
		/// Queuing is enabled and torrent is queued for download.
		/// </summary>
		QueuedDL,
		/// <summary>
		/// Torrent is being seeded and data is being transferred.
		/// </summary>
		Uploading,
		/// <summary>
		/// Torrent is being seeded, but no connection were made.
		/// </summary>
		StalledUP,
		/// <summary>
		/// Torrent has finished downloading and is being checked; 
		/// this status also applies to preallocation (if enabled) and checking resume data on qBt startup.
		/// </summary>
		CheckingUP,
		/// <summary>
		/// Same as checkingUP, but torrent has NOT finished downloading.
		/// </summary>
		CheckingDL,
		/// <summary>
		/// Torrent is being downloaded and data is being transferred.
		/// </summary>
		Downloading,
		/// <summary>
		/// Torrent is being downloaded, but no connection were made.
		/// </summary>
		StalledDL,
		/// <summary>
		/// Torrent has just started downloading and is fetching metadata.
		/// </summary>
		MetaDL,
		/// <summary>
		/// Torrent is being forced downloaded and data is being transferred.
		/// </summary>
		ForcedDL,
		/// <summary>
		/// Torrent is being forced uploaded, but no connection were made.
		/// </summary>
		ForcedUP
	};
}
