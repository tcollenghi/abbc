namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        Nascimento = c.DateTime(nullable: false),
                        CPF = c.String(),
                        RG = c.String(),
                        NivelAcessso = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Funcionario");
        }
    }
}
