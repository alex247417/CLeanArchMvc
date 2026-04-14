using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório concreto para operações de persistência da entidade <see cref="Product"/>.
    /// Implementa <see cref="IProductRepository"/> usando Entity Framework Core.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _productContext;

        /// <summary>
        /// Injeta o contexto do banco de dados via DI.
        /// </summary>
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        /// <summary>
        /// Adiciona um novo produto e persiste no banco de dados.
        /// </summary>
        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Products.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        /// <summary>
        /// Busca um produto pelo seu identificador único.
        /// Retorna null se não encontrado.
        /// </summary>
        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        /// <summary>
        /// Busca um produto pelo Id incluindo sua Category relacionada (Eager Loading).
        /// Útil quando os dados da categoria são necessários junto ao produto.
        /// </summary>
        public async Task<Product> GetProductCategoriyAsync(int? id)
        {
            // Eager Loading: carrega a Category junto com o Product em uma única query
            return await _productContext.Products
                .Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Retorna todos os produtos cadastrados no banco de dados.
        /// </summary>
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        /// <summary>
        /// Remove um produto existente e persiste a exclusão no banco de dados.
        /// </summary>
        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Products.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        /// <summary>
        /// Atualiza os dados de um produto existente e persiste as alterações.
        /// </summary>
        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Products.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}