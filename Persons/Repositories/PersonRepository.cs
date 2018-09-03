using Dapper;
using Persons.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using Z.Dapper.Plus;

namespace Persons.Repositories
{
	public class PersonRepository: BaseRepository<Person, Guid>
	{
		public PersonRepository(IDbConnection connection)
			:base(connection)
		{
			
		}

		public override Person Find(Guid id)
		{
			string sql = @"select Id, BirthDate, Name
							from Person
							where Id = @id";

			return _connection.QueryFirstOrDefault<Person>(sql, new { id });
		}

		public override void Insert(Person entity)
		{
			var result = _connection.BulkInsert(new List<Person>() { entity });			
		}
	}
}
