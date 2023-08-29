using System;

namespace GitHubApps.Models.Events;

/// <include file='documentation_shared.xml' path="Documentation/Interfaces/*"/>
internal interface IGitHubEventPullRequest
{
    /// <summary>
    /// A pull request was assigned to a user
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestAssigned(GitHubPayload<GitHubEventPullRequestAssigned> payload);
    /// <summary>
    /// Auto merge was disabled for a pull request
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestAutoMergeDisabled(GitHubPayload<GitHubEventPullRequestReasoned> payload);
    /// <summary>
    /// Auto merge was enabled for a pull request
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestAutoMergeEnabled(GitHubPayload<GitHubEventPullRequestReasoned> payload);
    /// <summary>
    /// A pull request was closed. If merged is false in the webhook payload, the pull request was closed with unmerged commits. If merged is true in the webhook payload, the pull request was merged.
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestClosed(GitHubPayload<GitHubEventPullRequest> payload);
    /// <summary>
    /// A pull request was converted to a draft
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestConvertedToDraft(GitHubPayload<GitHubEventPullRequest> payload);
    /// <summary>
    /// A pull request was removed from a milestone
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestDemilestoned(GitHubPayload<GitHubEventPullRequestMilestoned> payload);
    /// <summary>
    /// A pull request was removed from the merge queue
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestDequeued(GitHubPayload<GitHubEventPullRequestReasoned> payload);
    /// <summary>
    /// The title or body of a pull request was edited
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestEdited(GitHubPayload<GitHubEventPullRequestEdited> payload);
    /// <summary>
    /// A pull request was added to the merge queue
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestEnqueued(GitHubPayload<GitHubEventPullRequest> payload);
    /// <summary>
    /// A label was added to a pull request
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestLabeled(GitHubPayload<GitHubEventPullRequestLabeled> payload);
    /// <summary>
    /// Conversation on a pull request was locked
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestLocked(GitHubPayload<GitHubEventPullRequest> payload);
    /// <summary>
    /// A pull request was added to a milestone
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestMilestoned(GitHubPayload<GitHubEventPullRequestMilestoned> payload);
    /// <summary>
    /// A pull request was created
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestOpened(GitHubPayload<GitHubEventPullRequest> payload);
    /// <summary>
    /// A draft pull request was marked as ready for review
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestReadyForReview(GitHubPayload<GitHubEventPullRequest> payload);
    /// <summary>
    /// A previously closed pull request was reopened
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestReopened(GitHubPayload<GitHubEventPullRequest> payload);
    /// <summary>
    /// A request for review by a person or team was removed from a pull request
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestReviewRequestRemoved(GitHubPayload<GitHubEventPullRequestReviewRequested> payload);
    /// <summary>
    /// Review by a person or team was requested for a pull request
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestReviewRequest(GitHubPayload<GitHubEventPullRequestReviewRequested> payload);
    /// <summary>
    /// A pull request's head branch was updated. For example, the head branch was updated from the base branch or new commits were pushed to the head branch.
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestSynchronize(GitHubPayload<GitHubEventPullRequestSynchronized> payload);
    /// <summary>
    /// A user was unassigned from a pull request
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestUnassigned(GitHubPayload<GitHubEventPullRequestAssigned> payload);
    /// <summary>
    /// A label was removed from a pull request
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestUnlabeled(GitHubPayload<GitHubEventPullRequestLabeled> payload);
    /// <summary>
    /// Conversation on a pull request was unlocked
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventPullRequestUnlocked(GitHubPayload<GitHubEventPullRequest> payload);
}

