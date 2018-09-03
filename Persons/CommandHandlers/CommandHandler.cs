using Persons.Abstractions.CommandHandlers;
using Persons.Abstractions.Commands;
using Persons.Logging;

namespace Persons.CommandHandlers
{
	public class CommandHandler : ICommandHandler
	{
		private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();
				
		public TResult Handle<TParam, TResult, TCommand>(TParam param, TCommand command)
			where TCommand : ICommand<TParam, TResult>
		{
			Logger.Log(LogLevel.Info, () =>
			{
				return $"{command.GetType().Name}: {param.ToString()}";
			});

			return command.Run(param);
		}
	}

}
