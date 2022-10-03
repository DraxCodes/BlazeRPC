using DiscordRPC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace BlazeRPC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var configManager = new ConfigManager();
                var config = configManager.GetConfig();

                if (config.Client_ID == "change_me")
                {
                    Console.WriteLine("Configeration has not been edited. Please fill out the values for the config.");
                    Console.WriteLine("Program will now Pause, Press Q to exit");
                    while (true)
                    {
                        var key = Console.ReadKey();

                        if (key.Key == ConsoleKey.Q)
                        {
                            Environment.Exit(0);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Verbose)
                            .Enrich.FromLogContext()
                            .WriteTo.Console(LogEventLevel.Verbose)
                            .WriteTo.File("BlazeRPC.log", LogEventLevel.Verbose)
                            .CreateLogger();


                Log.Information("Starting web host");

                var builder = Host.CreateDefaultBuilder(args)
                    .UseSerilog();

                builder.ConfigureServices(
                    services =>
                        services
                            .AddSingleton(new DiscordRpcClient(config.Client_ID))
                            .AddSingleton<RPCClient>()
                            .AddSingleton(config)
                        );

                var host = builder.Build();
                var client = host.Services.GetRequiredService<RPCClient>();
                client.RunSetup();

                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}