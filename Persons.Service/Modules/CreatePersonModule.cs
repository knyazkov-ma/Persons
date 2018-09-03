using Nancy;
using Nancy.ModelBinding;
using Persons.Abstractions.CommandHandlers;
using Persons.Abstractions.Commands;
using Persons.Commands.Parameters;
using Persons.Service.Models;

namespace Persons.Service.Modules
{
	public class CreatePersonModule : NancyModule
	{
		private readonly ICommand<CreatePersonParameter, CreatePersonResult> _createPersonCommand;
		private readonly ICommandHandler _commandHandler;

		public CreatePersonModule(
			ICommand<CreatePersonParameter, CreatePersonResult> createPersonCommand,
			ICommandHandler commandHandler)
			: base("/api/v1/persons")
		{
			_createPersonCommand = createPersonCommand;
			_commandHandler = commandHandler;

			Post["/"] = parameters =>
			{

				var createPersonModel = this.Bind<CreatePersonModel>();
				if (!createPersonModel.BirthDate.HasValue)
					return HttpStatusCode.BadRequest;

				var param = new CreatePersonParameter
				{
					BirthDate = createPersonModel.BirthDate.Value,
					Name = createPersonModel.Name
				};
				var result = _commandHandler.Handle<CreatePersonParameter, CreatePersonResult, ICommand<CreatePersonParameter, CreatePersonResult>>(param, _createPersonCommand);

				if (result.Type ==  CreatePersonResultType.UncorrectEntity)
					return HttpStatusCode.UnprocessableEntity;

				return Response.AsText(null)
					.WithStatusCode(HttpStatusCode.Created)
					.WithHeader("Location", $"/api/v1/persons/{result.Id}");
			};
		}
	}
}
