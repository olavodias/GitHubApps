using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// Represents the payload for the Git Hub event Label
/// </summary>
public class GitHubEventLabel: GitHubEventWithAction<GitHubEventLabel>
{

    #region Properties

    /// <summary>
    /// The label
    /// </summary>
    public GitHubLabel? Label { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventLabel"/>
    /// </summary>
    public GitHubEventLabel()
	{
	}
}

