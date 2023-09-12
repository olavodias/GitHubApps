// *****************************************************************************
// UnitTestEventReader.Event.PullRequest.cs
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
/// The Unit Testing Class - For the Pull Request Event Only
/// </summary>
public partial class UnitTestEventReader
{

    /// <summary>
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_ASSIGNED"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestAssigned()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequestAssigned>("Payload", "PullRequest", "PullRequest.Assigned.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_ASSIGNED, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_CLOSED"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestClosed()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequest>("Payload", "PullRequest", "PullRequest.Closed.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_CLOSED, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_CONVERTED_TO_DRAFT"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestConvertedToDraft()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequest>("Payload", "PullRequest", "PullRequest.ConvertedToDraft.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_CONVERTED_TO_DRAFT, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_DEMILESTONED"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestDemilestoned()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequestMilestoned>("Payload", "PullRequest", "PullRequest.Demilestoned.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_DEMILESTONED, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_EDITED"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestEdited()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequestEdited>("Payload", "PullRequest", "PullRequest.Edited.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_EDITED, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

        // Validate Changes
        Assert.IsNotNull(obj.Payload.Changes);
        Assert.IsNotNull(obj.Payload.Changes.Title);
        Assert.AreEqual("Pull Request", obj.Payload.Changes.Title.From);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_LABELED"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestLabeled()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequestLabeled>("Payload", "PullRequest", "PullRequest.Labeled.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_LABELED, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_LOCKED"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestLocked()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequest>("Payload", "PullRequest", "PullRequest.Locked.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_LOCKED, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_MILESTONED"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestMilestoned()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequestMilestoned>("Payload", "PullRequest", "PullRequest.Milestoned.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_MILESTONED, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_OPENED"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestOpened()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequest>("Payload", "PullRequest", "PullRequest.Opened.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_OPENED, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_READY_FOR_REVIEW"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestReadyForReview()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequest>("Payload", "PullRequest", "PullRequest.ReadyForReview.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_READY_FOR_REVIEW, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_REOPENED"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestReopened()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequest>("Payload", "PullRequest", "PullRequest.Reopened.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_REOPENED, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_UNASSIGNED"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestUnassigned()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequestAssigned>("Payload", "PullRequest", "PullRequest.Unassigned.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_UNASSIGNED, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_UNLABELED"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestUnlabeled()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequestLabeled>("Payload", "PullRequest", "PullRequest.Unlabeled.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_UNLABELED, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Test the event <see cref="GitHubEventPullRequest"/> for action <see cref="GitHubEventActions.EVENT_ACTION_UNLOCKED"/>
    /// </summary>
    [TestMethod]
    public void TestEventPullRequestUnlocked()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPullRequest>("Payload", "PullRequest", "PullRequest.Unlocked.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PULL_REQUEST, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_UNLOCKED, obj.Payload.Action);
        Assert.AreEqual(5, obj.Payload.Number);

        // Validate Pull Request
        Assert.IsNotNull(obj.Payload.PullRequest);
        ValidatePullRequest(obj.Payload.PullRequest);

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
    /// Validates a <see cref="GitHubPullRequest"/>
    /// </summary>
    /// <param name="model">The <see cref="GitHubPullRequest"/> to be validated</param>
    /// <param name="memberName">The name of the method calling the function</param>
    private void ValidatePullRequest(GitHubPullRequest model, [CallerMemberName] string memberName = "")
    {
        // Validate Basic Properties
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/pulls/5", model.URL);
        Assert.AreEqual(1508937743, model.ID);
        Assert.AreEqual("PR_kwDOKNJSy85Z8JAP", model.NodeID);
        Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/pull/5", model.HTMLURL);
        Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/pull/5.patch", model.PatchURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/5", model.IssueURL);
        Assert.AreEqual(5, model.Number);
        Assert.AreEqual("Pull Request", model.Title);

        Assert.IsNull(model.Body);

        Assert.AreEqual(DefaultDateTime, model.CreatedAt);
        Assert.AreEqual(DefaultDateTime, model.UpdatedAt);

        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/pulls/5/commits", model.CommitsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/pulls/5/comments", model.ReviewCommentsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/pulls/comments{/number}", model.ReviewCommentURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/5/comments", model.CommentsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/statuses/634d59be5176e6c45ce0a73c3218e93afffa9b5e", model.StatusesURL);

        Assert.IsNotNull(model.RequestedReviewers);
        Assert.AreEqual(0, model.RequestedReviewers.Length);

        Assert.IsNotNull(model.RequestedTeams);
        Assert.AreEqual(0, model.RequestedTeams.Length);

        Assert.AreEqual(GitHubAuthorAssociations.OWNER, model.AuthorAssociation);
        Assert.IsNull(model.AutoMerge);
        Assert.IsFalse(model.IsMerged);
        Assert.IsTrue(model.IsMergeable);
        Assert.AreEqual("clean", model.MergeableState);
        Assert.IsNull(model.MergedBy);
        Assert.AreEqual(0, model.Comments);
        Assert.AreEqual(0, model.ReviewComments);
        Assert.IsFalse(model.MaintainerCanModify);
        Assert.AreEqual(2, model.Commits);
        Assert.AreEqual(3, model.Additions);
        Assert.AreEqual(0, model.Deletions);
        Assert.AreEqual(1, model.ChangedFiles);

        // Validate Active Lock Reason
        switch (memberName)
        {
            case nameof(TestEventPullRequestLocked):
                Assert.AreEqual(GitHubIssueActiveLockReasons.OffTopic, model.ActiveLockReason);
                break;

            default:
                Assert.IsNull(model.ActiveLockReason);
                break;
        }
        

        // Validate IsRebaseable
        switch (memberName)
        {
            case nameof(TestEventPullRequestOpened):
            case nameof(TestEventPullRequestClosed):
                Assert.IsFalse(model.IsRebaseable);
                break;

            default:
                Assert.IsTrue(model.IsRebaseable);
                break;
        }
        


        // Validate State
        switch (memberName)
        {
            case nameof(TestEventPullRequestClosed):
                Assert.AreEqual(GitHubPullRequestStates.Closed, model.State);
                break;

            default:
                Assert.AreEqual(GitHubPullRequestStates.Open, model.State);
                break;
        }

        // Validate IsLocked
        switch (memberName)
        {
            case nameof(TestEventPullRequestLocked):
                Assert.IsTrue(model.IsLocked);
                break;

            default:
                Assert.IsFalse(model.IsLocked);
                break;
        }

        // Validate User
        Assert.IsNotNull(model.User);
        ValidateDefaultAccount(model.User);

        // Validate Closed At
        switch (memberName)
        {
            case nameof(TestEventPullRequestClosed):
                Assert.AreEqual(DefaultDateTime, model.ClosedAt);
                break;

            default:
                Assert.IsNull(model.ClosedAt);
                break;
        }

        // Validate Merged
        Assert.IsNull(model.MergedAt);
        Assert.AreEqual("dae214b4bc0ed2e745a13e9ac5880c610cb308fd", model.MergeCommitSha);

        // Validate Assignee / Assignees
        switch (memberName)
        {
            case nameof(TestEventPullRequestAssigned):
                Assert.IsNotNull(model.Assignee);
                ValidateDefaultAccount(model.Assignee);

                Assert.IsNotNull(model.Assignees);
                Assert.IsNotNull(model.Assignees[0]);
                ValidateDefaultAccount(model.Assignees[0]);
                break;

            default:
                Assert.IsNull(model.Assignee);
                Assert.IsNotNull(model.Assignees);
                Assert.AreEqual(0, model.Assignees.Length);
                break;
        }

        // Validate Labels
        switch (memberName)
        {
            case nameof(TestEventPullRequestLabeled):
                Assert.IsNotNull(model.Labels);
                Assert.AreEqual(1, model.Labels.Length);

                break;

            default:
                Assert.IsNotNull(model.Labels);
                Assert.AreEqual(0, model.Labels.Length);

                break;
        }

        // Validate Milestone
        switch (memberName)
        {
            case nameof(TestEventPullRequestMilestoned):
                Assert.IsNotNull(model.Milestone);
                ValidateMilestone(model.Milestone);

                break;

            default:
                Assert.IsNull(model.Milestone);
                break;
        }        

        // Validate IsDraft
        switch (memberName)
        {
            case nameof(TestEventPullRequestConvertedToDraft):
                Assert.IsTrue(model.IsDraft);
                break;

            default:
                Assert.IsFalse(model.IsDraft);
                break;
        }

        // Validate Head
        Assert.IsNotNull(model.Head);
        ValidatePullRequestBaseDev(model.Head);

        // Validate Base
        Assert.IsNotNull(model.Base);
        ValidatePullRequestBaseMain(model.Base);

        // Validate _Links
        Assert.IsNotNull(model.Links);
        ValidatePullRequestLinks(model.Links);
    }

