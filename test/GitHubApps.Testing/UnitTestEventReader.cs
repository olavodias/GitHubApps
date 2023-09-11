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

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CA1822 // Mark members as static

using System.Runtime.CompilerServices;
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// This Unit Testing Class will test the reading of events
/// </summary>
[TestClass]
public partial class UnitTestEventReader
{
    /// <summary>
    /// Test the <see cref="GitHubEventCreate"/> class
    /// </summary>
    [TestMethod]
    public void TestEventCreate()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventCreate>("Payload", "Create", "Create.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_CREATE, obj.Event);
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
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), obj.Payload.Repository.CreatedAt);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), obj.Payload.Repository.UpdatedAt);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), obj.Payload.Repository.PushedAt);

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
        var obj = TestHelper.GetGitHubObject<GitHubEventFork>("Payload", "Fork", "Fork.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_FORK, obj.Event);
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
        var obj = TestHelper.GetGitHubObject<GitHubEventDelete>("Payload", "Delete", "Delete.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_DELETE, obj.Event);
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

    /// <summary>
    /// Test the <see cref="GitHubEventPush"/> class
    /// </summary>
    [TestMethod]
    public void TestEventPush()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventPush>("Payload", "Push", "Push.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_PUSH, obj.Event);
        Assert.IsNotNull(obj.Payload);

        Assert.AreEqual("refs/heads/dev", obj.Payload.Ref);
        Assert.AreEqual("0000000000000000000000000000000000000000", obj.Payload.Before);
        Assert.AreEqual("41203e3015ea1e86240d781a0efd3c9aa671dfdf", obj.Payload.After);
        Assert.IsTrue(obj.Payload.IsCreated);
        Assert.IsFalse(obj.Payload.IsDeleted);
        Assert.IsFalse(obj.Payload.IsForced);
        Assert.AreEqual("refs/heads/main", obj.Payload.BaseRef);
        Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/compare/dev", obj.Payload.Compare);

        Assert.IsNotNull(obj.Payload.Commits);
        Assert.AreEqual(0, obj.Payload.Commits.Length);

        // Validate Repository Object
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Pusher
        Assert.IsNotNull(obj.Payload.Pusher);
        ValidateDefaultAccountMetadataOnly(obj.Payload.Pusher);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);

        //TODO: Validate Head Commit
        Assert.Fail();
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
    /// Validates a <see cref="GitHubAccountMetaProperties"/> object
    /// </summary>
    /// <param name="model">The <see cref="GitHubAccountMetaProperties"/> to be validated</param>
    private void ValidateDefaultAccountMetadataOnly(GitHubAccountMetaProperties model)
    {
        Assert.AreEqual("githubuser", model.Name);
        Assert.AreEqual("32257178+githubuser@users.noreply.github.com", model.Email);
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
    /// Validates a <see cref="GitHubAccount"/>
    /// </summary>
    /// <param name="model">A <see cref="GitHubAccount"/> to be validated</param>
    private void ValidateDefaultOrganizationAccount(GitHubAccount model)
    {
        Assert.AreEqual("githuborg", model.Login);
        Assert.AreEqual(24394891, model.ID);
        Assert.AreEqual("MDEyOk9yZ2FuaXphdGlvbjI0Mzk0ODkx", model.NodeID);
        Assert.AreEqual("https://avatars.githubusercontent.com/u/24394891?v=4", model.AvatarURL);
        Assert.AreEqual("", model.GravatarID);
        Assert.AreEqual("https://api.github.com/users/githuborg", model.URL);
        Assert.AreEqual("https://github.com/githuborg", model.HTMLURL);
        Assert.AreEqual("https://api.github.com/users/githuborg/followers", model.FollowersURL);
        Assert.AreEqual("https://api.github.com/users/githuborg/following{/other_user}", model.FollowingURL);
        Assert.AreEqual("https://api.github.com/users/githuborg/gists{/gist_id}", model.GistsURL);
        Assert.AreEqual("https://api.github.com/users/githuborg/starred{/owner}{/repo}", model.StarredURL);
        Assert.AreEqual("https://api.github.com/users/githuborg/subscriptions", model.SubscriptionsURL);
        Assert.AreEqual("https://api.github.com/users/githuborg/orgs", model.OrganizationsURL);
        Assert.AreEqual("https://api.github.com/users/githuborg/repos", model.ReposURL);
        Assert.AreEqual("https://api.github.com/users/githuborg/events{/privacy}", model.EventsURL);
        Assert.AreEqual("https://api.github.com/users/githuborg/received_events", model.ReceivedEventsURL);
        Assert.AreEqual(GitHubAccountTypes.Organization, model.Type);
        Assert.IsFalse(model.IsSiteAdmin);
    }

    /// <summary>
    /// Validates a <see cref="GitHubInstallation"/> with full parameters
    /// </summary>
    /// <param name="model"></param>
    private void ValidateDefaultInstallation(GitHubInstallation model)
    {
        // Array with events that should be in the payload
        var eventList = new string[] { "branch_protection_configuration", "branch_protection_rule", "check_run", "check_suite",
                                       "code_scanning_alert", "commit_comment", "create", "delete", "dependabot_alert", "deployment",
                                       "deployment_protection_rule", "deployment_review", "deployment_status", "deploy_key",
                                       "discussion", "discussion_comment", "fork", "gollum", "issues", "issue_comment",
                                       "label", "member", "membership", "merge_group", "merge_queue_entry", "milestone",
                                       "organization", "org_block", "page_build", "personal_access_token_request",
                                       "project", "projects_v2", "projects_v2_item", "project_card", "project_column",
                                       "public", "pull_request", "pull_request_review", "pull_request_review_comment",
                                       "pull_request_review_thread", "push", "registry_package", "release", "repository",
                                       "repository_advisory", "repository_dispatch", "repository_ruleset", "secret_scanning_alert",
                                       "secret_scanning_alert_location", "security_and_analysis", "star", "status", "team",
                                       "team_add", "watch", "workflow_dispatch", "workflow_job", "workflow_run" };

        Assert.AreEqual(41251547, model.ID);

        Assert.IsNotNull(model.Account);
        ValidateDefaultOrganizationAccount(model.Account);

        Assert.AreEqual("https://api.github.com/app/installations/41251547/access_tokens", model.AccessTokensURL);
        Assert.AreEqual("https://api.github.com/installation/repositories", model.RepositoriesURL);
        Assert.AreEqual("https://github.com/organizations/githuborg/settings/installations/41251547", model.HTMLURL);
        Assert.AreEqual(383002, model.AppID);
        Assert.AreEqual("githubuser-githubtest", model.AppSlug);
        Assert.AreEqual(24394891, model.TargetID);
        Assert.AreEqual("Organization", model.TargetType);

        // Validate Permissions
        Assert.IsNotNull(model.Permissions);
        ValidateDefaultPermissions(model.Permissions);

        // Validate Events Array
        Assert.IsNotNull(model.Events);
        Assert.AreEqual(58, model.Events.Length);

        for (int i = 0; i < 58; i++)
            Assert.AreEqual(eventList[i], model.Events[i]);

        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.CreatedAt);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.UpdatedAt);

        Assert.IsNull(model.SingleFileName);
        Assert.IsFalse(model.HasMultipleSingleFiles);
        Assert.IsNotNull(model.SingleFilePaths);
        Assert.AreEqual(0, model.SingleFilePaths.Length);
    }

    /// <summary>
    /// Validate the <see cref="GitHubPermissions"/> for a <see cref="GitHubEventInstallation"/> event
    /// </summary>
    /// <param name="model">The <see cref="GitHubPermissions"/></param>
    private void ValidateDefaultPermissions(GitHubPermissions model)
    {
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Pages);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Checks);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Issues);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Actions);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Members);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Secrets);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Contents);
        Assert.AreEqual(GitHubPermissionOptions.Read, model.Metadata);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Packages);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Statuses);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Workflows);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Codespaces);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Deployments);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Discussions);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Environments);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.MergeQueues);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.PullRequests);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.Administration);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.SecurityEvents);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.RepositoryHooks);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.TeamDiscussions);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.ActionsVariables);
        Assert.AreEqual(GitHubPermissionOptions.Read, model.OrganizationPlan);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.CodespacesSecrets);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.DependabotSecrets);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationHooks);
        Assert.AreEqual(GitHubPermissionOptions.Read, model.CodespacesMetadata);
        Assert.AreEqual(GitHubPermissionOptions.Read, model.OrganizationEvents);
        Assert.AreEqual(GitHubPermissionOptions.Admin, model.RepositoryProjects);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationSecrets);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.VulnerabilityAlerts);
        Assert.AreEqual(GitHubPermissionOptions.Admin, model.OrganizationProjects);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.RepositoryAdvisories);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.SecretScanningAlerts);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationCodespaces);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationCustomRoles);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.CodespacesLifecycleAdmin);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationUserBlocking);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationAdministration);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationActionsVariables);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationCodespacesSecrets);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationDependabotSecrets);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationCodespacesSettings);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationSelfHostedRunners);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationAnnouncementBanners);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationPersonalAccessTokens);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationCopilotSeatManagement);
        Assert.AreEqual(GitHubPermissionOptions.Write, model.OrganizationPersonalAccessTokenRequests);
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
    /// <param name="model">The <see cref="GitHubRepository"/> to be validated</param>
    /// <param name="memberName">The name of the method calling the function</param>
    private void ValidateDefaultRepository(GitHubRepository model, [CallerMemberName] string memberName = "")
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
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.CreatedAt);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.UpdatedAt);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.PushedAt);
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
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.CreatedAt);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.UpdatedAt);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), model.PushedAt);
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