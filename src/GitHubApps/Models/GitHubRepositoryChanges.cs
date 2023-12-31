﻿// *****************************************************************************
// GitHubRepositoryChanges.cs
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
/// Represents the changes on a <see cref="GitHubRepository"/>
/// </summary>
public sealed class GitHubRepositoryChanges
{

    #region Properties

    /// <summary>
    /// The previous default branch
    /// </summary>
    public GitHubChangesFrom<string>? DefaultBranch { get; set; }
    /// <summary>
    /// The previous description
    /// </summary>
    public GitHubChangesFrom<string>? Description { get; set; }
    /// <summary>
    /// The previous homepage
    /// </summary>
    public GitHubChangesFrom<string>? Homepage { get; set; }
    /// <summary>
    /// The previous owner
    /// </summary>
    /// <remarks>An owner can be a <see cref="GitHubAccount"/>, or a <see cref="GitHubOrganization"/></remarks>
    public GitHubChangesFrom<GitHubChangesOwner>? Owner { get; set; }
    /// <summary>
    /// The repository changes
    /// </summary>
    public GitHubRepositoryChangesRepository? Repository { get; set; }
    /// <summary>
    /// THe previous topics
    /// </summary>
    public GitHubChangesFrom<string>? Topics { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubRepositoryChanges"/>
    /// </summary>
    public GitHubRepositoryChanges()
	{
	}
}

