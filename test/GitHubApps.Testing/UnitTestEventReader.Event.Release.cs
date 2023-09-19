// *****************************************************************************
// UnitTestEventReader.Event.Release.cs
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

using System.Runtime.CompilerServices;
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// The Unit Testing Class - For the Release Event Only
/// </summary>
public partial class UnitTestEventReader
{

    /// <summary>
    /// Test the event <see cref="GitHubEventRelease"/> for action <see cref="GitHubEventActions.EVENT_ACTION_CREATED"/>
    /// </summary>
    [TestMethod]
    public void TestEventReleaseCreated()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRelease>("Payload", "Release", "Release.Created.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_RELEASE, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_CREATED, obj.Payload.Action);

        // Validate Release
        Assert.IsNotNull(obj.Payload.Release);
        ValidateRelease(obj.Payload.Release);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRelease"/> for action <see cref="GitHubEventActions.EVENT_ACTION_DELETED"/>
    /// </summary>
    [TestMethod]
    public void TestEventReleaseDeleted()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRelease>("Payload", "Release", "Release.Deleted.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_RELEASE, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_DELETED, obj.Payload.Action);

        // Validate Release
        Assert.IsNotNull(obj.Payload.Release);
        ValidateRelease(obj.Payload.Release);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRelease"/> for action <see cref="GitHubEventActions.EVENT_ACTION_EDITED"/>
    /// </summary>
    [TestMethod]
    public void TestEventReleaseEdited()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventReleaseEdited>("Payload", "Release", "Release.Edited.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_RELEASE, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_EDITED, obj.Payload.Action);

        // Validate Changes
        Assert.IsNotNull(obj.Payload.Changes);
        Assert.IsNotNull(obj.Payload.Changes.Body);
        Assert.AreEqual("Release Comments From", obj.Payload.Changes.Body.From);

        // Validate Release
        Assert.IsNotNull(obj.Payload.Release);
        ValidateRelease(obj.Payload.Release);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRelease"/> for action <see cref="GitHubEventActions.EVENT_ACTION_PRERELEASED"/>
    /// </summary>
    [TestMethod]
    public void TestEventReleasePrereleased()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRelease>("Payload", "Release", "Release.Prereleased.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_RELEASE, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_PRERELEASED, obj.Payload.Action);

        // Validate Release
        Assert.IsNotNull(obj.Payload.Release);
        ValidateRelease(obj.Payload.Release);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRelease"/> for action <see cref="GitHubEventActions.EVENT_ACTION_PUBLISHED"/>
    /// </summary>
    [TestMethod]
    public void TestEventReleasePublished()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRelease>("Payload", "Release", "Release.Published.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_RELEASE, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_PUBLISHED, obj.Payload.Action);

        // Validate Release
        Assert.IsNotNull(obj.Payload.Release);
        ValidateRelease(obj.Payload.Release);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRelease"/> for action <see cref="GitHubEventActions.EVENT_ACTION_RELEASED"/>
    /// </summary>
    [TestMethod]
    public void TestEventReleaseReleased()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventRelease>("Payload", "Release", "Release.Released.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_RELEASE, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_RELEASED, obj.Payload.Action);

        // Validate Release
        Assert.IsNotNull(obj.Payload.Release);
        ValidateRelease(obj.Payload.Release);

        // Validate Repository
        Assert.IsNotNull(obj.Payload.Repository);
        ValidateDefaultRepository(obj.Payload.Repository);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateSimplifiedInstallation(obj.Payload.Installation);
    }

    /// <summary>
    /// Test the event <see cref="GitHubEventRelease"/> for action <see cref="GitHubEventActions.EVENT_ACTION_UNPUBLISHED"/>
    /// </summary>
    [TestMethod]
    public void TestEventReleaseUnpublished()
    {
        // This test method is not implemented because, as of September 2023, this event is not triggered yet.
        // Perhaps GitHub added this event for future usage. When this event is implemented, the unit testing will be implemented.
    }

    #region Model Validation

    /// <summary>
    /// Validates a <see cref="GitHubRelease"/>
    /// </summary>
    /// <param name="model">The <see cref="GitHubRelease"/> to be validated</param>
    /// <param name="memberName">The name of the method calling the function</param>
    private void ValidateRelease(GitHubRelease model, [CallerMemberName] string memberName = "")
    {
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/releases/121236468", model.URL);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/releases/121236468/assets", model.AssetsURL);
        Assert.AreEqual("https://uploads.github.com/repos/githubuser/TestGitHubApps/releases/121236468/assets{?name,label}", model.UploadURL);
        Assert.AreEqual(121236468, model.ID);

        Assert.AreEqual("RE_kwDOKNJSy84HOev0", model.NodeID);
        Assert.AreEqual("v1.0.1-prerelease.3", model.TagName);
        Assert.AreEqual("main", model.TargetCommitish);
        Assert.AreEqual("Release Title", model.Name);
        Assert.AreEqual(DefaultDateTime, model.CreatedAt);

        Assert.IsNotNull(model.Assets);
        Assert.AreEqual(0, model.Assets.Length);
        Assert.AreEqual("Release Comments", model.Body);

        // Validate Is Pre Release
        switch (memberName)
        {
            case nameof(TestEventReleasePrereleased):
                Assert.IsTrue(model.IsPreRelease);
                break;

            default:
                Assert.IsFalse(model.IsPreRelease);
                break;
        }

        // Validate Published At
        switch (memberName)
        {
            case nameof(TestEventReleaseDeleted):
            case nameof(TestEventReleasePublished):
            case nameof(TestEventReleaseReleased):
                Assert.AreEqual(DefaultDateTime, model.PublishedAt);
                break;

            default:
                Assert.IsNull(model.PublishedAt);
                break;
        }

        // Validate Is TarballURL and ZipballURL
        switch (memberName)
        {
            case nameof(TestEventReleaseDeleted):
            case nameof(TestEventReleasePublished):
            case nameof(TestEventReleaseReleased):
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/tarball/v1.0.1-prerelease.3", model.TarballURL);
                Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/zipball/v1.0.1-prerelease.3", model.ZipballURL);
                break;

            default:
                Assert.IsNull(model.TarballURL);
                Assert.IsNull(model.ZipballURL);
                break;
        }

        // Validate Is Draft
        switch (memberName)
        {
            case nameof(TestEventReleaseDeleted):
            case nameof(TestEventReleasePublished):
            case nameof(TestEventReleaseReleased):
                Assert.IsFalse(model.IsDraft);
                break;

            default:
                Assert.IsTrue(model.IsDraft);
                break;
        }


        // Validate HTML URL
        switch (memberName)
        {
            case nameof(TestEventReleaseDeleted):
            case nameof(TestEventReleasePublished):
            case nameof(TestEventReleaseReleased):
                Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/releases/tag/v1.0.1-prerelease.3", model.HTMLURL);
                break;

            default:
                Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/releases/tag/untagged-c95c6bf95a5a03727759", model.HTMLURL);
                break;
        }


        // Validate Author
        Assert.IsNotNull(model.Author);
        ValidateDefaultAccount(model.Author);
    }

    #endregion Model Validation

}

