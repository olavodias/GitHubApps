using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventIssuesMilestoned: GitHubEventIssues
{

    #region Properties

    /// <summary>
    /// A collection of related issues and pull requests
    /// </summary>
    public GitHubMilestone? Milestone { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventIssuesMilestoned"/> class
    /// </summary>
    public GitHubEventIssuesMilestoned():base() { }

}

