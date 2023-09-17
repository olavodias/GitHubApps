// *****************************************************************************
// GitHubOrganization.cs
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
/// Represents a GitHub Organization
/// </summary>
public sealed class GitHubOrganization
{

    #region Properties

    /// <summary>
    /// The Avatar URL
    /// </summary>
    public string? AvatarURL { get; set; }
    /// <summary>
    /// The Organization Description
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// The Organization Events URL
    /// </summary>
    public string? EventsURL { get; set; }
    /// <summary>
    /// The Organization Hooks URL
    /// </summary>
    public string? HooksURL { get; set; }
    /// <summary>
    /// The Organization ID
    /// </summary>
    public long ID { get; set; }
    /// <summary>
    /// The Organization Issues URL
    /// </summary>
    public string? IssuesURL { get; set; }
    /// <summary>
    /// The Organization login
    /// </summary>
    public string? Login { get; set; }
    /// <summary>
    /// The Organization Members URL
    /// </summary>
    public string? MembersURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <summary>
    /// The Public Members URL
    /// </summary>
    public string? PublicMembersURL { get; set; }
    /// <summary>
    /// The Organization Repositories URL
    /// </summary>
    public string? ReposURL { get; set; }
    /// <summary>
    /// The Organization URL
    /// </summary>
    public string? URL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubOrganization"/> class
    /// </summary>
    public GitHubOrganization()
	{

	}
}

