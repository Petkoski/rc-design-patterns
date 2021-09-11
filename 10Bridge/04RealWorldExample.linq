<Query Kind="Program" />

//Other way to implement this is with generics:
//Actual implementation (thing that the list is meant to hold) is separated 
//from the abstraction (list).

void Main()
{
	List<string> stringList = new List<string>();
	ICollection<string> stringCollection = new List<string>();
	IEnumerable<string> stringEnumerable = new List<string>();

	List<int> intList = new List<int>();
	ICollection<int> intCollection = new List<int>();
	IEnumerable<int> intEnumerable = new List<int>();
}