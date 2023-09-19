// *****************************************************************************
// GitHubCommit.cs
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
/// Represents a GitHub Commit
/// </summary>
public sealed class GitHubCommit
{

    #region Properties

    /// <summary>
    /// An array of files added in the commit
    /// </summary>
    public string[]? Added { get; set; }
    /// <summary>
    /// Metaproperties for Git author/committer information
    /// </summary>
    public GitHubAccountMetaProperties? Author { get; set; }
    /// <summary>
    /// Metaproperties for Git author/committer information
    /// </summary>
    public GitHubAccountMetaProperties? Committer { get; set; }
    /// <summary>
    /// Whether this commit is distinct from any that have been pushed before
    /// </summary>
    [JsonProperty("distinct")]
    public bool? IsDistinct { get; set; }
    /// <summary>
    /// The commit ID
    /// </summary>
    public string? ID { get; set; }
    /// <summary>
    /// The commit message
    /// </summary>
    public string? Message { get; set; }
    /// <summary>
    /// An array of files modified by the commit
    /// </summary>
    public string[]? Modified { get; set; }
    /// <summary>
    /// An array of files removed by the commit
    /// </summary>
    public string[]? Removed { get; set; }
    /// <summary>
    /// The ISO 8601 timestamp of the commit
    /// </summary>
    [JsonConverter(typeof(GitHubDateTimeConverter))]
    public DateTime? Timestamp { get; set; }
    /// <summary>
    /// The Tree ID
    /// </summary>
    public string? TreeID { get; set; }
    /// <summary>
    /// The URL
    /// </summary>
    public string? URL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubCommit"/> class
    /// </summary>
    public GitHubCommit()
	{
	}
}