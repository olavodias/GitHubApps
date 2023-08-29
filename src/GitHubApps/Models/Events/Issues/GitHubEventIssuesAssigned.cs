using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventIssuesAssigned: GitHubEventIssues
{

    #region Properties

    /// <summary>
    /// The user assigned to the issue
    /// </summary>
    public GitHubAccount? Assignee { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventIssuesAssigned"/> class
    /// </summary>
    public GitHubEventIssuesAssigned():base() { }

}

