// *****************************************************************************
// GitHubEventInstallation.cs
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

namespace GitHubApps.Models.Events;

/// <summary>
/// This event occurs when there is activity relating to a GitHub App installation. All GitHub Apps receive this event by default.
/// </summary>
/// <remarks>See https://docs.github.com/en/webhooks-and-events/webhooks/webhook-events-and-payloads#installation</remarks>
public sealed class GitHubEventInstallation : GitHubEventWithAction<GitHubEventInstallation>
{

    #region Properties

    /// <summary>
    /// An array of repositories
    /// </summary>
    public GitHubRepository[]? Repositories { get; set; }

    /// <summary>
    /// The requester of the installation
    /// </summary>
    public GitHubAccount? Requester { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubEventInstallation"/> class
    /// </summary>
    public GitHubEventInstallation()
    {

    }

}

