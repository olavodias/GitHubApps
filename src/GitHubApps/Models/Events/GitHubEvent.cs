using System;
namespace GitHubApps.Models.Events;

/// <summary>
/// Represents a base class for an event
/// </summary>
/// <typeparam name="TMainClass">The type with the event payload</typeparam>
public abstract class GitHubEvent<TMainClass>
{

    #region Properties

    /// <summary>
	/// An enterprise on GitHUb
	/// </summary>
    public object? Enterprise { get; set; } //TODO: Implement Property Enterprise

    /// <summary>
    /// The GitHub App installation. This property is included when the event is configured for and sent to a GitHub App
    /// </summary>
    public GitHubInstallation? Installation { get; set; }

    /// <summary>
	/// A GitHub organization
	/// </summary>
    public object? Organization { get; set; } //TODO: Implement Property Organization

    /// <summary>
    /// A repository on GitHub
    /// </summary>
    public GitHubRepository? Repository { get; set; }

    /// <summary>
    /// The sender of the event
    /// </summary>
    public GitHubAccount? Sender { get; set; }

    #endregion Properties

	/// <summary>
	/// Initializes a new instance of the <see cref="GitHubEvent{TMainClass}"/> class
	/// </summary>
    public GitHubEvent() { }

	/// <summary>
	/// Converts a json file into an object of type <typeparamref name="TMainClass"/>
	/// </summary>
	/// <param name="json">The json contents</param>
	/// <returns>The object converted from json</returns>
	public static TMainClass? ConvertFromJSON(string json)
	{
		return GitHubSerializer.ConvertFromJson<TMainClass>(json);
	}

}

#region Event Constants

/// <summary>
/// Represents string constants of the headers that come in a request done by a GitHub App
/// </summary>
public static class GitHubHeaders
{
    /// <summary>
    /// The header key for a GitHub Event
    /// </summary>
    public const string HEADERS_GITHUB_EVENT = "x-github-event";
    /// <summary>
    /// The header key for a GitHub Delivery
    /// </summary>
    public const string HEADERS_GITHUB_DELIVERY = "x-github-delivery";
    /// <summary>
    /// The header key for a Hub Signature
    /// </summary>
    public const string HEADERS_HUB_SIGNATURE = "x-hub-signature";
    /// <summary>
    /// The header key for a Hub Signature 256
    /// </summary>
    public const string HEADERS_HUB_SIGNATURE_256 = "x-hub-signature-256";
    /// <summary>
    /// The header signature for a GitHub hook installation target ID
    /// </summary>
    public const string HEADERS_GITHUB_HOOK_INSTALLATION_TARGET_ID = "x-github-hook-installation-target-id";
    /// <summary>
    /// The header signature for a GitHub hook installation target type
    /// </summary>
    public const string HEADERS_GITHUB_HOOK_INSTALLATION_TARGET_TYPE = "x-github-hook-installation-target-type";
}

/// <summary>
/// Represents string constants of the events implemented by the framework
/// </summary>
public static class GitHubEvents
{
	/// <inheritdoc cref="GitHubApps.Models.Events.GitHubEventInstallation"/>
	public const string EVENT_INSTALLATION = "installation";
    /// <inheritdoc cref="GitHubApps.Models.Events.GitHubEventIssueComment"/>
    public const string EVENT_ISSUE_COMMENT = "issue_comment";
    /// <inheritdoc cref="GitHubApps.Models.Events.GitHubEventIssues"/>
    public const string EVENT_ISSUES = "issues";
    /// <inheritdoc cref="GitHubApps.Models.Events.GitHubEventLabel"/>
    public const string EVENT_LABEL = "label";
    /// <inheritdoc cref="GitHubApps.Models.Events.GitHubEventPullRequest"/>
    public const string EVENT_PULL_REQUEST = "pull_request";
    /// <inheritdoc cref="GitHubApps.Models.Events.GitHubEventPullRequestReviewComment"/>
    public const string EVENT_PULL_REQUEST_REVIEW_COMMENT = "pull_request_review_comment";
    /// <inheritdoc cref="GitHubApps.Models.Events.GitHubEventPullRequestReview"/>
    public const string EVENT_PULL_REQUEST_REVIEW = "pull_request_review";
    /// <inheritdoc cref="GitHubApps.Models.Events.GitHubEventPullRequestReviewThread"/>
    public const string EVENT_PULL_REQUEST_REVIEW_THREAD = "pull_request_review_thread";
    /// <inheritdoc cref="GitHubApps.Models.Events.GitHubEventPush"/>
    public const string EVENT_PUSH = "push";
    /// <inheritdoc cref="GitHubApps.Models.Events.GitHubEventRelease"/>
	public const string EVENT_RELEASE = "release";
    /// <inheritdoc cref="GitHubApps.Models.Events.GitHubEventRepository"/>
	public const string EVENT_REPOSITORY = "repository";
}

