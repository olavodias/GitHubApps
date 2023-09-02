using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using GitHubApps.Exceptions;

namespace GitHubApps.Models;

/// <summary>
/// A class to perform serialization of the GitHub Objects
/// </summary>
internal static class GitHubSerializer
    {
	/// <summary>
	/// The default settings for serialization
	/// </summary>
	public static JsonSerializerSettings DefaultSerializerSettings = new()
	{
		ContractResolver = new DefaultContractResolver()
		{
			NamingStrategy = new SnakeCaseNamingStrategy()
		},
		DateFormatString = "yyyy-MM-dd HH:mm:ss"
	};

	/// <summary>
	/// Create the payload object based on a JSON data
	/// </summary>
	/// <typeparam name="TPayload">The type of the payload being converted</typeparam>
	/// <param name="json">The contents to be deserealized</param>
	/// <returns>An instance of <typeparamref name="TPayload"/></returns>
	/// <exception cref="SerializationException">Thrown when the serialization was not succesfull</exception>
	public static TPayload? ConvertFromJson<TPayload>(string json)
	{
		try
		{
			return JsonConvert.DeserializeObject<TPayload>(json, DefaultSerializerSettings);
        }
		catch (Exception ex)
		{
			throw new SerializationException(ex);
		}
	}

    /// <summary>
    /// Create the delivery object based on a JSON data
    /// </summary>
    /// <typeparam name="TPayload">The type of the payload being converted</typeparam>
    /// <param name="json">The contents to be deserealized</param>
    /// <returns>An instance of <typeparamref name="TPayload"/></returns>
	/// <exception cref="SerializationException">Thrown when the serialization was not succesfull</exception>
    public static GitHubDelivery<TPayload>? ConvertFromJsonToGitHubPayload<TPayload>(string json)
	{
		try
		{
            return JsonConvert.DeserializeObject<GitHubDelivery<TPayload>>(json, DefaultSerializerSettings);
        }
		catch (Exception ex)
		{
            throw new SerializationException(ex);
        }
	}
	
}

