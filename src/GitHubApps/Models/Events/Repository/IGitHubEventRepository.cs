// *****************************************************************************
// IGitHubEventRepository.cs
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
internal interface IGitHubEventRepository
{

    /// <summary>
    /// A repository was archived
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryArchived(GitHubDelivery<GitHubEventRepository> payload);
    /// <summary>
    /// A repository was created
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryCreated(GitHubDelivery<GitHubEventRepository> payload);
    /// <summary>
    /// A repository was deleted
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryDeleted(GitHubDelivery<GitHubEventRepository> payload);
    /// <summary>
    /// The topics, default branch, descriptiopn, or homepage of a repository was changed
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryEdited(GitHubDelivery<GitHubEventRepositoryEdited> payload);
    /// <summary>
    /// The visibility of a repository was changed to private
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryPrivatized(GitHubDelivery<GitHubEventRepository> payload);
    /// <summary>
    /// The visibility of a repository was changed to public
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryPublicized(GitHubDelivery<GitHubEventRepository> payload);
    /// <summary>
    /// The name of a repository was changed
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryRenamed(GitHubDelivery<GitHubEventRepositoryEdited> payload);
    /// <summary>
    /// Ownership of the repository was transferred to a user or organization account.
    /// This event is only sent to the account where the ownership is transferred.
    /// To receive the repository.transferred event, the new owner account must have the GitHub App installed, and the App must be subscribed to "Repository" events
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryTransferred(GitHubDelivery<GitHubEventRepositoryEdited> payload);
    /// <summary>
    /// A previously archived repository was unarchived
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventRepositoryUnarchived(GitHubDelivery<GitHubEventRepository> payload);
}

