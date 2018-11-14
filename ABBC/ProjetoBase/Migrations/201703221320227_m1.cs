namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        nomeUsuario = c.String(),
                        menu = c.String(),
                        opcao = c.String(),
                        acao = c.String(),
                        method = c.String(maxLength: 4),
                        data = c.DateTime(nullable: false),
                        Usuario_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuario", t => t.Usuario_ID)
                .Index(t => t.Usuario_ID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        nome = c.String(),
                        login = c.String(),
                        senha = c.String(),
                        email = c.String(),
                        funcao = c.String(),
                        ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Log", "Usuario_ID", "dbo.Usuario");
            DropIndex("dbo.Log", new[] { "Usuario_ID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Log");
        }
    }
}
