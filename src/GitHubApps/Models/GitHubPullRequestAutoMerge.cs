using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents the status of auto merging a pull request
/// </summary>
public sealed class GitHubPullRequestAutoMerge
{

    #region Properties

    /// <summary>
    /// Commit message for the merge commit
    /// </summary>
    public string? CommitMessage { get; set; }
    /// <summary>
    /// Title for the merge commit message
    /// </summary>
    public string? CommitTitle { get; set; }
    /// <summary>
    /// The <see cref="GitHubAccount"/> who enabled the Auto Merge
    /// </summary>
    public GitHubAccount? EnabledBy { get; set; }
    /// <summary>
    /// The merge method to use
    /// </summary>
    public GitHubMergeMethods? MergeMethod { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubPullRequestAutoMerge"/> class
    /// </summary>
    public GitHubPullRequestAutoMerge()
	{
	}
}

/// <summary>
/// A list of valid Merge Methods
/// </summary>
public enum GitHubMergeMethods
{
    /// <summary>
    /// A regular merge
    /// </summary>
    Merge,
    /// <summary>
    /// A squash merge
    /// </summary>
    Squash,
    /// <summary>
    /// A rebase merge
    /// </summary>
    Rebase
}