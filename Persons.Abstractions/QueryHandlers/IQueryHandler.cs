using Persons.Abstractions.Queries;

namespace Persons.Abstractions.QueryHandlers
{
	public interface IQueryHandler<TQuery, TDto>
		where TQuery : Query<TDto>
	{
		TDto Execute(TQuery query);
	}
}
