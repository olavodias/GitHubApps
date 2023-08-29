using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public class GitHubEventPullRequestReviewCommentEdited: GitHubEventPullRequestReviewComment
{

    #region Properties

    /// <summary>
    /// The changes to the Pull Request Review Comment
    /// </summary>
    public GitHubPullRequestReviewCommentChanges? Changes { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPullRequestReviewCommentEdited"/> class
    /// </summary>
    public GitHubEventPullRequestReviewCommentEdited()
	{
	}
}

