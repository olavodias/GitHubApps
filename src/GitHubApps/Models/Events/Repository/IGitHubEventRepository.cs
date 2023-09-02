using System;

namespace GitHubApps.Models.Events;

/// <include file='documentation_shared.xml' path="Documentation/Interfaces/*"/>
internal interface IGitHubEventRepository
{

    /// <summary>
    /// A repository was archived
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryArchived(GitHubDelivery<GitHubEventRepository> payload);
    /// <summary>
    /// A repository was created
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryCreated(GitHubDelivery<GitHubEventRepository> payload);
    /// <summary>
    /// A repository was deleted
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryDeleted(GitHubDelivery<GitHubEventRepository> payload);
    /// <summary>
    /// The topics, default branch, descriptiopn, or homepage of a repository was changed
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryEdited(GitHubDelivery<GitHubEventRepositoryEdited> payload);
    /// <summary>
    /// The visibility of a repository was changed to private
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryPrivatized(GitHubDelivery<GitHubEventRepository> payload);
    /// <summary>
    /// The visibility of a repository was changed to public
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryPublicized(GitHubDelivery<GitHubEventRepository> payload);
    /// <summary>
    /// The name of a repository was changed
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryRenamed(GitHubDelivery<GitHubEventRepositoryEdited> payload);
    /// <summary>
    /// Ownership of the repository was transferred to a user or organization account.
    /// This event is only sent to the account where the ownership is transferred.
    /// To receive the repository.transferred event, the new owner account must have the GitHub App installed, and the App must be subscribed to "Repository" events
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryTransferred(GitHubDelivery<GitHubEventRepositoryEdited> payload);
    /// <summary>
    /// A previously archived repository was unarchived
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryUnarchived(GitHubDelivery<GitHubEventRepository> payload);
}

