using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    /// <summary>
    /// Configuração do mapeamento da entidade <see cref="Category"/> para o banco de dados.
    /// Implementa as regras de coluna e restrições via Fluent API.
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// Define as configurações da tabela Categories:
        /// chave primária e tamanho máximo do nome.
        /// </summary>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Chave primária da entidade
            builder.HasKey(t => t.Id);

            // Nome obrigatório, limitado a 100 caracteres
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
        }
    }
}