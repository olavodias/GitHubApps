using System;
using Newtonsoft.Json;

namespace GitHubApps.Models;

/// <summary>
/// Represents the Links in a GitHub Object
/// </summary>
public sealed class GitHubLinks
{

    #region Properties

    /// <summary>
    /// The link to the Comments
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? Comments { get; set; }
    /// <summary>
    /// The link to the Commits
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? Commits { get; set; }
    /// <summary>
    /// The link to the HTML
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/> and <see cref="GitHubReview"/></remarks>
    [JsonProperty("html")]
    public GitHubLinksHref<string>? HTML { get; set; }
    /// <summary>
    /// The link to the Issue
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? Issue { get; set; }
    /// <summary>
    /// The link to the Pull Request
    /// </summary>
    /// <remarks>Available for <see cref="GitHubReview"/></remarks>
    public GitHubLinksHref<string>? PullRequest { get; set; }
    /// <summary>
    /// The link to the Comment
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? ReviewComment { get; set; }
    /// <summary>
    /// The link to the Comments
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? ReviewComments { get; set; }
    /// <summary>
    /// The link to the Self
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? Self { get; set; }
    /// <summary>
    /// The link to the Statuses
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? Statuses { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubLinks"/> class
    /// </summary>
    public GitHubLinks()
	{
	}
}

