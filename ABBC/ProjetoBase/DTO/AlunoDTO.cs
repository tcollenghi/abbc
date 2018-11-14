using System;
using System.Collections.Generic;
using ProjetoBase.Models;
using ProjetoBase.Service;

namespace ProjetoBase.DTO
{
    public class AlunoDTO
    {

        public long ID { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public bool ativo { get; set; }

        public string RG { get; set; }
        public string Contratante { get; set; }
        public string Filiacao { get; set; }
        public string rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public int Pais { get; set; }
        public string uf { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string TelefoneContratante { get; set; }
        public string TelefoneContato { get; set; }

        public string VencimentoParcela { get; set; }
        public int Curso { get; set; }
        public int Turma { get; set; }
        public string HorarioAula { get; set; }
        public string DiasDaSemana { get; set; }
        public string InicioDeAula { get; set; }
        public DateTime Nascimento { get; set; }
        public DateTime NascimentoContratante { get; set; }
        public string LocalCurso { get; set; }
        public int PlanoPagamento { get; set; }

        public AlunoDTO() { }

        public AlunoDTO(Aluno aluno)
        {
            ID = aluno.ID;
            nome = aluno.Nome;
            cpf = aluno.Cpf;
            telefone = aluno.Telefone;
            email = aluno.Email;
            ativo = aluno.Ativo;

            RG = aluno.RG;
            Contratante = aluno.Contratante;
            Filiacao = aluno.Filiacao;
            rua = aluno.Endereco;
            Numero = aluno.Numero;
            Bairro = aluno.Bairro;
            Pais = aluno.Pais;
            uf = aluno.Estado;
            Cidade = aluno.Cidade;
            CEP = aluno.CEP;
            TelefoneContratante = aluno.TelefoneContratante;
            TelefoneContato = aluno.TelefoneContato;
            VencimentoParcela = aluno.VencimentoParcela;
            Turma = aluno.Turma;
            Curso = aluno.Curso;
            HorarioAula = aluno.HorarioAula;
            DiasDaSemana = aluno.DiasDaSemana;
            InicioDeAula = aluno.InicioDeAula;
            Nascimento = aluno.Nascimento;
            NascimentoContratante = aluno.NascimentoContratante;
            LocalCurso = aluno.LocalCurso;
            PlanoPagamento = aluno.PlanoPagamento;

        }

        public Aluno ParseToAluno()
        {
            Aluno aluno = new Aluno()
            {
                Nome = nome,
                Ativo = ativo,
                Cpf = cpf,
                RG = RG,
                Email = email,
                Telefone = telefone,
                Contratante = Contratante,
                Filiacao = Filiacao,
                Endereco = rua,
                Numero = Numero,
                Bairro = Bairro,
                Pais = Pais,
                Estado = uf,
                Cidade = Cidade,
                CEP = CEP,
                TelefoneContratante = TelefoneContratante,
                TelefoneContato = TelefoneContato,
                VencimentoParcela = VencimentoParcela,
                Turma = Turma,
                Curso = Curso,
                HorarioAula = HorarioAula,
                DiasDaSemana = DiasDaSemana,
                InicioDeAula = InicioDeAula,
                Nascimento = Nascimento,
                NascimentoContratante = NascimentoContratante,
                LocalCurso = LocalCurso,
                PlanoPagamento = PlanoPagamento,
                ID = ID

            };

            return aluno;
        }

        public List<string> validate()
        {
            List<string> erros = new List<string>();
            if (nome == null || nome == "")
            {
                erros.Add("Nome do aluno não pode ser vazio.");
            }
            if (email == null || email == "")
            {
                erros.Add("E-mail não pode ser vazio.");
            }
            else
            {
                if (AutenticacaoService.ExisteAlunoComEmail(email))
                {
                    erros.Add("E-mail já cadastrado para outro aluno.");
                }
            }
            if (cpf == null || cpf.Length < 11 || cpf.Length > 12)
            {
                erros.Add("O CPF está incorreto.");
            }
            else
            {
                if (AutenticacaoService.ExisteAlunoComCPF(cpf))
                {
                    erros.Add("CPF já cadastrado para outro aluno.");
                }
            }

            return erros;
        }

        public List<string> validateEdit()
        {
            List<string> erros = new List<string>();

            if (cpf == null || cpf.Length < 11 || cpf.Length > 12)
            {
                erros.Add("O CPF está incorreto.");
            }

            return erros;
        }

        public List<string> validateEditCursoTurma(int Curso, int Turma)
        {
            List<string> erros = new List<string>();

            if ((cpf != null && cpf != "") && (cpf.Length < 12 || cpf.Length > 13))
            {
                erros.Add("O CPF está incorreto.");
            }

            return erros;
        }

        public Aluno ParseToAluno(Aluno aluno)
        {
            aluno.Nome = nome;
            aluno.Cpf = cpf;
            aluno.Email = email;
            aluno.Ativo = ativo;
            aluno.Telefone = telefone;

            aluno.RG = RG;
            aluno.Contratante = Contratante;
            aluno.Filiacao = Filiacao;
            aluno.Endereco = rua;
            aluno.Numero = Numero;
            aluno.Bairro = Bairro;
            aluno.Pais = Pais;
            aluno.Estado = uf;
            aluno.Cidade = Cidade;
            aluno.CEP = CEP;
            aluno.TelefoneContratante = TelefoneContratante;
            aluno.TelefoneContato = TelefoneContato;
            aluno.VencimentoParcela = VencimentoParcela;
            aluno.Turma = Turma;
            aluno.Curso = Curso;
            aluno.HorarioAula = HorarioAula;
            aluno.DiasDaSemana = DiasDaSemana;
            aluno.InicioDeAula = InicioDeAula;
            aluno.Nascimento = Nascimento;
            aluno.NascimentoContratante = NascimentoContratante;
            aluno.LocalCurso = LocalCurso;
            aluno.PlanoPagamento = PlanoPagamento;
            
            return aluno;
        }

    }
}