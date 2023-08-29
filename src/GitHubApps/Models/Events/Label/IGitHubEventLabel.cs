using System;

namespace GitHubApps.Models.Events;

/// <include file='documentation_shared.xml' path="Documentation/Interfaces/*"/>
internal interface IGitHubEventLabel
{
    /// <summary>
    /// A label was created
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventLabelCreated(GitHubPayload<GitHubEventLabel> payload);
    /// <summary>
    /// A label was deleted
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventLabelDeleted(GitHubPayload<GitHubEventLabel> payload);
    /// <summary>
    /// A label's name, description, or color was changed
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventLabelEdited(GitHubPayload<GitHubEventLabelEdited> payload);

}

