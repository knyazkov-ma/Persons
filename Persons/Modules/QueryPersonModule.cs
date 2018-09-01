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
		private readonly IQueryHanler _queryHanler;
		public QueryPersonModule(IQuery<Guid, PersonDto> personQuery,
			IQueryHanler queryHanler)
			: base("/api/v1/persons")
		{
			_personQuery = personQuery;
			_queryHanler = queryHanler;			

			Get["/{id:guid}"] = parameters =>
			{
				var result = _queryHanler.Handle(parameters.id, _personQuery);
				if(result == null)
					return HttpStatusCode.NoContent;

				return FormatterExtensions.AsJson(Response, result, HttpStatusCode.OK);
			};
			
		}
	}
}
