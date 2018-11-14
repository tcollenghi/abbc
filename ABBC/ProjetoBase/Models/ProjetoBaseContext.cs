using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ProjetoBase.Models
{
    public class ProjetoBaseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public ProjetoBaseContext() : base("ProjetoBaseConnect")
        {
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseModel
        {
            return base.Set<TEntity>();
        }

        public DbSet<Log> Log { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<PlanoPagamento> PlanoPagamento { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<FuncionarioNivelAcesso> FuncionarioNivelAcesso { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Não escrever os nomes dos objetos no plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
