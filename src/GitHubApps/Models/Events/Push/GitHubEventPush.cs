using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when a commit or tag is pushed, or when a repository is cloned.
/// </summary>
public class GitHubEventPush: GitHubEvent<GitHubEventPush>
{

    #region Properties

    /// <summary>
    /// The SHA of the most recent commit on <see cref="Ref"/> after the push
    /// </summary>
    public string? After { get; set; }
    /// <summary>
    /// The base Ref
    /// </summary>
    public string? BaseRef { get; set; }
    /// <summary>
    /// The SHA of the most recent commit on <see cref="Ref"/> before the push
    /// </summary>
    public string? Before { get; set; }
    /// <summary>
    /// An array of commit objects describing the pushed commits.
    /// (Pushed commits are all commits that are included in the <see cref="Compare"/> between <see cref="Before"/> and <see cref="After"/> commit).
    /// The array include a maximum of 20 commits. If necessary, you can use the Commits API to fetch additional commits.
    /// The limit is applied to timeline events only and isn't applied to webhook deliveries.
    /// </summary>
    public GitHubCommit[]? Commits { get; set; }
    /// <summary>
    /// URL that shows the changes in this <see cref="Ref"/> update, from the <see cref="Before"/> commit to the <see cref="After"/> commit.
    /// For a newly created <see cref="Ref"/> that is directly based on the default branch, this is the comparison between the head of the default branch and the <see cref="After"/> commit.
    /// Otherwise, this shows all commits until the <see cref="After"/> commit.0
    /// </summary>
    public string? Compare { get; set; }
    /// <summary>
    /// Whether this push created the <see cref="Ref"/>
    /// </summary>
    public bool? Created { get; set; }
    /// <summary>
    /// Whether this push deleted the <see cref="Ref"/>
    /// </summary>
    public bool? Deleted { get; set; }
    /// <summary>
    /// Whether this push was a force push to the <see cref="Ref"/>
    /// </summary>
    public bool? Forced { get; set; }
    /// <summary>
    /// The head commit
    /// </summary>
    public GitHubCommit? HeadCommit { get; set; }
    /// <summary>
    /// Metaproperties for Git author/committer information
    /// </summary>
    public GitHubAccountMetaProperties? Pusher { get; set; }
    /// <summary>
    /// The full git ref that was pushed. Example: refs/heads/main or refs/tags/v3.14.1
    /// </summary>
    public string? Ref { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPush"/> class
    /// </summary>
    public GitHubEventPush()
	{
	}

}