using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents the payload generated when an event is triggered
/// </summary>
public class GitHubPayload
{

    #region Properties

    /// <summary>
    /// The contents of the header X-GitHub-Event
    /// </summary>
    public string Event { get; internal set; } = "";
    /// <summary>
    /// The contents of the header X-GitHub-Delivery
    /// </summary>
    public string? Delivery { get; internal set; }
    /// <summary>
    /// The contents of the header X-Hub-Signature
    /// </summary>
    public string? HubSignature { get; internal set; }
    /// <summary>
    /// The contents of the header X-Hub-Signature-256
    /// </summary>
    public string? HubSignature256 { get; internal set; }
    /// <summary>
    /// The contents of the header X-GitHub-Hook-ID
    /// </summary>
    public long HookID { get; internal set; } = 0;
    /// <summary>
    /// The contents of the header X-GitHub-Hook-Installation-Target-ID
    /// </summary>
    public long HookInstallationTargetID { get; internal set; } = 0;
    /// <summary>
    /// The contents of the header X-GitHub-Hook-Installation-Target-Type
    /// </summary>
    public string HookInstallationTargetType { get; internal set; } = "";

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubPayload"/> class
    /// </summary>
    internal GitHubPayload()
    {

    }

    /// <summary>
    /// Converts the <see cref="GitHubPayload"/> object into a typed payload with the given input
    /// </summary>
    /// <typeparam name="TPayloadType">The type of the payload object</typeparam>
    /// <param name="payload">The payload object</param>
    /// <returns>Returns a typed <see cref="GitHubPayload"/></returns>
    public GitHubPayload<TPayloadType> ConvertToTypedPayload<TPayloadType>(TPayloadType? payload)
    {
        return new GitHubPayload<TPayloadType>(payload)
        {
            Event = this.Event,
            Delivery = this.Delivery,
            HookID = this.HookID,
            HookInstallationTargetID = this.HookInstallationTargetID,
            HookInstallationTargetType = this.HookInstallationTargetType,
            HubSignature = this.HubSignature,
            HubSignature256 = this.HubSignature256
        };
    }
}

/// <summary>
/// Represents a typed payload generated when an event is triggered
/// </summary>
/// <typeparam name="TGitHubEvent">The type of the payload</typeparam>
public sealed class GitHubPayload<TGitHubEvent> : GitHubPayload    
{
    #region Properties

    /// <summary>
    /// The event data for the payload
    /// </summary>
    public TGitHubEvent? EventData { get; internal set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubPayload{TGitHubEvent}"/> class
    /// </summary>
    /// <param name="eventData"></param>
    internal GitHubPayload(TGitHubEvent? eventData)
    {
        EventData = eventData;
    }
}
