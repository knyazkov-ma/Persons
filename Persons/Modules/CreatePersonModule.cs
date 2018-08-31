using Nancy;
using Nancy.ModelBinding;
using Persons.Abstractions.Commands;
using Persons.Abstractions.Commands.Parameters;
using Persons.Models;
using Serilog;

namespace Persons.Modules
{
	public class CreatePersonModule : NancyModule
	{
		//private static readonly ILog Logger = LogProvider.For<CreatePersonModule>();

		private readonly ICreatePersonCommand _createPersonCommand;

		public CreatePersonModule(ICreatePersonCommand createPersonCommand)
			: base("/api/v1/persons")
		{
			_createPersonCommand = createPersonCommand;

			Post["/"] = parameters =>
			{

				var createPersonModel = this.Bind<CreatePersonModel>();
				if (!createPersonModel.BirthDate.HasValue)
					return HttpStatusCode.BadRequest;

				var result = createPersonCommand.Run(new CreatePersonParameter
				{
					BirthDate = createPersonModel.BirthDate.Value,
					Name = createPersonModel.Name
				});

				if (result.Type ==  CreatePersonResultType.UncorrectEntity)
					return HttpStatusCode.UnprocessableEntity;

				return Response.AsText(null)
					.WithStatusCode(HttpStatusCode.Created)
					.WithHeader("Location", $"/api/v1/persons/{result.Id}");
			};
		}
	}
}
