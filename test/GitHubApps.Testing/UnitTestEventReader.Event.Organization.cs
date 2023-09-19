// *****************************************************************************
// UnitTestEventReader.Event.Organization.cs
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

#pragma warning disable CA1822 // Mark members as static

using System;
using System.Runtime.CompilerServices;
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// The Unit Testing Class - For the Organization Event Only
/// </summary>
public partial class UnitTestEventReader
{
    #region Model Validation

    /// <summary>
    /// Validates a <see cref="GitHubOrganization"/>
    /// </summary>
    /// <param name="model">The <see cref="GitHubOrganization"/> to be validated</param>
    /// <param name="memberName">The name of the method calling the function</param>
    private void ValidateOrganization(GitHubOrganization? model, [CallerMemberName] string memberName = "")
    {
        Assert.IsNotNull(model);
        Assert.AreEqual("githuborg", model.Login);
        Assert.AreEqual(24394891, model.ID);
        Assert.AreEqual("MDEyOk9yZ2FuaXphdGlvbjI0Mzk0ODkx", model.NodeID);
        Assert.AreEqual("https://api.github.com/orgs/githuborg", model.URL);
        Assert.AreEqual("https://api.github.com/orgs/githuborg/repos", model.ReposURL);
        Assert.AreEqual("https://api.github.com/orgs/githuborg/events", model.EventsURL);
        Assert.AreEqual("https://api.github.com/orgs/githuborg/hooks", model.HooksURL);
        Assert.AreEqual("https://api.github.com/orgs/githuborg/issues", model.IssuesURL);
        Assert.AreEqual("https://api.github.com/orgs/githuborg/members{/member}", model.MembersURL);
        Assert.AreEqual("https://api.github.com/orgs/githuborg/public_members{/member}", model.PublicMembersURL);
        Assert.AreEqual("https://avatars.githubusercontent.com/u/24394891?v=4", model.AvatarURL);
        Assert.IsNull(model.Description);        
    }

    #endregion Model Validation
}

#pragma warning restore CA1822 // Mark members as static