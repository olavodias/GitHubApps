// *****************************************************************************
// UnitTestEventReader.Event.Push.cs
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
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// The Unit Testing Class - For the Push Event Only
/// </summary>
public partial class UnitTestEventReader
{
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

        // Validate Head Commit
        Assert.IsNotNull(obj.Payload.HeadCommit);
        ValidateHeadCommit(obj.Payload.HeadCommit);
    }

    #region Model Validation

    /// <summary>
    /// Validates a <see cref="GitHubCommit"/>
    /// </summary>
    /// <param name="model">The model to be validated</param>
    private void ValidateHeadCommit(GitHubCommit model)
    {
        Assert.AreEqual("41203e3015ea1e86240d781a0efd3c9aa671dfdf", model.ID);
        Assert.AreEqual("40958ceddcd61c2b241d4b2af01dbd0ea13be44d", model.TreeID);
        Assert.IsTrue(model.IsDistinct);
        Assert.AreEqual("Initial commit", model.Message);
        Assert.AreEqual(DefaultDateTime, model.Timestamp);
        Assert.AreEqual("https://github.com/githubuser/TestGitHubApps/commit/41203e3015ea1e86240d781a0efd3c9aa671dfdf", model.URL);

        Assert.IsNotNull(model.Author);
        ValidateDefaultAccountMetadataOnly(model.Author);

        Assert.IsNotNull(model.Committer);
        Assert.AreEqual("GitHub", model.Committer.Name);
        Assert.AreEqual("noreply@github.com", model.Committer.Email);
        Assert.AreEqual("web-flow", model.Committer.Username);

        Assert.IsNotNull(model.Added);
        Assert.AreEqual(1, model.Added.Length);
        Assert.AreEqual("README.md", model.Added[0]);

        Assert.IsNotNull(model.Removed);
        Assert.AreEqual(0, model.Removed.Length);

        Assert.IsNotNull(model.Modified);
        Assert.AreEqual(0, model.Modified.Length);
    }

    #endregion Model Validation

}

