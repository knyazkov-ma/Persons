using Nancy.Hosting.Self;
using System;

namespace Persons.Service
{
	class HostService
	{
		public void Start()
		{
			HostConfiguration hostConfigs = new HostConfiguration();
			hostConfigs.UrlReservations.CreateAutomatically = true;

			using (var host = new NancyHost(hostConfigs, new Uri("http://localhost:1234")))
			{
				host.Start();
				Console.WriteLine("Running on http://localhost:1234");
				Console.ReadLine();
			}
		}
		public void Stop()
		{
			// write code here that runs when the Windows Service stops.  
		}
	}
}
