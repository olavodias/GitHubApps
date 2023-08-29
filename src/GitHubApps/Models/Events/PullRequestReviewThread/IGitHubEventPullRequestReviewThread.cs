using System;

namespace GitHubApps.Models.Events;

/// <include file='documentation_shared.xml' path="Documentation/Interfaces/*"/>
internal interface IGitHubEventPullRequestReviewThread
{
    /// <summary>
    /// A comment thread on a pull request was marked as resolved
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestReviewThreadResolved(GitHubPayload<GitHubEventPullRequestReviewThread> payload);

    /// <summary>
    /// A previously resolved comment thread on a pull request was marked as unresolved
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestReviewThreadUnresolved(GitHubPayload<GitHubEventPullRequestReviewThread> payload);
}

