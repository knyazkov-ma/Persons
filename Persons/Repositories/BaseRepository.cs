using Dapper;
using Persons.Abstractions.Entities;
using Persons.Abstractions.Repositories;
using System.Collections.Generic;
using System.Data;
using Z.Dapper.Plus;

namespace Persons.Repositories
{
	public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
		where TEntity : BaseEntity<TKey>
		where TKey : struct
	{
		protected readonly IDbConnection _connection;

		public BaseRepository(IDbConnection connection)
		{
			_connection = connection;
		}

		public virtual TEntity Find(TKey id)
		{
			string sql = $"select *	from {typeof(TEntity).Name}	where Id = @id";

			return _connection.QueryFirstOrDefault<TEntity>(sql, new { id });
		}

		public virtual void Insert(TEntity entity)
		{
			var result = _connection.BulkInsert(new List<TEntity>() { entity });
		}
	}
}
