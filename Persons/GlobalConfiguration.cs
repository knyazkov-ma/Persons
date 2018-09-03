using Persons.Mappings;
using Persons.Migrations.Core;

namespace Persons
{
	public static class GlobalConfiguration
	{
		public static void Configure(string connectionString)
		{
			var migrationRunner = new MigrationRunner(connectionString);
			migrationRunner.Update();

			DbEntityMappings.Configure();
			EntityDtoMappings.Configure();
		}
	}
}
