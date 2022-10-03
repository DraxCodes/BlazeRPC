using DiscordRPC;
using Serilog;
using Serilog.Events;

namespace BlazeRPC
{
    public class RPCClient
    {
        private readonly DiscordRpcClient _client;
        private readonly ILogger _logger;
        private readonly Config _config;

        public RPCClient(DiscordRpcClient client, Config config)
        {
            _client = client;
            _config = config;
            _logger = Log.ForContext<RPCClient>();

            SetupEvents();
        }

        private void SetupEvents()
        {
            _client.OnReady += (sender, e) =>
            {
                _logger.Information("Received Ready from user {0}", e.User.Username);
            };

            _client.OnPresenceUpdate += (sender, e) =>
            {
                _logger.Information("Received Update! {0}", e.Presence);
            };

        }

        public void RunSetup()
        {
            _logger.Verbose("Client Initializing...");
            _client.Initialize();
            _logger.Verbose("Client Initialized: {0}", _client.IsInitialized);

            _logger.Verbose("Setting up buttons");
            var buttons = new Button[] {
                new Button {
                    Label = "Join TPH",
                    Url = "https://discord.gg/programming"
                },
                new Button {
                    Label = "My Links",
                    Url = "https://links.joelparkinson.me"
                }
            };

            _client.SetPresence(new RichPresence()
            {
                Details = "Example Project",
                State = "csharp example",
                Assets = new Assets()
                {
                    LargeImageKey = "tphlogo",
                    LargeImageText = "The Programmers Hangout",
                    SmallImageKey = "avatar"
                },
                Buttons = buttons
            });

        }
    }
}