namespace Senai.Chamados.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cria_Tabela_Chamado_04_07_2018 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChamadoDomains",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Titulo = c.String(),
                        Descricao = c.String(),
                        Setor = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IdUsuario = c.Guid(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChamadoDomains", "IdUsuario", "dbo.Usuarios");
            DropIndex("dbo.ChamadoDomains", new[] { "IdUsuario" });
            DropTable("dbo.ChamadoDomains");
        }
    }
}
