namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Numero", c => c.String());
            AddColumn("dbo.Aluno", "Bairro", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "Bairro");
            DropColumn("dbo.Aluno", "Numero");
        }
    }
}
