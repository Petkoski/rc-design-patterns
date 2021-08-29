<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	//Problem: when size is incremented (from 4 to 20 for example), creating 
	//stops around the number of logical processors.
	int size = 4;
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

	private MemoryCache()
	{
		$"Created {i++}".Dump();
	}
	
	public static MemoryCache Create() {
		//No locking here, no synchronization
		//Each thread will create own MemoryCache instance (which should 
		//not happen).
		return _instance ?? (_instance = new MemoryCache());
	}
}