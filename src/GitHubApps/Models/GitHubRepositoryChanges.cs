using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents the changes on a <see cref="GitHubRepository"/>
/// </summary>
public sealed class GitHubRepositoryChanges
{

    #region Properties

    /// <summary>
    /// The previous default branch
    /// </summary>
    public GitHubChangesFrom<string>? DefaultBranch { get; set; }
    /// <summary>
    /// The previous description
    /// </summary>
    public GitHubChangesFrom<string>? Description { get; set; }
    /// <summary>
    /// The previous homepage
    /// </summary>
    public GitHubChangesFrom<string>? Homepage { get; set; }
    /// <summary>
    /// THe previous topics
    /// </summary>
    public GitHubChangesFrom<string>? Topics { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRepositoryChanges"/>
    /// </summary>
    public GitHubRepositoryChanges()
	{
	}
}

