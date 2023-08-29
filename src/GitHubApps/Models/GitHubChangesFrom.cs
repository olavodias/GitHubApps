using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents an object to be used on changes, containing a generic parameter named <see cref="From"/>
/// </summary>
/// <typeparam name="T">The type of the parameter <see cref="From"/></typeparam>
public sealed class GitHubChangesFrom<T>
{

    #region Properties

    /// <summary>
    /// The original data
    /// </summary>
    public T? From { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubChangesFrom{T}"/> class
    /// </summary>
    public GitHubChangesFrom()
	{
	}
}

