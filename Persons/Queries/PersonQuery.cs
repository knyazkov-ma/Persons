using AutoMapper;
using Persons.Abstractions.Queries;
using Persons.Abstractions.Repositories;
using Persons.Entities;
using Persons.Queries.Dto;
using System;

namespace Persons.Queries
{
	public class PersonQuery : IQuery<Guid, PersonDto>
	{
		private readonly IRepository<Person, Guid> _personRepository;
		public PersonQuery(IRepository<Person, Guid> personRepository)
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
