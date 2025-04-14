namespace WebApiTemplate.Infrastructure;

public class AppConfiguration
{
    private readonly IConfiguration _config;

    public string ASPNETCORE_ENVIRONMENT { get; set; }
    public string CONNECTION_STRING { get; }
    
    public AppConfiguration(IConfiguration config) {
        _config = config;
        ASPNETCORE_ENVIRONMENT = GetNonEmptyString(nameof(ASPNETCORE_ENVIRONMENT));
        CONNECTION_STRING = GetNonEmptyString(nameof(CONNECTION_STRING));
    }

    public  string GetNonEmptyString(string key) {
        var value = _config[key];
        if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(key); }

        return value;
    }
}
