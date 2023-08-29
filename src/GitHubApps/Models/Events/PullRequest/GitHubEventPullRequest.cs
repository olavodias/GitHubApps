using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when there is activity on a pull request.
/// </summary>
/// <remarks>See <see href="https://docs.github.com/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/about-pull-requests"/></remarks>
public class GitHubEventPullRequest: GitHubEventWithAction<GitHubEventPullRequest>
{

    #region Properties

    /// <summary>
    /// The pull request number
    /// </summary>
    public int Number { get; set; }

    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=PullRequest]"/>
    public GitHubPullRequest? PullRequest { get; set; }

    #endregion Properties

    /// <summary>
    /// Initalizes a new instance of the <see cref="GitHubEventPullRequest"/> class
    /// </summary>
    public GitHubEventPullRequest()
	{
	}

}

