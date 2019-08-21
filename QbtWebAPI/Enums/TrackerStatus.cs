namespace QbtWebAPI.Enums
{
	/// <summary>
	/// Tracker status.
	/// </summary>
	public enum Trackerstatus
	{
		/// <summary>
		/// Tracker has been contacted and is working
		/// </summary>
		Working,
		/// <summary>
		/// Tracker is currently being updated
		/// </summary>
		Updating,
		/// <summary>
		/// Tracker has been contacted, but it is not working (or doesn't send proper replies)
		/// </summary>
		NotWorking,
		/// <summary>
		/// Tracker has not been contacted yet
		/// </summary>
		NotContactedYet
	};
}
