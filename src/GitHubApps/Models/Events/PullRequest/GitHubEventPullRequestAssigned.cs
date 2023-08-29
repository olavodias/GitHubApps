using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventPullRequestAssigned: GitHubEventPullRequest
{

    #region Properties

    /// <summary>
    /// The pull request assignee
    /// </summary>
    public GitHubAccount? Assignee { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPullRequestAssigned"/> class
    /// </summary>
    public GitHubEventPullRequestAssigned()
	{
	}
}

