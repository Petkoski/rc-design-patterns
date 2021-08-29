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
	private static object _cacheLock = new object();

	private MemoryCache()
	{
		$"Created {i++}".Dump();
	}

	public static MemoryCache Create()
	{
		if (_instance == null)
		{
			//Locking an object - don't want multiple threads to enter this 
			//scope of execution
			//When 10 threads come in to instantiate the MemoryCache, the
			//lock will allow only one to do that.
			//Ideally let the DI container maintain the Singleton.
			lock (_cacheLock)
			{
				if (_instance == null)
				{
					return _instance = new MemoryCache();
				}
			}
		}

		return _instance;
	}
}