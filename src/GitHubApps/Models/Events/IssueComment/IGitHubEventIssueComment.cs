﻿using System;

namespace GitHubApps.Models.Events;

/// <include file='documentation_shared.xml' path="Documentation/Interfaces/*"/>
internal interface IGitHubEventIssueComment
{
    /// <summary>
    /// A comment on an issue or pull request was created
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssueCommentCreated(GitHubDelivery<GitHubEventIssueComment> payload);
    /// <summary>
    /// A comment on an issue or pull request was deleted
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssueCommentDeleted(GitHubDelivery<GitHubEventIssueComment> payload);
    /// <summary>
    /// A comment on an issue or pull request was edited
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssueCommentEdited(GitHubDelivery<GitHubEventIssueCommentEdited> payload);

}

