namespace DBTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DBTest.DataAccessLayer.ServerContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "DBTest.DataAccessLayer.ServerContext";
        }

        protected override void Seed(DBTest.DataAccessLayer.ServerContext context)
        {
           
        }
    }
}
