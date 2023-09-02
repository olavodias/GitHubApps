#pragma warning disable CA1822 // Mark members as static

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
    /// Test the <see cref="GitHubEventCreate"/>
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
        Validate(obj.Payload.Repository);

        Assert.AreEqual(new DateTime(2023, 08, 30, 2, 56, 51), obj.Payload.Repository.CreatedAt);
        Assert.AreEqual(new DateTime(2023, 08, 30, 2, 56, 52), obj.Payload.Repository.UpdatedAt);
        Assert.AreEqual(new DateTime(2023, 08, 30, 3, 0, 40), obj.Payload.Repository.PushedAt);

        // Validate Repository Owner
        Assert.IsNotNull(obj.Payload.Repository.Owner);
        Validate(obj.Payload.Repository.Owner);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        Validate(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        Assert.AreEqual(41249901, obj.Payload.Installation.ID);
        Assert.AreEqual("MDIzOkludGVncmF0aW9uSW5zdGFsbGF0aW9uNDEyNDk5MDE=", obj.Payload.Installation.NodeID);
    }

    #region Model Validation

    /// <summary>
    /// Validates a <see cref="GitHubAccount"/>
    /// </summary>
    /// <param name="model">A <see cref="GitHubAccount"/> to be validated</param>

    private void Validate(GitHubAccount model)
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
    /// Validates a <see cref="GitHubRepository"/>
    /// </summary>
    /// <param name="model"></param>
    private void Validate(GitHubRepository model)
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

    #endregion Model Validation

}

#pragma warning restore CA1822 // Mark members as static
