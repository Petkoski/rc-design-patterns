<Query Kind="Program" />

//Iterator pattern (also known as cursor, generator)
//In C# more commonly know as IEnumerable (native support for iterator pattern)
//Hides the logic of how to iterate an aggregate of items (list)

void Main()
{
	foreach (var n in NumberIterator(10))
	{
		n.Dump();
	}
}

public IEnumerable<int> NumberIterator(int l){
	for (int i = 0; i < l; i++)
	{
		yield return i;		
	}
}