// *****************************************************************************
// UnitTestEventReader.Event.Label.cs
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

using System;
using System.Runtime.CompilerServices;
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// The Unit Testing Class - For the Label Event Only
/// </summary>
public partial class UnitTestEventReader
{

    /// <summary>
    /// Test the event <see cref="GitHubEventLabel"/> for action <see cref="GitHubEventActions.EVENT_ACTION_CREATED"/>
    /// </summary>
	[TestMethod]
	public void TestEventLabelCreated()
	{
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventLabel>("Payload", "Label", "Label.Created.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_LABEL, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_CREATED, obj.Payload.Action);

        // Validate Label
        Assert.IsNotNull(obj.Payload.Label);
        ValidateLabel(obj.Payload.Label);

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
    /// Test the event <see cref="GitHubEventLabel"/> for action <see cref="GitHubEventActions.EVENT_ACTION_DELETED"/>
    /// </summary>
    [TestMethod]
    public void TestEventLabelDeleted()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventLabel>("Payload", "Label", "Label.Deleted.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_LABEL, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_DELETED, obj.Payload.Action);

        // Validate Label
        Assert.IsNotNull(obj.Payload.Label);
        ValidateLabel(obj.Payload.Label);

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
    /// Test the event <see cref="GitHubEventLabel"/> for action <see cref="GitHubEventActions.EVENT_ACTION_EDITED"/>
    /// </summary>
    [TestMethod]
    public void TestEventLabelEdited()
    {
        // Test File to Serialize
        var obj = TestHelper.GetGitHubObject<GitHubEventLabelEdited>("Payload", "Label", "Label.Edited.json");

        Assert.IsNotNull(obj);

        // Validate Payload Properties
        Assert.AreEqual(GitHubEvents.EVENT_LABEL, obj.Event);

        Assert.IsNotNull(obj.Payload);
        Assert.AreEqual(GitHubEventActions.EVENT_ACTION_EDITED, obj.Payload.Action);

        // Validate Label
        Assert.IsNotNull(obj.Payload.Label);
        ValidateLabel(obj.Payload.Label);

        // Validate Changes
        Assert.IsNotNull(obj.Payload.Changes);
        Assert.IsNotNull(obj.Payload.Changes.Description);
        Assert.AreEqual("test label", obj.Payload.Changes.Description.From);

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


    #region Model Validation

    /// <summary>
    /// Validates a <see cref="GitHubLabel"/>
    /// </summary>
    /// <param name="model">The <see cref="GitHubLabel"/> to be validated</param>
    /// <param name="memberName">The name of the method calling the function</param>
    private void ValidateLabel(GitHubLabel model, [CallerMemberName] string memberName = "")
    {
        Assert.AreEqual(5943452821, model.ID);
        Assert.AreEqual("LA_kwDOKNJSy88AAAABYkHklQ", model.NodeID);
        Assert.AreEqual("https://api.github.com/repos/githubuser/TestGitHubApps/labels/testlabel", model.URL);
        Assert.AreEqual("testlabel", model.Name);
        Assert.AreEqual("0e8a16", model.Color);
        Assert.AreEqual("test label", model.Description);
        Assert.IsFalse(model.IsDefault);
    }

    #endregion Model Validation

}

#pragma warning restore CA1822 // Mark members as static