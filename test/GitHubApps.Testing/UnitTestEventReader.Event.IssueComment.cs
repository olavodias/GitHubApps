// *****************************************************************************
// UnitTestEventReader.Event.IssueComment.cs
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
    /// <summary>
    /// Test the event <see cref="GitHubEventIssueComment"/> for action <see cref="GitHubEventActions.EVENT_ACTION_CREATED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssueCommentCreated()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssueComment>("Payload", "IssueComment", "IssueComment.Created.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUE_COMMENT, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_CREATED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Issue Comment
        Assert.IsNotNull(obj.Payload.Comment);
        ValidateIssueComment(obj.Payload.Comment);

        // Validate Repository Object
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventIssueComment"/> for action <see cref="GitHubEventActions.EVENT_ACTION_EDITED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssueCommentEdited()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssueCommentEdited>("Payload", "IssueComment", "IssueComment.Edited.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUE_COMMENT, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_EDITED, obj.Payload.Action);

        // Validate Changes
        Assert.IsNotNull(obj.Payload.Changes);
        Assert.IsNotNull(obj.Payload.Changes.Body);
        Assert.AreEqual("New comment here", obj.Payload.Changes.Body.From);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Issue Comment
        Assert.IsNotNull(obj.Payload.Comment);
        ValidateIssueComment(obj.Payload.Comment);

        // Validate Repository Object
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventIssueComment"/> for action <see cref="GitHubEventActions.EVENT_ACTION_DELETED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssueCommentDeleted()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssueComment>("Payload", "IssueComment", "IssueComment.Deleted.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUE_COMMENT, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_DELETED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Issue Comment
        Assert.IsNotNull(obj.Payload.Comment);
        ValidateIssueComment(obj.Payload.Comment);

        // Validate Repository Object
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    #region Model Validation

    /// <summary>
    /// Validates a <see cref="GitHubComment"/>
    /// </summary>
    /// <param name="model">The <see cref="GitHubComment"/> to be validated</param>
    private void ValidateIssueComment(GitHubComment model)
    {
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/comments/1705529943", model.URL);
        Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/issues/3#issuecomment-1705529943", model.HTMLURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/3", model.IssueURL);
        Assert.AreEqual(1705529943, model.ID);
        Assert.AreEqual("IC_kwDOKNJSy85lqFJX", model.NodeID);
        Assert.AreEqual(DefaultDateTime, model.CreatedAt);
        Assert.AreEqual(DefaultDateTime, model.UpdatedAt);
        Assert.AreEqual(GitHubAuthorAssociations.OWNER, model.AuthorAssociation);
        Assert.AreEqual("Issue Comment", model.Body);
        Assert.IsNull(model.PerformedViaGitHubApp);

        // Validate Issue Comment Reactions
        Assert.IsNotNull(model.Reactions);
        ValidateIssueCommentReactions(model.Reactions);
    }

    /// <summary>
    /// Validates a <see cref="GitHubReactions"/>
    /// </summary>
    /// <param name="model">The <see cref="GitHubReactions"/> to be validated</param>
    private void ValidateIssueCommentReactions(GitHubReactions model)
    {
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/comments/1705529943/reactions", model.URL);
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