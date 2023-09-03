// *****************************************************************************
// IGitHubEventIssues.cs
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

namespace GitHubApps.Models.Events;

/// <include file='documentation_shared.xml' path="Documentation/Interfaces/*"/>
internal interface IGitHubEventIssues
{
    /// <summary>
    /// An issue was assigned to an user
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesAssigned(GitHubDelivery<GitHubEventIssuesAssigned> payload);
    /// <summary>
    /// An issue was closed
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesClosed(GitHubDelivery<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was deleted
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesDeleted(GitHubDelivery<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was removed from a milestone
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesDemilestoned(GitHubDelivery<GitHubEventIssuesMilestoned> payload);
    /// <summary>
    /// The title or body of an issue was edited
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesEdited(GitHubDelivery<GitHubEventIssuesEdited> payload);
    /// <summary>
    /// A label was added to an issue
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesLabeled(GitHubDelivery<GitHubEventIssuesLabeled> payload);
    /// <summary>
    /// Conversation on an issue was locked
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesLocked(GitHubDelivery<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was added to a milestone
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesMilestoned(GitHubDelivery<GitHubEventIssuesMilestoned> payload);
    /// <summary>
    /// An issue was created
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesOpened(GitHubDelivery<GitHubEventIssuesChanged> payload);
    /// <summary>
    /// An issue was pinned to a repository
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesPinned(GitHubDelivery<GitHubEventIssues> payload);
    /// <summary>
    /// A closed issue was reopened
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesReopened(GitHubDelivery<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was transferred to another repository
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesTransferred(GitHubDelivery<GitHubEventIssuesChanged> payload);
    /// <summary>
    /// A user was unassigned from an issue
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesUnassigned(GitHubDelivery<GitHubEventIssuesAssigned> payload);
    /// <summary>
    /// A label was removed from an issue
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesUnlabeled(GitHubDelivery<GitHubEventIssuesLabeled> payload);
    /// <summary>
    /// Conversation on an issue was unlocked
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesUnlocked(GitHubDelivery<GitHubEventIssues> payload);
    /// <summary>
    /// An issue was unpinned from a repository
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventIssuesUnpinned(GitHubDelivery<GitHubEventIssues> payload);
}

