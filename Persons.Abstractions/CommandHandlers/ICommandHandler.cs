using Persons.Abstractions.Commands;

namespace Persons.Abstractions.CommandHandlers
{
	public interface ICommandHandler<TCommand, TResult>
		where TCommand : Command
	{
		TResult Execute(TCommand command);		
	}
}
