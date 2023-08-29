using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when there is activity relating to a pull request review. A pull request review is a group of pull request revfiew comments in addition to a body comment and a state.
/// </summary>
public class GitHubEventPullRequestReview: GitHubEventWithAction<GitHubEventPullRequestReviewRequested>
{

    #region Properties

    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=PullRequest]"/>
    public GitHubPullRequest? PullRequest { get; set; }

    /// <summary>
    /// The Review that was affected
    /// </summary>
    public GitHubReview? Review { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPullRequestReviewRequested"/> class
    /// </summary>
    public GitHubEventPullRequestReview()
	{
	}

}

