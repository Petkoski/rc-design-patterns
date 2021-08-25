<Query Kind="Program" />

void Main()
{
	new NavigationBar();
	new DropdownMenu();
	new AndroidNavigationBar();
	new AndroidDropdownMenu();
}

public abstract class Element
{
	//Factory method:
	protected abstract Button CreateButton();

	public Element() => CreateButton();
}

//Building blocks (using inheritance to enforce the structure of having button created):
//Inheritance = structure
public class NavigationBar : Element
{
	protected override Button CreateButton()
	{
		return new Button { Type = "Default Button".Dump() };
	}
}

public class DropdownMenu : Element
{
	protected override Button CreateButton()
	{
		return new Button { Type = "Default Button".Dump() };
	}
}

public class AndroidNavigationBar : Element
{
	protected override Button CreateButton()
	{
		return new Button { Type = "Android Button".Dump() };
	}
}

public class AndroidDropdownMenu : Element
{
	protected override Button CreateButton()
	{
		return new Button { Type = "Android Button".Dump() };
	}
}

public class Button
{
	public string Type { get; set; }
}