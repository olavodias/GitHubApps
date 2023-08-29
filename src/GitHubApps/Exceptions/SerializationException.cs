using System;
namespace GitHubApps.Exceptions
{
	/// <summary>
	/// An exception thrown when the system was unable to serialize or deserialize data
	/// </summary>
	public class SerializationException: Exception
	{
        /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="default_error_message"]/*'/>
        private const string DEFAULT_ERROR_MESSAGE = "Unable to serialize or deserialize data";

		/// <summary>
		/// Initializes a new instance of the <see cref="SerializationException"/> class
		/// </summary>
		public SerializationException(): this(DEFAULT_ERROR_MESSAGE) { }

		/// <inheritdoc cref="SerializationException.SerializationException()"/>
		/// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="message"]/*'/>
		public SerializationException(string? message): this(message, null) { }

        /// <inheritdoc cref="SerializationException.SerializationException()"/>
		/// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="innerException"]/*'/>
        public SerializationException(Exception? innerException) : this(DEFAULT_ERROR_MESSAGE, innerException) { }

        /// <inheritdoc cref="SerializationException.SerializationException()"/>
		/// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="message"]/*'/>
		/// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="innerException"]/*'/>
        public SerializationException(string? message, Exception? innerException): base(message, innerException) { }
	}
}

