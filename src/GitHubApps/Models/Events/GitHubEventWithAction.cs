// *****************************************************************************
// GitHubEventWithAction.cs
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
/// Represents a base class for an event that contains an action
/// </summary>
/// <typeparam name="TMainClass">The type with the event payload</typeparam>
public abstract class GitHubEventWithAction<TMainClass>: GitHubEvent<TMainClass>
{

    #region Properties

    /// <summary>
    /// The action being performed by the event
    /// </summary>
    public string Action { get; set; } = string.Empty;

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventActions"/> class
    /// </summary>
    public GitHubEventWithAction()
	{
	}

}

