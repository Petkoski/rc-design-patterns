<Query Kind="Program" />

//Proxy/ambassador design pattern - controlling access to an object.
//Implementation may look very similar to decorator/wrapper design pattern.

//Proxy is a compile-time decision. It is referencing the original object
//internally, it just may defer its creation (03Virtual), may restrict access 
//to it (04Protection) or may load it from some location (02Remote). 
//Not meant for composability, meant to overcome the infrastructure layer.

void Main()
{

}

public interface Abstraction { }

public class Concretion : Abstraction { }

//Thing that points to Concretion (without putting Concretion through 
//constructor [hidden])
//Don't create Concretion before creating the Proxy. Proxy is created first 
//in the Proxy design pattern. Proxy controls the Concretion, that's why 
//Concretion is hidden inside Proxy.
//Idea: Proxy is closer to an infrastructural bound.
public class ConcretionProxy : Abstraction
{
	//Hide concretion, if we inject it we already exposed it
	//Compile time decision
	Concretion concretion = new Concretion();

	//Simulate/hook/intercept/interupt communication with Concretion
}

//Decorator design pattern - Concretion is known (passed through constructor)
//Idea: Decorator is more about how you think in terms of information and 
//how it flows (thinking model where we are chaining functionality).
public class CocretionDecorator : Abstraction
{
	Abstraction _abstraction;

	//Concretion is known
	//Runtime decision
	public CocretionDecorator(Abstraction abstraction)
	{
		_abstraction = abstraction;
	}

	//Override concretion functionality
}