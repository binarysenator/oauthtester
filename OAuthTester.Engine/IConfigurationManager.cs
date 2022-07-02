namespace OAuthTester.Engine;

public interface IConfigurationManager
{
    void Load();
    void Save();
    OAuthTesterConfiguration Configuration { get; }
}