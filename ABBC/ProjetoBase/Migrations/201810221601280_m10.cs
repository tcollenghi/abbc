namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        DataAlteracao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Turma");
        }
    }
}
