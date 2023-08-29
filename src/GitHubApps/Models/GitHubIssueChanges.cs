using System;
using Newtonsoft.Json;

namespace GitHubApps.Models;

/// <summary>
/// Represents the changes on a <see cref="GitHubIssue"/>
/// </summary>
public sealed class GitHubIssueChanges
{

    #region Properties

    /// <summary>
    /// The previous version of the body
    /// </summary>
    public GitHubChangesFrom<string>? Body { get; set; }
    /// <summary>
    /// The previous version of the title
    /// </summary>
    public GitHubChangesFrom<string>? Title { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubIssueChanges"/> class
    /// </summary>
    public GitHubIssueChanges()
	{
	}
}

