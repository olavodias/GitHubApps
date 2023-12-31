﻿// *****************************************************************************
// GitHubReview.cs
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
/// Represents a GitHub Review
/// </summary>
public sealed class GitHubReview
{

    #region Properties

    /// <summary>
    /// Links to the review
    /// </summary>
    [JsonProperty("_links")]
    public GitHubLinks? Links { get; set; }
    /// <summary>
    /// How the author is associated with the repository
    /// </summary>
    public GitHubAuthorAssociations? AuthorAssociation { get; set; }
    /// <summary>
    /// The review body
    /// </summary>
    public string? Body { get; set; }
    /// <summary>
    /// A commit SHA for the review
    /// </summary>
    public string? CommitID { get; set; }
    /// <summary>
    /// The HTML URL
    /// </summary>
    [JsonProperty("html_url")]
    public string? HTMLURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <summary>
    /// The Pull Request URL
    /// </summary>
    public string? PullRequestURL { get; set; }
    /// <summary>
    /// The state of the review
    /// </summary>
    public GitHubReviewStates? State { get; set; }
    /// <summary>
    /// The date and time the review was submmited
    /// </summary>
    public DateTime? SubmittedAt { get; set; }
    /// <summary>
    /// The user who created the review
    /// </summary>
    public GitHubAccount? User { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubReview"/> class
    /// </summary>
    public GitHubReview()
	{
	}
}

/// <summary>
/// A list of valid GitHub Review States
/// </summary>
public enum GitHubReviewStates
{
    /// <summary>
    /// The review is dismissed
    /// </summary>
    Dismissed,
    /// <summary>
    /// The review is approved
    /// </summary>
    Approved,
    /// <summary>
    /// Changes were requested for the review
    /// </summary>
    [JsonProperty("changes_requested")]
    ChangesRequested
}

