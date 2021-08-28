<Query Kind="Program" />

//Prototype pattern - refers to instances of implementation of an interface (or
//some kind of abstract class) that implement a Copy() method.

void Main()
{
	var garden = new GardenFactory(
		new TreeSeed("Apple"),
		new GrassSeed("Red"),
		new FlowerSeed("Roses")
	);

	garden.CreatePlant1().Dump();
	garden.CreatePlant2().Dump();
	garden.CreatePlant3().Dump();
}

//Factory:
public class GardenFactory
{
	Seed _seed1;
	Seed _seed2;
	Seed _seed3;

	public GardenFactory(
		Seed seed1,
		Seed seed2,
		Seed seed3
	)
	{
		_seed1 = seed1;
		_seed2 = seed2;
		_seed3 = seed3;
	}

	internal Seed CreatePlant1() => _seed1.Copy();
	internal Seed CreatePlant2() => _seed2.Copy();
	internal Seed CreatePlant3() => _seed3.Copy();
}

public abstract class Seed
{
	//Main thing is this Copy() method:
	public abstract Seed Copy();
}

//Implementation should know how to clone itself
public class TreeSeed : Seed
{
	public string Type { get; }

	public TreeSeed(string type) => Type = type;

	//Make sure to make a real copy (to not corrupt each ones state)
	public override Seed Copy() => new TreeSeed(Type);
}

public class GrassSeed : Seed
{
	public string Type { get; }

	public GrassSeed(string type) => Type = type;

	public override Seed Copy() => new GrassSeed(Type);
}

public class FlowerSeed : Seed
{
	public string Type { get; }

	public FlowerSeed(string type) => Type = type;

	public override Seed Copy() => new FlowerSeed(Type);
}