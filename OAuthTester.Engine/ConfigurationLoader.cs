using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Redbridge.IO;

namespace OAuthTester.Engine
{
    public class ConfigurationLoader : IConfigurationManager
    {
        public ConfigurationLoader()
        {
            Configuration = OAuthTesterConfiguration.New();
        }

        public OAuthTesterConfiguration? Configuration { get; private set; }

        public void Load()
        {
            // If it exists, deserialize a state file.
            if (File.Exists("configuration.json"))
            {
                using var streamReader = File.OpenText("configuration.json");
                var content = streamReader.ReadToEnd();
                Configuration = JsonConvert.DeserializeObject<OAuthTesterConfiguration>(content);
            }
        }

        public void Save()
        {
            var configurationText = JsonConvert.SerializeObject(Configuration);
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
