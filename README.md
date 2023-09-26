# GitHub Apps .NET (Core)

[![nuget](https://img.shields.io/nuget/v/GitHubApps.svg)](https://www.nuget.org/packages/GitHubApps/) 
![GitHub release](https://img.shields.io/github/release/olavodias/GitHubApps.svg)
![NuGet](https://img.shields.io/nuget/dt/GitHubApps.svg)
![license](https://img.shields.io/github/license/olavodias/GitHubApps.svg)

The GitHub Apps Core is a component that allows the creation of GitHub Apps using .NET.

A GitHub App is a service that receives a post request from GitHub when certain actions are executed.

This component exposes a `GitHubAppBase` class that must be extended to implement your own Git Hub App.

Refer to the [API Documentation](https://olavodias.github.io/GitHubApps) to have a better understanding of each class and how to use it.

## In this repository

* [Usage](#usage)
  * [Creating your own GitHub App](#creating-your-own-github-app)
  * [Current Events](#current-events)
* [Links](#links)

## Usage

Add the nuget package [GitHubApps](https://www.nuget.org/packages/GitHubApps/) into your project. This package is compatible with `netstandard1.0`, `netstandard1.3`, `netstandard2.0`, `net45`, `net46`, `net461`, and `net6.0`. If your project target any framework higher than those, it will work fine.

> If you are planning to implement a ASP.NET Core Web Application using this component, install the [GitHubApps.AspNetCore](https://www.nuget.org/packages/GitHubApps.AspNetCore/) package instead. This package offers a MVC `Controller` that handles the `POST` request made by GitHub.

### Creating your own GitHub App

In order to create your own GitHub App, create a class and extend from the `GitHubAppBase` class.

```cs
using GitHubApps;

public class MyGitHubApp: GitHubAppBase
{
   //TODO: Override the virtual methods for each event
}
```

This class contains several virtual methods that can be overwritten to handle the proper event and action. For example, to handle the GitHub event `installation` with action `created`, you can override the `OnEventInstallationCreated()` method.

```cs
using GitHubApps;

public class MyGitHubApp: GitHubAppBase
{
   public override EventResult OnEventInstallationCreated(GitHubDelivery<GitHubEventInstallation> payload)
   {
      // Your code goes here...
   }
}
```

The method should always return an `EventResult` object.

If an event/action that is not handled yet is called, it will call the method `OnEventActionUnhandled()`. 

If an event without action that is not handled yet is called, it will call the method `OnEventUnhandled()`.

When implementing the `GitHubApps` package only, it is necessary to manually implement the `ProcessRequest()` call. This function is going to route the event to the proper method, which has to be overwritten.

## Current Events

This list contains the events that are currently implemented by this component.

| Event | Description | Package Version |
| :-- | :-- | :-- |
| `create` | This event occurs when a Git branch or tag is created | `v1.0.0` |
| `delete` | This event occurs when a Git branch or tag is deleted | `v1.0.0` |
| `fork` | This event occurs when someone forks a repository | `v1.0.0` |
| `installation` | This even toccurs when there activity relating to a GitHub App installation | `v1.0.0` |
| `issue_comment` | This event occurs when there is activity relating to a comment on an issue or pull request | `v1.0.0` |
| `issues` | This event occurs when there is activity relating to an issue | `v1.0.0` |
| `label` | This event occurs when there is activity relating to labels | `v1.0.0` |
| `pull_request` | This event occurs when there is activity on a pull request | `v1.0.0` |
| `push` | This event occurs when there is a push to a repository branch | `v1.0.0` |
| `release` | This event occurs when there is activity relating to releases | `v1.0.0` |
| `repository` | This event occurs when there is activity relating to repositories | `v1.0.0` |

> If you need to handle an event that is not implement yet, you can do it by overwriting the method `OnEventUnhandled()` or `OnEventActionUnhandled()`.

> All of the GitHub events that are not in this list are going to be implemented at some point. Check the [Project Roadmap](https://github.com/users/olavodias/projects/2/views/2) on the [Links](#links) section to see when it is likely to be delivered. Feel free to place an issue with your request in order to expedite its delivery.

## Links

This section contains links that are relevant to this repository.

| Link | Description |
| :-- | :-- |
| [GitHub Webhook Events and Payloads](https://docs.github.com/en/webhooks/webhook-events-and-payloads) | The specification of webhooks events and payloads |
| [Project Roadmap](https://github.com/users/olavodias/projects/2/views/2) | The project roadmap and expected delivery dates |
| [Project Board](https://github.com/users/olavodias/projects/2/views/1) | The project board containing the tasks and its status |
| [API Documentation](https://olavodias.github.io/GitHubApps) | The API Documentation |
