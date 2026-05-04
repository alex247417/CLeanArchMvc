using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;


namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper , IProductRepository productRepository) 
        { 
            _mapper = mapper;
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productEntity =  _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productEntity = await _productRepository.GetProductCategoriyAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productEntity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        }

        public async Task Remove(int id)
        {
            var pruductEntity =  _productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemoveAsync(pruductEntity);

        }

        public async Task Update(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateAsync(productEntity);
        }
    }
}
