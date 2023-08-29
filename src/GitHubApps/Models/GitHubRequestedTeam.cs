using System;
using Newtonsoft.Json;

namespace GitHubApps.Models;

/// <summary>
/// Represents a group of organization members that gives permissions on specified repositories
/// </summary>
public sealed class GitHubRequestedTeam
{

    #region Properties

    /// <summary>
    /// Whether the requested team is deleted
    /// </summary>
    public bool? Deleted { get; set; }
    /// <summary>
    /// The Description
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// The HTML URL
    /// </summary>
    [JsonProperty("html_url")]
    public string? HTMLURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public int ID { get; set; }
    /// <summary>
    /// The Members URL
    /// </summary>
    public string? MembersURL { get; set; }
    /// <summary>
    /// The Name
    /// </summary>
    public string? Name { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <summary>
    /// The Parent Requested Team
    /// </summary>
    public GitHubRequestedTeam? Parent { get; set; }
    /// <summary>
    /// Permission that the team will have for its repositories
    /// </summary>
    public string? Permission { get; set; }
    /// <summary>
    /// The privacy of the requested team
    /// </summary>
    public GitHubRequestedTeamPrivacy? Privacy { get; set; }
    /// <summary>
    /// The Repositories URL
    /// </summary>
    public string? RepositoriesURL { get; set; }
    /// <summary>
    /// the Slug
    /// </summary>
    public string? Slug { get; set; }
    /// <summary>
    /// The URL
    /// </summary>
    public string? URL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRequestedTeam"/> class
    /// </summary>
    public GitHubRequestedTeam()
	{
	}
}

/// <summary>
/// A list of valid values for the <see cref="GitHubRequestedTeam.Privacy"/> property
/// </summary>
public enum GitHubRequestedTeamPrivacy
{
    /// <summary>
    /// The Data is Open
    /// </summary>
    Open,
    /// <summary>
    /// The Data is Closed
    /// </summary>
    Closed,
    /// <summary>
    /// The Data is Secret
    /// </summary>
    Secret
}
