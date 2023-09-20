using System.Net;
using System.Text;
using CommandLine;
using static DBreeze.DBreezeResources;

namespace Blockcore.Indexer
{
	public class DefaultConfiguration : Kiwi.Tools.StandardConfiguration.DefaultConfiguration
    {
        protected override CommandLineApplication CreateCommandLineApplicationCore()
        {
            CommandLineApplication app = new CommandLineApplication(true)
            {
                FullName = "Kiwi\r\n, self-hosted App.",
                Name = "Kiwi App"
            };
            app.HelpOption("-? | -h | --help");
			app.Option("--config", $"Config file name", CommandOptionType.SingleValue);
			app.Option("--postgres", $"Connection string to a PostgreSQL database", CommandOptionType.SingleValue);
			app.Option("--chain", $"Connection string to a PostgreSQL database", CommandOptionType.SingleValue);
			app.Option("--local", $"Connection string to a PostgreSQL database", CommandOptionType.NoValue);

			return app;
        }

		protected override string GetDefaultDataDir(IConfiguration conf)
		{
			return Kiwi.Tools.StandardConfiguration.DefaultDataDirectory.GetDirectory("KiwiData", "App");
		}

		protected override string GetDefaultConfigurationFile(IConfiguration conf)
		{
			return Path.Combine(GetDefaultDataDir(conf), "settings.config");
		}

		protected override string GetDefaultConfigurationFileTemplate(IConfiguration conf)
		{
			return "";
		}

		protected override IPEndPoint GetDefaultEndpoint(IConfiguration conf)
		{
			return null ;
		}

		public override string EnvironmentVariablePrefix => "IDX_";

	}
}
