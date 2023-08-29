using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents the changes to a Git Hub Label
/// </summary>
public sealed class GitHubLabelChanges
{

    #region Properties

    /// <summary>
    /// The previous color
    /// </summary>
    public GitHubChangesFrom<string>? Color { get; set; }
    /// <summary>
    /// The previous description
    /// </summary>
    public GitHubChangesFrom<string>? Description { get; set; }
    /// <summary>
    /// The previous name
    /// </summary>
    public GitHubChangesFrom<string>? Name { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubLabelChanges"/> class
    /// </summary>
    public GitHubLabelChanges()
	{
	}
}

