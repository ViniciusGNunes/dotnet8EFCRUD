using dotnet8EFCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet8EFCRUD.Data.Mappings{
    public class FuncionarioMapping:IEntityTypeConfiguration<Funcionario>{

        public void Configure(EntityTypeBuilder<Funcionario> builder){
            //Tabela
            builder.ToTable("Funcionario");

            // Chave Primaria
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x=>x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1);
            
            //Propriedades
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.Idade)
                .IsRequired()
                .HasColumnName("Idade")
                .HasColumnType("INT");
                


        }
    }
}