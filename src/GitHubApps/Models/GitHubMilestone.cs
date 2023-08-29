using System;
using Newtonsoft.Json;

namespace GitHubApps.Models;

/// <summary>
/// Represents a Git Hub Milestone
/// </summary>
/// <remarks>A Milestone is a collection of related issues and pull requests</remarks>
public sealed class GitHubMilestone
{

    #region Properties

    /// <summary>
    /// The date and time the milestone was closed
    /// </summary>
    public DateTime? ClosedAt { get; set; }
    /// <summary>
    /// The total of closed issues in the milestone
    /// </summary>
    public int ClosedIssues { get; set; }
    /// <summary>
    /// The date and time the milestone was created
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The git hub user who created the milestone
    /// </summary>
    public GitHubAccount? Creator { get; set; }
    /// <summary>
    /// The description of the milestone
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// The date and time the milestone is due
    /// </summary>
    public DateTime? DueOn { get; set; }
    /// <summary>
    /// The HTML URL
    /// </summary>
    [JsonProperty("html_url")]
    public string? HTMLURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
    /// <summary>
    /// The Labels URL
    /// </summary>
    public string? LabelsURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public long NodeID { get; set; }
    /// <summary>
    /// The number of the milestone
    /// </summary>
    public int Number { get; set; }
    /// <summary>
    /// The total of open issues
    /// </summary>
    public int OpenIssues { get; set; }
    /// <summary>
    /// The milestone state
    /// </summary>
    public GitHubMilestoneStates? State { get; set; }
    /// <summary>
    /// The title of the milestone
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// The date and time the milestone was updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    /// <summary>
    /// The milestone URL
    /// </summary>
    public string? URL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubMilestone"/> class
    /// </summary>
    public GitHubMilestone()
	{
	}
}

/// <summary>
/// A list of valid milestone states
/// </summary>
public enum GitHubMilestoneStates
{
    /// <summary>
    /// The milestone is open
    /// </summary>
    Open,
    /// <summary>
    /// The milestone is closed
    /// </summary>
    Closed
}

