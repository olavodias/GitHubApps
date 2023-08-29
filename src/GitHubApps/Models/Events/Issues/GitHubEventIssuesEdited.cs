using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventIssuesEdited: GitHubEventIssuesLabeled
{

    #region Properties

    /// <summary>
    /// The changes on the issue
    /// </summary>
    public GitHubIssueChanges? Changes { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventIssuesEdited"/> class
    /// </summary>
    public GitHubEventIssuesEdited(): base() { }

}

