using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents the permissions in a GitHub Repository
/// </summary>
public sealed class GitHubRepositoryPermissions
{

    #region Properties

    /// <summary>
    /// Permission to Admin the repository
    /// </summary>
    public bool? Admin { get; set; }
    /// <summary>
    /// Permission to maintain the repository
    /// </summary>
    public bool? Maintain { get; set; }
    /// <summary>
    /// Permission to pull from the repository
    /// </summary>
    public bool? Pull { get; set; }
    /// <summary>
    /// Permission to push to the repository
    /// </summary>
    public bool? Push { get; set; }
    /// <summary>
    /// Permission to triage in the repository
    /// </summary>
    public bool? Triage { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRepositoryPermissions"/>
    /// </summary>
    public GitHubRepositoryPermissions()
	{
	}
}

