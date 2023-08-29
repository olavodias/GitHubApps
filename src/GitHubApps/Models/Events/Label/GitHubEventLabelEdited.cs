using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc/>
public sealed class GitHubEventLabelEdited: GitHubEventLabel
{

    #region Properties

    /// <summary>
    /// The changes to the label
    /// </summary>
    public GitHubLabelChanges? Changes { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventLabelEdited"/> class
    /// </summary>
    public GitHubEventLabelEdited()
	{
	}
}

