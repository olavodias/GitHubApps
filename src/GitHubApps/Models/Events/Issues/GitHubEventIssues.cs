using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when there is activity relating to a an issue.
/// </summary>
/// <remarks>See <see href="https://docs.github.com/en/webhooks-and-events/webhooks/webhook-events-and-payloads#issues"/></remarks>
public class GitHubEventIssues: GitHubEventWithAction<GitHubEventIssues>
{

    #region Properties

    /// <summary>
    /// The issue itself
    /// </summary>
    public GitHubIssue? Issue { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventIssues"/> class
    /// </summary>
    public GitHubEventIssues()
	{

    }
}
