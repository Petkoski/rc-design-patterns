<Query Kind="Program" />

//Remote proxy example - load object from some location

void Main()
{

}

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

public class RemoteSettings : ISettings
{
	Settings _config;
	
	public RemoteSettings(string address)
	{
		//Fetch from appsettings/db/registry etc.
		//Instantiating in the constructor.
		_config = new Settings("config");
	}

	public string GetConfig() {
		return "";
	}
}