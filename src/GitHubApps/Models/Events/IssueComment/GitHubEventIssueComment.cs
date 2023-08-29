using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when there is activity relating to a comment onan issue or pull request.
/// </summary>
/// <remarks>See <see href="https://docs.github.com/issues/tracking-your-work-with-issues/about-issues"/></remarks>
public class GitHubEventIssueComment: GitHubEventWithAction<GitHubEventIssueComment>
{

    #region Properties

    /// <summary>
    /// The comment itself
    /// </summary>
    public GitHubComment? Comment { get; set; }

    /// <summary>
    /// The issue the comment belongs to
    /// </summary>
    public GitHubIssue? Issue { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventIssueComment"/> class
    /// </summary>
    public GitHubEventIssueComment()
	{
	}
}
