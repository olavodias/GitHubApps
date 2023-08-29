using System;
using Newtonsoft.Json;

namespace GitHubApps.Models;

/// <summary>
/// Represents a Git Hub Comment
/// </summary>
public class GitHubComment
{

    #region Properties

    /// <summary>
    /// How the author is associated with the repository
    /// </summary>
    public GitHubAuthorAssociations? AuthorAssociation { get; set; }
    /// <summary>
    /// Cotnents of the issue comment
    /// </summary>
    public string? Body { get; set; }
    /// <summary>
    /// The date and time the comment was created
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The URL to the comment
    /// </summary>
    [JsonProperty("html_url")]
    public string? HTMLURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    [JsonProperty("id")]
    public int ID { get; set; }
    /// <summary>
    /// The URL to the issue
    /// </summary>
    public string? IssueURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <include file="documentation_shared.xml" path="Documents/RepetitiveProperties/RepetitiveProperty[@name=PerformedViaGitHubApp]"/>
    [JsonProperty("performed_via_github_app")]
    public GitHubPerformedViaGitHubApp? PerformedViaGitHubApp { get; set; }
    /// <include file="documentation_shared.xml" path="Documents/RepetitiveProperties/RepetitiveProperty[@name=Reactions]"/>
    public GitHubReactions? Reactions { get; set; }
    /// <summary>
    /// The date and the comment was updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    /// <summary>
    /// The URL for the issue comment
    /// </summary>
    [JsonProperty("url")]
    public string? URL { get; set; }
    /// <summary>
    /// The user who generated the comment
    /// </summary>
    public GitHubAccount? User { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubComment"/> class
    /// </summary>
    public GitHubComment()
	{
	}
}

