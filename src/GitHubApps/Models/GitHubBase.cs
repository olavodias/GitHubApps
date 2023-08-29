using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents a GitHub Base
/// </summary>
public sealed class GitHubBase
{

    #region Properties

    /// <summary>
    /// The Label
    /// </summary>
    public string? Label { get; set; }
    /// <summary>
    /// The Ref
    /// </summary>
    public string? Ref { get; set; }
    /// <summary>
    /// A git repository
    /// </summary>
    public GitHubRepository? Repo { get; set; }
    /// <summary>
    /// The SHA
    /// </summary>
    public string? Sha { get; set; }
    /// <summary>
    /// The GitHub User Account
    /// </summary>
    public GitHubAccount? User { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubBase"/> class
    /// </summary>
    public GitHubBase()
	{
	}
}

