using FluentMigrator;
using System;

namespace Persons.Migrations
{
    [Migration(20180831200000, "InitialDeployment")]
    public class InitialDeployment : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Script(AppDomain.CurrentDomain.BaseDirectory + @"\Migrations\0001\createdatabase.sql");
        }
    }
}