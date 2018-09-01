using Nancy;
using Nancy.TinyIoc;
using Npgsql;
using Persons.Abstractions.CommandHandlers;
using Persons.Abstractions.Commands;
using Persons.Abstractions.Commands.Parameters;
using Persons.Abstractions.Queries;
using Persons.Abstractions.Queries.Dto;
using Persons.Abstractions.QueryHandlers;
using Persons.CommandHandlers;
using Persons.Commands;
using Persons.Queries;
using Persons.QueryHandlers;
using Persons.Repositories;
using Persons.Repositories.Interfaces;
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
			
			Persons.Bootstrap.Install(connectionString);			

			base.ConfigureApplicationContainer(container);
		}

		protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
		{
			var npgsqlConnection = new NpgsqlConnection(connectionString);
			container.Register<IDbConnection, NpgsqlConnection>(npgsqlConnection);

			container.Register<IPersonRepository, PersonRepository>().AsSingleton();

			container.Register<IQueryHanler, QueryHandler>().AsSingleton();
			container.Register<ICommandHandler, CommandHandler>().AsSingleton();

			container.Register<ICommand<CreatePersonParameter, CreatePersonResult>, CreatePersonCommand>().AsSingleton();
			container.Register<IQuery<Guid, PersonDto>, PersonQuery>().AsSingleton();			

			base.ConfigureRequestContainer(container, context);
		}
	}
}
