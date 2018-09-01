namespace Persons.Abstractions.Commands
{
	public interface ICommand<TParam, TResult>
	{
		TResult Run(TParam param);
	}
}
