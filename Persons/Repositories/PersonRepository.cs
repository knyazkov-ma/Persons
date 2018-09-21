using Persons.Entities;
using System;
using System.Data;

namespace Persons.Repositories
{
	public class PersonRepository: BaseRepository<Person, Guid>
	{
		public PersonRepository(IDbConnection connection)
			:base(connection)
		{
			
		}
		
	}
}
