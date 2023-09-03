// *****************************************************************************
// GitHubIssue.cs
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
/// Represents a Git Hub Issue
/// </summary>
public sealed class GitHubIssue
{

    #region Properties

    /// <summary>
    /// The reason why there is a lock on the Issue
    /// </summary>
    public GitHubIssueActiveLockReasons? ActiveLockReason { get; set; }
    /// <summary>
    /// The user to whom the issue is assigned
    /// </summary>
    public GitHubAccount? Assignee { get; set; }
    /// <summary>
    /// A list of users assigned to the issue
    /// </summary>
    public GitHubAccount[]? Assignees { get; set; }
    /// <summary>
    /// How the author is associated with the repository
    /// </summary>
    public GitHubAuthorAssociations? AuthorAssociation { get; set; }
    /// <summary>
    /// Contents of the issue
    /// </summary>
    public string? Body { get; set; }
    /// <summary>
    /// The date and time the issue was closed
    /// </summary>
    public DateTime? ClosedAt { get; set; }
    /// <summary>
    /// The count of comments on the issue
    /// </summary>
    public int Comments { get; set; }
    /// <summary>
    /// The URL of the issue comments
    /// </summary>
    public string? CommentsURL { get; set; }
    /// <summary>
    /// The date and time the issue was created
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// Defines whether the issue is a draft or not
    /// </summary>
    public bool? Draft { get; set; }
    /// <summary>
    /// The Events URL
    /// </summary>
    public string? EventsURL { get; set; }
    /// <summary>
    /// The HTML URL
    /// </summary>
    [JsonProperty("html_url")]
    public string? HTMLURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
    /// <summary>
    /// An array of Labels assigned to the issue
    /// </summary>
    public GitHubLabel[]? Labels { get; set; }
    /// <summary>
    /// The Labels URL
    /// </summary>
    public string? LabelsURL { get; set; }
    /// <summary>
    /// A flag to define whether the issue is locked or not
    /// </summary>
    public bool? Locked { get; set; }
    /// <summary>
    /// A collection of related issues and pull requests
    /// </summary>
    public GitHubMilestone? Milestone { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <summary>
    /// The issue number
    /// </summary>
    public long Number { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=PerformedViaGitHubApp]"/>
    [JsonProperty("performed_via_github_app")]
    public GitHubPerformedViaGitHubApp? PerformedViaGitHubApp { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=PullRequest]"/>
    public GitHubPullRequest? PullRequest { get; set; }
    /// <include file="documentation_shared.xml" path="Documents/RepetitiveProperties/RepetitiveProperty[@name=Reactions]"/>
    public GitHubReactions? Reactions { get; set; }
    /// <summary>
    /// The Repository URL
    /// </summary>
    public string? RepositoryURL { get; set; }
    /// <summary>
    /// The State of the Issue
    /// </summary>
    public GitHubIssueStates? State { get; set; }
    /// <summary>
    /// The reason for the issue state
    /// </summary>
    public string? StateReason { get; set; }
    /// <summary>
    /// The timeline URL
    /// </summary>
    public string? TimelineURL { get; set; }
    /// <summary>
    /// The title of the issue
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// The date and time the issue was updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    /// <summary>
    /// The URL of the issue
    /// </summary>
    public string? URL { get; set; }
    /// <summary>
    /// The Git Hub account who created the issue
    /// </summary>
    public GitHubAccount? User { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubIssue"/> class
    /// </summary>
    public GitHubIssue()
	{

	}
}

/// <summary>
/// The valid values for the Issue State
/// </summary>
public enum GitHubIssueStates
{
    /// <summary>
    /// The issue is open
    /// </summary>
    Open,
    /// <summary>
    /// The issue is closed
    /// </summary>
    Closed
}

/// <summary>
/// The valid values for the author's association with the repository
/// </summary>
public enum GitHubAuthorAssociations
{
    /// <summary>
    /// The author is a collaborator
    /// </summary>
    COLLABORATOR,
    /// <summary>
    /// The author is a contributor
    /// </summary>
    CONTRIBUTOR,
    /// <summary>
    /// The author is a first timer
    /// </summary>
    FIRST_TIMER,
    /// <summary>
    /// The author is a first time contributor
    /// </summary>
    FIRST_TIME_CONTRIBUTOR,
    /// <summary>
    /// The author is a mannequin
    /// </summary>
    MANNEQUIN,
    /// <summary>
    /// The author is a member
    /// </summary>
    MEMBER,
    /// <summary>
    /// There is no association of the author with the repository
    /// </summary>
    NONE,
    /// <summary>
    /// The author is the owner
    /// </summary>
    OWNER
}

/// <summary>
/// The valid values for locking an issue
/// </summary>
public enum GitHubIssueActiveLockReasons
{
    /// <summary>
    /// The issue has been resolved
    /// </summary>
    Resolved,
    /// <summary>
    /// The issue is off-topic
    /// </summary>
    [JsonProperty("off-topic")]
    OffTopic,
    /// <summary>
    /// The issue is too heated
    /// </summary>
    [JsonProperty("too heated")]
    TooHeated,
    /// <summary>
    /// The issue is flagged as a spam
    /// </summary>
    Spam
}