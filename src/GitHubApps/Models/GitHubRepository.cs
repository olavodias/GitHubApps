// *****************************************************************************
// GitHubRepository.cs
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
using System;
using Newtonsoft.Json;

namespace GitHubApps.Models;

/// <summary>
/// Represents a GitHub Repository
/// </summary>
public sealed class GitHubRepository
{

	#region Properties

	/// <summary>
	/// Whether to allow auto-merge for pull requests
	/// </summary>
	public bool? AllowAutoMerge { get; set; }
	/// <summary>
	/// Whether to allow private forks
	/// </summary>
	public bool? AllowForking { get; set; }
	/// <summary>
	/// Whether to allow merge commits for pull requests
	/// </summary>
	public bool? AllowMergeCommit { get; set; }
	/// <summary>
	/// Whether to allow rebase merges for pull requests
	/// </summary>
	public bool? AllowRebaseMerge { get; set; }
	/// <summary>
	/// Whether to allow squash merges for pull requests
	/// </summary>
	public bool? AllowSquashMerge { get; set; }
	/// <summary>
	/// Whether to allow to update the branch
	/// </summary>
	public bool? AllowUpdateBranch { get; set; }
	/// <summary>
	/// The Archive URL
	/// </summary>
	public string? ArchiveURL { get; set; }
	/// <summary>
	/// Whether the repository is archived
	/// </summary>
	[JsonProperty("archived")]
	public bool? IsArchived { get; set; }
	/// <summary>
	/// The Asignees URL
	/// </summary>
	public string? AssigneesURL { get; set; }
	/// <summary>
	/// The Blobs URL
	/// </summary>
	public string? BlobsURL { get; set; }
	/// <summary>
	/// The Branches URL
	/// </summary>
	public string? BranchesURL { get; set; }
	/// <summary>
	/// The Clone URL
	/// </summary>
	public string? CloneURL { get; set; }
	/// <summary>
	/// The Collaborators URL
	/// </summary>
	public string? CollaboratorsURL { get; set; }
	/// <summary>
	/// The Comments URL
	/// </summary>
	public string? CommentsURL { get; set; }
	/// <summary>
	/// The Commits URL
	/// </summary>
	public string? CommitsURL { get; set; }
	/// <summary>
	/// The Compare URL
	/// </summary>
	public string? CompareURL { get; set; }
	/// <summary>
	/// The Contents URL
	/// </summary>
	public string? ContentsURL { get; set; }
	/// <summary>
	/// The Contributors URL
	/// </summary>
	public string? ContributorsURL { get; set; }
	/// <summary>
	/// A date and time representing when the repository was created
	/// </summary>
	[JsonConverter(typeof(GitHubDateTimeConverter))]
	public DateTime? CreatedAt { get; set; }
	/// <summary>
	/// The default branch of the repository
	/// </summary>
	public string? DefaultBranch { get; set; }
	/// <summary>
	/// Whether to delete head branches when pull requests are merged
	/// </summary>
	public bool? DeleteBranchOnMerge { get; set; }
	/// <summary>
	/// The Deployments URL
	/// </summary>
	public string? DeploymentsURL { get; set; }
	/// <summary>
	/// The Description
	/// </summary>
	public string? Description { get; set; }
	/// <summary>
	/// Whether or not this repository is disabled
	/// </summary>
	[JsonProperty("disabled")]
	public bool? IsDisabled { get; set; }
	/// <summary>
	/// The Downloads URL
	/// </summary>
	public string? DownloadsURL { get; set; }
	/// <summary>
	/// The Event URL
	/// </summary>
	public string? EventsURL { get; set; }
	/// <summary>
	/// Whether it is a fork of another repository or not
	/// </summary>
	[JsonProperty("fork")]
	public bool? IsFork { get; set; }
	/// <summary>
	/// The count of forks
	/// </summary>
	public int Forks { get; set; }
    /// <summary>
    /// The count of forks
    /// </summary>
    public int ForksCount { get; set; }
	/// <summary>
	/// The Forks URL
	/// </summary>
	public string? ForksURL { get; set; }
    /// <summary>
    /// The full name of the repository
    /// </summary>
    public string? FullName { get; set; }
	/// <summary>
	/// The Git Commits URL
	/// </summary>
	public string? GitCommitsURL { get; set; }
	/// <summary>
	/// The Git Refs URL
	/// </summary>
	public string? GitRefsURL { get; set; }
	/// <summary>
	/// The Git Tags URL
	/// </summary>
	public string? GitTagsURL { get; set; }
	/// <summary>
	/// The Git URL
	/// </summary>
	public string? GitURL { get; set; }
	/// <summary>
	/// Whether downloads are enabled
	/// </summary>
	public bool? HasDownloads { get; set; }
	/// <summary>
	/// Whether issues are enabled
	/// </summary>
	public bool? HasIssues { get; set; }
	/// <summary>
	/// Whether pages are enabled
	/// </summary>
	public bool? HasPages { get; set; }
	/// <summary>
	/// Whether projects are enabked
	/// </summary>
	public bool? HasProjects { get; set; }
	/// <summary>
	/// Whether wiki is enabled
	/// </summary>
	public bool? HasWiki { get; set; }
	/// <summary>
	/// Whether discussions are enabled
	/// </summary>
	public bool? HasDiscussions { get; set; }
	/// <summary>
	/// The Homepage
	/// </summary>
	public string? Homepage { get; set; }
	/// <summary>
	/// The Hooks URL
	/// </summary>
	public string? HooksURL { get; set; }
	/// <summary>
	/// The HTML URL
	/// </summary>
	[JsonProperty("html_url")]
	public string? HTMLURL { get; set; }
	/// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
	public long ID { get; set; }
	/// <summary>
	/// Whether the repository is a template
	/// </summary>
	public bool? IsTemplate { get; set; }
	/// <summary>
	/// The Issue Comment URL
	/// </summary>
	public string? IssueCommentURL { get; set; }
	/// <summary>
	/// The Issue Events URL
	/// </summary>
	public string? IssueEventsURL { get; set; }
	/// <summary>
	/// The Issues URL
	/// </summary>
	public string? IssuesURL { get; set; }
	/// <summary>
	/// The Keys URL
	/// </summary>
	public string? KeysURL { get; set; }
	/// <summary>
	/// The Labels URL
	/// </summary>
	public string? LabelsURL { get; set; }
	/// <summary>
	/// The Language
	/// </summary>
	public string? Language { get; set; }
	/// <summary>
	/// The Languages URL
	/// </summary>
	public string? LanguagesURL { get; set; }
	/// <summary>
	/// The License Information
	/// </summary>
	public GitHubLicense? License { get; set; }
	/// <summary>
	/// The Master Branch
	/// </summary>
	public string? MasterBranch { get; set; }
	/// <summary>
	/// The Default Value for a merge commit message
	/// </summary>
	public GitHubRepositoryMergeCommitMessages? MergeCommitMessage { get; set; }
	/// <summary>
	/// The Default Value for a merge commit title
	/// </summary>
	public GitHubRepositoryMergeCommitTitles? MergeCommitTitle { get; set; }
	/// <summary>
	/// The Merges URL
	/// </summary>
	public string? MergesURL { get; set; }
	/// <summary>
	/// The Milestones URL
	/// </summary>
	public string? MilestonesURL { get; set; }
	/// <summary>
	/// The Mirror URL
	/// </summary>
	public string? MirrorURL { get; set; }
    /// <summary>
    /// The name of the repository
    /// </summary>
    public string? Name { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
	/// <summary>
	/// The Notifications URL
	/// </summary>
	public string? NotificationsURL { get; set; }
	/// <summary>
	/// The count of open issues
	/// </summary>
	public int OpenIssues { get; set; }
	/// <summary>
	/// The count of open issues
	/// </summary>
	public int OpenIssuesCount { get; set; }
	/// <summary>
	/// The organization name
	/// </summary>
	public string? Organization { get; set; }
	/// <summary>
	/// The owner of the repository
	/// </summary>
	public GitHubAccount? Owner { get; set; }
	/// <summary>
	/// The permissions on the repository
	/// </summary>
	public GitHubRepositoryPermissions? Permissions { get; set; }
	/// <summary>
	/// Defines whether the repository is private or not
	/// </summary>
	[JsonProperty("private")]
	public bool? IsPrivate { get; set; }
	/// <summary>
	/// Whether the repository is public or not
	/// </summary>
	public bool? Public { get; set; }
	/// <summary>
	/// The Pulls URL
	/// </summary>
	public string? PullsURL { get; set; }
    /// <summary>
    /// A date and time when the repository was pushed
    /// </summary>
    [JsonConverter(typeof(GitHubDateTimeConverter))]
    public DateTime? PushedAt { get; set; }
	/// <summary>
	/// The Releases URL
	/// </summary>
	public string? ReleasesURL { get; set; }
	/// <summary>
	/// The Role Name
	/// </summary>
	public string? RoleName { get; set; }
	/// <summary>
	/// The size
	/// </summary>
	public int Size { get; set; }
	/// <summary>
	/// The default value for a squash merge commit message
	/// </summary>
	public GitHubRepositorySquashMergeCommitMessage? SquashMergeCommitMessage { get; set; }
	/// <summary>
	/// The default value for a squash merge commit title
	/// </summary>
	public GitHubRepositorySquashMergeCommitTitles? SquashMergeCommitTitle { get; set; }
	/// <summary>
	/// The SSH URL
	/// </summary>
	[JsonProperty("ssh_url")]
	public string? SSH_URL { get; set; }
    /// <summary>
    /// The count of stargazers
    /// </summary>
    public int Stargazers { get; set; }
	/// <summary>
	/// The count of stargazers
	/// </summary>
	public int StargazersCount { get; set; }
    /// <summary>
    /// The Stargazers URL
    /// </summary>
    public string? StargazersURL { get; set; }
	/// <summary>
	/// The Statuses URL
	/// </summary>
	public string? StatusesURL { get; set; }
	/// <summary>
	/// The Subscribers URL
	/// </summary>
	public string? SubscribersURL { get; set; }
	/// <summary>
	/// The Subscription URL
	/// </summary>
	public string? SubscriptionURL{ get; set; }
	/// <summary>
	/// The SVN URL
	/// </summary>
	[JsonProperty("svn_url")]
	public string? SVN_URL { get; set; }
	/// <summary>
	/// The Tags URL
	/// </summary>
	public string? TagsURL { get; set; }
	/// <summary>
	/// The Teams URL
	/// </summary>
	public string? TeamsURL { get; set; }
	/// <summary>
	/// An array of topics
	/// </summary>
	public string[]? Topics { get; set; }
	/// <summary>
	/// The Trees URL
	/// </summary>
	public string? TreesURL { get; set; }
    /// <summary>
    /// The date and time the repository was updated
    /// </summary>
    [JsonConverter(typeof(GitHubDateTimeConverter))]
    public DateTime? UpdatedAt { get; set; }
	/// <summary>
	/// The URL
	/// </summary>
	public string? URL { get; set; }
	/// <summary>
	/// Whether a squash merge commit can use the pull request title as default.
	/// </summary>
	[Obsolete("This property has been deprecated. Please use the " + nameof(SquashMergeCommitTitle) + " instead")]
	public bool? UseSquashPrTitleAsDefault { get; set; }
	/// <summary>
	/// The Repository Visibility
	/// </summary>
	public GitHubRepositoryVisibility? Visibility { get; set; }
	/// <summary>
	/// The count of watchers
	/// </summary>
	public int Watchers { get; set; }
    /// <summary>
    /// The count of watchers
    /// </summary>
    public int WatchersCount { get; set; }
	/// <summary>
	/// Whether to require contributors to sign off on web-based commits
	/// </summary>
	[JsonProperty("web_commit_signoff_required")]
	public bool? IsWebCommitSignoffRequired { get; set; }

	#endregion Properties

	/// <summary>
	/// Initializes a new instance of the <see cref="GitHubRepository"/> class
	/// </summary>
	public GitHubRepository()
	{
	}
}

/// <summary>
/// A list of valid values for the <see cref="GitHubRepository.MergeCommitMessage"/> property
/// </summary>
public enum GitHubRepositoryMergeCommitMessages
{
	/// <summary>
	/// Default to the pull request's body
	/// </summary>
	PR_BODY,
	/// <summary>
	/// Default to the pull request's title
	/// </summary>
	PR_TITLE,
	/// <summary>
	/// Default to a blank commit message
	/// </summary>
	BLANK
}

/// <summary>
/// A list of valid values for the <see cref="GitHubRepository.MergeCommitTitle"/> property
/// </summary>
public enum GitHubRepositoryMergeCommitTitles
{
    /// <summary>
    /// Default to the pull request's title
    /// </summary>
    PR_TITE,
    /// <summary>
    /// Default to the classic title for a merge message
    /// </summary>
	/// <example>Merge pull request #123 from branch-name</example>
    MERGE_MESSAGE
}

/// <summary>
/// A list of valid values for the <see cref="GitHubRepository.SquashMergeCommitMessage"/> property
/// </summary>
public enum GitHubRepositorySquashMergeCommitMessage
{
	/// <summary>
	/// Default to the pull request's body
	/// </summary>
	PR_BODY,
	/// <summary>
	/// Default to the branch's commit messages
	/// </summary>
	COMMIT_MESSAGES,
	/// <summary>
	/// Default to a blank commit message
	/// </summary>
	BLANK
}


/// <summary>
/// A list of valid values for the <see cref="GitHubRepository.SquashMergeCommitTitle"/> property
/// </summary>
public enum GitHubRepositorySquashMergeCommitTitles
{
	/// <summary>
	/// Default to the pull request's title
	/// </summary>
	PR_TITLE,
	/// <summary>
	/// Default to the commit's title (if only one commit) or the pull request's title (when more than one commit)
	/// </summary>
	COMMIT_OR_PR_TITLE
}

/// <summary>
/// A list of valid values for the <see cref="GitHubRepository.Visibility"/> property
/// </summary>
public enum GitHubRepositoryVisibility
{
	/// <summary>
	/// The repository is public
	/// </summary>
	Public,
	/// <summary>
	/// The repository is private
	/// </summary>
	Private,
	/// <summary>
	/// The repository is internal
	/// </summary>
	Internal
}