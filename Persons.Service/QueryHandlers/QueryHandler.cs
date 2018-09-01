using Persons.Abstractions.Queries;
using Persons.Abstractions.QueryHandlers;

namespace Persons.QueryHandlers
{
	public class QueryHandler: IQueryHanler
	{
		public TDto Handle<TParam, TDto, TQuery>(TParam param, TQuery query)
			where TQuery : IQuery<TParam, TDto>
		{
			return query.Get(param);
		}
	}
}
