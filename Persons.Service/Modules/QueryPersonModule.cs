using Nancy;
using Persons.Abstractions.Queries;
using Persons.Abstractions.QueryHandlers;
using Persons.Abstractions.Dto;

namespace Persons.Service.Modules
{
	public class QueryPersonModule : NancyModule
	{
		public QueryPersonModule(IQueryHandler<GetPersonQuery, PersonDto> getPersonQueryHandler)
			: base("/api/v1/persons")
		{
			Get["/{id:guid}"] = parameters =>
			{
				var result = getPersonQueryHandler.Execute(new GetPersonQuery { Id = parameters.id });
				if(result == null)
					return HttpStatusCode.NoContent;

				return FormatterExtensions.AsJson(Response, result, HttpStatusCode.OK);
			};
			
		}
	}
}
