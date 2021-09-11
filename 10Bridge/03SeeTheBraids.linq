<Query Kind="Program" />

void Main()
{

}

//Top level abstraction:
public abstract class Vehicle
{
	//Bridge towards the Make:
	private Make make;

	public void Start()
	{
		//Make has common functions:
		make.PerformRitual();
		make.StartCar();
	}
	
	public abstract bool AllowedToDrive(string person);
}

public abstract class Make
{
	public abstract void PerformRitual();
	public abstract void StartCar();
}

//Implementation:
public class Lada : Make
{
	public override void PerformRitual() => "Hit the car".Dump();

	public override void StartCar() {
		"fix the wiring".Dump();
		"lube the engine".Dump();
		"put the key in".Dump();
		"turn the key".Dump();
	}
}

public class Volvo : Make
{
	public override void PerformRitual() => "Greatful for buying a volvo".Dump();
	public override void StartCar() => "Press button".Dump();
}

//Lower level abstraction:
public class Car : Vehicle
{
	public override bool AllowedToDrive(string person) => person == "has license";
}

public class Truck : Vehicle
{
	public override bool AllowedToDrive(string person) => person == "has special truck license";
}