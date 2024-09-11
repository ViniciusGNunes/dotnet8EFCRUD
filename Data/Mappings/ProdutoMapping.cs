using dotnet8EFCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet8EFCRUD.Data.Mappings{
    public class ProdutoMapping: IEntityTypeConfiguration<Produto>{
        public void Configure(EntityTypeBuilder<Produto> builder){
            // Tabela
            builder.ToTable("Produto");

            // Chave Primária
            builder.HasKey(x=> x.Id);
 
            // Identity
            builder
                .Property(x=>x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1,1);

            // Propriedades
            builder
                .Property(x=> x.Name)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder
                .Property(x=> x.Price)
                .HasColumnName("Price")
                .HasColumnType("DECIMAL");
                            
            builder
                .Property(x=> x.QuantityOnStock)
                .HasColumnName("QuantityOnStock")
                .HasColumnType("INT");
        }
    }
}