using dotnet8EFCRUD.Data.Mappings;
using dotnet8EFCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet8EFCRUD.Data
{
    public class ProjectDataContext : DbContext{
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.UseSqlServer("Server=localhost,1433;Database=Teste;User ID=sa;Password=1q2w3e4r@#$;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());

        }
    }    
}