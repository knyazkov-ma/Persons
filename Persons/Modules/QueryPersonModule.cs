using Nancy;
using Persons.Abstractions.Queries;
using Persons.Abstractions.Queries.Dto;
using System;

namespace Persons.Modules
{
	public class QueryPersonModule : NancyModule
	{
		private readonly IQuery<Guid, PersonDto> _personQuery;
		
		public QueryPersonModule(IQuery<Guid, PersonDto> personQuery)
			: base("/api/v1/persons")
		{

			_personQuery = personQuery;			

			Get["/{id:guid}"] = parameters =>
			{
				var result = _personQuery.Get(parameters.id);
				if(result == null)
					return HttpStatusCode.NoContent;

				return FormatterExtensions.AsJson(Response, result, HttpStatusCode.OK);
			};
			
		}
	}
}
