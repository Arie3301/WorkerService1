using App.WindowsService;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = ".NET Joke Service";
});

if (OperatingSystem.IsWindows()) {
  LoggerProviderOptions.RegisterProviderOptions<
    EventLogSettings, EventLogLoggerProvider>(builder.Services);
}

builder.Services.AddSingleton<JokeService>();
builder.Services.AddSingleton<FileToDiskWriter>();
builder.Services.AddSingleton<TwilioSmsService>();
//builder.Services.AddSingleton<WorldTimeFetcher>();
builder.Services.AddHostedService<WindowsBackgroundService>();

IHost host = builder.Build();
host.Run();