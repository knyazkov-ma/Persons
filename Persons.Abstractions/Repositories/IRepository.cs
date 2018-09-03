using Persons.Abstractions.Entities;


namespace Persons.Abstractions.Repositories
{
	public interface IRepository<TEntity, TKey> 
		where TEntity: BaseEntity<TKey>
		where TKey : struct
	{
		TEntity Find(TKey id);

		void Insert(TEntity entity);
	}
}
