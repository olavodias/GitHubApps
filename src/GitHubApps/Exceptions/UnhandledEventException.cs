using System;
namespace GitHubApps.Exceptions;

/// <summary>
/// An exception thrown when there is no event handler for the event combination
/// </summary>
public class UnhandledEventException: System.Exception
{
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="default_error_message"]/*'/>
    private const string DEFAULT_ERROR_MESSAGE = "The event {0} is not handled";

    /// <summary>
    /// The name of the event
    /// </summary>
    public string EventName { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnhandledEventException"/>
    /// </summary>
    /// <param name="eventName">The name of the event</param>
    public UnhandledEventException(string eventName): this(eventName, null) { }

    /// <inheritdoc cref="UnhandledEventException.UnhandledEventException(string)"/>
    /// <param name="eventName">The name of the event</param>
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="innerException"]/*'/>
    public UnhandledEventException(string eventName, Exception? innerException): this(String.Format(DEFAULT_ERROR_MESSAGE, eventName), eventName, innerException) { }

    /// <inheritdoc cref="UnhandledEventException.UnhandledEventException(string)"/>
    /// <param name="eventName">The name of the event</param>
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="message"]/*'/>
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="innerException"]/*'/>
    public UnhandledEventException(string? message, string eventName, Exception? innerException): base(message, innerException)
    {
        EventName = eventName;
    }
}
