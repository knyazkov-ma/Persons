using AutoMapper;
using Persons.Abstractions.Dto;
using Persons.Abstractions.Queries;
using Persons.Abstractions.QueryHandlers;
using Persons.Abstractions.Repositories;
using Persons.Entities;
using System;

namespace Persons.QueryHandlers
{
	public class GetPersonQueryHandler: IQueryHandler<GetPersonQuery, PersonDto>
	{
		private readonly IRepository<Person, Guid> _personRepository;

		public GetPersonQueryHandler(IRepository<Person, Guid> personRepository)
		{
			_personRepository = personRepository;
		}

		public PersonDto Execute(GetPersonQuery query)
		{
			var entity = _personRepository.Find(query.Id);

			return Mapper.Map<PersonDto>(entity);
		}
		
	}
}
