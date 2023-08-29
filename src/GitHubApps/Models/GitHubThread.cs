using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents a GitHub thread
/// </summary>
public sealed class GitHubThread
{

    #region Properties

    /// <summary>
    /// An array of comments
    /// </summary>
    public GitHubComment? Comments { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubThread"/> class
    /// </summary>
    public GitHubThread()
	{
	}
}

