using Persons.Abstractions.Queries;

namespace Persons.Abstractions.QueryHandlers
{
	public interface IQueryHandler
	{
		TDto Handle<TParam, TDto, TQuery>(TParam param, TQuery query)
			where TQuery: IQuery<TParam, TDto>;
	}
}
