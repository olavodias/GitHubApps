using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// This even occurs whent here is activity relating to repositories
/// </summary>
public class GitHubEventRepository: GitHubEventWithAction<GitHubEventRepository>
{

	/// <summary>
	/// Initializes a new instance of the <see cref="GitHubEventRepository"/> class
	/// </summary>
	public GitHubEventRepository()
	{
	}
}

