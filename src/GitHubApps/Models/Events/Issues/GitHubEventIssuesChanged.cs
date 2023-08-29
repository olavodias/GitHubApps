using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventIssuesChanged: GitHubEventIssues
{

    #region Properties

    /// <summary>
    /// The changes to the issue
    /// </summary>
    public GitHubIssueChanges? Changes { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventIssuesChanged"/>
    /// </summary>
    public GitHubEventIssuesChanged(): base() { }

}

