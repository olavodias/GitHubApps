using System;
namespace GitHubApps.Exceptions;

/// <summary>
/// An exception thrown when there is no event handler for the event/action combination
/// </summary>
public class UnhandledEventActionException: System.Exception
{
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="default_error_message"]/*'/>
    private const string DEFAULT_ERROR_MESSAGE = "The action {1} for event {0} is not handled";

    /// <summary>
    /// The event that was triggered
    /// </summary>
    public string EventName { get; protected set; }
    /// <summary>
    /// The action inside the event that was triggered
    /// </summary>
    public string Action { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnhandledEventActionException"/>
    /// </summary>
    /// <param name="eventName">The event that was triggered</param>
    /// <param name="action">The action inside the event that was triggered</param>
    public UnhandledEventActionException(string eventName, string action): this(eventName, action, null) { }

    /// <inheritdoc cref="UnhandledEventActionException(string, string)"/>
    /// <param name="eventName">The event that was triggered</param>
    /// <param name="action">The action inside the event that was triggered</param>
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="innerException"]/*'/>
    public UnhandledEventActionException(string eventName, string action, Exception? innerException): this(string.Format(DEFAULT_ERROR_MESSAGE, eventName, action), eventName, action, innerException) { }

    /// <inheritdoc cref="UnhandledEventActionException(string, string, Exception?)"/>
    /// <param name="eventName">The event that was triggered</param>
    /// <param name="action">The action inside the event that was triggered</param>
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="message"]/*'/>
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="innerException"]/*'/>
    public UnhandledEventActionException(string? message, string eventName, string action, Exception? innerException): base(message, innerException)
    {
        EventName = eventName;
        Action = action;
    }

}

