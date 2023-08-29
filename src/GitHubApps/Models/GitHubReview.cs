using System;
using Newtonsoft.Json;

namespace GitHubApps.Models;

/// <summary>
/// Represents a GitHub Review
/// </summary>
public sealed class GitHubReview
{

    #region Properties

    /// <summary>
    /// Links to the review
    /// </summary>
    [JsonProperty("_links")]
    public GitHubLinks? Links { get; set; }
    /// <summary>
    /// How the author is associated with the repository
    /// </summary>
    public GitHubAuthorAssociations? AuthorAssociation { get; set; }
    /// <summary>
    /// The review body
    /// </summary>
    public string? Body { get; set; }
    /// <summary>
    /// A commit SHA for the review
    /// </summary>
    public string? CommitID { get; set; }
    /// <summary>
    /// The HTML URL
    /// </summary>
    [JsonProperty("html_url")]
    public string? HTMLURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <summary>
    /// The Pull Request URL
    /// </summary>
    public string? PullRequestURL { get; set; }
    /// <summary>
    /// The state of the review
    /// </summary>
    public GitHubReviewStates? State { get; set; }
    /// <summary>
    /// The date and time the review was submmited
    /// </summary>
    public DateTime? SubmittedAt { get; set; }
    /// <summary>
    /// The user who created the review
    /// </summary>
    public GitHubAccount? User { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubReview"/> class
    /// </summary>
    public GitHubReview()
	{
	}
}

/// <summary>
/// A list of valid GitHub Review States
/// </summary>
public enum GitHubReviewStates
{
    /// <summary>
    /// The review is dismissed
    /// </summary>
    Dismissed,
    /// <summary>
    /// The review is approved
    /// </summary>
    Approved,
    /// <summary>
    /// Changes were requested for the review
    /// </summary>
    [JsonProperty("changes_requested")]
    ChangesRequested
}

