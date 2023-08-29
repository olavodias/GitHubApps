//#pragma warning disable CA1822

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
        var payloadHeaders = new GitHubPayload();

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
    public async Task<EventResult> ProcessRequest(GitHubPayload payloadHeaders, string body)
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
                    return await Task.FromResult(OnEventPush(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPush>.ConvertFromJSON(body)))).ConfigureAwait(false);

                case GitHubEvents.EVENT_RELEASE:
                    if (this is IGitHubEventRelease eventRelease)
                        return await Task.FromResult(RouteEvent(eventRelease, payloadHeaders, GetActionFromRequest(body), body)).ConfigureAwait(false);
                    break;

                case GitHubEvents.EVENT_REPOSITORY:
                    if (this is IGitHubEventRepository eventRepository)
                        return await Task.FromResult(RouteEvent(eventRepository, payloadHeaders, GetActionFromRequest(body), body)).ConfigureAwait(false);
                    break;

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
    private EventResult RouteEvent(IGitHubEventInstallation @event, GitHubPayload payloadHeaders, string action, string requestBody)
    {
        // Retrieve Payload. If it doesn't serialize properly, return an Error
        var gitHubPayload = payloadHeaders.ConvertToTypedPayload(GitHubEventInstallation.ConvertFromJSON(requestBody)) ??
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
    public virtual EventResult OnEventInstallationCreated(GitHubPayload<GitHubEventInstallation> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CREATED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventInstallationDeleted(GitHubPayload<GitHubEventInstallation> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventInstallationNewPermissionsAccepted(GitHubPayload<GitHubEventInstallation> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_NEW_PERMISSIONS_ACCEPTED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventInstallationSuspend(GitHubPayload<GitHubEventInstallation> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_SUSPEND);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventInstallationUnsuspend(GitHubPayload<GitHubEventInstallation> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNSUSPEND);
    }


    #endregion Event Installation

    #region Event Issues

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventIssues @event, GitHubPayload payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_OPENED => @event.OnEventIssuesOpened(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssuesChanged>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_TRANSFERRED => @event.OnEventIssuesTransferred(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssuesChanged>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_ASSIGNED => @event.OnEventIssuesAssigned(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssuesAssigned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNASSIGNED => @event.OnEventIssuesUnassigned(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssuesAssigned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_CLOSED => @event.OnEventIssuesClosed(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventIssuesDeleted(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_LOCKED => @event.OnEventIssuesLocked(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_PINNED => @event.OnEventIssuesPinned(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_REOPENED => @event.OnEventIssuesReopened(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNLOCKED => @event.OnEventIssuesUnlocked(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNPINNED => @event.OnEventIssuesUnpinned(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssues>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_MILESTONED => @event.OnEventIssuesMilestoned(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssuesMilestoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DEMILESTONED => @event.OnEventIssuesDemilestoned(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssuesMilestoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventIssuesEdited(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssuesEdited>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_LABELED => @event.OnEventIssuesLabeled(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssuesLabeled>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNLABELED => @event.OnEventIssuesUnlabeled(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssuesLabeled>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesAssigned(GitHubPayload<GitHubEventIssuesAssigned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_ASSIGNED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesClosed(GitHubPayload<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CLOSED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesDeleted(GitHubPayload<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesDemilestoned(GitHubPayload<GitHubEventIssuesMilestoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DEMILESTONED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesEdited(GitHubPayload<GitHubEventIssuesEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesLabeled(GitHubPayload<GitHubEventIssuesLabeled> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_LABELED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesLocked(GitHubPayload<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_LOCKED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesMilestoned(GitHubPayload<GitHubEventIssuesMilestoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_MILESTONED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesOpened(GitHubPayload<GitHubEventIssuesChanged> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_OPENED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesPinned(GitHubPayload<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_PINNED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesReopened(GitHubPayload<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_REOPENED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesTransferred(GitHubPayload<GitHubEventIssuesChanged> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_TRANSFERRED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesUnassigned(GitHubPayload<GitHubEventIssuesAssigned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNASSIGNED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesUnlabeled(GitHubPayload<GitHubEventIssuesLabeled> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNLABELED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesUnlocked(GitHubPayload<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNLOCKED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssuesUnpinned(GitHubPayload<GitHubEventIssues> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNPINNED);
    }

    #endregion Event Issues

    #region Event Issue Comment

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventIssueComment @event, GitHubPayload payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_CREATED => @event.OnEventIssueCommentCreated(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssueComment>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventIssueCommentDeleted(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssueComment>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventIssueCommentEdited(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventIssueCommentEdited>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssueCommentCreated(GitHubPayload<GitHubEventIssueComment> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CREATED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssueCommentDeleted(GitHubPayload<GitHubEventIssueComment> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventIssueCommentEdited(GitHubPayload<GitHubEventIssueCommentEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    #endregion Event Issue Comment

    #region Event Label

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventLabel @event, GitHubPayload payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_CREATED => @event.OnEventLabelCreated(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventLabel>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventLabelDeleted(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventLabel>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventLabelEdited(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventLabelEdited>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventLabelCreated(GitHubPayload<GitHubEventLabel> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CREATED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventLabelDeleted(GitHubPayload<GitHubEventLabel> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventLabelEdited(GitHubPayload<GitHubEventLabelEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    #endregion Event Label

    #region Event Pull Request

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventPullRequest @event, GitHubPayload payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_ASSIGNED => @event.OnEventPullRequestAssigned(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestAssigned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_AUTO_MERGE_DISABLED => @event.OnEventPullRequestAutoMergeDisabled(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReasoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_AUTO_MERGE_ENABLED => @event.OnEventPullRequestAutoMergeEnabled(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReasoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_CLOSED => @event.OnEventPullRequestClosed(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_CONVERTED_TO_DRAFT => @event.OnEventPullRequestConvertedToDraft(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DEMILESTONED => @event.OnEventPullRequestDemilestoned(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestMilestoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DEQUEUED => @event.OnEventPullRequestDequeued(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReasoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventPullRequestEdited(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestEdited>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_ENQUEUED => @event.OnEventPullRequestEnqueued(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_LABELED => @event.OnEventPullRequestLabeled(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestLabeled>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_LOCKED => @event.OnEventPullRequestLocked(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_MILESTONED => @event.OnEventPullRequestMilestoned(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestMilestoned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_OPENED => @event.OnEventPullRequestOpened(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_READY_FOR_REVIEW => @event.OnEventPullRequestReadyForReview(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_REOPENED => @event.OnEventPullRequestReopened(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_REVIEW_REQUEST_REMOVED => @event.OnEventPullRequestReviewRequestRemoved(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReviewRequested>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_REVIEW_REQUESTED => @event.OnEventPullRequestReviewRequest(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReviewRequested>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_SYNCHRONIZE => @event.OnEventPullRequestSynchronize(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestSynchronized>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNASSIGNED => @event.OnEventPullRequestUnassigned(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestAssigned>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNLABELED => @event.OnEventPullRequestUnlabeled(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestLabeled>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNLOCKED => @event.OnEventPullRequestUnlocked(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequest>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestAssigned(GitHubPayload<GitHubEventPullRequestAssigned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_ASSIGNED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestAutoMergeDisabled(GitHubPayload<GitHubEventPullRequestReasoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_AUTO_MERGE_DISABLED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestAutoMergeEnabled(GitHubPayload<GitHubEventPullRequestReasoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_AUTO_MERGE_ENABLED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestClosed(GitHubPayload<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CLOSED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestConvertedToDraft(GitHubPayload<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CONVERTED_TO_DRAFT);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestDemilestoned(GitHubPayload<GitHubEventPullRequestMilestoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DEMILESTONED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestDequeued(GitHubPayload<GitHubEventPullRequestReasoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DEQUEUED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestEdited(GitHubPayload<GitHubEventPullRequestEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestEnqueued(GitHubPayload<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_ENQUEUED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestLabeled(GitHubPayload<GitHubEventPullRequestLabeled> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_LABELED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestLocked(GitHubPayload<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_LOCKED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestMilestoned(GitHubPayload<GitHubEventPullRequestMilestoned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_MILESTONED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestOpened(GitHubPayload<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_OPENED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReadyForReview(GitHubPayload<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_READY_FOR_REVIEW);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReopened(GitHubPayload<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_REOPENED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewRequestRemoved(GitHubPayload<GitHubEventPullRequestReviewRequested> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_REVIEW_REQUEST_REMOVED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewRequest(GitHubPayload<GitHubEventPullRequestReviewRequested> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_REVIEW_REQUESTED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestSynchronize(GitHubPayload<GitHubEventPullRequestSynchronized> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_SYNCHRONIZE);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestUnassigned(GitHubPayload<GitHubEventPullRequestAssigned> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNASSIGNED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestUnlabeled(GitHubPayload<GitHubEventPullRequestLabeled> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNLABELED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestUnlocked(GitHubPayload<GitHubEventPullRequest> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNLOCKED);
    }

    #endregion Event Pull Request

    #region Event Pull Request Review Comment

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventPullRequestReviewComment @event, GitHubPayload payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_CREATED => @event.OnEventPullRequestReviewCommentCreated(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReviewComment>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventPullRequestReviewCommentDeleted(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReviewComment>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventPullRequestReviewCommentEdited(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReviewCommentEdited>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewCommentCreated(GitHubPayload<GitHubEventPullRequestReviewComment> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CREATED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewCommentDeleted(GitHubPayload<GitHubEventPullRequestReviewComment> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewCommentEdited(GitHubPayload<GitHubEventPullRequestReviewCommentEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    #endregion Event Pull Request Review Comment

    #region Event Pull Request Review

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventPullRequestReview @event, GitHubPayload payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_DISMISSED => @event.OnEventPullRequestReviewDismissed(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReview>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_SUBMITTED => @event.OnEventPullRequestReviewSubmitted(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReview>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventPullRequestReviewEdited(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReviewEdited>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewDismissed(GitHubPayload<GitHubEventPullRequestReview> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DISMISSED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewSubmitted(GitHubPayload<GitHubEventPullRequestReview> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_SUBMITTED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewEdited(GitHubPayload<GitHubEventPullRequestReviewEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    #endregion Event Pull Request Review

    #region Event Pull Request Review Thread

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventPullRequestReviewThread @event, GitHubPayload payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_RESOLVED => @event.OnEventPullRequestReviewThreadResolved(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReviewThread>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNRESOLVED => @event.OnEventPullRequestReviewThreadUnresolved(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventPullRequestReviewThread>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewThreadResolved(GitHubPayload<GitHubEventPullRequestReviewThread> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_RESOLVED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventPullRequestReviewThreadUnresolved(GitHubPayload<GitHubEventPullRequestReviewThread> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNRESOLVED);
    }

    #endregion Event Pull Request Review Thread

    #region Event Push (No Actions)

    /// <inheritdoc cref="GitHubEventPush"/>
    /// <include file='documentation_shared.xml' path='Documentation/EventActionLessHandlers/*'/>
    public virtual EventResult OnEventPush(GitHubPayload<GitHubEventPush> payload)
    {
        throw new UnhandledEventException(payload.Event);
    }

    #endregion Event Push (No Actions)

    #region Event Release

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventRelease @event, GitHubPayload payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_CREATED => @event.OnEventReleaseCreated(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRelease>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventReleaseDeleted(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRelease>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventReleaseEdited(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventReleaseEdited>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_PRERELEASED => @event.OnEventReleasePreReleased(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRelease>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_PUBLISHED => @event.OnEventReleasePublished(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRelease>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_RELEASED => @event.OnEventReleaseReleased(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRelease>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNPUBLISHED => @event.OnEventReleaseUnpublished(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRelease>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleaseCreated(GitHubPayload<GitHubEventRelease> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CREATED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleaseDeleted(GitHubPayload<GitHubEventRelease> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleaseEdited(GitHubPayload<GitHubEventReleaseEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleasePreReleased(GitHubPayload<GitHubEventRelease> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_PRERELEASED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleasePublished(GitHubPayload<GitHubEventRelease> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_PUBLISHED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleaseReleased(GitHubPayload<GitHubEventRelease> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_RELEASED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventReleaseUnpublished(GitHubPayload<GitHubEventRelease> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNPUBLISHED);
    }

    #endregion Event Release

    #region Event Repository

    /// <include file='documentation_shared.xml' path='Documentation/RouteEvent/*'/>
    private EventResult RouteEvent(IGitHubEventRepository @event, GitHubPayload payloadHeaders, string action, string requestBody)
    {
        return action switch
        {
            GitHubEventActions.EVENT_ACTION_ARCHIVED => @event.OnEventRepositoryArchived(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRepository>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_CREATED => @event.OnEventRepositoryCreated(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRepository>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_DELETED => @event.OnEventRepositoryDeleted(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRepository>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_EDITED => @event.OnEventRepositoryEdited(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRepositoryEdited>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_PRIVATIZED => @event.OnEventRepositoryPrivatized(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRepository>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_PUBLICIZED => @event.OnEventRepositoryPublicized(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRepository>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_RENAMED => @event.OnEventRepositoryRenamed(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRepositoryEdited>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_TRANSFERRED => @event.OnEventRepositoryTransferred(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRepositoryEdited>.ConvertFromJSON(requestBody))),
            GitHubEventActions.EVENT_ACTION_UNARCHIVED => @event.OnEventRepositoryUnarchived(payloadHeaders.ConvertToTypedPayload(GitHubEvent<GitHubEventRepository>.ConvertFromJSON(requestBody))),
            _ => throw new UnhandledEventActionException(payloadHeaders.Event, action),
        };
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryArchived(GitHubPayload<GitHubEventRepository> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_ARCHIVED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryCreated(GitHubPayload<GitHubEventRepository> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_CREATED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryDeleted(GitHubPayload<GitHubEventRepository> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_DELETED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryEdited(GitHubPayload<GitHubEventRepositoryEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_EDITED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryPrivatized(GitHubPayload<GitHubEventRepository> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_PRIVATIZED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryPublicized(GitHubPayload<GitHubEventRepository> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_PUBLICIZED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryRenamed(GitHubPayload<GitHubEventRepositoryEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_RENAMED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryTransferred(GitHubPayload<GitHubEventRepositoryEdited> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_TRANSFERRED);
    }

    /// <inheritdoc/>
    public virtual EventResult OnEventRepositoryUnarchived(GitHubPayload<GitHubEventRepository> payload)
    {
        throw new UnhandledEventActionException(payload.Event, GitHubEventActions.EVENT_ACTION_UNARCHIVED);
    }

    #endregion Event Repository

}

//#pragma warning restore CA1822