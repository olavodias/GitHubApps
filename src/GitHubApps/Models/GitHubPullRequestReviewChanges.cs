using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents the changes to a GitHub Pull Request Review
/// </summary>
public sealed class GitHubPullRequestReviewChanges
{

    #region Properties

    /// <summary>
    /// The previous version of the body
    /// </summary>
    public GitHubChangesFrom<string>? Body { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubPullRequestReviewChanges"/>
    /// </summary>
    public GitHubPullRequestReviewChanges()
	{
	}
}

