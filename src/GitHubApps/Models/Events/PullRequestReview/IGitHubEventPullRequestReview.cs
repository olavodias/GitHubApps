using System;

namespace GitHubApps.Models.Events;

/// <include file='documentation_shared.xml' path="Documentation/Interfaces/*"/>
internal interface IGitHubEventPullRequestReview
{
    /// <summary>
    /// A review on a pull request was dismissed
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestReviewDismissed(GitHubDelivery<GitHubEventPullRequestReview> payload);
    /// <summary>
    /// A review on a pull request was submitted
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestReviewSubmitted(GitHubDelivery<GitHubEventPullRequestReview> payload);
    /// <summary>
    /// The body comment on a pull request review was edited
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestReviewEdited(GitHubDelivery<GitHubEventPullRequestReviewEdited> payload);
}

