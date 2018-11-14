using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBase.Models;
using ProjetoBase.Service;

namespace ProjetoBase.DTO
{
    public class UsuarioSimplesDTO
    {
        public long ID { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public string funcao { get; set; }
        public string email { get; set; }
        public bool ativo { get; set; }

        public UsuarioSimplesDTO() { }

        public UsuarioSimplesDTO(Usuario usuario)
        {
            ID = usuario.ID;
            login = usuario.login;
            //senha = usuario.senha; Motivos de segurança não vai levar a senha
            nome = usuario.nome;
            funcao = usuario.funcao;
            ativo = usuario.ativo;
            email = usuario.email;
        }

        public Usuario ParseToUsuario()
        {
            Usuario usuario = new Usuario()
            {
                nome = nome,
                ativo = ativo,
                funcao = funcao,
                email = email,
                login = login,
                ID = ID,
                senha = senha
            };
            return usuario;
        }

        public List<string> validate()
        {
            List<string> erros = new List<string>();
            if (nome == null || nome == "")
            {
                erros.Add("Nome do usuário não pode ser vazio.");
            }

            if (login == null || login == "")
            {
                erros.Add("Login não pode ser vazio.");
            }
            else
            {
                bool userExistente = AutenticacaoService.ExisteUsuarioComLogin(login);
                if (userExistente)
                {
                    erros.Add("Já existe um usuário com esse login cadastrado no sistema.");
                }
            }
            if (email == null || email == "")
            {
                erros.Add("E-mail não pode ser vazio.");
            }
            else
            {
                if (AutenticacaoService.ExisteUsuarioComEmail(email))
                {
                    erros.Add("E-mail já cadastrado para outro usuário.");
                }
            }
            if (senha == null || senha.Length < 6 || senha.Length > 20)
            {
                erros.Add("A senha deve possuir entre 6 e 20 digitos.");
            }

            return erros;
        }

        public List<string> validateEdit()
        {
            List<string> erros = new List<string>();

            if ((senha != null && senha != "") && (senha.Length < 6 || senha.Length > 20))
            {
                erros.Add("A senha deve possuir entre 6 e 20 digitos.");
            }

            return erros;
        }

        public Usuario ParseToUsuario(Usuario usuario)
        {
            usuario.nome = nome;
            usuario.login = login;
            if (senha != null && senha.Length >= 6)
            {
                usuario.senha = senha;
            }
            usuario.email = email;
            usuario.ativo = ativo;

            return usuario;
        }
    }
}