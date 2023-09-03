// *****************************************************************************
// GitHubMilestone.cs
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
/// Represents a Git Hub Milestone
/// </summary>
/// <remarks>A Milestone is a collection of related issues and pull requests</remarks>
public sealed class GitHubMilestone
{

    #region Properties

    /// <summary>
    /// The date and time the milestone was closed
    /// </summary>
    public DateTime? ClosedAt { get; set; }
    /// <summary>
    /// The total of closed issues in the milestone
    /// </summary>
    public int ClosedIssues { get; set; }
    /// <summary>
    /// The date and time the milestone was created
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The git hub user who created the milestone
    /// </summary>
    public GitHubAccount? Creator { get; set; }
    /// <summary>
    /// The description of the milestone
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// The date and time the milestone is due
    /// </summary>
    public DateTime? DueOn { get; set; }
    /// <summary>
    /// The HTML URL
    /// </summary>
    [JsonProperty("html_url")]
    public string? HTMLURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
    /// <summary>
    /// The Labels URL
    /// </summary>
    public string? LabelsURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public long NodeID { get; set; }
    /// <summary>
    /// The number of the milestone
    /// </summary>
    public int Number { get; set; }
    /// <summary>
    /// The total of open issues
    /// </summary>
    public int OpenIssues { get; set; }
    /// <summary>
    /// The milestone state
    /// </summary>
    public GitHubMilestoneStates? State { get; set; }
    /// <summary>
    /// The title of the milestone
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// The date and time the milestone was updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    /// <summary>
    /// The milestone URL
    /// </summary>
    public string? URL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubMilestone"/> class
    /// </summary>
    public GitHubMilestone()
	{
	}
}

/// <summary>
/// A list of valid milestone states
/// </summary>
public enum GitHubMilestoneStates
{
    /// <summary>
    /// The milestone is open
    /// </summary>
    Open,
    /// <summary>
    /// The milestone is closed
    /// </summary>
    Closed
}

