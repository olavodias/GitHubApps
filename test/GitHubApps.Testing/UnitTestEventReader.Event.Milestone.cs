// *****************************************************************************
// UnitTestEventReader.Event.Milestone.cs
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
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// The Unit Testing Class - For the Milestone Event Only
/// </summary>
public partial class UnitTestEventReader
{

    #region Model Validation

    /// <summary>
    /// Validates a <see cref="GitHubMilestone"/>
    /// </summary>
    /// <param name="model"></param>
    private void ValidateMilestone(GitHubMilestone model)
    {
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/milestones/1", model.URL);
        Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/milestone/1", model.HTMLURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/milestones/1/labels", model.LabelsURL);
        Assert.AreEqual(9858372, model.ID);
        Assert.AreEqual("MI_kwDOKNJSy84Alm1E", model.NodeID);
        Assert.AreEqual(1, model.Number);
        Assert.AreEqual("First Milestone", model.Title);
        Assert.IsNull(model.Description);

        Assert.IsNotNull(model.Creator);
        ValidateDefaultAccount(model.Creator);

        Assert.AreEqual(1, model.OpenIssues);
        Assert.AreEqual(0, model.ClosedIssues);
        Assert.AreEqual(GitHubMilestoneStates.Open, model.State);
        Assert.AreEqual(DefaultDateTime, model.CreatedAt);
        Assert.AreEqual(DefaultDateTime, model.UpdatedAt);
        Assert.IsNull(model.DueOn);
        Assert.IsNull(model.ClosedAt);        
    }

    #endregion Model Validation

}


