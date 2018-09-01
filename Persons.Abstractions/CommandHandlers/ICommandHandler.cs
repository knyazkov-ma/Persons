using Persons.Abstractions.Commands;

namespace Persons.Abstractions.CommandHandlers
{
	public interface ICommandHandler
	{
		TResult Handle<TParam, TResult, TCommand>(TParam param, TCommand command)
			where TCommand : ICommand<TParam, TResult>;		
	}
}
