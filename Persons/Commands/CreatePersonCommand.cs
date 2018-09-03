using Persons.Abstractions.Commands;
using Persons.Abstractions.Repositories;
using Persons.Commands.Parameters;
using Persons.Entities;
using System;

namespace Persons.Commands
{
	public class CreatePersonCommand : ICommand<CreatePersonParameter, CreatePersonResult>
	{
		
		private readonly IRepository<Person, Guid> _personRepository;
		public CreatePersonCommand(IRepository<Person, Guid> personRepository)
		{
			_personRepository = personRepository;
		}

		public CreatePersonResult Run(CreatePersonParameter param)
		{
			var entity = Person.Create(param.BirthDate, param.Name);

			if (entity == null)
				return new CreatePersonResult { Type = CreatePersonResultType.UncorrectEntity };

			_personRepository.Insert(entity);

			return new CreatePersonResult
			{
				Type = CreatePersonResultType.OK,
				Id = entity.Id
			};
		}
	}
}
