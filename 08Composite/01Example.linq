<Query Kind="Program" />

//Composite design pattern - similar to tree data structure. There is 
//an object (called node or leaf) that has reference(s) to other 
//nodes/leaves of the same type. Infinitely compose these nodes to
//represent something.

void Main()
{
	new CompositeComponent().Dump();
}

public interface IComponent
{
	IList<IComponent> Children { get; }
}

//Does not contain any children
public class RegularComponent : IComponent
{
	public string Name = nameof(RegularComponent);
	public IList<IComponent> Children => null;
}

//Does not contain any children
public class OrdinaryComponent : IComponent
{
	public string Name = nameof(OrdinaryComponent);
	public IList<IComponent> Children => null;
}

//Contains other IComponent children
public class CompositeComponent : IComponent
{
	public string Name = nameof(CompositeComponent);
	public IList<IComponent> Children => new List<IComponent>
	{
		new RegularComponent(),
		new OrdinaryComponent(),
		//new CompositeComponent() children will create infinite tree:
		new CompositeComponent(),
		new CompositeComponent(),
	};
}