using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventPullRequestLabeled: GitHubEventPullRequest
{

    #region Properties

    /// <summary>
    /// The label itself
    /// </summary>
    public GitHubLabel? Label { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPullRequestLabeled"/> class
    /// </summary>
    public GitHubEventPullRequestLabeled()
	{
	}
}

