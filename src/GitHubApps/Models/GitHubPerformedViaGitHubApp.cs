using System;
using Newtonsoft.Json;

namespace GitHubApps.Models;

/// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=PerformedViaGitHubApp]"/>
public sealed class GitHubPerformedViaGitHubApp
{

    #region Properties

    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
    /// <summary>
    /// The slug name of the GitHub app
    /// </summary>
    public string? Slug { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <summary>
    /// The owner (a Git Hub User)
    /// </summary>
    public GitHubAccount? Owner { get; set; }
    /// <summary>
    /// The name of the GitHub App
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// The description of the GitHub App
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// The External URL
    /// </summary>
    public string? ExternalURL { get; set; }
    /// <summary>
    /// The HTML URL
    /// </summary>
    [JsonProperty("html_url")]
    public string? HTMLURL { get; set; }
    /// <summary>
    /// The date and time the GitHub App was created
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The date and time the GitHub App was updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    /// <summary>
    /// The set of permissions for the GitHub App
    /// </summary>
    public GitHubPermissions? Permissions { get; set; }
    /// <summary>
    /// The list of events for the GitHub App
    /// </summary>
    public string[]? Events { get; set; }
    /// <summary>
    /// The number of installations associated with the GitHub App
    /// </summary>
    public int InstallationsCount { get; set; }
    /// <summary>
    /// The client unique identifier
    /// </summary>
    public int ClientID { get; set; }
    /// <summary>
    /// The client secret
    /// </summary>
    public string? ClientSecret { get; set; }
    /// <summary>
    /// The webhook secret
    /// </summary>
    public string? WebhookSecret { get; set; }
    /// <summary>
    /// The PEM
    /// </summary>
    public string? Pem { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubPerformedViaGitHubApp"/> class
    /// </summary>
    public GitHubPerformedViaGitHubApp()
	{
	}
}
