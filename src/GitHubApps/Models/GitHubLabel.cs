using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents a Git Hub Label
/// </summary>
public sealed class GitHubLabel
{

    #region Properties

    /// <summary>
    /// The color of the label
    /// </summary>
    public string? Color { get; set; }
    /// <summary>
    /// Defines whether the label is the default or not
    /// </summary>
    public bool? Default { get; set; }
    /// <summary>
    /// The description of the label
    /// </summary>
    public string? Description { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
    /// <summary>
    /// The name of the label
    /// </summary>
    public string? Name { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <summary>
    /// The label URL
    /// </summary>
    public string? URL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubLabel"/> class
    /// </summary>
    public GitHubLabel()
	{

	}
}