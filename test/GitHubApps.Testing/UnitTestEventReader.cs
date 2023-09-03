// *****************************************************************************
// UnitTestEventReader.cs
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

using System.Reflection;
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// This Unit Testing Class will test the reading of events
/// </summary>
[TestClass]
public class UnitTestEventReader
{
    /// <summary>
    /// Test the <see cref="GitHubEventCreate"/> class
    /// </summary>
    [TestMethod]
    public void TestEventCreate()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventCreate>("Payload", "Create", "Create.01.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual("create", obj.Event);
        Assert.IsNotNull(obj.Payload);

        Assert.AreEqual("dev", obj.Payload.Ref);
        Assert.AreEqual(GitHubRefTypes.Branch, obj.Payload.RefType);
        Assert.AreEqual("main", obj.Payload.MasterBranch);
        Assert.AreEqual("Test GitHub Apps", obj.Payload.Description);
        Assert.AreEqual("user", obj.Payload.PusherType);

        // Validate Repository Object
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        Assert.AreEqual(0, obj.Payload.Repository.Size);
        Assert.AreEqual(0, obj.Payload.Repository.ForksCount);
        Assert.AreEqual(0, obj.Payload.Repository.Forks);
        Assert.AreEqual(new DateTime(2023, 08, 30, 2, 56, 51), obj.Payload.Repository.CreatedAt);
        Assert.AreEqual(new DateTime(2023, 08, 30, 2, 56, 52), obj.Payload.Repository.UpdatedAt);
        Assert.AreEqual(new DateTime(2023, 08, 30, 3, 0, 40), obj.Payload.Repository.PushedAt);

        // Validate Repository Owner
        Assert.IsNotNull(obj.Payload.Repository.Owner);
        ValidateDefaultAccount(obj.Payload.Repository.Owner);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        Assert.AreEqual(41249901, obj.Payload.Installation.ID);
        Assert.AreEqual("MDIzOkludGVncmF0aW9uSW5zdGFsbGF0aW9uNDEyNDk5MDE=", obj.Payload.Installation.NodeID);
    }

    /// <summary>
    /// Test the <see cref="GitHubEventFork"/> class
    /// </summary>
    [TestMethod]
    public void TestEventFork()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventFork>("Payload", "Fork", "Fork.01.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual("fork", obj.Event);
        Assert.IsNotNull(obj.Payload);

        // Validate Forkee Object
        Assert.IsNotNull(obj.Payload.Forkee);
        ValidateForkeeRepository(obj.Payload.Forkee);

        // Validate Repository Object
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Repository Owner
        Assert.IsNotNull(obj.Payload.Repository.Owner);
        ValidateDefaultAccount(obj.Payload.Repository.Owner);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateAlternativeAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the <see cref="GitHubEventDelete"/> class
    /// </summary>
    [TestMethod]
    public void TestEventDelete()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventDelete>("Payload", "Delete", "Delete.01.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual("delete", obj.Event);
        Assert.IsNotNull(obj.Payload);

        Assert.AreEqual("test", obj.Payload.Ref);
        Assert.AreEqual(GitHubRefTypes.Branch, obj.Payload.RefType);
        Assert.AreEqual("user", obj.Payload.PusherType);

        // Validate Repository Object
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Repository Owner
        Assert.IsNotNull(obj.Payload.Repository.Owner);
        ValidateDefaultAccount(obj.Payload.Repository.Owner);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);

    }

    #region Model Validation

    /// <summary>
    /// Validates a <see cref="GitHubAccount"/>
    /// </summary>
    /// <param name="model">A <see cref="GitHubAccount"/> to be validated</param>
    private void ValidateDefaultAccount(GitHubAccount model)
    {
        Assert.AreEqual("githubuser", model.Login);
        Assert.AreEqual(32257178, model.ID);
        Assert.AreEqual("MDQ6VXNlcjMyMjU3MTc4", model.NodeID);
        Assert.AreEqual("https://avatars.githubusercontent.com/u/32257178?v=4", model.AvatarURL);
        Assert.AreEqual("", model.GravatarID);
        Assert.AreEqual("https://api.github.com/users/githubuser", model.URL);
        Assert.AreEqual("https://github.com/githubuser", model.HTMLURL);
        Assert.AreEqual("https://api.github.com/users/githubuser/followers", model.FollowersURL);
        Assert.AreEqual("https://api.github.com/users/githubuser/following{/other_user}", model.FollowingURL);
        Assert.AreEqual("https://api.github.com/users/githubuser/gists{/gist_id}", model.GistsURL);
        Assert.AreEqual("https://api.github.com/users/githubuser/starred{/owner}{/repo}", model.StarredURL);
        Assert.AreEqual("https://api.github.com/users/githubuser/subscriptions", model.SubscriptionsURL);
        Assert.AreEqual("https://api.github.com/users/githubuser/orgs", model.OrganizationsURL);
        Assert.AreEqual("https://api.github.com/users/githubuser/repos", model.ReposURL);
        Assert.AreEqual("https://api.github.com/users/githubuser/events{/privacy}", model.EventsURL);
        Assert.AreEqual("https://api.github.com/users/githubuser/received_events", model.ReceivedEventsURL);
        Assert.AreEqual(GitHubAccountTypes.User, model.Type);
        Assert.IsFalse(model.IsSiteAdmin);
    }

