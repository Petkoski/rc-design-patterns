<Query Kind="Program" />

//Virtual proxy - lazy initialization

public interface ISettings
{
	string GetConfig();
}

public class Settings : ISettings
{
	string _config;
	
	public Settings(string config) => _config = config;
	
	public string GetConfig() => _config;
}

public class LazyRemoteSettings : ISettings
{
	Settings _config;

	public LazyRemoteSettings(string address)
	{
		//Prepare some http/db
	}

	//Lazy instantiation - deferring the instantiation (until it is 
	//actually used), instead of putting it in a constructor.
	//Then cache the work once the settings are loaded (in _config).
	public string GetConfig()
	{
		if (_config == null)
		{
			//Fetch from appsettings/db/registry etc...
			_config = new Settings("config");
		}
		return "";
	}
}

void Main()
{
	//Another example: implementation of virtual proxy that C# provides
	var a = new Lazy<string>(() => "Hello World".Dump("a"));
	var b = a.Value;
	var c = a.Value;
	//Output is produced only once (first a.Value assigned to b), second
	//time value is already cached.
}