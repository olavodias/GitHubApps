// *****************************************************************************
// GitHubLinks.cs
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
/// Represents the Links in a GitHub Object
/// </summary>
public sealed class GitHubLinks
{

    #region Properties

    /// <summary>
    /// The link to the Comments
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? Comments { get; set; }
    /// <summary>
    /// The link to the Commits
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? Commits { get; set; }
    /// <summary>
    /// The link to the HTML
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/> and <see cref="GitHubReview"/></remarks>
    [JsonProperty("html")]
    public GitHubLinksHref<string>? HTML { get; set; }
    /// <summary>
    /// The link to the Issue
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? Issue { get; set; }
    /// <summary>
    /// The link to the Pull Request
    /// </summary>
    /// <remarks>Available for <see cref="GitHubReview"/></remarks>
    public GitHubLinksHref<string>? PullRequest { get; set; }
    /// <summary>
    /// The link to the Comment
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? ReviewComment { get; set; }
    /// <summary>
    /// The link to the Comments
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? ReviewComments { get; set; }
    /// <summary>
    /// The link to the Self
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? Self { get; set; }
    /// <summary>
    /// The link to the Statuses
    /// </summary>
    /// <remarks>Available for <see cref="GitHubPullRequest"/></remarks>
    public GitHubLinksHref<string>? Statuses { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubLinks"/> class
    /// </summary>
    public GitHubLinks()
	{
	}
}

