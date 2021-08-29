<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//Solution: make sure only one MemoryCache instance gets created.

void Main()
{
	int size = 8;
	Task[] tasks = new Task[size];
	for (int i = 0; i < size; i++)
	{
		//Recreating the MemoryCache on each thread:
		tasks[i] = Task.Run(() => MemoryCache.Create());
	}
	Task.WaitAll(tasks);
}

public class MemoryCache
{
	private static int i = 0;
	private static MemoryCache _instance;
	
	//Static ctor:
	//As soon as app starts - it RUNS the static ctor (downfall: having 1000
	//singletons with static ctor, takes time to load them).
	//Also hard to manage dependencies with static ctor.
	static MemoryCache()
	{
		_instance = new MemoryCache();
	}

	private MemoryCache()
	{
		$"Created {i++}".Dump();
	}
	
	public static MemoryCache Create() {
		return _instance;
	}
}