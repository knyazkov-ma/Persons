using Nancy;
using Nancy.TinyIoc;
using Npgsql;
using Persons.Abstractions.CommandHandlers;
using Persons.Abstractions.Commands;
using Persons.Abstractions.Queries;
using Persons.Abstractions.QueryHandlers;
using Persons.Abstractions.Repositories;
using Persons.CommandHandlers;
using Persons.Commands;
using Persons.Commands.Parameters;
using Persons.Entities;
using Persons.Queries;
using Persons.Queries.Dto;
using Persons.QueryHandlers;
using Persons.Repositories;
using System;
using System.Configuration;
using System.Data;

namespace Persons.Service
{
	public class NancyBootstrapper: DefaultNancyBootstrapper
	{
		private const string connectionStringName = "Persons";
		private string connectionString;

		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
			
			Persons.GlobalConfiguration.Configure(connectionString);			

			base.ConfigureApplicationContainer(container);
		}

		protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
		{
			var npgsqlConnection = new NpgsqlConnection(connectionString);
			container.Register<IDbConnection, NpgsqlConnection>(npgsqlConnection);

			container.Register<IRepository<Person, Guid>, PersonRepository>().AsSingleton();

			container.Register<IQueryHandler, QueryHandler>().AsSingleton();
			container.Register<ICommandHandler, CommandHandler>().AsSingleton();

			container.Register<ICommand<CreatePersonParameter, CreatePersonResult>, CreatePersonCommand>().AsSingleton();
			container.Register<IQuery<Guid, PersonDto>, PersonQuery>().AsSingleton();			

			base.ConfigureRequestContainer(container, context);
		}
	}
}
