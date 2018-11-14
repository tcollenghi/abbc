namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CodCidade = c.Int(nullable: false),
                        CodEstado = c.Int(nullable: false),
                        NomeCidade = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CodEstado = c.Int(nullable: false),
                        CodPais = c.Int(nullable: false),
                        SglEstado = c.String(),
                        NomeEstado = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CodPais = c.Int(nullable: false),
                        SglPais = c.String(),
                        NomePais = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pais");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
        }
    }
}
