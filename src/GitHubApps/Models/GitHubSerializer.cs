using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using GitHubApps.Exceptions;

namespace GitHubApps.Models
{
	internal static class GitHubSerializer
    {
		public static string DefaultDateFormatString = "yyyy-MM-dd HH:mm:ss";
		public static DefaultContractResolver DefaultContractResolver = new()
        {
			NamingStrategy = new SnakeCaseNamingStrategy()
		};

		/// <summary>
		/// Create the object based on a JSON data
		/// </summary>
		/// <typeparam name="TObject">The type of the object being converted</typeparam>
		/// <param name="json">The contents to be deserealized</param>
		/// <returns>An instance of <typeparamref name="TObject"/></returns>
		public static TObject? ConvertFromJson<TObject>(string json)
		{
			try
			{
				return JsonConvert.DeserializeObject<TObject>(json, new JsonSerializerSettings
				{
					ContractResolver = GitHubSerializer.DefaultContractResolver,
					DateFormatString = GitHubSerializer.DefaultDateFormatString
				});
            }
			catch (Exception ex)
			{
				throw new SerializationException(ex);
			}
		}

	}
}

