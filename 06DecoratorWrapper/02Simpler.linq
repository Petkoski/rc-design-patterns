<Query Kind="Program" />

//Simpler example:

void Main()
{
	//Composing things in different orders:
	var d = new Doer();
	d.Something();
	"---".Dump();
	
	var atd = new AnotherThing(d);
	atd.Something();
	"---".Dump();
	
	var iad = new InAddition(d);
	iad.Something();
	"---".Dump();
	
	var iaatd = new InAddition(atd);
	iaatd.Something();
	"---".Dump();
	
	var atiad = new AnotherThing(iad);
	atiad.Something();
}

//Interface (0):
public interface IDoSomething
{
	void Something();
}

//Implementation (1):
public class Doer : IDoSomething
{
	public void Something() => "Something".Dump();
}

//AnotherThing inherits and overrides (2):
//Original object (IDoSomething) passed to constructor.
public class AnotherThing : IDoSomething
{
	protected IDoSomething _doSomething;

	public AnotherThing(IDoSomething doSomething) => _doSomething = doSomething;

	public void Something()
	{
		_doSomething.Something();
		"Another Thing".Dump();
	}
}

//InAddition inherits and overrides (3):
//Original object (IDoSomething) passed to constructor.
public class InAddition : IDoSomething
{
	protected IDoSomething _doSomething;

	public InAddition(IDoSomething doSomething) => _doSomething = doSomething;

	public void Something()
	{
		_doSomething.Something();
		"In Addition".Dump();
	}
}