using Persons.Abstractions.Commands;
using Persons.Abstractions.Commands.Parameters;
using Persons.Service.Entities;
using Persons.Service.Repositories.Interfaces;

namespace Persons.Service.Commands
{
	public class CreatePersonCommand : ICreatePersonCommand
	{
		private readonly IPersonRepository _personRepository;
		public CreatePersonCommand(IPersonRepository personRepository)
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
