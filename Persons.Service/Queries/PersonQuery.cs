using Persons.Abstractions.Queries;
using Persons.Abstractions.Queries.Dto;
using Persons.Service.Repositories.Interfaces;
using System;

namespace Persons.Service.Queries
{
	public class PersonQuery : IQuery<Guid, PersonDto>
	{
		private readonly IPersonRepository _personRepository;
		public PersonQuery(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		public PersonDto Get(Guid id)
		{
			var entity = _personRepository.Find(id);
			if (entity == null)
				return null;

			return new PersonDto
			{
				Id = entity.Id,
				Age = entity.Age,
				BirthDate = entity.BirthDate,
				Name = entity.Name
			};
		}
	}
}
