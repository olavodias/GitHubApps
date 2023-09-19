// *****************************************************************************
// IGitHubEventRelease.cs
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
internal interface IGitHubEventRelease
{
    /// <summary>
    /// A draft was saved, or a release or pre-release was publihshed without previously being saved as a draft
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventReleaseCreated(GitHubDelivery<GitHubEventRelease> payload);
    /// <summary>
    /// A release, pre-release, or draft release was deleted
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventReleaseDeleted(GitHubDelivery<GitHubEventRelease> payload);
    /// <summary>
    /// The details of a release, pre-release, or draft release were edited
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventReleaseEdited(GitHubDelivery<GitHubEventReleaseEdited> payload);
    /// <summary>
    /// A release was created and identified as a pre-release.
    /// A pre-release is a release that is not ready for production and may be unstable.
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventReleasePreReleased(GitHubDelivery<GitHubEventRelease> payload);
    /// <summary>
    /// A release, pre-release, or draft of a release was published
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventReleasePublished(GitHubDelivery<GitHubEventRelease> payload);
    /// <summary>
    /// A release was published, or a pre-release was changed to a release
    /// </summary>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventReleaseReleased(GitHubDelivery<GitHubEventRelease> payload);
    /// <summary>
    /// A release or pre-release was unpublished
    /// </summary>
    /// <remarks>As of September 2023, this event is not being triggered by GitHub.</remarks>
    /// <include file='documentation_shared.xml' path='Documentation/ActionHandlers/*'/>
    EventResult OnEventReleaseUnpublished(GitHubDelivery<GitHubEventRelease> payload);
}

