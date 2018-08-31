namespace Persons.Abstractions.Queries
{
	public interface IQuery<TParam, TDto>
	{
		TDto Get(TParam param);
	}
}
