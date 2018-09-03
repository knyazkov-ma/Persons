using AutoMapper;
using Persons.Abstractions.Queries;
using Persons.Queries.Dto;
using Persons.Repositories.Interfaces;
using System;

namespace Persons.Queries
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
			
			return Mapper.Map<PersonDto>(entity);
		}
	}
}
