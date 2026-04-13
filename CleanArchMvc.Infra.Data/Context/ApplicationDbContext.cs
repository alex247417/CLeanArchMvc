using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context
{
    /// <summary>
    /// Contexto principal do banco de dados da aplicação.
    /// Herda de <see cref="DbContext"/> e configura as entidades
    /// mapeadas para o Entity Framework Core.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Inicializa o contexto com as opções de configuração do EF Core,
        /// como string de conexão e provedor de banco de dados.
        /// </summary>
        /// <param name="options">Opções de configuração injetadas via DI.</param>
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Representa a tabela de categorias no banco de dados.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Representa a tabela de produtos no banco de dados.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Sobrescreve a configuração do modelo de dados.
        /// Aplica automaticamente todas as configurações Fluent API
        /// definidas no assembly atual (classes que implementam IEntityTypeConfiguration).
        /// </summary>
        /// <param name="builder">Construtor do modelo do EF Core.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /// <summary>
            /// Varre o assembly em busca de todas as configurações de entidade
            /// (ex: CategoryConfiguration, ProductConfiguration) e as aplica automaticamente.
            /// </summary>
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}