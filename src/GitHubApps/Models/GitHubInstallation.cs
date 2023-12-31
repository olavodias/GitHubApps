﻿// *****************************************************************************
// GitHubInstallation.cs
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
/// Represents a Git Hub Installation
/// </summary>
public sealed class GitHubInstallation
{

    #region Properties

    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; } = 0;
	/// <summary>
	/// The Git Hub Account
	/// </summary>
	public GitHubAccount? Account { get; set; }
	/// <summary>
	/// The repositories selected
	/// </summary>
	public string? RepositorySelection { get; set; }
	/// <summary>
	/// The access token URL
	/// </summary>
	public string? AccessTokensURL { get; set; }
	/// <summary>
	/// The repositories URL
	/// </summary>
	public string? RepositoriesURL { get; set; }
	/// <summary>
	/// The HTML url
	/// </summary>
	[JsonProperty(PropertyName = "html_url")]
	public string? HTMLURL { get; set; }
	/// <summary>
	/// The Application ID
	/// </summary>
	public long AppID { get; set; }
	/// <summary>
	/// The Application Slug
	/// </summary>
	public string? AppSlug { get; set; }
	/// <summary>
	/// The Target ID
	/// </summary>
	public long TargetID { get; set; }
	/// <summary>
	/// The Target Type
	/// </summary>
	public string? TargetType { get; set; }
	/// <summary>
	/// An array of permissions
	/// </summary>
	public GitHubPermissions? Permissions { get; set; }
	/// <summary>
	/// An array of events
	/// </summary>
	public string[]? Events { get; set; }
	/// <summary>
	/// The date and time the installation was created
	/// </summary>
	public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The date and time the installation was updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
	/// <summary>
	/// The single file name
	/// </summary>
	public string? SingleFileName { get; set; }
	/// <summary>
	/// A flag to define whether there are multiple single files
	/// </summary>
	public bool HasMultipleSingleFiles { get; set; }
	/// <summary>
	/// An array of single files
	/// </summary>
	public string[]? SingleFilePaths { get; set; }
	/// <summary>
	/// The user who suspended the installation
	/// </summary>
	public GitHubAccount? SuspendedBy { get; set; }
	/// <summary>
	/// The date and time the installation was suspended
	/// </summary>
	public DateTime? SuspendedAt { get; set; }

    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubInstallation"/> class
    /// </summary>
    public GitHubInstallation()
	{

	
	}
}

