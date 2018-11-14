namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanoPagamento",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        NumeroParcelas = c.Int(nullable: false),
                        Periodicidade = c.String(),
                        DataPrimeiraParcela = c.DateTime(nullable: false),
                        Desconto = c.String(),
                        Juros = c.String(),
                        Multa = c.String(),
                        DataAlteracao = c.DateTime(nullable: false),
                        UsuarioAlteracao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlanoPagamento");
        }
    }
}
