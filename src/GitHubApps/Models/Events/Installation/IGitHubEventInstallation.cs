﻿using System;

namespace GitHubApps.Models.Events;

/// <include file='documentation_shared.xml' path="Documentation/Interfaces/*"/>
internal interface IGitHubEventInstallation
{
    /// <summary>
    /// Someone installed a GitHub App on a user or organization account.
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventInstallationCreated(GitHubDelivery<GitHubEventInstallation> payload);
    /// <summary>
    /// Someone uninstalled a GitHub App from their user or organization account
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventInstallationDeleted(GitHubDelivery<GitHubEventInstallation> payload);
    /// <summary>
    /// Someone granted new permissions to a GitHub App
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventInstallationNewPermissionsAccepted(GitHubDelivery<GitHubEventInstallation> payload);
    /// <summary>
    /// Someone blocked access by a GitHub App to their user or organization account
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventInstallationSuspend(GitHubDelivery<GitHubEventInstallation> payload);
    /// <summary>
    /// A GitHub App that was blocked from accessing a user or organization account was given access the account again
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventInstallationUnsuspend(GitHubDelivery<GitHubEventInstallation> payload);
}

