﻿// *****************************************************************************
// GitHubAccount.cs
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
using Newtonsoft.Json;

namespace GitHubApps.Models;

/// <summary>
/// Represents a Git Hub Account
/// </summary>
public sealed class GitHubAccount
{

	#region Properties

	/// <summary>
	/// The Avatar URL
	/// </summary>
	public string? AvatarURL { get; set; }
	/// <summary>
	/// Defines whether the account was deleted or not
	/// </summary>
	public bool? Deleted { get; set; }
	/// <summary>
	/// The user email
	/// </summary>
	public string? Email { get; set; }
	/// <summary>
	/// The Events URL
	/// </summary>
	public string? EventsURL { get; set; }
	/// <summary>
	/// The Followers URL
	/// </summary>
	public string? FollowersURL { get; set; }
	/// <summary>
	/// The Following URL
	/// </summary>
	public string? FollowingURL { get; set; }
	/// <summary>
	/// The Gists URL
	/// </summary>
	public string? GistsURL { get; set; }
	/// <summary>
	/// The Gravatar ID
	/// </summary>
	public string? GravatarID { get; set; }
	/// <summary>
	/// The HTML URL
	/// </summary>
	[JsonProperty("html_url")]
	public string? HTMLURL { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
	/// <summary>
	/// The Account Login
	/// </summary>
	public string? Login { get; set; }
	/// <summary>
	/// The Account Name
	/// </summary>
	public string? Name { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
	/// <summary>
	/// The Organizations URL
	/// </summary>
	public string? OrganizationsURL { get; set; }
	/// <summary>
	/// The Received Events URL
	/// </summary>
	public string? ReceivedEventsURL { get; set; }
	/// <summary>
	/// The Repositories URL
	/// </summary>
	public string? ReposURL { get; set; }
	/// <summary>
	/// Defines whether the account is a site admin or not
	/// </summary>
	[JsonProperty("site_admin")]
	public bool? IsSiteAdmin { get; set; }
	/// <summary>
	/// The Starred URL
	/// </summary>
	public string? StarredURL { get; set; }
	/// <summary>
	/// The Subscriptions URL
	/// </summary>
	public string? SubscriptionsURL { get; set; }
	/// <summary>
	/// The Account Type
	/// </summary>
	public GitHubAccountTypes? Type { get; set; }
	/// <summary>
	/// The URL
	/// </summary>
	public string? URL { get; set; }

	#endregion Properties

	/// <summary>
	/// Initializes a new instance of the <see cref="GitHubAccount"/> class
	/// </summary>
	public GitHubAccount()
	{
						

	}

}

/// <summary>
/// Metaproperties for a Git User
/// </summary>
public sealed class GitHubAccountMetaProperties
{
	/// <summary>
	/// The date
	/// </summary>
    public string? Date { get; set; }
	/// <summary>
	/// The email
	/// </summary>
    public string? Email { get; set; }
	/// <summary>
	/// The name
	/// </summary>
    public string? Name { get; set; }
	/// <summary>
	/// The user name
	/// </summary>
	public string? Username { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="GitHubAccountMetaProperties"/> class
	/// </summary>
	public GitHubAccountMetaProperties()
	{

	}
}

/// <summary>
/// A list of valid account types
/// </summary>
public enum GitHubAccountTypes
{
	/// <summary>
	/// The account is a bot
	/// </summary>
	Bot,
	/// <summary>
	/// The account is a Git Hub user
	/// </summary>
	User,
	/// <summary>
	/// The account is a Git Hub organization
	/// </summary>
	Organization		
}

