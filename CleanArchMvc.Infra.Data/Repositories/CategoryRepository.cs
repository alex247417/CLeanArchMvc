using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório concreto para operações de persistência da entidade <see cref="Category"/>.
    /// Implementa <see cref="ICategoryRepository"/> usando Entity Framework Core.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _categoryContext;

        /// <summary>
        /// Injeta o contexto do banco de dados via DI.
        /// </summary>
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        /// <summary>
        /// Adiciona uma nova categoria e persiste no banco de dados.
        /// </summary>
        public async Task<Category> CreateAsync(Category category)
        {
            _categoryContext.Categories.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        /// <summary>
        /// Busca uma categoria pelo seu identificador único.
        /// Retorna null se não encontrada.
        /// </summary>
        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        /// <summary>
        /// Retorna todas as categorias cadastradas no banco de dados.
        /// </summary>
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        /// <summary>
        /// Remove uma categoria existente e persiste a exclusão no banco de dados.
        /// </summary>
        public async Task<Category> RemoveAsync(Category category)
        {
            _categoryContext.Categories.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        /// <summary>
        /// Atualiza os dados de uma categoria existente e persiste as alterações.
        /// </summary>
        public async Task<Category> UpdateAsync(Category category)
        {
            _categoryContext.Categories.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}