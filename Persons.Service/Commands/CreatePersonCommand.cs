using Persons.Abstractions.Commands;
using Persons.Abstractions.Commands.Parameters;
using Persons.Entities;
using Persons.Repositories.Interfaces;

namespace Persons.Commands
{
	public class CreatePersonCommand : ICommand<CreatePersonParameter, CreatePersonResult>
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
