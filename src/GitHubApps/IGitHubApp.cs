// *****************************************************************************
// IGitHubApp.cs
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
using System.Collections.Generic;
using System.Threading.Tasks;
using GitHubApps.Models;

namespace GitHubApps;

/// <summary>
/// Defines the interface to be implemented by a GitHub App
/// </summary>
public interface IGitHubApp
{
    /// <summary>
    /// The function to process a request
    /// </summary>
    /// <param name="headers">A dictionary containing the headers of the request</param>
    /// <param name="body">The request body</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="EventResult"/> with the results of the process</returns>
    Task<EventResult> ProcessRequest(Dictionary<string, string> headers, string body);
    /// <summary>
    /// The function to process a request
    /// </summary>
    /// <param name="payloadHeaders">An <see cref="GitHubDelivery"/> with the parsed headers</param>
    /// <param name="body">The request body</param>
    /// <returns></returns>
    Task<EventResult> ProcessRequest(GitHubDelivery payloadHeaders, string body);
}

