using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents the changes to a GitHUb Pull Request Review Comment
/// </summary>
public sealed class GitHubPullRequestReviewCommentChanges
{

    #region Properties

    /// <summary>
    /// The previous version of the body
    /// </summary>
    public GitHubChangesFrom<string>? Body { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubPullRequestReviewCommentChanges"/> class
    /// </summary>
    public GitHubPullRequestReviewCommentChanges()
	{
	}
}