/// <summary>
/// Represents string constants of the actions implemented by the framework
/// </summary>
public static class GitHubEventActions
{
	/// <summary>A string representing the created event</summary>
	public const string EVENT_ACTION_CREATED = "created";
    /// <summary>A string representing the deleted event</summary>
    public const string EVENT_ACTION_DELETED = "deleted";
    /// <summary>A string representing the new permissions accepted event</summary>
    public const string EVENT_ACTION_NEW_PERMISSIONS_ACCEPTED = "new_permissions_accepted";
    /// <summary>A string representing the suspend event</summary>
    public const string EVENT_ACTION_SUSPEND = "suspend";
    /// <summary>A string representing the unsuspend event</summary>
    public const string EVENT_ACTION_UNSUSPEND = "unsuspend";
    /// <summary>A string representing the assigned event</summary>
    public const string EVENT_ACTION_ASSIGNED = "assigned";
    /// <summary>A string representing the closed event</summary>
    public const string EVENT_ACTION_CLOSED = "closed";
    /// <summary>A string representing the demilestoned event</summary>
    public const string EVENT_ACTION_DEMILESTONED = "demilestoned";
    /// <summary>A string representing the edited event</summary>
    public const string EVENT_ACTION_EDITED = "edited";
    /// <summary>A string representing the labeled event</summary>
    public const string EVENT_ACTION_LABELED = "labeled";
    /// <summary>A string representing the locked event</summary>
    public const string EVENT_ACTION_LOCKED = "locked";
    /// <summary>A string representing the milestoned event</summary>
    public const string EVENT_ACTION_MILESTONED = "milestoned";
    /// <summary>A string representing the opened event</summary>
    public const string EVENT_ACTION_OPENED = "opened";
    /// <summary>A string representing the pinned event</summary>
    public const string EVENT_ACTION_PINNED = "pinned";
    /// <summary>A string representing the reopened event</summary>
    public const string EVENT_ACTION_REOPENED = "reopened";
    /// <summary>A string representing the transferred event</summary>
    public const string EVENT_ACTION_TRANSFERRED = "transferred";
    /// <summary>A string representing the unassigned event</summary>
    public const string EVENT_ACTION_UNASSIGNED = "unassigned";
    /// <summary>A string representing the unlabeled event</summary>
    public const string EVENT_ACTION_UNLABELED = "unlabeled";
    /// <summary>A string representing the unlocked event</summary>
    public const string EVENT_ACTION_UNLOCKED = "unlocked";
    /// <summary>A string representing the unpinned event</summary>
    public const string EVENT_ACTION_UNPINNED = "unpinned";
    /// <summary>A string representing the auto merge disabled event</summary>
    public const string EVENT_ACTION_AUTO_MERGE_DISABLED = "auto_merge_disabled";
    /// <summary>A string representing the auto merge enabled event</summary>
    public const string EVENT_ACTION_AUTO_MERGE_ENABLED = "auto_merge_enabled";
    /// <summary>A string representing the converted to draft event</summary>
    public const string EVENT_ACTION_CONVERTED_TO_DRAFT = "converted_to_draft";
    /// <summary>A string representing the dequeued event</summary>
    public const string EVENT_ACTION_DEQUEUED = "dequeued";
    /// <summary>A string representing the enqueued event</summary>
    public const string EVENT_ACTION_ENQUEUED = "enqueued";
    /// <summary>A string representing the ready for review event</summary>
    public const string EVENT_ACTION_READY_FOR_REVIEW = "ready_for_review";
    /// <summary>A string representing the review request removed event</summary>
    public const string EVENT_ACTION_REVIEW_REQUEST_REMOVED = "review_request_removed";
    /// <summary>A string representing the review requested event</summary>
    public const string EVENT_ACTION_REVIEW_REQUESTED = "review_requested";
    /// <summary>A string representing the synchronize event</summary>
    public const string EVENT_ACTION_SYNCHRONIZE = "synchronize";
    /// <summary>A string representing the dismissed event</summary>
    public const string EVENT_ACTION_DISMISSED = "dismissed";
    /// <summary>A string representing the submitted event</summary>
    public const string EVENT_ACTION_SUBMITTED = "submitted";
    /// <summary>A string representing the resolved event</summary>
    public const string EVENT_ACTION_RESOLVED = "resolved";
    /// <summary>A string representing the unresolved event</summary>
    public const string EVENT_ACTION_UNRESOLVED = "unresolved";
    /// <summary>A string representing the prereleased event</summary>
    public const string EVENT_ACTION_PRERELEASED = "prereleased";
    /// <summary>A string representing the published event</summary>
    public const string EVENT_ACTION_PUBLISHED = "published";
    /// <summary>A string representing the released event</summary>
    public const string EVENT_ACTION_RELEASED = "released";
    /// <summary>A string representing the unpublished event</summary>
    public const string EVENT_ACTION_UNPUBLISHED = "unpublished";
    /// <summary>A string representing the archived event</summary>
    public const string EVENT_ACTION_ARCHIVED = "archived";
    /// <summary>A string representing the privatized event</summary>
    public const string EVENT_ACTION_PRIVATIZED = "privatized";
    /// <summary>A string representing the publicized event</summary>
    public const string EVENT_ACTION_PUBLICIZED = "publicized";
    /// <summary>A string representing the renamed event</summary>
    public const string EVENT_ACTION_RENAMED = "renamed";
    /// <summary>A string representing the unarchived event</summary>
    public const string EVENT_ACTION_UNARCHIVED = "unarchived";

}

#endregion Event Constants

