<Query Kind="Program" />

//Protection proxy - restrict access to object

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

public class ProtectedSettings : ISettings
{
	AuthService _auth;
	Settings _config;

	//Not doing any lazy instantiation
	public ProtectedSettings(AuthService auth)
	{
		_auth = auth;
		_config = new Settings("config");
	}

	//Position in the middle between _config and whatever is using it.
	//Protection proxy restricts access and brings functionality that way.
	//Restricting the fetch of _config.GetConfig().
	public string GetConfig()
	{
		if (!_auth.Allowed)
		{
			throw new Exception("not allowed");
		}
		return _config.GetConfig();
	}
}

public class AuthService
{
	public bool Allowed => false;
}