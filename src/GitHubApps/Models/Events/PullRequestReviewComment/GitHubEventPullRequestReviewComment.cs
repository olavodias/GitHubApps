using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when there is activity relating to a pull request review comment. A pull request review comment is a comment on a pull request's diff.
/// </summary>
public class GitHubEventPullRequestReviewComment: GitHubEventWithAction<GitHubEventPullRequestReviewComment>
{

    #region Properties

    /// <summary>
    /// The comment itself
    /// </summary>
    public GitHubPullRequestComment? Comment { get; set; }

    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=PullRequest]"/>
    public GitHubPullRequest? PullRequest { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPullRequestReviewComment"/> class
    /// </summary>
    public GitHubEventPullRequestReviewComment()
	{
	}
}

