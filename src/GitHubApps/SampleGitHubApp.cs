// *****************************************************************************
// SampleGitHubApp.cs
//
// Author:
//       Olavo Henrique Dias <olavodias@gmail.com>
//
// Copyright (c) 2023 Olavo Henrique Dias
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// *****************************************************************************

using System.Runtime.CompilerServices;
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps;

/// <summary>
/// Represents a Sample GitHub App to be used for Unit Testing
/// </summary>
/// <remarks>This class is only for unit testing. Whenever the process request method is callsed, it will route the event and populate the property <see cref="LastMethodCalled"/> with the name of the method that was called last.</remarks>
internal sealed class SampleGitHubApp: GitHubAppBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SampleGitHubApp"/>
    /// </summary>
	public SampleGitHubApp()
	{
	}

    /// <summary>
    /// The name of the last method that was called
    /// </summary>
    public string? LastMethodCalled { get; private set; }

    /// <summary>
    /// An internal function to be called by all action handlers
    /// </summary>
    /// <param name="memberName">The name of the method calling this method</param>
    /// <returns>A <see cref="EventResult.SuccessEventResult"/></returns>
    private EventResult ProcessMethod([CallerMemberName] string memberName = "")
    {
        LastMethodCalled = memberName.ToLower();
        return EventResult.SuccessEventResult;
    }

    /// <inheritdoc/>
    public override EventResult OnEventUnhandled()
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventActionUnhandled()
    {
        return ProcessMethod();
    }

    #region Create Event

    /// <inheritdoc/>
    public override EventResult OnEventCreate(GitHubDelivery<GitHubEventCreate> payload)
    {
        return ProcessMethod();
    }

    #endregion Create Event

    #region Delete Event

    /// <inheritdoc/>
    public override EventResult OnEventDelete(GitHubDelivery<GitHubEventDelete> payload)
    {
        return ProcessMethod();
    }

    #endregion Delete Event

    #region Fork Event

    /// <inheritdoc/>
    public override EventResult OnEventFork(GitHubDelivery<GitHubEventFork> payload)
    {
        return ProcessMethod();
    }

    #endregion Fork Event

    #region Installation Event

    /// <inheritdoc/>
    public override EventResult OnEventInstallationCreated(GitHubDelivery<GitHubEventInstallation> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventInstallationDeleted(GitHubDelivery<GitHubEventInstallation> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventInstallationNewPermissionsAccepted(GitHubDelivery<GitHubEventInstallation> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventInstallationSuspend(GitHubDelivery<GitHubEventInstallation> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventInstallationUnsuspend(GitHubDelivery<GitHubEventInstallation> payload)
    {
        return ProcessMethod();
    }

    #endregion Installation Event

    #region Issue Comment Event

    /// <inheritdoc/>
    public override EventResult OnEventIssueCommentCreated(GitHubDelivery<GitHubEventIssueComment> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssueCommentDeleted(GitHubDelivery<GitHubEventIssueComment> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssueCommentEdited(GitHubDelivery<GitHubEventIssueCommentEdited> payload)
    {
        return ProcessMethod();
    }

    #endregion Issue Comment Event

    #region Issues Event

    /// <inheritdoc/>
    public override EventResult OnEventIssuesAssigned(GitHubDelivery<GitHubEventIssuesAssigned> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesClosed(GitHubDelivery<GitHubEventIssues> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesDeleted(GitHubDelivery<GitHubEventIssues> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesDemilestoned(GitHubDelivery<GitHubEventIssuesMilestoned> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesEdited(GitHubDelivery<GitHubEventIssuesEdited> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesLabeled(GitHubDelivery<GitHubEventIssuesLabeled> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesLocked(GitHubDelivery<GitHubEventIssues> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesMilestoned(GitHubDelivery<GitHubEventIssuesMilestoned> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesOpened(GitHubDelivery<GitHubEventIssuesChanged> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesPinned(GitHubDelivery<GitHubEventIssues> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesReopened(GitHubDelivery<GitHubEventIssues> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesTransferred(GitHubDelivery<GitHubEventIssuesTransferred> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesUnassigned(GitHubDelivery<GitHubEventIssuesAssigned> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesUnlabeled(GitHubDelivery<GitHubEventIssuesLabeled> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesUnlocked(GitHubDelivery<GitHubEventIssues> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventIssuesUnpinned(GitHubDelivery<GitHubEventIssues> payload)
    {
        return ProcessMethod();
    }

    #endregion Issues Event

    #region Label Event

    /// <inheritdoc/>
    public override EventResult OnEventLabelCreated(GitHubDelivery<GitHubEventLabel> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventLabelDeleted(GitHubDelivery<GitHubEventLabel> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventLabelEdited(GitHubDelivery<GitHubEventLabelEdited> payload)
    {
        return ProcessMethod();
    }

    #endregion Label Event

    #region Pull Request Event

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestAssigned(GitHubDelivery<GitHubEventPullRequestAssigned> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestAutoMergeDisabled(GitHubDelivery<GitHubEventPullRequestReasoned> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestAutoMergeEnabled(GitHubDelivery<GitHubEventPullRequestReasoned> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestClosed(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestConvertedToDraft(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestDemilestoned(GitHubDelivery<GitHubEventPullRequestMilestoned> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestDequeued(GitHubDelivery<GitHubEventPullRequestReasoned> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestEdited(GitHubDelivery<GitHubEventPullRequestEdited> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestEnqueued(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestLabeled(GitHubDelivery<GitHubEventPullRequestLabeled> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestLocked(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestMilestoned(GitHubDelivery<GitHubEventPullRequestMilestoned> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestOpened(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestReadyForReview(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestReopened(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestReviewDismissed(GitHubDelivery<GitHubEventPullRequestReview> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestReviewEdited(GitHubDelivery<GitHubEventPullRequestReviewEdited> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestReviewRequest(GitHubDelivery<GitHubEventPullRequestReviewRequested> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestReviewRequestRemoved(GitHubDelivery<GitHubEventPullRequestReviewRequested> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestReviewSubmitted(GitHubDelivery<GitHubEventPullRequestReview> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestSynchronize(GitHubDelivery<GitHubEventPullRequestSynchronized> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestUnassigned(GitHubDelivery<GitHubEventPullRequestAssigned> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestUnlabeled(GitHubDelivery<GitHubEventPullRequestLabeled> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestUnlocked(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        return ProcessMethod();
    }

    #endregion Pull Request Event

    #region Pull Request Review Comment Event

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestReviewCommentCreated(GitHubDelivery<GitHubEventPullRequestReviewComment> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestReviewCommentDeleted(GitHubDelivery<GitHubEventPullRequestReviewComment> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestReviewCommentEdited(GitHubDelivery<GitHubEventPullRequestReviewCommentEdited> payload)
    {
        return ProcessMethod();
    }

    #endregion Pull Request Review Comment Event

    #region Pull Request Review Thread Event

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestReviewThreadResolved(GitHubDelivery<GitHubEventPullRequestReviewThread> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventPullRequestReviewThreadUnresolved(GitHubDelivery<GitHubEventPullRequestReviewThread> payload)
    {
        return ProcessMethod();
    }

    #endregion Pull Request Review Thread Event

    #region Push Event

    /// <inheritdoc/>
    public override EventResult OnEventPush(GitHubDelivery<GitHubEventPush> payload)
    {
        return ProcessMethod();
    }

    #endregion Push Event

    #region Release Event

    /// <inheritdoc/>
    public override EventResult OnEventReleaseCreated(GitHubDelivery<GitHubEventRelease> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventReleaseDeleted(GitHubDelivery<GitHubEventRelease> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventReleaseEdited(GitHubDelivery<GitHubEventReleaseEdited> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventReleasePreReleased(GitHubDelivery<GitHubEventRelease> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventReleasePublished(GitHubDelivery<GitHubEventRelease> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventReleaseReleased(GitHubDelivery<GitHubEventRelease> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventReleaseUnpublished(GitHubDelivery<GitHubEventRelease> payload)
    {
        return ProcessMethod();
    }

    #endregion Release Event

    #region Repository Event

    /// <inheritdoc/>
    public override EventResult OnEventRepositoryArchived(GitHubDelivery<GitHubEventRepository> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventRepositoryCreated(GitHubDelivery<GitHubEventRepository> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventRepositoryDeleted(GitHubDelivery<GitHubEventRepository> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventRepositoryEdited(GitHubDelivery<GitHubEventRepositoryEdited> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventRepositoryPrivatized(GitHubDelivery<GitHubEventRepository> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventRepositoryPublicized(GitHubDelivery<GitHubEventRepository> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventRepositoryRenamed(GitHubDelivery<GitHubEventRepositoryEdited> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventRepositoryTransferred(GitHubDelivery<GitHubEventRepositoryEdited> payload)
    {
        return ProcessMethod();
    }

    /// <inheritdoc/>
    public override EventResult OnEventRepositoryUnarchived(GitHubDelivery<GitHubEventRepository> payload)
    {
        return ProcessMethod();
    }

    #endregion Repository Event

}

