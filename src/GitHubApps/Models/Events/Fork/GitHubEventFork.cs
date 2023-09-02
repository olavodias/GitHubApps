using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when someone forks a repository
/// </summary>
public sealed class GitHubEventFork: GitHubEvent<GitHubEventFork>
{

    #region Properties

    /// <summary>
    /// The created repository resource
    /// </summary>
    public GitHubRepository? Forkee { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventFork"/> class
    /// </summary>
    public GitHubEventFork()
	{
	}
}

