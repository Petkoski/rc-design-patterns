<Query Kind="Program" />

//Flyweight pattern - complexity of state management when trying 
//to reuse an object.
//Flyweight is essentially around caching the object and controlling
//the state.
//Optimization pattern used to reduce the amount of objects stored 
//in memory. Objects we are reusing are called flyweights.

void Main()
{

}

public class Icon
{
	public Icon(string path)
	{
		//Load icon
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
		Icon = new Icon("path_to_settings_icon");
	}
}

//Three different places where icon is instantiated:
//Potential improvement: cache & reuse it.
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