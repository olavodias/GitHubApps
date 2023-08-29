using System;
using Newtonsoft.Json;

namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when there is activity relating to a GitHub App installation. All GitHub Apps receive this event by default.
/// </summary>
/// <remarks>See https://docs.github.com/en/webhooks-and-events/webhooks/webhook-events-and-payloads#installation</remarks>
public sealed class GitHubEventInstallation : GitHubEventWithAction<GitHubEventInstallation>
{

    #region Properties

    /// <summary>
    /// An array of repositories
    /// </summary>
    public GitHubRepository[]? Repositories { get; set; }

    /// <summary>
    /// The requester of the installation
    /// </summary>
    public GitHubAccount? Requester { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventInstallation"/> class
    /// </summary>
    public GitHubEventInstallation()
    {

    }

}

