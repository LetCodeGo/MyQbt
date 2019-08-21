namespace QbtWebAPI.Enums
{
	/// <summary>
	/// State of torrent piece.
	/// </summary>
    public enum PieceState
    {
		/// <summary>
		/// Not downloaded yet.
		/// </summary>
		NotDownloadedYet = 0,
		/// <summary>
		/// Now downloading.
		/// </summary>
		NowDownloading = 1,
		/// <summary>
		/// Already downloaded.
		/// </summary>
		AlreadyDownloaded = 2
    };
}
