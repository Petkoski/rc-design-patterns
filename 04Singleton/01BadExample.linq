<Query Kind="Program" />

//MemoryCache - example of a singleton (persistent cache is required).
//Below example is not ideal solution for multithreaded environment.

void Main()
{
	MemoryCache.Create();
	MemoryCache.Create();
	MemoryCache.Create();
	MemoryCache.Create();
	MemoryCache.Create();
}

public class MemoryCache
{
	//Instance is static:
	private static MemoryCache _instance;
	
	//Private ctor, accessible just from within the class:
	private MemoryCache() {
		"Created".Dump();
	}
	
	public static MemoryCache Create() {
		return _instance ?? (_instance = new MemoryCache());
	}
}