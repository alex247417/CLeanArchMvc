using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    /// <summary>
    /// Configuração do mapeamento da entidade <see cref="Product"/> para o banco de dados.
    /// Implementa as regras de coluna, restrições e relacionamentos via Fluent API.
    /// </summary>
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Define as configurações da tabela Products:
        /// chave primária, tamanhos máximos, campos obrigatórios,
        /// precisão do preço e relacionamento com Category.
        /// </summary>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Chave primária da entidade
            builder.HasKey(t => t.Id);

            // Nome obrigatório, limitado a 100 caracteres
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();

            // Descrição obrigatória, limitada a 200 caracteres
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();

            // Preço com precisão de 10 dígitos no total e 2 casas decimais
            builder.Property(p => p.Price).HasPrecision(10, 2);

            // Relacionamento N:1 — um Product pertence a uma Category
            // uma Category pode ter muitos Products
            builder.HasOne(e => e.Category)
                   .WithMany(e => e.Products)
                   .HasForeignKey(e => e.CategoryId);
        }
    }
}