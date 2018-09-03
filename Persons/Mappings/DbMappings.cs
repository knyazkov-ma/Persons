using Persons.Entities;
using Z.Dapper.Plus;

namespace Persons.Mappings
{
	public static class DbMappings
	{
		public static void Configure()
		{
			DapperPlusManager.Entity<Person>()
				.Table("person")
				.Map(x => x.Id, "id")
				.Map(x => x.Name, "name")
				.Map(x => x.BirthDate, "birthdate")
				.Identity(x => x.Id);
		}
	}
}
