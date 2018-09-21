using Nancy;
using Nancy.ModelBinding;
using Persons.Abstractions.CommandHandlers;
using Persons.Abstractions.Commands;
using Persons.Service.Models;
using System;

namespace Persons.Service.Modules
{
	public class CreatePersonModule : NancyModule
	{
		public CreatePersonModule(
			ICommandHandler<CreatePersonCommand, CreatePersonCommand.CreatePersonResult> createPersonCommandHandler)
			: base("/api/v1/persons")
		{
			
			Post["/"] = parameters =>
			{

				var createPersonModel = this.Bind<CreatePersonModel>();
				if (createPersonModel.BirthDate > DateTime.Now)
					return HttpStatusCode.BadRequest;

				var cmd = new CreatePersonCommand
				{
					BirthDate = createPersonModel.BirthDate,
					Name = createPersonModel.Name
				};
				var result = createPersonCommandHandler.Execute(cmd);

				if (result.Type ==  ResultType.UncorrectEntity)
					return HttpStatusCode.UnprocessableEntity;

				return Response.AsText(null)
					.WithStatusCode(HttpStatusCode.Created)
					.WithHeader("Location", $"/api/v1/persons/{result.Id}");
			};
		}
	}
}
