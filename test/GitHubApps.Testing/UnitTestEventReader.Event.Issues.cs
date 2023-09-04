// *****************************************************************************
// UnitTestEventReader.Event.Issues.cs
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
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// The Unit Testing Class - For the Issue Comment Event Only
/// </summary>
public partial class UnitTestEventReader
{

    #region Model Validation

    /// <summary>
    /// Validates a <see cref="GitHubIssue"/>
    /// </summary>
    /// <param name="model">The <see cref="GitHubIssue"/> to be validated</param>
    private void ValidateIssue(GitHubIssue model)
    {
        // Issue Root Elements
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/3", model.URL);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps", model.RepositoryURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/3/labels{/name}", model.LabelsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/3/comments", model.CommentsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/3/events", model.EventsURL);
        Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/issues/3", model.HTMLURL);
        Assert.AreEqual(1880621325, model.ID);
        Assert.AreEqual("I_kwDOKNJSy85wGAEN", model.NodeID);
        Assert.AreEqual(3, model.Number);
        Assert.AreEqual("Test Issue Created", model.Title);

        Assert.IsNull(model.Milestone);
        Assert.AreEqual(1, model.Comments);

        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.CreatedAt);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.UpdatedAt);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.ClosedAt);

        Assert.AreEqual(GitHubAuthorAssociations.OWNER, model.AuthorAssociation);
        Assert.IsNull(model.ActiveLockReason);

        Assert.AreEqual("Body of the issue", model.Body);

        Assert.AreEqual(GitHubIssueStates.Open, model.State);
        Assert.IsFalse(model.IsLocked);

        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/3/timeline", model.TimelineURL);
        Assert.IsNull(model.PerformedViaGitHubApp);
        Assert.IsNull(model.StateReason);

        Assert.IsNotNull(model.User);
        ValidateDefaultAccount(model.User);

        // Validate Labels
        Assert.IsNotNull(model.Labels);
        Assert.AreEqual(2, model.Labels.Length);

        Assert.AreEqual(5902421710, model.Labels[0].ID);
        Assert.AreEqual("LA_kwDOKNJSy88AAAABX8_Ozg", model.Labels[0].NodeID);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/labels/documentation", model.Labels[0].URL);
        Assert.AreEqual("documentation", model.Labels[0].Name);
        Assert.AreEqual("0075ca", model.Labels[0].Color);
        Assert.AreEqual("Improvements or additions to documentation", model.Labels[0].Description);
        Assert.IsTrue(model.Labels[0].IsDefault);

        Assert.AreEqual(5902421725, model.Labels[1].ID);
        Assert.AreEqual("LA_kwDOKNJSy88AAAABX8_O3Q", model.Labels[1].NodeID);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/labels/enhancement", model.Labels[1].URL);
        Assert.AreEqual("enhancement", model.Labels[1].Name);
        Assert.AreEqual("a2eeef", model.Labels[1].Color);
        Assert.AreEqual("New feature or request", model.Labels[1].Description);
        Assert.IsTrue(model.Labels[1].IsDefault);

        // Validate Assignee
        Assert.IsNotNull(model.Assignee);
        ValidateDefaultAccount(model.Assignee);

        // Validate Assignees
        Assert.IsNotNull(model.Assignees);
        Assert.AreEqual(1, model.Assignees.Length);
        ValidateDefaultAccount(model.Assignees[0]);

        // Validate Reactions
        Assert.IsNotNull(model.Reactions);
        ValidateIssueReactions(model.Reactions);
    }

    /// <summary>
    /// Validates a <see cref="GitHubReactions"/>
    /// </summary>
    /// <param name="model">The <see cref="GitHubReactions"/> to be validated</param>
    private void ValidateIssueReactions(GitHubReactions model)
    {
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/3/reactions", model.URL);
        Assert.AreEqual(0, model.TotalCount);
        Assert.AreEqual(0, model.Plus1);
        Assert.AreEqual(0, model.Minus1);
        Assert.AreEqual(0, model.Laugh);
        Assert.AreEqual(0, model.Hooray);
        Assert.AreEqual(0, model.Confused);
        Assert.AreEqual(0, model.Heart);
        Assert.AreEqual(0, model.Rocket);
        Assert.AreEqual(0, model.Eyes);
    }

    #endregion Model Validation

}

#pragma warning restore CA1822 // Mark members as static