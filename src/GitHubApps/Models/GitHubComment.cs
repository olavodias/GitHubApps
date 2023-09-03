// *****************************************************************************
// GitHubComment.cs
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
/// Represents a Git Hub Comment
/// </summary>
public class GitHubComment
{

    #region Properties

    /// <summary>
    /// How the author is associated with the repository
    /// </summary>
    public GitHubAuthorAssociations? AuthorAssociation { get; set; }
    /// <summary>
    /// Cotnents of the issue comment
    /// </summary>
    public string? Body { get; set; }
    /// <summary>
    /// The date and time the comment was created
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The URL to the comment
    /// </summary>
    [JsonProperty("html_url")]
    public string? HTMLURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    [JsonProperty("id")]
    public int ID { get; set; }
    /// <summary>
    /// The URL to the issue
    /// </summary>
    public string? IssueURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <include file="documentation_shared.xml" path="Documents/RepetitiveProperties/RepetitiveProperty[@name=PerformedViaGitHubApp]"/>
    [JsonProperty("performed_via_github_app")]
    public GitHubPerformedViaGitHubApp? PerformedViaGitHubApp { get; set; }
    /// <include file="documentation_shared.xml" path="Documents/RepetitiveProperties/RepetitiveProperty[@name=Reactions]"/>
    public GitHubReactions? Reactions { get; set; }
    /// <summary>
    /// The date and the comment was updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    /// <summary>
    /// The URL for the issue comment
    /// </summary>
    [JsonProperty("url")]
    public string? URL { get; set; }
    /// <summary>
    /// The user who generated the comment
    /// </summary>
    public GitHubAccount? User { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubComment"/> class
    /// </summary>
    public GitHubComment()
	{
	}
}

