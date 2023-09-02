using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GitHubApps.Exceptions;
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps;

/// <summary>
/// Represents the Base Class for the GitHub Apps Implementation
/// </summary>
/// <remarks>Inherit from this class to create your own GitHub App</remarks>
public abstract class GitHubAppBase : IGitHubApp,
    IGitHubEventInstallation, IGitHubEventIssues, IGitHubEventIssueComment, IGitHubEventLabel,
    IGitHubEventPullRequest, IGitHubEventPullRequestReviewComment, IGitHubEventPullRequestReview, IGitHubEventPullRequestReviewThread,
    IGitHubEventRelease, IGitHubEventRepository
{

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubAppBase"/> class
    /// </summary>
    public GitHubAppBase()
	{
        
	}


    #region Internal Methods

    /// <inheritdoc/>
    public virtual async Task<EventResult> ProcessRequest(Dictionary<string, string> headers, string body)
	{
        // Create the GitHubPayload object
        var payloadHeaders = new GitHubDelivery();

        // Process Request Headers
        foreach (var requestHeader in headers)
        {
            var requestKeyLowerCase = requestHeader.Key.ToLower();

            if (requestKeyLowerCase == GitHubHeaders.HEADERS_GITHUB_EVENT)
                payloadHeaders.Event = requestKeyLowerCase;
            else if (requestKeyLowerCase == GitHubHeaders.HEADERS_GITHUB_DELIVERY)
                payloadHeaders.Delivery = requestKeyLowerCase;
            else if (requestKeyLowerCase == GitHubHeaders.HEADERS_HUB_SIGNATURE)
                payloadHeaders.HubSignature = requestKeyLowerCase;
            else if (requestKeyLowerCase == GitHubHeaders.HEADERS_HUB_SIGNATURE_256)
                payloadHeaders.HubSignature256 = requestKeyLowerCase;
            else if (requestKeyLowerCase == GitHubHeaders.HEADERS_GITHUB_HOOK_INSTALLATION_TARGET_ID)
                payloadHeaders.HookInstallationTargetID = long.Parse(requestKeyLowerCase);
            else if (requestKeyLowerCase == GitHubHeaders.HEADERS_GITHUB_HOOK_INSTALLATION_TARGET_TYPE)
                payloadHeaders.HookInstallationTargetType = requestKeyLowerCase;
        }

        return await ProcessRequest(payloadHeaders, body);
	}

    /// <inheritdoc/>
    public async Task<EventResult> ProcessRequest(GitHubDelivery payloadHeaders, string body)
    {
        // Route the Event/Action
        try
        {
            switch (payloadHeaders.Event)
            {
                case GitHubEvents.EVENT_INSTALLATION:
                    if (this is IGitHubEventInstallation eventInstallation)
                        return await Task.FromResult(RouteEvent(eventInstallation, payloadHeaders, GetActionFromRequest(body), body)).ConfigureAwait(false);
                    break;

                case GitHubEvents.EVENT_ISSUES:
                    if (this is IGitHubEventIssues eventIssues)
                        return await Task.FromResult(RouteEvent(eventIssues, payloadHeaders, GetActionFromRequest(body), body)).ConfigureAwait(false);
                    break;

                case GitHubEvents.EVENT_ISSUE_COMMENT:
                    if (this is IGitHubEventIssueComment eventIssueComment)
                        return await Task.FromResult(RouteEvent(eventIssueComment, payloadHeaders, GetActionFromRequest(body), body)).ConfigureAwait(false);
                    break;

                case GitHubEvents.EVENT_LABEL:
                    if (this is IGitHubEventLabel eventLabel)
                        return await Task.FromResult(RouteEvent(eventLabel, payloadHeaders, GetActionFromRequest(body), body)).ConfigureAwait(false);
                    break;

                case GitHubEvents.EVENT_PULL_REQUEST:
                    if (this is IGitHubEventPullRequest eventPullRequest)
                        return await Task.FromResult(RouteEvent(eventPullRequest, payloadHeaders, GetActionFromRequest(body), body)).ConfigureAwait(false);
                    break;

                case GitHubEvents.EVENT_PULL_REQUEST_REVIEW_COMMENT:
                    if (this is IGitHubEventPullRequestReviewComment eventPullRequestReviewComment)
                        return await Task.FromResult(RouteEvent(eventPullRequestReviewComment, payloadHeaders, GetActionFromRequest(body), body)).ConfigureAwait(false);
                    break;

                case GitHubEvents.EVENT_PULL_REQUEST_REVIEW:
                    if (this is IGitHubEventPullRequestReview eventPullRequestReview)
                        return await Task.FromResult(RouteEvent(eventPullRequestReview, payloadHeaders, GetActionFromRequest(body), body)).ConfigureAwait(false);
                    break;

                case GitHubEvents.EVENT_PULL_REQUEST_REVIEW_THREAD:
                    if (this is IGitHubEventPullRequestReviewThread eventPullRequestReviewThread)
                        return await Task.FromResult(RouteEvent(eventPullRequestReviewThread, payloadHeaders, GetActionFromRequest(body), body)).ConfigureAwait(false);
                    break;

                case GitHubEvents.EVENT_PUSH:
                    return await Task.FromResult(OnEventPush(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPush>.ConvertFromJSON(body)))).ConfigureAwait(false);

                case GitHubEvents.EVENT_RELEASE:
                    if (this is IGitHubEventRelease eventRelease)
                        return await Task.FromResult(RouteEvent(eventRelease, payloadHeaders, GetActionFromRequest(body), body)).ConfigureAwait(false);
                    break;

                case GitHubEvents.EVENT_REPOSITORY:
                    if (this is IGitHubEventRepository eventRepository)
                        return await Task.FromResult(RouteEvent(eventRepository, payloadHeaders, GetActionFromRequest(body), body)).ConfigureAwait(false);
                    break;

                case GitHubEvents.EVENT_CREATE:
                    return await Task.FromResult(OnEventCreate(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventCreate>.ConvertFromJSON(body)))).ConfigureAwait(false);

                default:
                    break;

            }

            // Object conversion returned null, or event is not handled
            throw new UnhandledEventException(payloadHeaders.Event);

        }
        catch (UnhandledEventException)
        {
            return await Task.FromResult(OnEventUnhandled()).ConfigureAwait(false);
        }
        catch (UnhandledEventActionException)
        {
            return await Task.FromResult(OnEventActionUnhandled()).ConfigureAwait(false);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Reads the request body and returns the action, if applicable
    /// </summary>
    /// <param name="requestBody">The request body</param>
    /// <returns>A string containing the action</returns>
    protected virtual string GetActionFromRequest(string requestBody)
    {
        StringBuilder action = new(30);
        var copyData = false;
        char currentChar;

        for (int iChar = 0; iChar < requestBody.Length; iChar++)
        {
            currentChar = requestBody[iChar];

            if (currentChar == ':')
            {
                copyData = true;
                continue;
            }

            if (copyData)
            {
                if (currentChar == ',')
                    break;

                if ((currentChar != '\"') && (currentChar != ' '))
                    action.Append(currentChar);
            }
        }

        return action.ToString();
    }

    #endregion Internal Methods

    #region Unhandled Events

    /// <summary>
    /// Method called when the event is not handled by the GitHub App
    /// </summary>
    /// <remarks>This method should be overwritten. Async is allowed.</remarks>
    /// <returns>A <see cref="EventResult"/>containing the results of the event that was not handled</returns>
    protected virtual EventResult OnEventUnhandled()
    {
        return EventResult.SuccessEventResult;
    }

    /// <summary>
    /// Method called when the event action is not handled by the GitHub App
    /// </summary>
    /// <remarks>This method should be overwritten. Async is allowed.</remarks>
    /// <returns>A <see cref="EventResult"/>containing the results of the event/action that was not handled</returns>
    protected virtual EventResult OnEventActionUnhandled()
    {
        return EventResult.SuccessEventResult;
    }

    #endregion Unhandled Events

    #region Event Installation

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventInstallation @event, GitHubDelivery payloadHeaders, string action, string requestBody)
    {
        // Retrieve Payload. If it doesn't serialize properly, return an Error
        var gitHubPayload = payloadHeaders.ConvertToTypedDelivery(GitHubEventInstallation.ConvertFromJSON(requestBody)) ??
                            throw new Exception("Unable to read payload");

        return action switch
        {
            GitHubEventActions.EVENT_ACTION_CREATED => @event.OnEventInstallationCreated(gitHubPayload),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventInstallationDeleted(gitHubPayload),
            GitHubEventActions.EVENT_ACTION_NEW_PERMISSIONS_ACCEPTED => @event.OnEventInstallationNewPermissionsAccepted(gitHubPayload),
            GitHubEventActions.EVENT_ACTION_SUSPEND => @event.OnEventInstallationSuspend(gitHubPayload),
            GitHubEventActions.EVENT_ACTION_UNSUSPEND => @event.OnEventInstallationUnsuspend(gitHubPayload),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };

    }

    /// <inheritdoc/>
    public virtual EventResult OnEventInstallationCreated(GitHubDelivery<GitHubEventInstallation> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CREATED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventInstallationDeleted(GitHubDelivery<GitHubEventInstallation> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventInstallationNewPermissionsAccepted(GitHubDelivery<GitHubEventInstallation> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_NEW_PERMISSIONS_ACCEPTED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventInstallationSuspend(GitHubDelivery<GitHubEventInstallation> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_SUSPEND);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventInstallationUnsuspend(GitHubDelivery<GitHubEventInstallation> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNSUSPEND);
    }


    #endregion Event Installation

    #region Event Issues

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventIssues @event, GitHubDelivery payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_OPENED => @event.OnEventIssuesOpened(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssuesChanged>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_TRANSFERRED => @event.OnEventIssuesTransferred(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssuesChanged>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_ASSIGNED => @event.OnEventIssuesAssigned(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssuesAssigned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNASSIGNED => @event.OnEventIssuesUnassigned(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssuesAssigned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_CLOSED => @event.OnEventIssuesClosed(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventIssuesDeleted(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_LOCKED => @event.OnEventIssuesLocked(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_PINNED => @event.OnEventIssuesPinned(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_REOPENED => @event.OnEventIssuesReopened(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNLOCKED => @event.OnEventIssuesUnlocked(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNPINNED => @event.OnEventIssuesUnpinned(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_MILESTONED => @event.OnEventIssuesMilestoned(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssuesMilestoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DEMILESTONED => @event.OnEventIssuesDemilestoned(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssuesMilestoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventIssuesEdited(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssuesEdited>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_LABELED => @event.OnEventIssuesLabeled(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssuesLabeled>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNLABELED => @event.OnEventIssuesUnlabeled(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssuesLabeled>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesAssigned(GitHubDelivery<GitHubEventIssuesAssigned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_ASSIGNED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesClosed(GitHubDelivery<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CLOSED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesDeleted(GitHubDelivery<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesDemilestoned(GitHubDelivery<GitHubEventIssuesMilestoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DEMILESTONED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesEdited(GitHubDelivery<GitHubEventIssuesEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesLabeled(GitHubDelivery<GitHubEventIssuesLabeled> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_LABELED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesLocked(GitHubDelivery<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_LOCKED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesMilestoned(GitHubDelivery<GitHubEventIssuesMilestoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_MILESTONED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesOpened(GitHubDelivery<GitHubEventIssuesChanged> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_OPENED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesPinned(GitHubDelivery<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_PINNED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesReopened(GitHubDelivery<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_REOPENED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesTransferred(GitHubDelivery<GitHubEventIssuesChanged> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_TRANSFERRED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesUnassigned(GitHubDelivery<GitHubEventIssuesAssigned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNASSIGNED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesUnlabeled(GitHubDelivery<GitHubEventIssuesLabeled> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNLABELED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesUnlocked(GitHubDelivery<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNLOCKED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesUnpinned(GitHubDelivery<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNPINNED);
    }

    #endregion Event Issues

    #region Event Issue Comment

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventIssueComment @event, GitHubDelivery payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_CREATED => @event.OnEventIssueCommentCreated(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssueComment>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventIssueCommentDeleted(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssueComment>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventIssueCommentEdited(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventIssueCommentEdited>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssueCommentCreated(GitHubDelivery<GitHubEventIssueComment> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CREATED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssueCommentDeleted(GitHubDelivery<GitHubEventIssueComment> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssueCommentEdited(GitHubDelivery<GitHubEventIssueCommentEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    #endregion Event Issue Comment

    #region Event Label

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventLabel @event, GitHubDelivery payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_CREATED => @event.OnEventLabelCreated(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventLabel>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventLabelDeleted(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventLabel>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventLabelEdited(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventLabelEdited>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventLabelCreated(GitHubDelivery<GitHubEventLabel> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CREATED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventLabelDeleted(GitHubDelivery<GitHubEventLabel> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventLabelEdited(GitHubDelivery<GitHubEventLabelEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    #endregion Event Label

    #region Event Pull Request

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventPullRequest @event, GitHubDelivery payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_ASSIGNED => @event.OnEventPullRequestAssigned(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestAssigned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_AUTO_MERGE_DISABLED => @event.OnEventPullRequestAutoMergeDisabled(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReasoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_AUTO_MERGE_ENABLED => @event.OnEventPullRequestAutoMergeEnabled(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReasoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_CLOSED => @event.OnEventPullRequestClosed(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_CONVERTED_TO_DRAFT => @event.OnEventPullRequestConvertedToDraft(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DEMILESTONED => @event.OnEventPullRequestDemilestoned(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestMilestoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DEQUEUED => @event.OnEventPullRequestDequeued(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReasoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventPullRequestEdited(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestEdited>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_ENQUEUED => @event.OnEventPullRequestEnqueued(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_LABELED => @event.OnEventPullRequestLabeled(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestLabeled>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_LOCKED => @event.OnEventPullRequestLocked(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_MILESTONED => @event.OnEventPullRequestMilestoned(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestMilestoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_OPENED => @event.OnEventPullRequestOpened(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_READY_FOR_REVIEW => @event.OnEventPullRequestReadyForReview(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_REOPENED => @event.OnEventPullRequestReopened(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_REVIEW_REQUEST_REMOVED => @event.OnEventPullRequestReviewRequestRemoved(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReviewRequested>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_REVIEW_REQUESTED => @event.OnEventPullRequestReviewRequest(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReviewRequested>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_SYNCHRONIZE => @event.OnEventPullRequestSynchronize(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestSynchronized>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNASSIGNED => @event.OnEventPullRequestUnassigned(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestAssigned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNLABELED => @event.OnEventPullRequestUnlabeled(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestLabeled>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNLOCKED => @event.OnEventPullRequestUnlocked(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestAssigned(GitHubDelivery<GitHubEventPullRequestAssigned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_ASSIGNED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestAutoMergeDisabled(GitHubDelivery<GitHubEventPullRequestReasoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_AUTO_MERGE_DISABLED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestAutoMergeEnabled(GitHubDelivery<GitHubEventPullRequestReasoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_AUTO_MERGE_ENABLED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestClosed(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CLOSED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestConvertedToDraft(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CONVERTED_TO_DRAFT);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestDemilestoned(GitHubDelivery<GitHubEventPullRequestMilestoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DEMILESTONED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestDequeued(GitHubDelivery<GitHubEventPullRequestReasoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DEQUEUED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestEdited(GitHubDelivery<GitHubEventPullRequestEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestEnqueued(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_ENQUEUED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestLabeled(GitHubDelivery<GitHubEventPullRequestLabeled> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_LABELED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestLocked(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_LOCKED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestMilestoned(GitHubDelivery<GitHubEventPullRequestMilestoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_MILESTONED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestOpened(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_OPENED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReadyForReview(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_READY_FOR_REVIEW);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReopened(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_REOPENED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewRequestRemoved(GitHubDelivery<GitHubEventPullRequestReviewRequested> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_REVIEW_REQUEST_REMOVED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewRequest(GitHubDelivery<GitHubEventPullRequestReviewRequested> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_REVIEW_REQUESTED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestSynchronize(GitHubDelivery<GitHubEventPullRequestSynchronized> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_SYNCHRONIZE);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestUnassigned(GitHubDelivery<GitHubEventPullRequestAssigned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNASSIGNED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestUnlabeled(GitHubDelivery<GitHubEventPullRequestLabeled> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNLABELED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestUnlocked(GitHubDelivery<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNLOCKED);
    }

    #endregion Event Pull Request

    #region Event Pull Request Review Comment

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventPullRequestReviewComment @event, GitHubDelivery payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_CREATED => @event.OnEventPullRequestReviewCommentCreated(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReviewComment>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventPullRequestReviewCommentDeleted(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReviewComment>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventPullRequestReviewCommentEdited(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReviewCommentEdited>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewCommentCreated(GitHubDelivery<GitHubEventPullRequestReviewComment> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CREATED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewCommentDeleted(GitHubDelivery<GitHubEventPullRequestReviewComment> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewCommentEdited(GitHubDelivery<GitHubEventPullRequestReviewCommentEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    #endregion Event Pull Request Review Comment

    #region Event Pull Request Review

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventPullRequestReview @event, GitHubDelivery payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_DISMISSED => @event.OnEventPullRequestReviewDismissed(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReview>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_SUBMITTED => @event.OnEventPullRequestReviewSubmitted(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReview>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventPullRequestReviewEdited(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReviewEdited>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewDismissed(GitHubDelivery<GitHubEventPullRequestReview> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DISMISSED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewSubmitted(GitHubDelivery<GitHubEventPullRequestReview> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_SUBMITTED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewEdited(GitHubDelivery<GitHubEventPullRequestReviewEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    #endregion Event Pull Request Review

    #region Event Pull Request Review Thread

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventPullRequestReviewThread @event, GitHubDelivery payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_RESOLVED => @event.OnEventPullRequestReviewThreadResolved(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReviewThread>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNRESOLVED => @event.OnEventPullRequestReviewThreadUnresolved(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventPullRequestReviewThread>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewThreadResolved(GitHubDelivery<GitHubEventPullRequestReviewThread> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_RESOLVED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewThreadUnresolved(GitHubDelivery<GitHubEventPullRequestReviewThread> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNRESOLVED);
    }

    #endregion Event Pull Request Review Thread

    #region Event Push (No Actions)

    /// <inheritdoc cref="GitHubEventPush"/>
    /// <include file='documentation_shared.xml' path='Documentation/EventActionLessHandlers/*'/>
    public virtual EventResult OnEventPush(GitHubDelivery<GitHubEventPush> payload)
    {
        throw new UnhandledEventException(payload.Event);
    }

    #endregion Event Push (No Actions)

    #region Event Release

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventRelease @event, GitHubDelivery payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_CREATED => @event.OnEventReleaseCreated(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRelease>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventReleaseDeleted(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRelease>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventReleaseEdited(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventReleaseEdited>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_PRERELEASED => @event.OnEventReleasePreReleased(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRelease>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_PUBLISHED => @event.OnEventReleasePublished(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRelease>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_RELEASED => @event.OnEventReleaseReleased(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRelease>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNPUBLISHED => @event.OnEventReleaseUnpublished(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRelease>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleaseCreated(GitHubDelivery<GitHubEventRelease> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CREATED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleaseDeleted(GitHubDelivery<GitHubEventRelease> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleaseEdited(GitHubDelivery<GitHubEventReleaseEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleasePreReleased(GitHubDelivery<GitHubEventRelease> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_PRERELEASED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleasePublished(GitHubDelivery<GitHubEventRelease> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_PUBLISHED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleaseReleased(GitHubDelivery<GitHubEventRelease> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_RELEASED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleaseUnpublished(GitHubDelivery<GitHubEventRelease> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNPUBLISHED);
    }

    #endregion Event Release

    #region Event Repository

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventRepository @event, GitHubDelivery payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_ARCHIVED => @event.OnEventRepositoryArchived(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRepository>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_CREATED => @event.OnEventRepositoryCreated(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRepository>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventRepositoryDeleted(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRepository>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventRepositoryEdited(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRepositoryEdited>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_PRIVATIZED => @event.OnEventRepositoryPrivatized(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRepository>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_PUBLICIZED => @event.OnEventRepositoryPublicized(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRepository>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_RENAMED => @event.OnEventRepositoryRenamed(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRepositoryEdited>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_TRANSFERRED => @event.OnEventRepositoryTransferred(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRepositoryEdited>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNARCHIVED => @event.OnEventRepositoryUnarchived(payloadHeaders.ConvertToTypedDelivery(GitHubEvent<GitHubEventRepository>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryArchived(GitHubDelivery<GitHubEventRepository> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_ARCHIVED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryCreated(GitHubDelivery<GitHubEventRepository> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CREATED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryDeleted(GitHubDelivery<GitHubEventRepository> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryEdited(GitHubDelivery<GitHubEventRepositoryEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryPrivatized(GitHubDelivery<GitHubEventRepository> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_PRIVATIZED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryPublicized(GitHubDelivery<GitHubEventRepository> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_PUBLICIZED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryRenamed(GitHubDelivery<GitHubEventRepositoryEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_RENAMED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryTransferred(GitHubDelivery<GitHubEventRepositoryEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_TRANSFERRED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryUnarchived(GitHubDelivery<GitHubEventRepository> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNARCHIVED);
    }

    #endregion Event Repository

    #region Event Create (No Actions)

    /// <inheritdoc cref="GitHubEventCreate"/>
    /// <include file='documentation_shared.xml' path='Documentation/EventActionLessHandlers/*'/>
    public virtual EventResult OnEventCreate(GitHubDelivery<GitHubEventCreate> payload)
    {
        throw new UnhandledEventException(payload.Event);
    }

    #endregion Event Create (No Actions)
}
