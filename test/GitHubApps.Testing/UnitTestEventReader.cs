﻿// *****************************************************************************
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

using System.Runtime.CompilerServices;
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// This Unit Testing Class will test the reading of events
/// </summary>
[TestClass]
public sealed partial class UnitTestEventReader
{
    /// <summary>
    /// The default DateTime variable to be used when validating dates
    /// </summary>
    private readonly DateTime DefaultDateTime = new(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);

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
        Assert.AreEqual(DefaultDateTime, obj.Payload.Repository.CreatedAt);
        Assert.AreEqual(DefaultDateTime, obj.Payload.Repository.UpdatedAt);
        Assert.AreEqual(DefaultDateTime, obj.Payload.Repository.PushedAt);

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
    private void ValidateOrganizationAccount(GitHubAccount model)
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
        ValidateOrganizationAccount(model.Account);

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

        Assert.AreEqual(DefaultDateTime, model.CreatedAt);
        Assert.AreEqual(DefaultDateTime, model.UpdatedAt);

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

    #endregion Model Validation

}

#pragma warning restore CA1822 // Mark members as static
