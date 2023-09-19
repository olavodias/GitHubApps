// *****************************************************************************
// GitHubAssets.cs
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
/// Represents GitHub Assets
/// </summary>
public sealed class GitHubAssets
{

    #region Properties

    /// <summary>
    /// The download URL
    /// </summary>
    public string? BrowserDownloadURL { get; set; }
    /// <summary>
    /// The Content Type
    /// </summary>
    public string? ContentType { get; set; }
    /// <summary>
    /// The date and time the Asset was created
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The total of downloads of the asset
    /// </summary>
    public int DownloadCount { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
    /// <summary>
    /// The asset label
    /// </summary>
    public string? Label { get; set; }
    /// <summary>
    /// The name of the asset
    /// </summary>
    public string? Name { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <summary>
    /// The size of the asset
    /// </summary>
    public int Size { get; set; }
    /// <summary>
    /// The state of the asset
    /// </summary>
    public GitHubAssetStates? State { get; set; }
    /// <summary>
    /// The date and time the asset was uploaded
    /// </summary>
    public DateTime? UploadedAt { get; set; }
    /// <summary>
    /// The GitHub account who uploaded the asset
    /// </summary>
    public GitHubAccount? Uploader { get; set; }
    /// <summary>
    /// The URL
    /// </summary>
    public string? URL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubAssets"/> class
    /// </summary>
    public GitHubAssets()
	{
	}
}

/// <summary>
/// A list of valid values for the <see cref="GitHubAssets.State"/>
/// </summary>
public enum GitHubAssetStates
{
    /// <summary>
    /// The asset state is uploaded
    /// </summary>
    Uploaded
}