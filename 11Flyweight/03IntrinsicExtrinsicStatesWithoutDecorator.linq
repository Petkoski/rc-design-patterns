<Query Kind="Program" />

//Intrinsic (internal state), Extrinsic (external state).

void Main()
{
	var btn = ButtonProvider.GetButton<string[]>("settings", SettingsButtonFactory);

	//Dropdown menu on click:
	btn.Click(new[] { "option1", "option2", "option3", "option4" });
}


public class Icon
{
	public Icon(string type)
	{
		//Load icon
	}
}

//ButtonProvider instead of IconProvider:
static class ButtonProvider
{
	private static Dictionary<string, Button> _cache = new Dictionary<string, Button>();

	public static Button<T> GetButton<T>(string type, Func<Button<T>> buttonFactory)
	{
		if (!_cache.ContainsKey(type))
		{
			_cache[type] = buttonFactory();
		}

		return (Button<T>) _cache[type];
	}
}

static SettingsButton SettingsButtonFactory() => new SettingsButton();

abstract class Button
{
	//Intrinsic state (internal state, something that object comes with):
	//Should not change (could be shared across the app).
	public Icon Icon { get; set; }
}

//Generic button (accepts configuration):
abstract class Button<T> : Button
{
	public abstract void Click(T config);
}

//Turning the SettingsButton into a flyweight object:
class SettingsButton : Button<string[]>
{
	public SettingsButton()
	{
		//Always one instance:
		Icon = new Icon("settings");
	}

	//Extrinsic state, config that may come from the outside:
	public override void Click(string[] config)
	{  
		//Display options
	}
}

//Internal state - Icon
//External state - Options (passed at runtime)
//Result: Provide different options at multiple components (external 
//state), but the icon (button) will look the same (internal state).
//External state should not affect the internal state.