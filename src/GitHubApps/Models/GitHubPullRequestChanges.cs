using System;
namespace GitHubApps.Models;


/// <summary>
/// Represent the changes to a pull request
/// </summary>
public sealed class GitHubPullRequestChanges
{

    #region Properties

    /// <summary>
    /// The Base of the changes
    /// </summary>
    public GitHubChangesBase? Base { get; set; }
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
    /// Initializes a new instance of the <see cref="GitHubPullRequestChanges"/> class
    /// </summary>
    public GitHubPullRequestChanges()
	{
	}
}

