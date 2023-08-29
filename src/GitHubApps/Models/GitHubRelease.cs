using System;
using Newtonsoft.Json;

namespace GitHubApps.Models;

/// <summary>
/// Represents a GitHub Release
/// </summary>
public sealed class GitHubRelease
{

    #region Properties

    /// <summary>
    /// The Release Assets
    /// </summary>
    public GitHubAssets[]? Assets { get; set; }
    /// <summary>
    /// The Release Assets URL
    /// </summary>
    public string? AssetsURL { get; set; }
    /// <summary>
    /// The Release Author
    /// </summary>
    public GitHubAccount? Author { get; set; }
    /// <summary>
    /// The Release Body
    /// </summary>
    public string? Body { get; set; }
    /// <summary>
    /// The date and time the release was created
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The Release Discussion URL
    /// </summary>
    public string? DiscussionURL { get; set; }
    /// <summary>
    /// Whether the release is a draft or published
    /// </summary>
    [JsonProperty("draft")]
    public bool? IsDraft { get; set; }
    /// <summary>
    /// The Release HTML URL
    /// </summary>
    [JsonProperty("html_url")]
    public string? HTMLURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
    /// <summary>
    /// The Release Name
    /// </summary>
    public string? Name { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <summary>
    /// Whether the release is identified as a prerelease or a full release
    /// </summary>
    [JsonProperty("prerelease")]
    public bool? IsPreRelease { get; set; }
    /// <summary>
    /// The date and time the release was published
    /// </summary>
    public DateTime? PublishedAt { get; set; }
    /// <summary>
    /// The reactions to the release
    /// </summary>
    public GitHubReactions? Reactions { get; set; }
    /// <summary>
    /// The Release Tag Name
    /// </summary>
    public string? TagName { get; set; }
    /// <summary>
    /// The Release Tarball URL
    /// </summary>
    public string? TarballURL { get; set; }
    /// <summary>
    /// Specified the commitish value that determines where the Git tag is created from
    /// </summary>
    public string? TargetCommitish { get; set; }
    /// <summary>
    /// The Release Upload URL
    /// </summary>
    public string? UploadURL { get; set; }
    /// <summary>
    /// The Release URL
    /// </summary>
    public string? URL { get; set; }
    /// <summary>
    /// The Release Zipball URL
    /// </summary>
    public string? ZipballURL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRelease"/> class
    /// </summary>
    public GitHubRelease()
	{
	}
}

