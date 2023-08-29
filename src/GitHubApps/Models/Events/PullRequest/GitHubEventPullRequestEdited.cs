using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventPullRequestEdited: GitHubEventPullRequest
{

    #region Properties

    /// <summary>
    /// The changes to the comment if the action was <see cref="GitHubEventActions.EVENT_ACTION_EDITED"/>
    /// </summary>
    public GitHubPullRequestChanges? Changes { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPullRequestEdited"/> class
    /// </summary>
    public GitHubEventPullRequestEdited()
	{
	}
}

