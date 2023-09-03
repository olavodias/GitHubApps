// *****************************************************************************
// GitHubReactions.cs
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
/// Represents the reactions to a comment
/// </summary>
public sealed class GitHubReactions
{

    #region Properties

    /// <summary>
    /// The total of positive reactions
    /// </summary>
    [JsonProperty("+1")]
    public int Plus1 { get; set; }
    /// <summary>
    /// The total of negative reactions
    /// </summary>
    [JsonProperty("-1")]
    public int Minus1 { get; set; }

    /// <summary>
    /// The total of confused reactions
    /// </summary>
    public int Confused { get; set; }
    /// <summary>
    /// The total of eyes reactions
    /// </summary>
    public int Eyes { get; set; }
    /// <summary>
    /// The total of heart reactions
    /// </summary>
    public int Heart { get; set; }
    /// <summary>
    /// The total of hooray reactions
    /// </summary>
    public int Hooray { get; set; }
    /// <summary>
    /// The total of laugh reactions
    /// </summary>
    public int Laugh { get; set; }
    /// <summary>
    /// The total of rocket reactions
    /// </summary>
    public int Rocket { get; set; }
    /// <summary>
    /// The total count of reactions
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// The url
    /// </summary>
    public string? URL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubReactions"/> class
    /// </summary>
    public GitHubReactions()
	{
	}
}

