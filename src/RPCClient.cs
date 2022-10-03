using DiscordRPC;
using DiscordRPC.Logging;

namespace BlazeRPC
{
    public class RPCClient
    {
        private readonly DiscordRpcClient _client;

        public RPCClient(DiscordRpcClient client)
        {
            _client = client;
            _client.Logger = new ConsoleLogger(LogLevel.Info, coloured: true);

            SetupEvents();

            _client.Initialize();
        }

        private void SetupEvents()
        {
            _client.OnReady += (sender, e) =>
            {
                _client.Logger.Info("Received Ready from user {0}", e.User.Username);
            };

            _client.OnPresenceUpdate += (sender, e) =>
            {
                _client.Logger.Info("Received Update! {0}", e.Presence);
            };


        }

        public void RunSetup()
        {
            try
            {
                _client.SetPresence(new RichPresence()
                {
                    Details = "Example Project",
                    State = "csharp example",
                    Assets = new Assets()
                    {
                        LargeImageKey = "tphlogo",
                        LargeImageText = "The Programmers Hangout",
                        SmallImageKey = "avatar"
                    }
                });
            }
            finally
            {
                _client.Dispose();
            }
        }
    }
}