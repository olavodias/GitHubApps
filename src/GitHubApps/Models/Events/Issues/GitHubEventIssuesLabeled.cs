using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public class GitHubEventIssuesLabeled: GitHubEventIssues
{

    #region Properties

    /// <summary>
    /// The label itself
    /// </summary>
    public GitHubLabel? Label { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventIssuesLabeled"/> class
    /// </summary>
    public GitHubEventIssuesLabeled(): base() { }
	
}

