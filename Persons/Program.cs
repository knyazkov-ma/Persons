using Nancy.Hosting.Self;
using System;

namespace Persons
{
	class Program
	{
		static void Main(string[] args)
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
	}
}
