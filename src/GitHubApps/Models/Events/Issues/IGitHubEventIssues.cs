using System;

namespace GitHubApps.Models.Events;

/// <include file='documentation_shared.xml' path="Documentation/Interfaces/*"/>
internal interface IGitHubEventIssues
{
    /// <summary>
    /// An issue was assigned to an user
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesAssigned(GitHubPayload<GitHubEventIssuesAssigned> payload);
    /// <summary>
    /// An issue was closed
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesClosed(GitHubPayload<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was deleted
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesDeleted(GitHubPayload<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was removed from a milestone
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesDemilestoned(GitHubPayload<GitHubEventIssuesMilestoned> payload);
    /// <summary>
    /// The title or body of an issue was edited
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesEdited(GitHubPayload<GitHubEventIssuesEdited> payload);
    /// <summary>
    /// A label was added to an issue
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesLabeled(GitHubPayload<GitHubEventIssuesLabeled> payload);
    /// <summary>
    /// Conversation on an issue was locked
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesLocked(GitHubPayload<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was added to a milestone
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesMilestoned(GitHubPayload<GitHubEventIssuesMilestoned> payload);
    /// <summary>
    /// An issue was created
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesOpened(GitHubPayload<GitHubEventIssuesChanged> payload);
    /// <summary>
    /// An issue was pinned to a repository
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesPinned(GitHubPayload<GitHubEventIssues> payload);
    /// <summary>
    /// A closed issue was reopened
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesReopened(GitHubPayload<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was transferred to another repository
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesTransferred(GitHubPayload<GitHubEventIssuesChanged> payload);
    /// <summary>
    /// A user was unassigned from an issue
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesUnassigned(GitHubPayload<GitHubEventIssuesAssigned> payload);
    /// <summary>
    /// A label was removed from an issue
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesUnlabeled(GitHubPayload<GitHubEventIssuesLabeled> payload);
    /// <summary>
    /// Conversation on an issue was unlocked
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesUnlocked(GitHubPayload<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was unpinned from a repository
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesUnpinned(GitHubPayload<GitHubEventIssues> payload);
}

