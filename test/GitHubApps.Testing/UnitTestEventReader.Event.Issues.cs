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
using System.Runtime.CompilerServices;
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// The Unit Testing Class - For the Issue Event Only
/// </summary>
public partial class UnitTestEventReader
{
    /// <summary>
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_ASSIGNED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesAssigned()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssuesAssigned>("Payload", "Issues", "Issues.Assigned.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_ASSIGNED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Assignee
        Assert.IsNotNull(obj.Payload.Assignee);
        ValidateDefaultAccount(obj.Payload.Assignee);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_CLOSED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesClosed()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssues>("Payload", "Issues", "Issues.Closed.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_CLOSED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_DELETED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesDeleted()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssues>("Payload", "Issues", "Issues.Deleted.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_DELETED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_DEMILESTONED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesDemilestoned()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssues>("Payload", "Issues", "Issues.Demilestoned.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_DEMILESTONED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_EDITED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesEdited()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssuesEdited>("Payload", "Issues", "Issues.Edited.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_EDITED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Changes
        Assert.IsNotNull(obj.Payload.Changes);
        Assert.IsNotNull(obj.Payload.Changes.Body);
        Assert.AreEqual("Body of the issue", obj.Payload.Changes.Body.From);
        Assert.IsNotNull(obj.Payload.Changes.Title);
        Assert.AreEqual("Test Issue Created", obj.Payload.Changes.Title.From);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_LABELED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesLabeled()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssuesLabeled>("Payload", "Issues", "Issues.Labeled.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_LABELED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Label
        Assert.IsNotNull(obj.Payload.Label);
        Assert.AreEqual(5902421725, obj.Payload.Label.ID);
        Assert.AreEqual("LA_kwDOKNJSy88AAAABX8_O3Q", obj.Payload.Label.NodeID);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/labels/enhancement", obj.Payload.Label.URL);
        Assert.AreEqual("enhancement", obj.Payload.Label.Name);
        Assert.AreEqual("a2eeef", obj.Payload.Label.Color);
        Assert.AreEqual("New feature or request", obj.Payload.Label.Description);
        Assert.IsTrue(obj.Payload.Label.IsDefault);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_LOCKED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesLocked()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssues>("Payload", "Issues", "Issues.Locked.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_LOCKED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_MILESTONED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesMilestoned()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssuesMilestoned>("Payload", "Issues", "Issues.Milestoned.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_MILESTONED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Milestone
        Assert.IsNotNull(obj.Payload.Milestone);
        ValidateMilestone(obj.Payload.Milestone);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_OPENED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesOpened()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssues>("Payload", "Issues", "Issues.Opened.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_OPENED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_PINNED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesPinned()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssues>("Payload", "Issues", "Issues.Pinned.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_PINNED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_REOPENED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesReopened()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssues>("Payload", "Issues", "Issues.Reopened.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_REOPENED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_TRANSFERRED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesTransferred()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssuesTransferred>("Payload", "Issues", "Issues.Transferred.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_TRANSFERRED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Changes
        Assert.IsNotNull(obj.Payload.Changes);
        Assert.IsNotNull(obj.Payload.Changes.NewIssue);
        ValidateIssue(obj.Payload.Changes.NewIssue);
        Assert.IsNotNull(obj.Payload.Changes.NewRepository);
        ValidateDefaultRepository(obj.Payload.Changes.NewRepository);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_UNASSIGNED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesUnassigned()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssuesAssigned>("Payload", "Issues", "Issues.Unassigned.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_UNASSIGNED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Assignee
        Assert.IsNotNull(obj.Payload.Assignee);
        ValidateDefaultAccount(obj.Payload.Assignee);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_UNLABELED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesUnlabeled()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssuesLabeled>("Payload", "Issues", "Issues.Unlabeled.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_UNLABELED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Label
        Assert.IsNotNull(obj.Payload.Label);
        Assert.AreEqual(5902421725, obj.Payload.Label.ID);
        Assert.AreEqual("LA_kwDOKNJSy88AAAABX8_O3Q", obj.Payload.Label.NodeID);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/labels/enhancement", obj.Payload.Label.URL);
        Assert.AreEqual("enhancement", obj.Payload.Label.Name);
        Assert.AreEqual("a2eeef", obj.Payload.Label.Color);
        Assert.AreEqual("New feature or request", obj.Payload.Label.Description);
        Assert.IsTrue(obj.Payload.Label.IsDefault);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_UNLOCKED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesUnlocked()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssues>("Payload", "Issues", "Issues.Unlocked.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_UNLOCKED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Repository
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
    /// Test the event <see cref="GitHubEventIssues"/> for action <see cref="GitHubEventActions.EVENT_ACTION_UNPINNED"/>
    /// </summary>
    [TestMethod]
    public void TestEventIssuesUnpinned()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventIssues>("Payload", "Issues", "Issues.Unpinned.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_ISSUES, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_UNPINNED, obj.Payload.Action);

        // Validate Issue
        Assert.IsNotNull(obj.Payload.Issue);
        ValidateIssue(obj.Payload.Issue);

        // Validate Repository
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
    /// Validates a <see cref="GitHubIssue"/>
    /// </summary>
    /// <param name="model">The <see cref="GitHubIssue"/> to be validated</param>
    private void ValidateIssue(GitHubIssue model, [CallerMemberName] string memberName = "")
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

        Assert.AreEqual(1, model.Comments);

        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.CreatedAt);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.UpdatedAt);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.ClosedAt);

        Assert.AreEqual(GitHubAuthorAssociations.OWNER, model.AuthorAssociation);

        Assert.AreEqual("Body of the issue", model.Body);

        // Validate Milestone
        switch (memberName)
        {
            case nameof(TestEventIssuesMilestoned):
                Assert.IsNotNull(model.Milestone);
                ValidateMilestone(model.Milestone);
                break;

            default:
                Assert.IsNull(model.Milestone);
                break;
        }

        // Validate Labels
        switch (memberName)
        {
            case nameof(TestEventIssuesClosed):
            case nameof(TestEventIssuesDeleted):
            case nameof(TestEventIssuesDemilestoned):
            case nameof(TestEventIssuesEdited):
            case nameof(TestEventIssuesOpened):
            case nameof(TestEventIssuesReopened):
            case nameof(TestEventIssuesTransferred):
            case nameof(TestEventIssuesUnlabeled):

                // Validate Labels
                Assert.IsNotNull(model.Labels);
                Assert.AreEqual(0, model.Labels.Length);

                break;

            default:

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

                break;
        }

        // Validate Assignee
        switch (memberName)
        {
            case nameof(TestEventIssuesClosed):
            case nameof(TestEventIssuesDeleted):
            case nameof(TestEventIssuesDemilestoned):
            case nameof(TestEventIssuesEdited):
            case nameof(TestEventIssuesMilestoned):
            case nameof(TestEventIssuesOpened):
            case nameof(TestEventIssuesReopened):
            case nameof(TestEventIssuesTransferred):
            case nameof(TestEventIssuesUnassigned):
            case nameof(TestEventIssuesUnlabeled):

                // Validate Assignee
                Assert.IsNull(model.Assignee);

                // Validate Assignees
                Assert.IsNotNull(model.Assignees);
                Assert.AreEqual(0, model.Assignees.Length);

                break;

            default:

                // Validate Assignee
                Assert.IsNotNull(model.Assignee);
                ValidateDefaultAccount(model.Assignee);

                // Validate Assignees
                Assert.IsNotNull(model.Assignees);
                Assert.AreEqual(1, model.Assignees.Length);
                ValidateDefaultAccount(model.Assignees[0]);

                break;
        }

        // Validate State
        switch (memberName)
        {
            case nameof(TestEventIssuesClosed):
                Assert.AreEqual(GitHubIssueStates.Closed, model.State);
                Assert.AreEqual("completed", model.StateReason);

                break;

            case nameof(TestEventIssuesDeleted):
                Assert.AreEqual(GitHubIssueStates.Open, model.State);
                Assert.AreEqual("reopened", model.StateReason);

                break;

            case nameof(TestEventIssuesDemilestoned):
                Assert.AreEqual(GitHubIssueStates.Open, model.State);
                Assert.IsNull(model.StateReason);

                Assert.IsNotNull(model.PullRequest);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/pulls/1", model.PullRequest.URL);
                Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/pull/1", model.PullRequest.HTMLURL);
                Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/pull/1.diff", model.PullRequest.DiffURL);
                Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/pull/1.patch", model.PullRequest.PatchURL);
                Assert.IsNull(model.PullRequest.MergedAt);

                break;

            case nameof(TestEventIssuesReopened):
            case nameof(TestEventIssuesTransferred):
                Assert.AreEqual(GitHubIssueStates.Open, model.State);
                Assert.AreEqual("reopened", model.StateReason);

                break;

            default:
                Assert.AreEqual(GitHubIssueStates.Open, model.State);
                Assert.IsNull(model.StateReason);

                break;
        }

        // Validate Active Lock Reason
        switch (memberName)
        {
            case nameof(TestEventIssuesLocked):
                Assert.AreEqual(GitHubIssueActiveLockReasons.TooHeated, model.ActiveLockReason);
                Assert.IsTrue(model.IsLocked);
                break;

            default:
                Assert.IsNull(model.ActiveLockReason);
                Assert.IsFalse(model.IsLocked);
                break;
        }

        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/3/timeline", model.TimelineURL);
        Assert.IsNull(model.PerformedViaGitHubApp);

        Assert.IsNotNull(model.User);
        ValidateDefaultAccount(model.User);

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