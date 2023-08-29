using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventRepositoryEdited: GitHubEventRepository
{

    #region Properties

    /// <summary>
    /// The changes on the repository
    /// </summary>
    public GitHubRepositoryChanges? Changes { get; set; }
    
    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventRepositoryEdited"/> class
    /// </summary>
    public GitHubEventRepositoryEdited()
	{
	}
}

