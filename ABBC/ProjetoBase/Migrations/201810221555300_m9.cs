namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Curso", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "Curso");
        }
    }
}
