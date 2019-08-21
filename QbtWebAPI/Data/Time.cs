using System;

namespace QbtWebAPI.Data
{
	/// <summary>
	/// Time, i.e. 18:30.
	/// </summary>
    public class Time
    {
		/// <summary>
		/// Hours.
		/// </summary>
		public int Hours { get; set; }
		/// <summary>
		/// Minutes.
		/// </summary>
		public int Minutes { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Time"/> class.
		/// </summary>
		/// <param name="hours">Hours needs to be 0-23.</param>
		/// <param name="minutes">Minutes needs to be 0-59.</param>
		public Time(int hours, int minutes)
		{
			if (hours < 0 || hours > 23)
				throw new ArgumentOutOfRangeException("Hours needs to be 0-23");

			if (minutes < 0 || minutes > 59)
				throw new ArgumentOutOfRangeException("Minutes needs to be 0-59");

			Hours = hours;
			Minutes = minutes;
		}
	}
}
