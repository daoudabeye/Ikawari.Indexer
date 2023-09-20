using Blockcore.Indexer;
using Blockcore.Indexer.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Additionnal Config From Env By Beye
var confBuilder = new DefaultConfiguration().CreateConfigurationBuilder(args);
IConfiguration conf = confBuilder.Build();
builder.WebHost.UseConfiguration(conf);
//------

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<HostOptions>(option =>
{
	// the BlockStore task can take long time to complete
	// to avoid rewind on shutdown we allow it extra time
	option.ShutdownTimeout = System.TimeSpan.FromSeconds(20);
});
//AddBlockcore("Blockore Indexer", args);

builder.Configuration.AddBlockcore("Blockore Indexer", args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
	serverOptions.AddServerHeader = false;
});

//var conf = new DefaultConfiguration() { Logger = Logs.Configuration }.CreateConfiguration(args);
// Sanity check of the config, this is not strictly needed as it would happen down the line when the host is built
// However, a bug in .NET Core fixed in 2.1 will prevent the app from stopping if an exception is thrown by the host
// at startup. We need to remove this line later
//new ExplorerConfiguration().LoadArgs(conf);

//webBuilder.UseConfiguration(conf);
//builder.WebHost.UseStartup<BlockcoreStartup>();
var startup = new BlockcoreStartup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, builder.Environment);


app.Run();
