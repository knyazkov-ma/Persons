using Persons.Abstractions.Entities;
using Persons.Abstractions.Repositories;
using System.Data;

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

		public abstract TEntity Find(TKey id);
		public abstract void Insert(TEntity entity);
	}
}
