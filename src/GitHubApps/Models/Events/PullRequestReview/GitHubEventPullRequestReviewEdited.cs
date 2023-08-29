using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public class GitHubEventPullRequestReviewEdited: GitHubEventPullRequestReview
{

    #region Properties

    /// <summary>
    /// The changes to the Pull Request Review
    /// </summary>
    public GitHubPullRequestReviewChanges? Changes { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPullRequestReviewEdited"/> class
    /// </summary>
    public GitHubEventPullRequestReviewEdited()
	{
	}
}

