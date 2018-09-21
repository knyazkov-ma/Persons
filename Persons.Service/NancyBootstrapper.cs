using Nancy;
using Nancy.TinyIoc;
using Npgsql;
using Persons.Abstractions.CommandHandlers;
using Persons.Abstractions.Commands;
using Persons.Abstractions.Dto;
using Persons.Abstractions.Queries;
using Persons.Abstractions.QueryHandlers;
using Persons.Abstractions.Repositories;
using Persons.CommandHandlers;
using Persons.Entities;
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

			container.Register<IQueryHandler<GetPersonQuery, PersonDto>, 
				GetPersonQueryHandler>().AsSingleton();
			container.Register<ICommandHandler<CreatePersonCommand, CreatePersonCommand.CreatePersonResult>, 
				CreatePersonCommandHandler>().AsSingleton();
									

			base.ConfigureRequestContainer(container, context);
		}
	}
}
