namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Aluno", "Estado");
            DropColumn("dbo.Aluno", "Cidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluno", "Cidade", c => c.Int(nullable: false));
            AddColumn("dbo.Aluno", "Estado", c => c.Int(nullable: false));
        }
    }
}
