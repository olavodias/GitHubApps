// *****************************************************************************
// UnitTestEventReader.Event.Repository.cs
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

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CA1822 // Mark members as static

using System;
using System.Runtime.CompilerServices;
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// The Unit Testing Class - For the Repository Event Only
/// </summary>
public partial class UnitTestEventReader
{
    /// <summary>
    /// Test the event <see cref="GitHubEventRepository"/> for action <see cref="GitHubEventActions.EVENT_ACTION_ARCHIVED"/>
    /// </summary>
    [TestMethod]
    public void TestEventRepositoryArchived()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRepository>("Payload", "Repository", "Repository.Archived.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_REPOSITORY, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_ARCHIVED, obj.Payload.Action);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Organization
        Assert.IsNotNull(obj.Payload.Organization);
        ValidateOrganization(obj.Payload.Organization);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRepository"/> for action <see cref="GitHubEventActions.EVENT_ACTION_CREATED"/>
    /// </summary>
    [TestMethod]
    public void TestEventRepositoryCreated()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRepository>("Payload", "Repository", "Repository.Created.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_REPOSITORY, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_CREATED, obj.Payload.Action);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Organization
        Assert.IsNotNull(obj.Payload.Organization);
        ValidateOrganization(obj.Payload.Organization);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRepository"/> for action <see cref="GitHubEventActions.EVENT_ACTION_DELETED"/>
    /// </summary>
    [TestMethod]
    public void TestEventRepositoryDeleted()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRepository>("Payload", "Repository", "Repository.Deleted.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_REPOSITORY, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_DELETED, obj.Payload.Action);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Organization
        Assert.IsNotNull(obj.Payload.Organization);
        ValidateOrganization(obj.Payload.Organization);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRepository"/> for action <see cref="GitHubEventActions.EVENT_ACTION_EDITED"/>
    /// </summary>
    [TestMethod]
    public void TestEventRepositoryEdited()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRepositoryEdited>("Payload", "Repository", "Repository.Edited.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_REPOSITORY, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_EDITED, obj.Payload.Action);

        // Validate Changes
        Assert.IsNotNull(obj.Payload.Changes);
        Assert.IsNotNull(obj.Payload.Changes.Homepage);
        Assert.IsNull(obj.Payload.Changes.Homepage.From);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Organization
        Assert.IsNotNull(obj.Payload.Organization);
        ValidateOrganization(obj.Payload.Organization);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRepository"/> for action <see cref="GitHubEventActions.EVENT_ACTION_PRIVATIZED"/>
    /// </summary>
    [TestMethod]
    public void TestEventRepositoryPrivatized()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRepository>("Payload", "Repository", "Repository.Privatized.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_REPOSITORY, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_PRIVATIZED, obj.Payload.Action);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Organization
        Assert.IsNotNull(obj.Payload.Organization);
        ValidateOrganization(obj.Payload.Organization);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRepository"/> for action <see cref="GitHubEventActions.EVENT_ACTION_PUBLICIZED"/>
    /// </summary>
    [TestMethod]
    public void TestEventRepositoryPublicized()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRepository>("Payload", "Repository", "Repository.Publicized.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_REPOSITORY, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_PUBLICIZED, obj.Payload.Action);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Organization
        Assert.IsNotNull(obj.Payload.Organization);
        ValidateOrganization(obj.Payload.Organization);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRepository"/> for action <see cref="GitHubEventActions.EVENT_ACTION_RENAMED"/>
    /// </summary>
    [TestMethod]
    public void TestEventRepositoryRenamed()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRepositoryEdited>("Payload", "Repository", "Repository.Renamed.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_REPOSITORY, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_RENAMED, obj.Payload.Action);

        // Validate Changes
        Assert.IsNotNull(obj.Payload.Changes);
        Assert.IsNotNull(obj.Payload.Changes.Repository);
        Assert.IsNotNull(obj.Payload.Changes.Repository.Name);
        Assert.AreEqual("TestRepo02", obj.Payload.Changes.Repository.Name.From);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Organization
        Assert.IsNotNull(obj.Payload.Organization);
        ValidateOrganization(obj.Payload.Organization);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRepository"/> for action <see cref="GitHubEventActions.EVENT_ACTION_RENAMED"/>
    /// </summary>
    [TestMethod]
    public void TestEventRepositoryTransferred()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRepositoryEdited>("Payload", "Repository", "Repository.Transferred.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_REPOSITORY, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_TRANSFERRED, obj.Payload.Action);

        // Validate Changes
        Assert.IsNotNull(obj.Payload.Changes);
        Assert.IsNotNull(obj.Payload.Changes.Owner);
        Assert.IsNotNull(obj.Payload.Changes.Owner.From);
        Assert.IsNotNull(obj.Payload.Changes.Owner.From.Organization);
        Assert.IsNull(obj.Payload.Changes.Owner.From.User);
        ValidateOrganization(obj.Payload.Changes.Owner.From.Organization);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Organization
        Assert.IsNotNull(obj.Payload.Organization);
        ValidateOrganization(obj.Payload.Organization);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRepository"/> for action <see cref="GitHubEventActions.EVENT_ACTION_UNARCHIVED"/>
    /// </summary>
    [TestMethod]
    public void TestEventRepositoryUnarchived()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRepository>("Payload", "Repository", "Repository.Unarchived.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_REPOSITORY, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_UNARCHIVED, obj.Payload.Action);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Organization
        Assert.IsNotNull(obj.Payload.Organization);
        ValidateOrganization(obj.Payload.Organization);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    #region Model Validation

    /// <summary>
    /// Validates a <see cref="GitHubRepository"/> with simplified properties
    /// </summary>
    /// <param name="model">A <see cref="GitHubRepository"/> to be validated</param>
    private void ValidateSimplifiedRepository(GitHubRepository model)
    {
        Assert.AreEqual(684890442, model.ID);
        Assert.AreEqual("R_kgDOKNKZSg", model.NodeID);
        Assert.AreEqual("TestGitHubApp", model.Name);
        Assert.AreEqual("githuborg/TestGitHubApp", model.FullName);
        Assert.IsTrue(model.IsPrivate);
    }

    /// <summary>
    /// Validates a <see cref="GitHubRepository"/>
    /// </summary>
    /// <param name="model">The <see cref="GitHubRepository"/> to be validated</param>
    /// <param name="memberName">The name of the method calling the function</param>
    private void ValidateDefaultRepository(GitHubRepository model, [CallerMemberName] string memberName = "")
    {
        switch (memberName)
        {
            case nameof(TestEventRepositoryArchived):
            case nameof(TestEventRepositoryCreated):
            case nameof(TestEventRepositoryEdited):
            case nameof(TestEventRepositoryDeleted):
            case nameof(TestEventRepositoryPrivatized):
            case nameof(TestEventRepositoryPublicized):
            case nameof(TestEventRepositoryRenamed):
            case nameof(TestEventRepositoryTransferred):
            case nameof(TestEventRepositoryUnarchived):
                Assert.AreEqual(692294519, model.ID);
                Assert.AreEqual("R_kgDOKUOTdw", model.NodeID);
                Assert.AreEqual("TestRepo02", model.Name);
                Assert.AreEqual("githuborg/TestRepo02", model.FullName);

                Assert.AreEqual("https://github.com/githuborg/TestRepo02", model.HTMLURL);
                Assert.AreEqual("Test Repo 02", model.Description);
                Assert.IsFalse(model.IsFork);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02", model.URL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/forks", model.ForksURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/keys{/key_id}", model.KeysURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/collaborators{/collaborator}", model.CollaboratorsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/teams", model.TeamsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/hooks", model.HooksURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/issues/events{/number}", model.IssueEventsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/events", model.EventsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/assignees{/user}", model.AssigneesURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/branches{/branch}", model.BranchesURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/tags", model.TagsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/git/blobs{/sha}", model.BlobsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/git/tags{/sha}", model.GitTagsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/git/refs{/sha}", model.GitRefsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/git/trees{/sha}", model.TreesURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/statuses/{sha}", model.StatusesURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/languages", model.LanguagesURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/stargazers", model.StargazersURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/contributors", model.ContributorsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/subscribers", model.SubscribersURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/subscription", model.SubscriptionURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/commits{/sha}", model.CommitsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/git/commits{/sha}", model.GitCommitsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/comments{/number}", model.CommentsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/issues/comments{/number}", model.IssueCommentURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/contents/{+path}", model.ContentsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/compare/{base}...{head}", model.CompareURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/merges", model.MergesURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/{archive_format}{/ref}", model.ArchiveURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/downloads", model.DownloadsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/issues{/number}", model.IssuesURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/pulls{/number}", model.PullsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/milestones{/number}", model.MilestonesURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/notifications{?since,all,participating}", model.NotificationsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/labels{/name}", model.LabelsURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/releases{/id}", model.ReleasesURL);
                Assert.AreEqual("https://api.github.com/repos/githuborg/TestRepo02/deployments", model.DeploymentsURL);

                Assert.AreEqual("git://github.com/githuborg/TestRepo02.git", model.GitURL);
                Assert.AreEqual("git@github.com:githuborg/TestRepo02.git", model.SSH_URL);
                Assert.AreEqual("https://github.com/githuborg/TestRepo02.git", model.CloneURL);
                Assert.AreEqual("https://github.com/githuborg/TestRepo02", model.SVN_URL);

                Assert.IsTrue(model.HasWiki);
                Assert.IsFalse(model.AllowForking);

                break;

            default:
                Assert.AreEqual(684872395, model.ID);
                Assert.AreEqual("R_kgDOKNJSyw", model.NodeID);
                Assert.AreEqual("TestGitHubApps", model.Name);
                Assert.AreEqual("githubuser/TestGitHubApps", model.FullName);

                Assert.AreEqual("https://github.com/githubuser/TestGitHubApps", model.HTMLURL);
                Assert.AreEqual("Test GitHub Apps", model.Description);
                Assert.IsFalse(model.IsFork);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps", model.URL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/forks", model.ForksURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/keys{/key_id}", model.KeysURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/collaborators{/collaborator}", model.CollaboratorsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/teams", model.TeamsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/hooks", model.HooksURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/events{/number}", model.IssueEventsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/events", model.EventsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/assignees{/user}", model.AssigneesURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/branches{/branch}", model.BranchesURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/tags", model.TagsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/git/blobs{/sha}", model.BlobsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/git/tags{/sha}", model.GitTagsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/git/refs{/sha}", model.GitRefsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/git/trees{/sha}", model.TreesURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/statuses/{sha}", model.StatusesURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/languages", model.LanguagesURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/stargazers", model.StargazersURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/contributors", model.ContributorsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/subscribers", model.SubscribersURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/subscription", model.SubscriptionURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/commits{/sha}", model.CommitsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/git/commits{/sha}", model.GitCommitsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/comments{/number}", model.CommentsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues/comments{/number}", model.IssueCommentURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/contents/{+path}", model.ContentsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/compare/{base}...{head}", model.CompareURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/merges", model.MergesURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/{archive_format}{/ref}", model.ArchiveURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/downloads", model.DownloadsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/issues{/number}", model.IssuesURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/pulls{/number}", model.PullsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/milestones{/number}", model.MilestonesURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/notifications{?since,all,participating}", model.NotificationsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/labels{/name}", model.LabelsURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/releases{/id}", model.ReleasesURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/deployments", model.DeploymentsURL);

                Assert.AreEqual("git://github.com/githubuser/TestGitHubApps.git", model.GitURL);
                Assert.AreEqual("git@github.com:githubuser/TestGitHubApps.git", model.SSH_URL);
                Assert.AreEqual("https://github.com/githubuser/TestGitHubApps.git", model.CloneURL);
                Assert.AreEqual("https://github.com/githubuser/TestGitHubApps", model.SVN_URL);

                Assert.IsFalse(model.HasWiki);
                Assert.IsTrue(model.AllowForking);

                break;
        }

        Assert.AreEqual(DefaultDateTime, model.CreatedAt);
        Assert.AreEqual(DefaultDateTime, model.UpdatedAt);
        Assert.AreEqual(DefaultDateTime, model.PushedAt);
        Assert.AreEqual(0, model.Size);
        Assert.AreEqual(0, model.StargazersCount);
        Assert.AreEqual(0, model.WatchersCount);
        Assert.IsNull(model.Language);
        Assert.IsTrue(model.HasIssues);
        Assert.IsTrue(model.HasProjects);
        Assert.IsTrue(model.HasDownloads);
        Assert.IsFalse(model.HasPages);
        Assert.IsFalse(model.HasDiscussions);
        Assert.AreEqual(0, model.ForksCount);
        Assert.IsNull(model.MirrorURL);
        Assert.AreEqual(0, model.OpenIssuesCount);
        Assert.IsNull(model.License);
        Assert.IsFalse(model.IsTemplate);
        Assert.IsFalse(model.IsWebCommitSignoffRequired);
        Assert.AreEqual(0, model.Forks);
        Assert.AreEqual(0, model.OpenIssues);
        Assert.AreEqual(0, model.Watchers);
        Assert.AreEqual("main", model.DefaultBranch);

        // Validate Visibility
        switch (memberName)
        {
            case nameof(TestEventRepositoryPublicized):
                Assert.AreEqual(GitHubRepositoryVisibility.Public, model.Visibility);
                Assert.IsFalse(model.IsPrivate);

                break;

            default:
                Assert.AreEqual(GitHubRepositoryVisibility.Private, model.Visibility);
                Assert.IsTrue(model.IsPrivate);

                break;
        }
        

        // Validate Is Disabled
        switch (memberName)
        {
            case nameof(TestEventRepositoryDeleted):
                Assert.IsTrue(model.IsDisabled);
                break;

            default:
                Assert.IsFalse(model.IsDisabled);
                break;
        }
        
        // Validate Homepage
        switch (memberName)
        {
            case nameof(TestEventRepositoryArchived):
            case nameof(TestEventRepositoryDeleted):
            case nameof(TestEventRepositoryEdited):
            case nameof(TestEventRepositoryPrivatized):
            case nameof(TestEventRepositoryPublicized):
            case nameof(TestEventRepositoryRenamed):
            case nameof(TestEventRepositoryUnarchived):
                Assert.AreEqual(string.Empty, model.Homepage);
                break;

            default:
                Assert.IsNull(model.Homepage);
                break;

        }

        // Validate Topics Array
        switch (memberName)
        {
            case nameof(TestEventRepositoryArchived):
            case nameof(TestEventRepositoryDeleted):
            case nameof(TestEventRepositoryEdited):
            case nameof(TestEventRepositoryPrivatized):
            case nameof(TestEventRepositoryPublicized):
            case nameof(TestEventRepositoryRenamed):
            case nameof(TestEventRepositoryUnarchived):
                Assert.IsNotNull(model.Topics);
                Assert.AreEqual(2, model.Topics.Length);
                Assert.AreEqual("test", model.Topics[0]);
                Assert.AreEqual("topic", model.Topics[1]);
                break;

            default:
                Assert.IsNotNull(model.Topics);
                Assert.AreEqual(0, model.Topics.Length);
                break;
        }

        // Validate IsArchived Property
        switch (memberName)
        {
            case nameof(TestEventRepositoryArchived):
                Assert.IsTrue(model.IsArchived);
                break;

            default:
                Assert.IsFalse(model.IsArchived);
                break;
        }

        // Validation specific to the Pull Request Event
        switch (memberName)
        {
            case nameof(ValidatePullRequestBaseDev):
            case nameof(ValidatePullRequestBaseMain):
                Assert.IsTrue(model.AllowSquashMerge);
                Assert.IsTrue(model.AllowMergeCommit);
                Assert.IsTrue(model.AllowRebaseMerge);
                Assert.IsFalse(model.AllowAutoMerge);
                Assert.IsFalse(model.DeleteBranchOnMerge);
                Assert.IsFalse(model.AllowUpdateBranch);
                Assert.IsFalse(model.UseSquashPrTitleAsDefault);
                Assert.AreEqual(GitHubRepositorySquashMergeCommitMessage.COMMIT_MESSAGES, model.SquashMergeCommitMessage);
                Assert.AreEqual(GitHubRepositorySquashMergeCommitTitles.COMMIT_OR_PR_TITLE, model.SquashMergeCommitTitle);
                Assert.AreEqual(GitHubRepositoryMergeCommitMessages.PR_TITLE, model.MergeCommitMessage);
                Assert.AreEqual(GitHubRepositoryMergeCommitTitles.MERGE_MESSAGE, model.MergeCommitTitle);
                break;
        }

    }

    /// <summary>
    /// Validates a <see cref="GitHubRepository"/> for a Forkee in <see cref="GitHubEventFork"/>
    /// </summary>
    /// <param name="model">The model to be validated</param>
    private void ValidateForkeeRepository(GitHubRepository model)
    {
        Assert.AreEqual(686406589, model.ID);
        Assert.AreEqual("R_kgDOKOm7vQ", model.NodeID);
        Assert.AreEqual("TestGitHubAppsForked", model.Name);
        Assert.AreEqual("githubuser2/TestGitHubAppsForked", model.FullName);
        Assert.IsTrue(model.IsPrivate);
        Assert.AreEqual("https://github.com/githubuser2/TestGitHubAppsForked", model.HTMLURL);
        Assert.AreEqual("Test GitHub Apps Forked", model.Description);
        Assert.IsTrue(model.IsFork);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked", model.URL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/forks", model.ForksURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/keys{/key_id}", model.KeysURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/collaborators{/collaborator}", model.CollaboratorsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/teams", model.TeamsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/hooks", model.HooksURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/issues/events{/number}", model.IssueEventsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/events", model.EventsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/assignees{/user}", model.AssigneesURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/branches{/branch}", model.BranchesURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/tags", model.TagsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/git/blobs{/sha}", model.BlobsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/git/tags{/sha}", model.GitTagsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/git/refs{/sha}", model.GitRefsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/git/trees{/sha}", model.TreesURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/statuses/{sha}", model.StatusesURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/languages", model.LanguagesURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/stargazers", model.StargazersURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/contributors", model.ContributorsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/subscribers", model.SubscribersURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/subscription", model.SubscriptionURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/commits{/sha}", model.CommitsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/git/commits{/sha}", model.GitCommitsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/comments{/number}", model.CommentsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/issues/comments{/number}", model.IssueCommentURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/contents/{+path}", model.ContentsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/compare/{base}...{head}", model.CompareURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/merges", model.MergesURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/{archive_format}{/ref}", model.ArchiveURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/downloads", model.DownloadsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/issues{/number}", model.IssuesURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/pulls{/number}", model.PullsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/milestones{/number}", model.MilestonesURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/notifications{?since,all,participating}", model.NotificationsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/labels{/name}", model.LabelsURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/releases{/id}", model.ReleasesURL);
        Assert.AreEqual("https://api.github.com/repos/githubuser2/TestGitHubAppsForked/deployments", model.DeploymentsURL);
        Assert.AreEqual(DefaultDateTime, model.CreatedAt);
        Assert.AreEqual(DefaultDateTime, model.UpdatedAt);
        Assert.AreEqual(DefaultDateTime, model.PushedAt);
        Assert.AreEqual("git://github.com/githubuser2/TestGitHubAppsForked.git", model.GitURL);
        Assert.AreEqual("git@github.com:githubuser2/TestGitHubAppsForked.git", model.SSH_URL);
        Assert.AreEqual("https://github.com/githubuser2/TestGitHubAppsForked.git", model.CloneURL);
        Assert.AreEqual("https://github.com/githubuser2/TestGitHubAppsForked", model.SVN_URL);
        Assert.IsNull(model.Homepage);
        Assert.AreEqual(2, model.Size);
        Assert.AreEqual(0, model.StargazersCount);
        Assert.AreEqual(0, model.WatchersCount);
        Assert.IsNull(model.Language);
        Assert.IsFalse(model.HasIssues);
        Assert.IsTrue(model.HasProjects);
        Assert.IsTrue(model.HasDownloads);
        Assert.IsFalse(model.HasWiki);
        Assert.IsFalse(model.HasPages);
        Assert.IsFalse(model.HasDiscussions);
        Assert.AreEqual(0, model.ForksCount);
        Assert.IsNull(model.MirrorURL);
        Assert.IsFalse(model.IsArchived);
        Assert.IsFalse(model.IsDisabled);
        Assert.AreEqual(0, model.OpenIssuesCount);
        Assert.IsNull(model.License);
        Assert.IsFalse(model.AllowForking);
        Assert.IsFalse(model.IsTemplate);
        Assert.IsFalse(model.IsWebCommitSignoffRequired);
        Assert.IsNotNull(model.Topics);
        Assert.AreEqual(0, model.Topics.Length);
        Assert.AreEqual(GitHubRepositoryVisibility.Private, model.Visibility);
        Assert.AreEqual(0, model.Forks);
        Assert.AreEqual(0, model.OpenIssues);
        Assert.AreEqual(0, model.Watchers);
        Assert.AreEqual("main", model.DefaultBranch);
    }


    #endregion Model Validation

}

#pragma warning restore CA1822 // Mark members as static
#pragma warning restore CS0618 // Type or member is obsolete
