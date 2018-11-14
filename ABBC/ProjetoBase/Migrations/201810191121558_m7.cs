namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Estado", c => c.String());
            AddColumn("dbo.Aluno", "Cidade", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "Cidade");
            DropColumn("dbo.Aluno", "Estado");
        }
    }
}
