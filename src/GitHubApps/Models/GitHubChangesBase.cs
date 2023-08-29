using System;
namespace GitHubApps.Models;

/// <summary>
/// Representes GitHub Changes containing a base Ref and SHA
/// </summary>
public sealed class GitHubChangesBase
{

    #region Properties

    /// <summary>
    /// The Ref of the changes
    /// </summary>
    public GitHubChangesFrom<string>? Ref { get; set; }
    /// <summary>
    /// The Sha of the changes
    /// </summary>
    public GitHubChangesFrom<string>? Sha { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubChangesBase"/> class
    /// </summary>
    public GitHubChangesBase()
	{
	}
}

