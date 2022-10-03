using DiscordRPC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazeRPC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = Host.CreateDefaultBuilder(args);

                builder.ConfigureServices(
                    services =>
                        services
                            .AddSingleton(new DiscordRpcClient("1012486137148883074"))
                            .AddSingleton<RPCClient>()
                        );

                var host = builder.Build();
                var client = host.Services.GetRequiredService<RPCClient>();
                client.RunSetup();

                host.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Exception {ex.Message}");
                return;
            }
        }
    }
}