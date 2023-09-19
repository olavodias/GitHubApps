// *****************************************************************************
// GitHubRelease.cs
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
/// Represents a GitHub Release
/// </summary>
public sealed class GitHubRelease
{

    #region Properties

    /// <summary>
    /// The Release Assets
    /// </summary>
    public GitHubAssets[]? Assets { get; set; }
    /// <summary>
    /// The Release Assets URL
    /// </summary>
    public string? AssetsURL { get; set; }
    /// <summary>
    /// The Release Author
    /// </summary>
    public GitHubAccount? Author { get; set; }
    /// <summary>
    /// The Release Body
    /// </summary>
    public string? Body { get; set; }
    /// <summary>
    /// The date and time the release was created
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The Release Discussion URL
    /// </summary>
    public string? DiscussionURL { get; set; }
    /// <summary>
    /// Whether the release is a draft or published
    /// </summary>
    [JsonProperty("draft")]
    public bool? IsDraft { get; set; }
    /// <summary>
    /// The Release HTML URL
    /// </summary>
    [JsonProperty("html_url")]
    public string? HTMLURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
    /// <summary>
    /// The Release Name
    /// </summary>
    public string? Name { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <summary>
    /// Whether the release is identified as a prerelease or a full release
    /// </summary>
    [JsonProperty("prerelease")]
    public bool? IsPreRelease { get; set; }
    /// <summary>
    /// The date and time the release was published
    /// </summary>
    public DateTime? PublishedAt { get; set; }
    /// <summary>
    /// The reactions to the release
    /// </summary>
    public GitHubReactions? Reactions { get; set; }
    /// <summary>
    /// The Release Tag Name
    /// </summary>
    public string? TagName { get; set; }
    /// <summary>
    /// The Release Tarball URL
    /// </summary>
    public string? TarballURL { get; set; }
    /// <summary>
    /// Specified the commitish value that determines where the Git tag is created from
    /// </summary>
    public string? TargetCommitish { get; set; }
    /// <summary>
    /// The Release Upload URL
    /// </summary>
    public string? UploadURL { get; set; }
    /// <summary>
    /// The Release URL
    /// </summary>
    public string? URL { get; set; }
    /// <summary>
    /// The Release Zipball URL
    /// </summary>
    public string? ZipballURL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRelease"/> class
    /// </summary>
    public GitHubRelease()
	{
	}
}

