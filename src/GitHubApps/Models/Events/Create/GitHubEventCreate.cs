using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when a Git branch or tag is created
/// </summary>
public sealed class GitHubEventCreate: GitHubEvent<GitHubEventCreate>
{

    #region Properties

    /// <summary>
    /// The repository's current description
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// The name of the repository's default branch (usually main)
    /// </summary>
    public string? MasterBranch { get; set; }
    /// <summary>
    /// The pusher type for the event. Can be either user or a deploy key.
    /// </summary>
    public string? PusherType { get; set; }
    /// <summary>
    /// The git ref resource
    /// </summary>
    public string? Ref { get; set; }
    /// <summary>
    /// The type of Git ref object created in the repository
    /// </summary>
    public GitHubRefTypes? RefType { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventCreate"/> class
    /// </summary>
    public GitHubEventCreate()
	{
	}
}

/// <summary>
/// A list of valid Ref Types
/// </summary>
public enum GitHubRefTypes
{
    /// <summary>
    /// The Ref Type is a Tag
    /// </summary>
    Tag,
    /// <summary>
    /// The Ref Type is a Branch
    /// </summary>
    Branch
}
