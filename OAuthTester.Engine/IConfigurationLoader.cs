namespace OAuthTester.Engine;

public interface IConfigurationLoader
{
    void Load();
    void Save();
    OAuthTesterConfiguration Configuration { get; }
}