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

