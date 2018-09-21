using Persons.Abstractions.Dto;
using System;

namespace Persons.Abstractions.Queries
{
	public class GetPersonQuery: Query<PersonDto>
	{
		public Guid Id { get; set; }
	}
}
