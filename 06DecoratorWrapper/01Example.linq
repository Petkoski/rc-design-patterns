<Query Kind="Program" />

//Decorator pattern: Extend an original thing (object) and give it some
//additional responsibility/functionality. Do that in a composable way.

void Main()
{

}

public interface IDumbData
{
	int Id { get; set; }
	string Name { get; set; }
	string Description { get; set; }
}

public class DumbData : IDumbData
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
}

//BaseDecrator example:
//Inheriting IDumbData, but also passing the original IDumbData (the 
//thing to add functionality into) to constructor.
public abstract class BaseDecrator : IDumbData
{
	protected IDumbData data;

	public BaseDecrator(IDumbData data) => this.data = data;

	//Scaffolding (proxy everything to the default one):
	public virtual int Id { get => data.Id; set => data.Id = value; }
	public virtual string Name { get => data.Name; set => data.Name = value; }
	public virtual string Description { get => data.Description; set => data.Description = value; }
}

//InjectedFunctionality (inheriting from BaseDecrator)
//Again putting the original object (IDumbData) to constructor.
public class InjectedFunctionality : BaseDecrator
{
	//Supply original known object as parameter to constructor
	//Enables composability
	//Main difference to proxy pattern: the passed object (IDumbData) is known at runtime.
	public InjectedFunctionality(IDumbData data) : base(data) { }

	//Hook to particular part we want to override and attach functionality into it:
	public override string Name
	{
		get => data.Name;
		set
		{
			data.Name = value;
			EmitEvent(value);
		}
	}

	//Private (making the pattern configurable at runtime):
	private void EmitEvent(string name)
	{
		//Added functionality/responsiblity is not know to the outside, 
		//in favour of ability to pick decoration at runtime.
	}
}