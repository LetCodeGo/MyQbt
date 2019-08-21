using QbtWebAPI.Enums;

namespace QbtWebAPI.Data
{
	/// <summary>
	/// Torrent contents.
	/// </summary>
    public class TorrentContents
    {
		/// <summary>
		/// File name (including relative path).
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// File size (bytes).
		/// </summary>
		public long Size { get; set; }
		/// <summary>
		/// File progress.
		/// </summary>
		public float Progress { get; set; }
		/// <summary>
		/// File priority.
		/// </summary>
		public Priority Priority { get; set; }
		/// <summary>
		/// True if file is seeding/complete.
		/// </summary>
		public bool Is_Seed { get; set; }
		/// <summary>
		/// The first number is the starting piece index and the second number is the ending piece index (inclusive).
		/// </summary>
		public int[] Piece_Range { get; set; }

		/// <summary>
		///  Initializes a new instance of the <see cref="TorrentContents"/> class.
		/// </summary>
		public TorrentContents() { }
	}
}
