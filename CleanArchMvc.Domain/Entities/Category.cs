using CleanArchMvc.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    /// <summary>
    /// Entidade de domínio que representa uma Categoria de produtos.
    /// </summary>
    public sealed class Category : Entity
    {
                public string Name { get; private set; }      

        /// <summary>
        /// Instancia uma nova categoria (Utilizado para criações iniciais sem ID).
        /// </summary>
        /// <param name="name">Nome da categoria.</param>
        public Category(string name)
        {
            ValidateDomain(name);
        }

        /// <summary>
        /// Instancia uma categoria existente (Utilizado para operações de persistência e atualização).
        /// </summary>
        /// <param name="id">Identificador único da categoria.</param>
        /// <param name="name">Nome da categoria.</param>
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        /// <summary>
        /// Atualiza os dados da categoria garantindo a manutenção do estado válido da entidade.
        /// </summary>
        /// <param name="name">Novo nome a ser atribuído à categoria.</param>
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Name. Name is Required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name. Name is Too Short, Minimum 3 Characters");

            Name = name;
        }
    }
}
