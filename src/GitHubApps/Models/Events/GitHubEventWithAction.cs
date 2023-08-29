using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// Represents a base class for an event that contains an action
/// </summary>
/// <typeparam name="TMainClass">The type with the event payload</typeparam>
public abstract class GitHubEventWithAction<TMainClass>: GitHubEvent<TMainClass>
{

    #region Properties

    /// <summary>
    /// The action being performed by the event
    /// </summary>
    public string Action { get; set; } = string.Empty;

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventActions"/> class
    /// </summary>
    public GitHubEventWithAction()
	{
	}

}

