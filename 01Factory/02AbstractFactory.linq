<Query Kind="Program" />

void Main()
{
	new NavigationBar(new Apple());
	new DropdownMenu(new Android());
}

public class NavigationBar
{
	public NavigationBar(IUIFactory factory) => factory.CreateButton();
}

public class DropdownMenu
{
	public DropdownMenu(IUIFactory factory) => factory.CreateButton();
}

//Concept also known as dependency inversion:
//Defining what we need (template):
public interface IUIFactory
{
	public Button CreateButton();
}

//Actual creation logic (different implementations):
public class Apple : IUIFactory
{
	public Button CreateButton()
	{
		return new Button { Type = "iOS Button".Dump() };
	}
}

public class Android : IUIFactory
{
	public Button CreateButton()
	{
		return new Button { Type = "Android Button".Dump() };
	}
}

public class Button
{
	public string Type { get; set; }
}

//Another example might be dark/light UI mode (both classes inheriting same theme interface).