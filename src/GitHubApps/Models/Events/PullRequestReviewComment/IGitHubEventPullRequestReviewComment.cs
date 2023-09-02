using System;

namespace GitHubApps.Models.Events;

/// <include file='documentation_shared.xml' path="Documentation/Interfaces/*"/>
internal interface IGitHubEventPullRequestReviewComment
{
    /// <summary>
    /// A comment on a pull request diff was created
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestReviewCommentCreated(GitHubDelivery<GitHubEventPullRequestReviewComment> payload);
    /// <summary>
    /// A comment on a pull request diff was deleted
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestReviewCommentDeleted(GitHubDelivery<GitHubEventPullRequestReviewComment> payload);
    /// <summary>
    /// The content of a commment on a pull request diff was changed
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestReviewCommentEdited(GitHubDelivery<GitHubEventPullRequestReviewCommentEdited> payload);
}

