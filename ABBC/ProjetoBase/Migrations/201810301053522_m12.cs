namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "TelefoneContato", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "TelefoneContato");
        }
    }
}
