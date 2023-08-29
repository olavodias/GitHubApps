using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventPullRequestMilestoned: GitHubEventPullRequest
{

    #region Properties

    /// <summary>
    /// A collection of related issues and pull requests
    /// </summary>
    public GitHubMilestone? Milestone { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPullRequestMilestoned"/> class
    /// </summary>
    public GitHubEventPullRequestMilestoned()
	{
	}
}

