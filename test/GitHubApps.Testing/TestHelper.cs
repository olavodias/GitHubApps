// *****************************************************************************
// TestHelper.cs
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
using System.Diagnostics;
using System.Text;
using GitHubApps.Models;
using GitHubApps.Models.Events;

namespace GitHubApps.Testing;

/// <summary>
/// A static class containing methods to support Unit Testing
/// </summary>
public static class TestHelper
{

    /// <summary>
    /// Return the contents of a text file
    /// </summary>
    /// <param name="args">The path to the file</param>
    /// <returns>A string containing the contents of the file</returns>
    public static string GetFileData(params string[] args)
    {
        return File.ReadAllText(Path.Combine(args));
    }

    /// <summary>
    /// Returns a GitHub object or throw an exception if unable to create one
    /// </summary>
    /// <typeparam name="TGitHubObject">The type of the GitHub Object</typeparam>
    /// <param name="args">The path where the example file is located</param>
    /// <returns>A <see cref="GitHubEvent{TMainClass}"/> of type <typeparamref name="TGitHubObject"/> or null if not found</returns>
    public static GitHubDelivery<TGitHubObject>? GetGitHubObject<TGitHubObject>(params string[] args)
        where TGitHubObject : GitHubEvent<TGitHubObject>
    {
        try
        {
            var contents = GetFileData(args) ?? throw new InvalidDataException("Unable to load data from file");
            
            return GitHubDelivery<TGitHubObject>.ConvertFromJSON(contents);
        }
        catch (Exception ex)
        {
            DumpException(ex, 0);
            return default;
        }        
    }


    public static void DumpException(Exception e, int level)
    {
        var sbDump = new StringBuilder();
        DumpException(sbDump, e, level);

        Debug.WriteLine(sbDump.ToString());
    }

    private static void DumpException(StringBuilder stringBuilder, Exception e, int level)
    {
        var padding = (level > 0 ? '\u2514' : null) +
                      string.Empty.PadRight(level * 3, '\u2500') +
                      (level > 0 ? ' ' : null);

        stringBuilder.Append(padding);
        stringBuilder.Append("Exception......: ");
        stringBuilder.Append(e.GetType().Name);
        stringBuilder.AppendLine();

        stringBuilder.Append(padding);
        stringBuilder.Append("Message........: ");
        stringBuilder.Append(e.Message);
        stringBuilder.AppendLine();

        stringBuilder.Append(padding);
        stringBuilder.Append("Stack Trace....: ");
        stringBuilder.Append(e.StackTrace?.Replace("\n", "\n" + padding + string.Empty.PadRight(17, ' ')));
        
        if (e.InnerException is not null)
        {
            stringBuilder.AppendLine();
            stringBuilder.Append(padding);
            stringBuilder.Append("Inner Exception: ");
            stringBuilder.AppendLine();
            DumpException(stringBuilder, e.InnerException, level + 1);
        }

        stringBuilder.AppendLine();
    }
}

