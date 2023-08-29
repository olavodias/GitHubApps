using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when there is activity relating to a comment thread on a pull request
/// </summary>
public class GitHubEventPullRequestReviewThread
{

    #region Properties

    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=PullRequest]"/>
    public GitHubPullRequest? PullRequest { get; set; }

    /// <summary>
    /// The thread ifselt
    /// </summary>
    public GitHubThread? Thread { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPullRequestReviewThread"/> class
    /// </summary>
    public GitHubEventPullRequestReviewThread()
	{
	}
}

