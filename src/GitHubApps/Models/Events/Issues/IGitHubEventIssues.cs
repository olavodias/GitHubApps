using System;

namespace GitHubApps.Models.Events;

/// <include file='documentation_shared.xml' path="Documentation/Interfaces/*"/>
internal interface IGitHubEventIssues
{
    /// <summary>
    /// An issue was assigned to an user
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesAssigned(GitHubDelivery<GitHubEventIssuesAssigned> payload);
    /// <summary>
    /// An issue was closed
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesClosed(GitHubDelivery<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was deleted
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesDeleted(GitHubDelivery<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was removed from a milestone
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesDemilestoned(GitHubDelivery<GitHubEventIssuesMilestoned> payload);
    /// <summary>
    /// The title or body of an issue was edited
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesEdited(GitHubDelivery<GitHubEventIssuesEdited> payload);
    /// <summary>
    /// A label was added to an issue
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesLabeled(GitHubDelivery<GitHubEventIssuesLabeled> payload);
    /// <summary>
    /// Conversation on an issue was locked
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesLocked(GitHubDelivery<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was added to a milestone
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesMilestoned(GitHubDelivery<GitHubEventIssuesMilestoned> payload);
    /// <summary>
    /// An issue was created
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesOpened(GitHubDelivery<GitHubEventIssuesChanged> payload);
    /// <summary>
    /// An issue was pinned to a repository
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesPinned(GitHubDelivery<GitHubEventIssues> payload);
    /// <summary>
    /// A closed issue was reopened
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesReopened(GitHubDelivery<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was transferred to another repository
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesTransferred(GitHubDelivery<GitHubEventIssuesChanged> payload);
    /// <summary>
    /// A user was unassigned from an issue
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesUnassigned(GitHubDelivery<GitHubEventIssuesAssigned> payload);
    /// <summary>
    /// A label was removed from an issue
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesUnlabeled(GitHubDelivery<GitHubEventIssuesLabeled> payload);
    /// <summary>
    /// Conversation on an issue was unlocked
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesUnlocked(GitHubDelivery<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was unpinned from a repository
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesUnpinned(GitHubDelivery<GitHubEventIssues> payload);
}

