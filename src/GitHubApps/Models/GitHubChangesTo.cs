using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents an object to be used on changes, containing a generic parameter named <see cref="To"/>
/// </summary>
/// <typeparam name="T">The type of the parameter <see cref="To"/></typeparam>
public sealed class GitHubChangesTo<T>
{

    #region Properties

    /// <summary>
    /// The destination data
    /// </summary>
    public T? To { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubChangesTo{T}"/> class
    /// </summary>
    public GitHubChangesTo()
	{
	}
}

