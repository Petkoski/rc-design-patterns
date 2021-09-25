<Query Kind="Program" />

//Intrinsic, Extrinsic states with decorator pattern.

void Main()
{

}


public class Icon
{
	public Icon(string type)
	{
		//Load icon
	}
}

static class ButtonProvider
{
	private static Dictionary<string, Button> _cache = new Dictionary<string, Button>();

	public static Button GetButton(string type, Func<Button> buttonFactory)
	{
		if (!_cache.ContainsKey(type))
		{
			_cache[type] = buttonFactory();
		}

		return _cache[type];
	}
}

static Button SettingsButtonFactory() => new SettingsButton();

abstract class Button
{
	public Icon Icon { get; set; }
	public abstract void Click();
}

class SettingsButton : Button
{
	public SettingsButton()
	{
		//Always one instance:
		Icon = new Icon("settings");
	}

	//Intrinsic state - behavior of displaying the options
	public override void Click()
	{
		//Do something
	}
}

class DropdownButton : Button
{
	Button _btn;
	
	//Extrinsic state (things that come from the outside):
	//Button provided
	//Options to display
	public DropdownButton(Button btn, params string[] options)
	{
		_btn = btn;
	}

	public override void Click()
	{
		_btn.Click(); //Do the original thing
		//Display options
	}
}

class SolutionWindow
{
	Button settings = new DropdownButton(ButtonProvider.GetButton("settings", SettingsButtonFactory), "option1", "option2");
}

class TerminalWindow
{
	Button settings = new DropdownButton(ButtonProvider.GetButton("settings", SettingsButtonFactory), "option2", "option3", "option4");
}

class TestRunnerWindow
{
	Button settings = new DropdownButton(ButtonProvider.GetButton("settings", SettingsButtonFactory), "option1", "option2", "option4");
}