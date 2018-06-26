namespace Senai.Chamados.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Senai.Chamados.Data.Contexto.SenaiChamadosDBContext>
    {
        public Configuration()
        {
             AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Senai.Chamados.Data.Contexto.SenaiChamadosDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
