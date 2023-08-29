using System;
namespace GitHubApps;

/// <summary>
/// Represents the result of an event processing
/// </summary>
public sealed class EventResult
{

	#region Properties

	/// <summary>
	/// An <see cref="EventResult"/> containing a success message
	/// </summary>
	public static readonly EventResult SuccessEventResult = new();
    /// <summary>
    /// An <see cref="EventResult"/> containing a warning message
    /// </summary>
    public static readonly EventResult WarningEventResult = new(EventResultStatuses.Warning);
    /// <summary>
    /// An <see cref="EventResult"/> containing an error message
    /// </summary>
    public static readonly EventResult ErrorEventResult = new(EventResultStatuses.Error);

    /// <summary>
    /// The Status of the event processing
    /// </summary>
    public EventResultStatuses Status { get; set; } = EventResultStatuses.Success;
	/// <summary>
	/// A variable to store data coming from the result
	/// </summary>
	public object? Data { get; private set; }

	#endregion Properties

	/// <summary>
	/// Initializes a new instance of the <see cref="EventResult"/> class
	/// </summary>
	public EventResult(): this(EventResultStatuses.Success) { }

	/// <inheritdoc cref="EventResult.EventResult()"/>
	/// <param name="status">The status of the event</param>
	public EventResult(EventResultStatuses status): this(status, null) { }

    /// <inheritdoc cref="EventResult.EventResult()"/>
	/// <param name="status">The status of the event</param>
    /// <param name="data">A variable to store data coming from the result</param>
    public EventResult(EventResultStatuses status, object? data)
	{
		Status = status;
		Data = data;
	}

}

/// <summary>
/// A list of valid statuses for the event result
/// </summary>
public enum EventResultStatuses
{
    /// <summary>
    /// The event completed with success
    /// </summary>
    Success,
	/// <summary>
	/// The event completed with warnings
	/// </summary>
	Warning,
    /// <summary>
    /// The event completed with errors
    /// </summary>
    Error
}