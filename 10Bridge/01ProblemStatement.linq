<Query Kind="Program" />

//Bridge design pattern - separate implementation from abstraction.

void Main()
{

}

//1) Top level abstraction:
public abstract class Vehicle {}

//2) Implementation:
public class Lada : Vehicle {}
public class Volvo : Vehicle {}

//3) Lower level abstraction:
public class LCar : Lada {}
public class LTruck : Lada {}
public class VCar : Volvo {}
public class VTruck : Volvo {}
//Exponential effect, adding one more implementation 
//(ex. public class BMW : Vehicle {}) results
//with 2 more lower level abstractions.
//We don't have linear scaling.

//---------------
//Try to re-arrange
//---------------

//2) Lower level abstraction:
public class Car : Vehicle {}
public class Truck : Vehicle {}

//3) Implementations:
public class L2Car : Car {}
public class L2Truck : Truck {}
public class V2Car : Car {}
public class V2Truck : Truck {}