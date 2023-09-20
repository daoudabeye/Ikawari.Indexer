using Blockcore.Indexer.Core;

namespace Blockcore.Indexer
{
    public class BlockcoreStartup
   {
      public IConfiguration Configuration { get; }

      public BlockcoreStartup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public void ConfigureServices(IServiceCollection services)
      {
        Startup.AddIndexerServices(services, Configuration);
        services.AddHttpClient();
        /*services.AddHttpClient(nameof(IRPCClients), httpClient =>
        {
            httpClient.Timeout = System.Threading.Timeout.InfiniteTimeSpan;
        });*/
        //services.ConfigureNBxplorer(Configuration);
        //services.AddNBXplorer(Configuration);
        }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         Startup.Configure(app, env);
      }
   }
}
