using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventPullRequestReasoned: GitHubEventPullRequest
{

    #region Properties

    /// <summary>
    /// The reason for the action
    /// </summary>
    public string? Reason { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPullRequestReasoned"/> class
    /// </summary>
    public GitHubEventPullRequestReasoned()
	{
	}
}

