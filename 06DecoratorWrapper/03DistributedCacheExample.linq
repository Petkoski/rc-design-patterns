<Query Kind="Program">
  <NuGetReference>Microsoft.Extensions.Caching.Abstractions</NuGetReference>
  <Namespace>Microsoft.Extensions.Caching.Distributed</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//Real-world example with known cache interface (IDistributedCache)
//Distributed part means the interface requires to work with byte[]

void Main()
{

}

public class KeyPrefixedCache : IDistributedCache
{
	IDistributedCache _cache;
	string _prefix;

	//Original object (IDistributedCache) passed to constructor.
	public KeyPrefixedCache(IDistributedCache cache, string prefix)
	{
		_cache = cache;
		_prefix = prefix;
	}

	//We have the original cache (IDistributedCache) decorated with
	//functionality of prefixing all the keys.
	private string PrefixKey(string key) => $"{_prefix}_{key}";

	public byte[] Get(string key) =>
		_cache.Get(PrefixKey(key));

	public Task<byte[]> GetAsync(string key, CancellationToken token = default) =>
		_cache.GetAsync(PrefixKey(key), token)

	public void Refresh(string key) =>
		_cache.Refresh(PrefixKey(key));

	public Task RefreshAsync(string key, CancellationToken token = default) =>
		_cache.RefreshAsync(PrefixKey(key), token);

	public void Remove(string key) =>
		_cache.Remove(PrefixKey(key));

	public Task RemoveAsync(string key, CancellationToken token = default) =>
		_cache.RemoveAsync(PrefixKey(key), token)

	public void Set(string key, byte[] value, DistributedCacheEntryOptions options) =>
		_cache.Set(PrefixKey(key), value, options);

	public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default) =>
		_cache.SetAsync(PrefixKey(key), value, options, token);
}