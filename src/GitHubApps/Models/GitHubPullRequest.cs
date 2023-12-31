﻿// *****************************************************************************
// GitHubPullRequest.cs
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
/// Represents a GitHub Pull Request
/// </summary>
public sealed class GitHubPullRequest
{

    #region Properties

    /// <summary>
    /// The Pull Request Links
    /// </summary>
    [JsonProperty("_links")]
    public GitHubLinks? Links { get; set; }
    /// <summary>
    /// The Reason why the Pull Request is locked
    /// </summary>
    public GitHubIssueActiveLockReasons? ActiveLockReason { get; set; }
    /// <summary>
    /// The count of additions
    /// </summary>
    public int Additions { get; set; }
    /// <summary>
    /// The Assignee
    /// </summary>
    public GitHubAccount? Assignee { get; set; }
    /// <summary>
    /// An array of assignees
    /// </summary>
    public GitHubAccount[]? Assignees { get; set; }
    /// <summary>
    /// How the author is associated with the repository
    /// </summary>
    public GitHubAuthorAssociations? AuthorAssociation { get; set; }
    /// <summary>
    /// The status of auto merging a pull request
    /// </summary>
    public GitHubPullRequestAutoMerge? AutoMerge { get; set; }
    /// <summary>
    /// The Base of the Pull Request
    /// </summary>
    public GitHubBase? Base { get; set; }
    /// <summary>
    /// The Body of the Pull Request
    /// </summary>
    public string? Body { get; set; }
    /// <summary>
    /// The total of files changed
    /// </summary>
    public int ChangedFiles { get; set; }
    /// <summary>
    /// The date and time the pull request was closed
    /// </summary>
    public DateTime? ClosedAt { get; set; }
    /// <summary>
    /// The total of comments
    /// </summary>
    public int Comments { get; set; }
    /// <summary>
    /// The Comments URL
    /// </summary>
    [JsonProperty("comments_url")]
    public string? CommentsURL { get; set; }
    /// <summary>
    /// The total of commits in the pull request
    /// </summary>
    public int Commits { get; set; }
    /// <summary>
    /// The Commits URL
    /// </summary>
    [JsonProperty("commits_url")]
    public string? CommitsURL { get; set; }
    /// <summary>
    /// The date and time the pull request was created
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The total of deletions
    /// </summary>
    public int Deletions { get; set; }
    /// <summary>
    /// The Diff URL
    /// </summary>
    [JsonProperty("diff_url")]
    public string? DiffURL { get; set; }
    /// <summary>
    /// Defines whether the pull request is a draft or not
    /// </summary>
    [JsonProperty("draft")]
    public bool? IsDraft { get; set; }
    /// <summary>
    /// The head of the pull request
    /// </summary>
    public GitHubBase? Head { get; set; }
    /// <summary>
    /// The HTML URL
    /// </summary>
    [JsonProperty("html_url")]
    public string? HTMLURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
    /// <summary>
    /// The issue URL
    /// </summary>
    [JsonProperty("issue_url")]
    public string? IssueURL { get; set; }
    /// <summary>
    /// An array of GitHub Labels added to the pull request
    /// </summary>
    public GitHubLabel[]? Labels { get; set; }
    /// <summary>
    /// Defines whether the Pull Request is locked or not
    /// </summary>
    [JsonProperty("locked")]
    public bool? IsLocked { get; set; }
    /// <summary>
    /// Indicates whether maintainers can modify the pull request
    /// </summary>
    public bool? MaintainerCanModify { get; set; }
    /// <summary>
    /// The Merge Commit SHA
    /// </summary>
    public string? MergeCommitSha { get; set; }
    /// <summary>
    /// Indicates whether the pull request is mergeable or not
    /// </summary>
    [JsonProperty("mergeable")]
    public bool? IsMergeable { get; set; }
    /// <summary>
    /// The mergeable state
    /// </summary>
    public string? MergeableState { get; set; }
    /// <summary>
    /// Indicates whether the pull request was merged or not
    /// </summary>
    [JsonProperty("merged")]
    public bool? IsMerged { get; set; }
    /// <summary>
    /// The Merge At
    /// </summary>
    public string? MergedAt { get; set; }
    /// <summary>
    /// The GitHub account who merged the pull request
    /// </summary>
    public GitHubAccount? MergedBy { get; set; }
    /// <summary>
    /// A collection of related issues and pull requests
    /// </summary>
    public GitHubMilestone? Milestone { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <summary>
    /// The Pull Request Number
    /// </summary>
    public int Number { get; set; }
    /// <summary>
    /// The Patch URL
    /// </summary>
    [JsonProperty("patch_url")]
    public string? PatchURL { get; set; }
    /// <summary>
    /// Indicates whether the branch is rebaseable or not
    /// </summary>
    [JsonProperty("rebaseable")]
    public bool? IsRebaseable { get; set; }
    /// <summary>
    /// An array of users requested to review the pull request
    /// </summary>
    public GitHubAccount[]? RequestedReviewers { get; set; }
    /// <summary>
    /// An array of teams requested to review the pull request
    /// </summary>
    public GitHubRequestedTeam[]? RequestedTeams { get; set; }
    /// <summary>
    /// The total of review comments
    /// </summary>
    public int ReviewComments { get; set; }
    /// <summary>
    /// The URL for Review Comment
    /// </summary>
    [JsonProperty("review_comment_url")]
    public string? ReviewCommentURL { get; set; }
    /// <summary>
    /// The URL for Review Comments
    /// </summary>
    [JsonProperty("review_comments_url")]
    public string? ReviewCommentsURL { get; set; }
    /// <summary>
    /// State of the Pull Request
    /// </summary>
    public GitHubPullRequestStates? State { get; set; }
    /// <summary>
    /// The Statuses URL
    /// </summary>
    [JsonProperty("statuses_url")]
    public string? StatusesURL { get; set; }
    /// <summary>
    /// The title of the pull request
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// The date and time the pull request was updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    /// <summary>
    /// The URL
    /// </summary>
    public string? URL { get; set; }
    /// <summary>
    /// The user who created the pull request
    /// </summary>
    public GitHubAccount? User { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubPullRequest"/> class
    /// </summary>
    public GitHubPullRequest()
	{
	}
}

/// <summary>
/// A list of valid pull request states
/// </summary>
public enum GitHubPullRequestStates
{
    /// <summary>
    /// The pull request is open
    /// </summary>
    Open,
    /// <summary>
    /// The pull request is closed
    /// </summary>
    Closed
}
