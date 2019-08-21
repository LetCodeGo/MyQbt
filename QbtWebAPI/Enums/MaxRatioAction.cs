namespace QbtWebAPI.Enums
{
	/// <summary>
	/// Action when maximum ratio has been reached.
	/// </summary>
    public enum MaxRatioAction
    {
		/// <summary>
		/// Pause torrent.
		/// </summary>
		PauseTorrent = 0,
		/// <summary>
		/// Remove torrent.
		/// </summary>
		RemoveTorrent = 1
    };
}
