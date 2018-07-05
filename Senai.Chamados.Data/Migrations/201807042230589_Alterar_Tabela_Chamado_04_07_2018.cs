namespace Senai.Chamados.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alterar_Tabela_Chamado_04_07_2018 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ChamadoDomains", newName: "Chamados");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Chamados", newName: "ChamadoDomains");
        }
    }
}