    /// <summary>
    /// Validates the Head of a Pull Request
    /// </summary>
    /// <param name="model">A <see cref="GitHubBase"/> object containing the model to be validated</param>
    private void ValidatePullRequestBaseDev(GitHubBase model)
    {
        Assert.AreEqual("githubuser:dev", model.Label);
        Assert.AreEqual("dev", model.Ref);
        Assert.AreEqual("634d59be5176e6c45ce0a73c3218e93afffa9b5e", model.Sha);

        Assert.IsNotNull(model.User);
        ValidateDefaultAccount(model.User);

        Assert.IsNotNull(model.Repo);
        ValidateDefaultRepository(model.Repo);
    }

    /// <summary>
    /// Validates the Base of a Pull Request
    /// </summary>
    /// <param name="model">A <see cref="GitHubBase"/> object containing the model to be validated</param>
    private void ValidatePullRequestBaseMain(GitHubBase model)
    {
        Assert.AreEqual("githubuser:main", model.Label);
        Assert.AreEqual("main", model.Ref);
        Assert.AreEqual("5599d8f680ab533f4165866ab2b5dbcaa036bb63", model.Sha);

        Assert.IsNotNull(model.User);
        ValidateDefaultAccount(model.User);

        Assert.IsNotNull(model.Repo);
        ValidateDefaultRepository(model.Repo);
    }

    /// <summary>
    /// Validate the <see cref="GitHubLinks"/> for a <see cref="GitHubPullRequest"/>
    /// </summary>
    /// <param name="model">The <see cref="GitHubLinks"/> to be validated</param>
    private void ValidatePullRequestLinks(GitHubLinks model)
    {
        Assert.IsNotNull(model.Self);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/pulls/5", model.Self.Href);

        Assert.IsNotNull(model.HTML);
        Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/pull/5", model.HTML.Href);

        Assert.IsNotNull(model.Issue);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/5", model.Issue.Href);

        Assert.IsNotNull(model.Comments);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/5/comments", model.Comments.Href);

        Assert.IsNotNull(model.ReviewComments);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/pulls/5/comments", model.ReviewComments.Href);

        Assert.IsNotNull(model.ReviewComment);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/pulls/comments{/number}", model.ReviewComment.Href);

        Assert.IsNotNull(model.Commits);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/pulls/5/commits", model.Commits.Href);

        Assert.IsNotNull(model.Statuses);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/statuses/634d59be5176e6c45ce0a73c3218e93afffa9b5e", model.Statuses.Href);
    }

    #endregion Model Validation


}

#pragma warning restore CA1822 // Mark members as static