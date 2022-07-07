namespace OAuthTester.Engine;

public interface IConfigurationManager
{
    void Load();
    void Save();
    OAuthTesterConfiguration Current { get; }
}