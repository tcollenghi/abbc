namespace ProjetoBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "RG", c => c.String());
            AddColumn("dbo.Aluno", "Contratante", c => c.String());
            AddColumn("dbo.Aluno", "Filiacao", c => c.String());
            AddColumn("dbo.Aluno", "Endereco", c => c.String());
            AddColumn("dbo.Aluno", "Pais", c => c.Int(nullable: false));
            AddColumn("dbo.Aluno", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Aluno", "Cidade", c => c.Int(nullable: false));
            AddColumn("dbo.Aluno", "CEP", c => c.String());
            AddColumn("dbo.Aluno", "TelefoneContratante", c => c.String());
            AddColumn("dbo.Aluno", "VencimentoParcela", c => c.String());
            AddColumn("dbo.Aluno", "Turma", c => c.Int(nullable: false));
            AddColumn("dbo.Aluno", "HorarioAula", c => c.String());
            AddColumn("dbo.Aluno", "DiasDaSemana", c => c.String());
            AddColumn("dbo.Aluno", "InicioDeAula", c => c.String());
            AddColumn("dbo.Aluno", "Nascimento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Aluno", "NascimentoContratante", c => c.DateTime(nullable: false));
            AddColumn("dbo.Aluno", "LocalCurso", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "LocalCurso");
            DropColumn("dbo.Aluno", "NascimentoContratante");
            DropColumn("dbo.Aluno", "Nascimento");
            DropColumn("dbo.Aluno", "InicioDeAula");
            DropColumn("dbo.Aluno", "DiasDaSemana");
            DropColumn("dbo.Aluno", "HorarioAula");
            DropColumn("dbo.Aluno", "Turma");
            DropColumn("dbo.Aluno", "VencimentoParcela");
            DropColumn("dbo.Aluno", "TelefoneContratante");
            DropColumn("dbo.Aluno", "CEP");
            DropColumn("dbo.Aluno", "Cidade");
            DropColumn("dbo.Aluno", "Estado");
            DropColumn("dbo.Aluno", "Pais");
            DropColumn("dbo.Aluno", "Endereco");
            DropColumn("dbo.Aluno", "Filiacao");
            DropColumn("dbo.Aluno", "Contratante");
            DropColumn("dbo.Aluno", "RG");
        }
    }
}
