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
    /// <param name="payloadHeaders">An <see cref="GitHubPayload"/> with the parsed headers</param>
    /// <param name="body">The request body</param>
    /// <returns></returns>
    Task<EventResult> ProcessRequest(GitHubPayload payloadHeaders, string body);
}

