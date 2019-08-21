using System;
using System.Net;

namespace QbtWebAPI
{
	/// <summary>
	/// Represents an exception thrown by API.
	/// </summary>
	public class QBTException : ApplicationException
	{
		/// <summary>
		/// The <see cref="HttpStatusCode"/>.
		/// </summary>
		public HttpStatusCode HttpStatusCode { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="QBTException"/> class.
		/// </summary>
		/// /// <param name="httpStatusCode">The <see cref="HttpStatusCode"/>.</param>
		/// <param name="message">The message which describes the reason of throwing this exception.</param>
		public QBTException(HttpStatusCode httpStatusCode, string message)
			: base(message)
		{
			HttpStatusCode = httpStatusCode;
		}
	}
}
