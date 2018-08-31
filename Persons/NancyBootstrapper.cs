using Nancy;
using Nancy.TinyIoc;
using Npgsql;
using Persons.Abstractions.Commands;
using Persons.Abstractions.Queries;
using Persons.Abstractions.Queries.Dto;
using Persons.Service.Commands;
using Persons.Service.Queries;
using Persons.Service.Repositories;
using Persons.Service.Repositories.Interfaces;
using System;
using System.Configuration;
using System.Data;

namespace Persons
{
	public class NancyBootstrapper: DefaultNancyBootstrapper
	{
		private const string connectionStringName = "Persons";
		private string connectionString;
		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
			
			Persons.Service.Bootstrap.Install(connectionString);

			base.ConfigureApplicationContainer(container);
		}

		protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
		{
			var npgsqlConnection = new NpgsqlConnection(connectionString);
			//container.Register<IDbConnection, NpgsqlConnection>().UsingConstructor(() => new NpgsqlConnection(connectionString));
			container.Register<IDbConnection, NpgsqlConnection>(npgsqlConnection);

			container.Register<IPersonRepository, PersonRepository>().AsSingleton();

			container.Register<ICreatePersonCommand, CreatePersonCommand>().AsSingleton();
			container.Register<IQuery<Guid, PersonDto>, PersonQuery>().AsSingleton();			

			base.ConfigureRequestContainer(container, context);
		}
	}
}
