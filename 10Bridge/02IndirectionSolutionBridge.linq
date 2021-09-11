<Query Kind="Program" />

//Solution: Put the Make inside the abstraction.

void Main()
{

}

//Top level abstraction:
//Abstraction has a pointer (reference) to the implementation.
public abstract class Vehicle {
	private Make make;
}

public abstract class Make {}

//Implementation:
//Lives completely separate from the vehicle.
//Even if we add another Make, it does not force us to implement
//more cars or more trucks (won't have exponential effect) for 
//that specific Make.
public class Lada : Make {}
public class Volvo : Make {}

//Lower level abstraction:
public class Car : Vehicle {}
public class Truck : Vehicle {}