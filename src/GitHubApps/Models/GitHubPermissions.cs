// *****************************************************************************
// GitHubPermissions.cs
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
namespace GitHubApps.Models;

/// <summary>
/// Represents the GitHub Permissions
/// </summary>
public sealed class GitHubPermissions
{

    #region Properties

	/// <summary>
	/// Permission to Actions
	/// </summary>
    public GitHubPermissionOptions? Actions { get; set; }
	/// <summary>
	/// Permission to Administration
	/// </summary>
	public GitHubPermissionOptions? Administration { get; set; }
	/// <summary>
	/// Permission to Checks
	/// </summary>
	public GitHubPermissionOptions? Checks { get; set; }
	/// <summary>
	/// Permission to Content References
	/// </summary>
	public GitHubPermissionOptions? ContentReferences { get; set; }
	/// <summary>
	/// Permission to Contents
	/// </summary>
	public GitHubPermissionOptions? Contents { get; set; }
	/// <summary>
	/// Permission to Deployments
	/// </summary>
	public GitHubPermissionOptions? Deployments { get; set; }
	/// <summary>
	/// Permission to Discussions
	/// </summary>
	public GitHubPermissionOptions? Discussions { get; set; }
	/// <summary>
	/// Permission to Emails
	/// </summary>
	public GitHubPermissionOptions? Emails { get; set; }
	/// <summary>
	/// Permission to Environments
	/// </summary>
	public GitHubPermissionOptions? Environments { get; set; }
	/// <summary>
	/// Permission to Issues
	/// </summary>
	public GitHubPermissionOptions? Issues { get; set; }
	/// <summary>
	/// Permission to Keys
	/// </summary>
	public GitHubPermissionOptions? Keys { get; set; }
	/// <summary>
	/// Permission to Members
	/// </summary>
	public GitHubPermissionOptions? Members { get; set; }
	/// <summary>
	/// Permission to Metadata
	/// </summary>
	public GitHubPermissionOptions? Metadata { get; set; }
	/// <summary>
	/// Permission to Organization Administration
	/// </summary>
	public GitHubPermissionOptions? OrganizationAdministration { get; set; }
	/// <summary>
	/// Permission to Organization Hooks
	/// </summary>
	public GitHubPermissionOptions? OrganizationHooks { get; set; }
	/// <summary>
	/// Permission to Organization Packages
	/// </summary>
	public GitHubPermissionOptions? OrganizationPackages { get; set; }
	/// <summary>
	/// Permission to Organization Plan
	/// </summary>
	public GitHubPermissionOptions? OrganizationPlan { get; set; }
	/// <summary>
	/// Permission to Organization Projects
	/// </summary>
	public GitHubPermissionOptions? OrganizationProjects { get; set; }
	/// <summary>
	/// Permission to Organization Secrets
	/// </summary>
	public GitHubPermissionOptions? OrganizationSecrets { get; set; }
	/// <summary>
	/// Permission to Organization Self Hosted Runners
	/// </summary>
	public GitHubPermissionOptions? OrganizationSelfHostedRunners { get; set; }
	/// <summary>
	/// Permission to Organization User Blocking
	/// </summary>
	public GitHubPermissionOptions? OrganizationUserBlocking { get; set; }
	/// <summary>
	/// Permission to Packages
	/// </summary>
	public GitHubPermissionOptions? Packages { get; set; }
	/// <summary>
	/// Permission to Pages
	/// </summary>
	public GitHubPermissionOptions? Pages { get; set; }
	/// <summary>
	/// Permission to Pull Requests
	/// </summary>
	public GitHubPermissionOptions? PullRequests { get; set; }
	/// <summary>
	/// Permission to Repository Hooks
	/// </summary>
	public GitHubPermissionOptions? RepositoryHooks { get; set; }
	/// <summary>
	/// Permission to Repository Projects
	/// </summary>
	public GitHubPermissionOptions? RepositoryProjects { get; set; }
	/// <summary>
	/// Permission to Secret Scanning Alerts
	/// </summary>
	public GitHubPermissionOptions? SecretScanningAlerts { get; set; }
	/// <summary>
	/// Permission to Secrets
	/// </summary>
	public GitHubPermissionOptions? Secrets { get; set; }
	/// <summary>
	/// Permission to Security Events
	/// </summary>
	public GitHubPermissionOptions? SecurityEvents { get; set; }
	/// <summary>
	/// Permission to Security Scanning Alert
	/// </summary>
	public GitHubPermissionOptions? SecurityScanningAlert { get; set; }
	/// <summary>
	/// Permission to Single File
	/// </summary>
	public GitHubPermissionOptions? SingleFile { get; set; }
	/// <summary>
	/// Permission to Statuses
	/// </summary>
	public GitHubPermissionOptions? Statuses { get; set; }
	/// <summary>
	/// Permission to Team Discussions
	/// </summary>
	public GitHubPermissionOptions? TeamDiscussions { get; set; }
	/// <summary>
	/// Permission to Vulnerability Alerts
	/// </summary>
	public GitHubPermissionOptions? VulnerabilityAlerts { get; set; }
	/// <summary>
	/// Permission to Workflows
	/// </summary>
	public GitHubPermissionOptions? Workflows { get; set; }
	/// <summary>
	/// Permission to Action Variables
	/// </summary>
	public GitHubPermissionOptions? ActionsVariables { get; set; }

	#endregion Properties

	/// <summary>
	/// Initializes a new instance of the <see cref="GitHubPermissions"/> class
	/// </summary>
	public GitHubPermissions()
	{
	}
}

/// <summary>
/// A list of valid permissions
/// </summary>
public enum GitHubPermissionOptions
{
	/// <summary>
	/// The contents can be read
	/// </summary>
	Read,
	/// <summary>
	/// The contents can be written
	/// </summary>
	Write
}

