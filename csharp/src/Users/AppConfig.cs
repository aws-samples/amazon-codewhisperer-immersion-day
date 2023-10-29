using Microsoft.Extensions.Configuration;

public interface IAppConfig
{
    string GetConnectionString(string name);
    bool EnsureDBCreated { get; }
}

public class AppConfig : IAppConfig
{
    private readonly IConfiguration _configuration;

    public AppConfig(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool EnsureDBCreated => _configuration["EnsureDBCreated"]?.Equals(true.ToString(), StringComparison.OrdinalIgnoreCase) ?? false;

    public string GetConnectionString(string name) => _configuration.GetConnectionString(name);
}
