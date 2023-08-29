using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents a class to be used with links
/// </summary>
public sealed class GitHubLinksHref<T>
{

    #region Properties

    /// <summary>
    /// The link itself
    /// </summary>
    public T? Href { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubLinksHref{T}"/> class
    /// </summary>
    public GitHubLinksHref()
	{
	}
}

