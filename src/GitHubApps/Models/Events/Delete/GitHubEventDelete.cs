using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when a Git branch or tag is deleted
/// </summary>
public sealed class GitHubEventDelete: GitHubEvent<GitHubEventDelete>
{

    #region Properties

    /// <summary>
    /// The pushser type for the event. Can be either user or a deploy key
    /// </summary>
    public string? PusherType { get; set; }

    /// <summary>
    /// The Git Ref Resource
    /// </summary>
    public string? Ref { get; set; }
    /// <summary>
    /// The type of Git Ref object created in the repository
    /// </summary>
    public GitHubRefTypes? RefType { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventDelete"/> class
    /// </summary>
    public GitHubEventDelete()
	{
	}
}

