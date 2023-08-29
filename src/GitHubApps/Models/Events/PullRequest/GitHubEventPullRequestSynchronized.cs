using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventPullRequestSynchronized: GitHubEventPullRequest
{

    #region Properties

    /// <summary>
    /// The data after the syncrhonize
    /// </summary>
    public string? After { get; set; }
    /// <summary>
    /// The data before the syncrhonize
    /// </summary>
    public string? Before { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPullRequestSynchronized"/> class
    /// </summary>
    public GitHubEventPullRequestSynchronized()
	{
	}
}

