namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        CargaHoraria = c.String(),
                        DataAlteracao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Curso");
        }
    }
}
