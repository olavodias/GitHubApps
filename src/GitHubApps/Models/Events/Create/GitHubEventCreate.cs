// *****************************************************************************
// GitHubEventCreate.cs
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
namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when a Git branch or tag is created
/// </summary>
public sealed class GitHubEventCreate: GitHubEvent<GitHubEventCreate>
{

    #region Properties

    /// <summary>
    /// The repository's current description
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// The name of the repository's default branch (usually main)
    /// </summary>
    public string? MasterBranch { get; set; }
    /// <summary>
    /// The pusher type for the event. Can be either user or a deploy key.
    /// </summary>
    public string? PusherType { get; set; }
    /// <summary>
    /// The Git Ref Resource
    /// </summary>
    public string? Ref { get; set; }
    /// <summary>
    /// The type of Git Ref object created in the repository
    /// </summary>
    public GitHubRefTypes? RefType { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventCreate"/> class
    /// </summary>
    public GitHubEventCreate()
	{
	}
}

/// <summary>
/// A list of valid Ref Types
/// </summary>
public enum GitHubRefTypes
{
    /// <summary>
    /// The Ref Type is a Tag
    /// </summary>
    Tag,
    /// <summary>
    /// The Ref Type is a Branch
    /// </summary>
    Branch
}
