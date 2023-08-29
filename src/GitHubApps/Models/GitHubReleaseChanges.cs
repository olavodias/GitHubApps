using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents the changes on a <see cref="GitHubRelease"/>
/// </summary>
public sealed class GitHubReleaseChanges
{

    #region Properties

    /// <summary>
    /// The previous version of the body
    /// </summary>
    public GitHubChangesFrom<string>? Body { get; set; }
    /// <summary>
    /// The previous version of the name
    /// </summary>
    public GitHubChangesFrom<string>? Name { get; set; }
    /// <summary>
    /// Whether this release was explicitly edited to be the latest
    /// </summary>
    public GitHubChangesTo<bool>? MakeLatest { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubReleaseChanges"/> class
    /// </summary>
    public GitHubReleaseChanges()
	{
	}
}

