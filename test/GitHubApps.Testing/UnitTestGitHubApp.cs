// *****************************************************************************
// UnitTestGitHubApp.cs
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
using GitHubApps;

namespace GitHubApps.Testing;

/// <summary>
/// Tests the <see cref="GitHubAppBase"/> class
/// </summary>
[TestClass]
public class UnitTestGitHubApp
{

    /// <summary>
    /// This test will go thru each json file in the payload folder, and try to submit it to the github app.
    /// It will use the property <see cref="GitHubApp.LastMethodCalled"/> to idenfity which method was called, to confirm the event was routed properly.
    /// </summary>
    [TestMethod]
    public void TestProcessRequest()
    {
        var gitHubApp = new GitHubApp();
        Assert.IsTrue(Directory.Exists("Payload"));
        var files = Directory.GetFiles("Payload", "*.json", SearchOption.AllDirectories);

        foreach (var file in from f in files orderby f select f)
        {
            try
            {
                var filePathArray = file.Split(Path.DirectorySeparatorChar);
                var fileEvent = filePathArray[1].ToLower();
                var fileAction = filePathArray[2].Split('.')[1].ToLower();
                if (fileAction == "json") fileAction = string.Empty;

                var methodToBeCalled = $"onevent{fileEvent}{fileAction}";

                var parsedFileData = TestHelper.GetPayloadFromFile(file) ?? throw new NullReferenceException();
                Assert.IsNotNull(parsedFileData.Event);
                Assert.AreEqual(fileEvent, parsedFileData.Event.Replace("_",string.Empty));
                Assert.IsNotNull(parsedFileData.Payload);

                var gitHubDeliveryHeaders = new GitHubApps.Models.GitHubDelivery
                {
                    Event = parsedFileData.Event
                };

                // Process the request itself
                var result = gitHubApp.ProcessRequest(gitHubDeliveryHeaders, parsedFileData.Payload).GetAwaiter().GetResult();

                Assert.AreEqual(methodToBeCalled, gitHubApp.LastMethodCalled);
                Assert.AreEqual(EventResult.SuccessEventResult, result);

            }
            catch (Exception ex)
            {
                TestHelper.DumpException(ex, 0);
                Assert.Fail($"Unable to process file '{file}'");
            }
        }

    }

}

