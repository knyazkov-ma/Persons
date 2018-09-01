using Nancy;
using Persons.Abstractions.Queries;
using Persons.Abstractions.Queries.Dto;
using Persons.Abstractions.QueryHandlers;
using System;

namespace Persons.Service.Modules
{
	public class QueryPersonModule : NancyModule
	{
		private readonly IQuery<Guid, PersonDto> _personQuery;
		private readonly IQueryHandler _queryHandler;
		public QueryPersonModule(IQuery<Guid, PersonDto> personQuery,
			IQueryHandler queryHandler)
			: base("/api/v1/persons")
		{
			_personQuery = personQuery;
			_queryHandler = queryHandler;			

			Get["/{id:guid}"] = parameters =>
			{
				var result = _queryHandler.Handle<Guid, PersonDto, IQuery<Guid, PersonDto>>(parameters.id, _personQuery);
				if(result == null)
					return HttpStatusCode.NoContent;

				return FormatterExtensions.AsJson(Response, result, HttpStatusCode.OK);
			};
			
		}
	}
}
