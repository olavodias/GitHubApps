// *****************************************************************************
// GitHubEventPush.cs
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

namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when a commit or tag is pushed, or when a repository is cloned.
/// </summary>
public class GitHubEventPush: GitHubEvent<GitHubEventPush>
{

    #region Properties

    /// <summary>
    /// The SHA of the most recent commit on <see cref="Ref"/> after the push
    /// </summary>
    public string? After { get; set; }
    /// <summary>
    /// The base Ref
    /// </summary>
    public string? BaseRef { get; set; }
    /// <summary>
    /// The SHA of the most recent commit on <see cref="Ref"/> before the push
    /// </summary>
    public string? Before { get; set; }
    /// <summary>
    /// An array of commit objects describing the pushed commits.
    /// (Pushed commits are all commits that are included in the <see cref="Compare"/> between <see cref="Before"/> and <see cref="After"/> commit).
    /// The array include a maximum of 20 commits. If necessary, you can use the Commits API to fetch additional commits.
    /// The limit is applied to timeline events only and isn't applied to webhook deliveries.
    /// </summary>
    public GitHubCommit[]? Commits { get; set; }
    /// <summary>
    /// URL that shows the changes in this <see cref="Ref"/> update, from the <see cref="Before"/> commit to the <see cref="After"/> commit.
    /// For a newly created <see cref="Ref"/> that is directly based on the default branch, this is the comparison between the head of the default branch and the <see cref="After"/> commit.
    /// Otherwise, this shows all commits until the <see cref="After"/> commit.0
    /// </summary>
    public string? Compare { get; set; }
    /// <summary>
    /// Whether this push created the <see cref="Ref"/>
    /// </summary>
    [JsonProperty("created")]
    public bool? IsCreated { get; set; }
    /// <summary>
    /// Whether this push deleted the <see cref="Ref"/>
    /// </summary>
    [JsonProperty("deleted")]
    public bool? IsDeleted { get; set; }
    /// <summary>
    /// Whether this push was a force push to the <see cref="Ref"/>
    /// </summary>
    [JsonProperty("forced")]
    public bool? IsForced { get; set; }
    /// <summary>
    /// The head commit
    /// </summary>
    public GitHubCommit? HeadCommit { get; set; }
    /// <summary>
    /// Metaproperties for Git author/committer information
    /// </summary>
    public GitHubAccountMetaProperties? Pusher { get; set; }
    /// <summary>
    /// The full git ref that was pushed. Example: refs/heads/main or refs/tags/v3.14.1
    /// </summary>
    public string? Ref { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventPush"/> class
    /// </summary>
    public GitHubEventPush()
	{
	}

}