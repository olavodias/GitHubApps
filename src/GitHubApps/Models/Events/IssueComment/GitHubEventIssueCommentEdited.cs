using System;
namespace GitHubApps.Models.Events;

/// <inheritdoc cref="GitHubEventIssueComment"/>
public sealed class GitHubEventIssueCommentEdited: GitHubEventIssueComment
{

    #region Properties

    /// <summary>
    /// The changes to the comment
    /// </summary>
    public GitHubIssueChanges? Changes { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventIssueCommentEdited"/> class
    /// </summary>
    public GitHubEventIssueCommentEdited(): base()
	{
	}
}