    /// <summary>
    /// Validates a <see cref="GitHubAccount"/>
    /// </summary>
    /// <param name="model">A <see cref="GitHubAccount"/> to be validated</param>
    private void ValidateAlternativeAccount(GitHubAccount model)
    {
        Assert.AreEqual("githubuser2", model.Login);
        Assert.AreEqual(139399022, model.ID);
        Assert.AreEqual("O_kgDOCE8Pbg", model.NodeID);
        Assert.AreEqual("https://avatars.githubusercontent.com/u/139399022?v=4", model.AvatarURL);
        Assert.AreEqual("", model.GravatarID);
        Assert.AreEqual("https://api.github.com/users/githubuser2", model.URL);
        Assert.AreEqual("https://github.com/githubuser2", model.HTMLURL);
        Assert.AreEqual("https://api.github.com/users/githubuser2/followers", model.FollowersURL);
        Assert.AreEqual("https://api.github.com/users/githubuser2/following{/other_user}", model.FollowingURL);
        Assert.AreEqual("https://api.github.com/users/githubuser2/gists{/gist_id}", model.GistsURL);
        Assert.AreEqual("https://api.github.com/users/githubuser2/starred{/owner}{/repo}", model.StarredURL);
        Assert.AreEqual("https://api.github.com/users/githubuser2/subscriptions", model.SubscriptionsURL);
        Assert.AreEqual("https://api.github.com/users/githubuser2/orgs", model.OrganizationsURL);
        Assert.AreEqual("https://api.github.com/users/githubuser2/repos", model.ReposURL);
        Assert.AreEqual("https://api.github.com/users/githubuser2/events{/privacy}", model.EventsURL);
        Assert.AreEqual("https://api.github.com/users/githubuser2/received_events", model.ReceivedEventsURL);
        Assert.AreEqual(GitHubAccountTypes.Organization, model.Type);
        Assert.IsFalse(model.IsSiteAdmin);
    }

    /// <summary>
    /// Validates a <see cref="GitHubInstallation"/> that contains very minimal parameters
    /// </summary>
    /// <param name="model">A <see cref="GitHubInstallation"/> to be validated</param>
    private void ValidateSimplifiedInstallation(GitHubInstallation model)
    {
        Assert.AreEqual(41249901, model.ID);
        Assert.AreEqual("MDIzOkludGVncmF0aW9uSW5zdGFsbGF0aW9uNDEyNDk5MDE=", model.NodeID);
    }


    /// <summary>
    /// Validates a <see cref="GitHubRepository"/>
    /// </summary>
    /// <param name="model"></param>
    private void ValidateDefaultRepository(GitHubRepository model)
    {
        Assert.AreEqual(684872395, model.ID);
        Assert.AreEqual("R_kgDOKNJSyw", model.NodeID);
        Assert.AreEqual("TestGitHubApps", model.Name);
        Assert.AreEqual("githubuser/TestGitHubApps", model.FullName);
        Assert.IsTrue(model.IsPrivate);
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
        Assert.AreEqual(new DateTime(2023, 08, 30, 2, 56, 51), model.CreatedAt);
        Assert.AreEqual(new DateTime(2023, 08, 30, 2, 56, 52), model.UpdatedAt);
        Assert.AreEqual(new DateTime(2023, 08, 30, 3, 0, 40), model.PushedAt);
        Assert.AreEqual("git://github.com/githubuser/TestGitHubApps.git", model.GitURL);
        Assert.AreEqual("git@github.com:githubuser/TestGitHubApps.git", model.SSH_URL);
        Assert.AreEqual("https://github.com/githubuser/TestGitHubApps.git", model.CloneURL);
        Assert.AreEqual("https://github.com/githubuser/TestGitHubApps", model.SVN_URL);
        Assert.IsNull(model.Homepage);
        Assert.AreEqual(0, model.Size);
        Assert.AreEqual(0, model.StargazersCount);
        Assert.AreEqual(0, model.WatchersCount);
        Assert.IsNull(model.Language);
        Assert.IsTrue(model.HasIssues);
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
        Assert.IsTrue(model.AllowForking);
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
        Assert.AreEqual(new DateTime(2023, 09, 2, 17, 25, 31), model.CreatedAt);
        Assert.AreEqual(new DateTime(2023, 09, 2, 17, 25, 31), model.UpdatedAt);
        Assert.AreEqual(new DateTime(2023, 08, 30, 4, 32, 19), model.PushedAt);
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
