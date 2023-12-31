﻿// *****************************************************************************
// GitHubPullRequestAutoMerge.cs
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
namespace GitHubApps.Models;

/// <summary>
/// Represents the status of auto merging a pull request
/// </summary>
public sealed class GitHubPullRequestAutoMerge
{

    #region Properties

    /// <summary>
    /// Commit message for the merge commit
    /// </summary>
    public string? CommitMessage { get; set; }
    /// <summary>
    /// Title for the merge commit message
    /// </summary>
    public string? CommitTitle { get; set; }
    /// <summary>
    /// The <see cref="GitHubAccount"/> who enabled the Auto Merge
    /// </summary>
    public GitHubAccount? EnabledBy { get; set; }
    /// <summary>
    /// The merge method to use
    /// </summary>
    public GitHubMergeMethods? MergeMethod { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubPullRequestAutoMerge"/> class
    /// </summary>
    public GitHubPullRequestAutoMerge()
	{
	}
}

/// <summary>
/// A list of valid Merge Methods
/// </summary>
public enum GitHubMergeMethods
{
    /// <summary>
    /// A regular merge
    /// </summary>
    Merge,
    /// <summary>
    /// A squash merge
    /// </summary>
    Squash,
    /// <summary>
    /// A rebase merge
    /// </summary>
    Rebase
}