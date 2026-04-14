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

            builder.HasData(
               new { Id = 1, Name = "Caderno Espiral", Description = "Caderno espiral 100 folhas", Price = 7.45m, Stock = 50, Image = "caderno1.jpg", CategoryId = 1 },
               new { Id = 2, Name = "Estojo Escolar", Description = "Estojo de plástico cinza", Price = 5.25m, Stock = 30, Image = "estojo1.jpg", CategoryId = 1 },
               new { Id = 3, Name = "Calculadora Científica", Description = "Calculadora com 240 funções", Price = 15.39m, Stock = 20, Image = "calculadora1.jpg", CategoryId = 2 }
           );
        }
    }
}