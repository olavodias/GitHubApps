using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventPullRequestReviewRequested: GitHubEventPullRequest
{

    #region Properties

    /// <summary>
    /// The account requested to review the pull requested
    /// </summary>
    public GitHubAccount? RequestedReviewer { get; set; }

    /// <summary>
    /// Groups of organization members that gives permissions on specific repositories
    /// </summary>
    public GitHubRequestedTeam? RequestedTeam { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPullRequestReviewRequested"/> class
    /// </summary>
    public GitHubEventPullRequestReviewRequested()
	{
	}
}

