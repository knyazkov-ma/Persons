using AutoMapper;
using Persons.Abstractions.Dto;
using Persons.Entities;


namespace Persons.Mappings
{
	public static class EntityDtoMappings
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
