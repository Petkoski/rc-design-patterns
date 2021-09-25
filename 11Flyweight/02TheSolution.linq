<Query Kind="Program" />

//Solution: caching the object and controlling the state.

void Main()
{

}

//Flyweight:
public class Icon
{
	public Icon(string type)
	{
		//Load icon
	}
}

static class IconProvider
{
	private static Dictionary<string, Icon> _cache = new Dictionary<string, Icon>();

	public static Icon GetIcon(string type)
	{
		//Create new instance only if does not exist in cache:
		if (!_cache.ContainsKey(type))
		{
			_cache[type] = new Icon(type);
		}

		return _cache[type];
	}
}

abstract class Button
{
	public Icon Icon { get; set; }
}

class SettingsButton : Button
{
	public SettingsButton()
	{
		//Instead of instantiation, use the IconProvider:
		Icon = IconProvider.GetIcon("settings");
	}
}

//Three different windows will be using the same icon in memory:
class SolutionWindow
{
	SettingsButton settings = new SettingsButton();
}

class TerminalWindow
{
	SettingsButton settings = new SettingsButton();
}

class TestRunnerWindow
{
	SettingsButton settings = new SettingsButton();
}