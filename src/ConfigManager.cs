using Newtonsoft.Json;
using Serilog;
using System.IO;

namespace BlazeRPC
{
    public class ConfigManager
    {
        private readonly ILogger _logger;
        private readonly string _configLocation;
        private readonly string _defaultStringValue = "change_me";

        public ConfigManager()
        {
            var documentLocation = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            _configLocation = Path.Combine(documentLocation, "BlazeRPCConfig.json");
            _logger = Log.ForContext<ConfigManager>();
        }

        public Config GetConfig()
        {
            if (TryInitialize(out var config))
            {
                _logger.Information("Config Created: {0}", config);
                return config;
            }
            else
            {
                _logger.Information("Config not found", "generating new config.");
                var freshConfig = CreateFreshConfig();
                var rawConfig  = JsonConvert.SerializeObject(freshConfig, Formatting.Indented);
                File.WriteAllText(_configLocation, rawConfig);
                return GetConfig();
            }
        }

        private bool TryInitialize(out Config conf)
        {
            if (File.Exists(_configLocation))
            {
                try
                {
                    var rawConfig = File.ReadAllText(_configLocation);
                    var config = JsonConvert.DeserializeObject<Config>(rawConfig);
                    conf = config!;
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    throw;
                }
            }
            else
            {                    
                conf = new();
                return false;

            }
        }

        private Config CreateFreshConfig() => new()
        {
            Client_ID = _defaultStringValue,
            LargeImageAlt = _defaultStringValue,
            SmallImageAlt = _defaultStringValue,
            LargeImageName = _defaultStringValue,
            SmallImageName = _defaultStringValue, 
            Details = _defaultStringValue,
            State = _defaultStringValue,
            Buttons = new()
            {
                new()
                {
                    Name = _defaultStringValue,
                    Url = _defaultStringValue,
                }
            }
        };

    }
}
