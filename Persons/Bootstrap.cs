using Persons.Entities;
using Persons.Migrations.Core;
using Z.Dapper.Plus;

namespace Persons
{
	public static class Bootstrap
	{
		public static void Install(string connectionString)
		{
			var migrationRunner = new MigrationRunner(connectionString);
			migrationRunner.Update();

			DapperPlusManager.Entity<Person>()
				.Table("person")
				.Map(x => x.Id, "id")
				.Map(x => x.Name, "name")
				.Map(x => x.BirthDate, "birthdate")
				.Identity(x => x.Id);
		}
	}
}
