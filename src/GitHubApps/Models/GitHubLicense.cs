using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents a GitHub Repository License
/// </summary>
public sealed class GitHubLicense
{

    #region Properties

    /// <summary>
    /// The License Key
    /// </summary>
    public string? Key { get; set; }
    /// <summary>
    /// The License Name
    /// </summary>
    public string? Name { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public int NodeID { get; set; }
    /// <summary>
    /// The SPDX ID
    /// </summary>
    public string? SpdxID { get; set; }
    /// <summary>
    /// The URL
    /// </summary>
    public string? URL { get; set; }

    #endregion Properties

    /// <summary>
    /// Intializes a new instance of the <see cref="GitHubLicense"/> class
    /// </summary>
    public GitHubLicense()
	{
	}
}

