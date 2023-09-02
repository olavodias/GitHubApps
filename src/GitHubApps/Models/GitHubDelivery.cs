using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents the delivery generated when an event is triggered, containing the event headers and the payload
/// </summary>
public class GitHubDelivery
{

    #region Properties

    /// <summary>
    /// The contents of the header X-GitHub-Event
    /// </summary>
    public string Event { get; set; } = "";
    /// <summary>
    /// The contents of the header X-GitHub-Delivery
    /// </summary>
    public string? Delivery { get; set; }
    /// <summary>
    /// The contents of the header X-Hub-Signature
    /// </summary>
    public string? HubSignature { get; set; }
    /// <summary>
    /// The contents of the header X-Hub-Signature-256
    /// </summary>
    public string? HubSignature256 { get; set; }
    /// <summary>
    /// The contents of the header X-GitHub-Hook-ID
    /// </summary>
    public long HookID { get; set; } = 0;
    /// <summary>
    /// The contents of the header X-GitHub-Hook-Installation-Target-ID
    /// </summary>
    public long HookInstallationTargetID { get; set; } = 0;
    /// <summary>
    /// The contents of the header X-GitHub-Hook-Installation-Target-Type
    /// </summary>
    public string HookInstallationTargetType { get; set; } = "";

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubDelivery"/> class
    /// </summary>
    internal GitHubDelivery()
    {

    }

    /// <summary>
    /// Converts the <see cref="GitHubDelivery"/> object into a typed delivery with the given input
    /// </summary>
    /// <typeparam name="TPayloadType">The type of the payload object</typeparam>
    /// <param name="payload">The payload object</param>
    /// <returns>Returns a typed <see cref="GitHubDelivery"/></returns>
    public GitHubDelivery<TPayloadType> ConvertToTypedDelivery<TPayloadType>(TPayloadType? payload)
    {
        return new GitHubDelivery<TPayloadType>(payload)
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
/// Represents the delivery generated when an event is triggered, containing the event headers and the payload
/// </summary>
/// <typeparam name="TGitHubPayload">The type of the payload</typeparam>
public sealed class GitHubDelivery<TGitHubPayload> : GitHubDelivery    
{
    #region Properties

    /// <summary>
    /// The payload of the delivery
    /// </summary>
    public TGitHubPayload? Payload { get; internal set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubDelivery{TGitHubPayload}"/> class
    /// </summary>
    /// <param name="payload">The event payload</param>
    public GitHubDelivery(TGitHubPayload? payload)
    {
        Payload = payload;
    }

    /// <summary>
    /// Converts a json file into a typed <see cref="GitHubDelivery"/>
    /// </summary>
    /// <param name="json">The json contents</param>
    /// <returns>A <see cref="GitHubDelivery"/> of type <typeparamref name="TGitHubPayload"/></returns>
    public static GitHubDelivery<TGitHubPayload>? ConvertFromJSON(string json)
    {
        return GitHubSerializer.ConvertFromJsonToGitHubPayload<TGitHubPayload>(json);
    }
}
