using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents a GitHub Commit
/// </summary>
public sealed class GitHubCommit
{

    #region Properties

    /// <summary>
    /// An array of files added in the commit
    /// </summary>
    public string[]? Added { get; set; }
    /// <summary>
    /// Metaproperties for Git author/committer information
    /// </summary>
    public GitHubAccountMetaProperties? Author { get; set; }
    /// <summary>
    /// Metaproperties for Git author/committer information
    /// </summary>
    public GitHubAccountMetaProperties? Committer { get; set; }
    /// <summary>
    /// Whether this commit is distinct from any that have been pushed before
    /// </summary>
    public bool? Distinct { get; set; }
    /// <summary>
    /// The commit ID
    /// </summary>
    public string? ID { get; set; }
    /// <summary>
    /// The commit message
    /// </summary>
    public string? Message { get; set; }
    /// <summary>
    /// An array of files modified by the commit
    /// </summary>
    public string[]? Modified { get; set; }
    /// <summary>
    /// An array of files removed by the commit
    /// </summary>
    public string[]? Removed { get; set; }
    /// <summary>
    /// The ISO 8601 timestamp of the commit
    /// </summary>
    public string? Timestamp { get; set; }
    /// <summary>
    /// The Tree ID
    /// </summary>
    public string? TreeID { get; set; }
    /// <summary>
    /// The URL
    /// </summary>
    public string? URL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubCommit"/> class
    /// </summary>
    public GitHubCommit()
	{
	}
}