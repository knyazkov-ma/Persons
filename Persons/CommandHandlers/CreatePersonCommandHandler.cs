using Persons.Abstractions.CommandHandlers;
using Persons.Abstractions.Commands;
using Persons.Abstractions.Repositories;
using Persons.Entities;
using System;

namespace Persons.CommandHandlers
{
	public class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand, CreatePersonCommand.CreatePersonResult>
	{
		
		private readonly IRepository<Person, Guid> _personRepository;
		public CreatePersonCommandHandler(IRepository<Person, Guid> personRepository)
		{
			_personRepository = personRepository;
		}

		public CreatePersonCommand.CreatePersonResult Execute(CreatePersonCommand command)
		{
			//Logger.Log(Logging.LogLevel.Info, () =>
			//{
			//	return $"{command.GetType().Name}: {param.ToString()}";
			//});

			var entity = Person.Create(command.BirthDate, command.Name);

			if (entity == null)
				return new CreatePersonCommand.CreatePersonResult { Type = ResultType.UncorrectEntity };

			_personRepository.Insert(entity);

			return new CreatePersonCommand.CreatePersonResult
			{
				Type = ResultType.OK,
				Id = entity.Id
			};
		}
		
	}
}
