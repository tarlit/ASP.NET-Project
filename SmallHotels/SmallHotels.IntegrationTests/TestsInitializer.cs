using SmallHotels.Data;
using SmallHotels.Data.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace SmallHotels.IntegrationTests
{
    [TestClass]
    public class TestsInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SmallHotelsEfDbContext, TestDbConfiguration>());
        }
    }

    public sealed class TestDbConfiguration : DbMigrationsConfiguration<SmallHotelsEfDbContext>
    {
        public TestDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}