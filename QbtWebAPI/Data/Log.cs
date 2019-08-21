using QbtWebAPI.Enums;
using QbtWebAPI.JSON;
using System;

namespace QbtWebAPI.Data
{
	/// <summary>
	/// Log.
	/// </summary>
    public class Log
    {
		/// <summary>
		/// ID of the message.
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Text of the message.
		/// </summary>
		public string Message { get; set; }
		/// <summary>
		/// Time since epoch.
		/// </summary>
		public TimeSpan Timestamp { get; set; }
		/// <summary>
		/// Type of the message.
		/// </summary>
		public LogType Type { get; set; }

		/// <summary>
		///  Initializes a new instance of the <see cref="Log"/> class.
		/// </summary>
		public Log() { }

		internal Log(LogJSON l)
		{
			Id = l.id;
			Message = l.message;
			Timestamp = TimeSpan.FromMilliseconds(l.timestamp);
			Type = (LogType)l.type;
		}
    }
}
