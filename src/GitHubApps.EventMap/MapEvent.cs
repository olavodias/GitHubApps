using System;
namespace GitHubApps.EventMap;

public class MapEvent
{

	public string Name { get; set; }

	public MapAction[]? Actions { get; set; }

	public MapEvent(string name)
	{
		this.Name = name;
	}
}

