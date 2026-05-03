using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper , IProductRepository productRepository) 
        { 
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productEntity =  _mapper.Map<ProductDTO>(productDTO);
            return await _productRepository.CreateAsync(productEntity);
        }

        public Task<ProductDTO> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetProductCategory(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
