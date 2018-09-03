using Dapper;
using Persons.Entities;
using Persons.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Z.Dapper.Plus;

namespace Persons.Repositories
{
	public class PersonRepository: IPersonRepository
	{
		protected readonly IDbConnection _connection;

		public PersonRepository(IDbConnection connection)
		{
			_connection = connection;
		}

		public Person Find(Guid id)
		{
			string sql = @"select Id, BirthDate, Name
							from Person
							where Id = @id";

			return _connection.QueryFirstOrDefault<Person>(sql, new { id });
		}

		public void Insert(Person entity)
		{
			var result = _connection.BulkInsert(new List<Person>() { entity });			
		}
	}
}
