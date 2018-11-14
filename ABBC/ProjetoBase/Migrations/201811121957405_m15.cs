namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "PlanoPagamento", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "PlanoPagamento");
        }
    }
}
