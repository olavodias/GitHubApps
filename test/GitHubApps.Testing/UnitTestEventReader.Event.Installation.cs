// *****************************************************************************
// UnitTestEventReader.Event.Installation.cs
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
using System.Reflection;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// The Unit Testing Class - For the Installation Event Only
/// </summary>
public partial class UnitTestEventReader
{

    /// <summary>
    /// Test the event <see cref="GitHubInstallation"/> for action <see cref="GitHubEventActions.EVENT_ACTION_CREATED"/>
    /// </summary>
    [TestMethod]
    public void TestEventInstallationCreated()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventInstallation>("Payload", "Installation", "Installation.Created.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_INSTALLATION, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_CREATED, obj.Payload.Action);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateDefaultInstallation(obj.Payload.Installation);
        Assert.IsNull(obj.Payload.Installation.SuspendedBy);
        Assert.IsNull(obj.Payload.Installation.SuspendedAt);

        // Validate Repositories Array
        Assert.IsNotNull(obj.Payload.Repositories);
        Assert.AreEqual(1, obj.Payload.Repositories.Length);
        ValidateSimplifiedRepository(obj.Payload.Repositories[0]);

        // Validate Requester
        Assert.IsNull(obj.Payload.Requester);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);
    }

    /// <summary>
    /// Test the event <see cref="GitHubInstallation"/> for action <see cref="GitHubEventActions.EVENT_ACTION_DELETED"/>
    /// </summary>
    [TestMethod]
    public void TestEventInstallationDeleted()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventInstallation>("Payload", "Installation", "Installation.Deleted.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_INSTALLATION, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_DELETED, obj.Payload.Action);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateDefaultInstallation(obj.Payload.Installation);
        Assert.IsNull(obj.Payload.Installation.SuspendedBy);
        Assert.IsNull(obj.Payload.Installation.SuspendedAt);

        // Validate Repositories Array
        Assert.IsNotNull(obj.Payload.Repositories);
        Assert.AreEqual(1, obj.Payload.Repositories.Length);
        ValidateSimplifiedRepository(obj.Payload.Repositories[0]);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);

    }

    /// <summary>
    /// Test the event <see cref="GitHubInstallation"/> for action <see cref="GitHubEventActions.EVENT_ACTION_SUSPEND"/>
    /// </summary>
    [TestMethod]
    public void TestEventInstallationSuspend()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventInstallation>("Payload", "Installation", "Installation.Suspend.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_INSTALLATION, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_SUSPEND, obj.Payload.Action);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateDefaultInstallation(obj.Payload.Installation);

        // Validate Suspended Information
        Assert.IsNotNull(obj.Payload.Installation.SuspendedBy);
        ValidateDefaultAccount(obj.Payload.Installation.SuspendedBy);
        Assert.AreEqual(DefaultDateTime, obj.Payload.Installation.SuspendedAt);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);
    }

    /// <summary>
    /// Test the event <see cref="GitHubInstallation"/> for action <see cref="GitHubEventActions.EVENT_ACTION_UNSUSPEND"/>
    /// </summary>
    [TestMethod]
    public void TestEventInstallationUnsuspend()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventInstallation>("Payload", "Installation", "Installation.Unsuspend.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_INSTALLATION, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_UNSUSPEND, obj.Payload.Action);

        // Validate Installation
        Assert.IsNotNull(obj.Payload.Installation);
        ValidateDefaultInstallation(obj.Payload.Installation);
        Assert.IsNull(obj.Payload.Installation.SuspendedBy);
        Assert.IsNull(obj.Payload.Installation.SuspendedAt);

        // Validate Sender
        Assert.IsNotNull(obj.Payload.Sender);
        ValidateDefaultAccount(obj.Payload.Sender);
    }

}