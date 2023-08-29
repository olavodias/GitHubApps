using System;
using Newtonsoft.Json;

namespace GitHubApps.Models;

/// <summary>
/// Represents the reactions to a comment
/// </summary>
public sealed class GitHubReactions
{

    #region Properties

    /// <summary>
    /// The total of positive reactions
    /// </summary>
    [JsonProperty("+1")]
    public int Plus1 { get; set; }
    /// <summary>
    /// The total of negative reactions
    /// </summary>
    [JsonProperty("-1")]
    public int Minus1 { get; set; }

    /// <summary>
    /// The total of confused reactions
    /// </summary>
    public int Confused { get; set; }
    /// <summary>
    /// The total of eyes reactions
    /// </summary>
    public int Eyes { get; set; }
    /// <summary>
    /// The total of heart reactions
    /// </summary>
    public int Heart { get; set; }
    /// <summary>
    /// The total of hooray reactions
    /// </summary>
    public int Hooray { get; set; }
    /// <summary>
    /// The total of laugh reactions
    /// </summary>
    public int Laugh { get; set; }
    /// <summary>
    /// The total of rocket reactions
    /// </summary>
    public int Rocket { get; set; }
    /// <summary>
    /// The total count of reactions
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// The url
    /// </summary>
    public string? URL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubReactions"/> class
    /// </summary>
    public GitHubReactions()
	{
	}
}

