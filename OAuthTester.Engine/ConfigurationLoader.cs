using Newtonsoft.Json;

namespace OAuthTester.Engine
{
    public class ConfigurationLoader : IConfigurationManager
    {
        public ConfigurationLoader()
        {
            Current = OAuthTesterConfiguration.New();
        }

        public OAuthTesterConfiguration Current { get; private set; }

        public void Load()
        {
            // If it exists, deserialize a state file.
            if (File.Exists("configuration.json"))
            {
                using var streamReader = File.OpenText("configuration.json");
                var content = streamReader.ReadToEnd();
                var instance = JsonConvert.DeserializeObject<OAuthTesterConfiguration>(content);
                if (instance != null)
                {
                    Current = instance;
                }
            }
        }

        public void Save()
        {
            var configurationText = JsonConvert.SerializeObject(Current);
            if (File.Exists("configuration.json"))
            {
                File.Delete("configuration.json");
            }

            using var writer = File.CreateText("configuration.json");
            writer.Write(configurationText);
            writer.Flush();
        }
    }
}
