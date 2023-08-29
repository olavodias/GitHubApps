using System;
namespace GitHubApps.EventMap;

public class MapAction
{

	public string ActionName { get; set; } = string.Empty;

	public string[] Parameters { get; set; } = Array.Empty<string>();

	public MapAction(string actionName): this(actionName, Array.Empty<string>()) { }

	public MapAction(string actionName, params string[] parameters)
	{
		this.ActionName = actionName;
		this.Parameters = parameters;
	}

	public void SortParameters()
	{
		var temp = from p in Parameters orderby p select p;
		Parameters = temp.ToArray();
	}
}

