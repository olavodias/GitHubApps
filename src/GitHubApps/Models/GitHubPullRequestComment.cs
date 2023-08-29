using System;
using Newtonsoft.Json;

namespace GitHubApps.Models;

/// <summary>
/// Represents a comment on a Pull Request
/// </summary>
public sealed class GitHubPullRequestComment: GitHubComment
{

    #region Properties

    /// <summary>
    /// The Links
    /// </summary>
    [JsonProperty("_links")]
    public object? Links { get; set; }
    /// <summary>
    /// The SHA of the commit to which the comment applies
    /// </summary>
    public string? CommitID { get; set; }
    /// <summary>
    /// The diff of the line that the comment refers to
    /// </summary>
    public string? DiffHunk { get; set; }
    /// <summary>
    /// The comment ID to reply to
    /// </summary>
    public int? InReplyToID { get; set; }
    /// <summary>
    /// The line of the blob to which the comment applies. The last line of the range for a multi-line comment.
    /// </summary>
    public int? Line { get; set; }
    /// <summary>
    /// The SHA of the original commit to which the comment applies
    /// </summary>
    public string? OriginalCommitID { get; set; }
    /// <summary>
    /// The line of the blob to which the comment applies. The last line of the range for a multi-line comment.
    /// </summary>
    public int? OriginalLine { get; set; }
    /// <summary>
    /// The index of the original line in the diff to which the comment applies
    /// </summary>
    public int? OriginalPosition { get; set; }
    /// <summary>
    /// The first line of the range for a multi-line comment
    /// </summary>
    public int? OriginalStartLine { get; set; }
    /// <summary>
    /// The relative path of the file to which the comment applies
    /// </summary>
    public string? Path { get; set; }
    /// <summary>
    /// The line index in the diff to which the comment applies
    /// </summary>
    public int? Position { get; set; }
    /// <summary>
    /// The ID of the pull request review to which the comment belongs
    /// </summary>
    public int? PullRequestReviewID { get; set; }
    /// <summary>
    /// URL for the pull request that the review comment belongs to
    /// </summary>
    public string? PullRequestURL { get; set; }
    /// <summary>
    /// The side of the first line of the range for a multi-line comment
    /// </summary>
    public string? Side { get; set; }
    /// <summary>
    /// The first line of the range for a multi-line comment
    /// </summary>
    public int? StartLine { get; set; }
    /// <summary>
    /// The side of the first line of the range for a multi-line comment
    /// </summary>
    public int? StartSide { get; set; }
    /// <summary>
    /// The level at which the comment is targeted, can be a diff line or a file
    /// </summary>
    public GitHubPullRequestCommentSubjectTypes? SubjectType { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubPullRequestComment"/> class
    /// </summary>
    public GitHubPullRequestComment()
	{
	}
}

/// <summary>
/// A list of valid subject types for a pull request comment
/// </summary>
public enum GitHubPullRequestCommentSubjectTypes
{
    /// <summary>
    /// The level at which the comment is targeted is line
    /// </summary>
    Line,
    /// <summary>
    /// The level at which the comment is targeted is file
    /// </summary>
    File
}
