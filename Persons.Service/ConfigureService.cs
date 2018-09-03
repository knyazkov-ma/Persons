using Serilog;
using Topshelf;

namespace Persons.Service
{
	internal static class ConfigureService
	{
		internal static void Configure()
		{
			Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

			HostFactory.Run(configure =>
			{
				configure.Service<HostService>(service =>
				{
					service.ConstructUsing(s => new HostService());
					service.WhenStarted(s => s.Start());
					service.WhenStopped(s => s.Stop());
				});
				//Setup Account that window service use to run.  
				configure.RunAsLocalSystem();
				configure.SetServiceName("Persons.Service");
				configure.SetDisplayName("Persons.Service");
				configure.SetDescription("Persons.Service");
			});
		}
	}
}
