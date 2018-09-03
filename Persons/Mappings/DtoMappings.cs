using AutoMapper;
using Persons.Entities;
using Persons.Queries.Dto;

namespace Persons.Mappings
{
	public static class DtoMappings
	{
		public static void Configure()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<Person, PersonDto>();

				cfg.AllowNullCollections = true;
			});
			Mapper.AssertConfigurationIsValid();
		}
	}
}
