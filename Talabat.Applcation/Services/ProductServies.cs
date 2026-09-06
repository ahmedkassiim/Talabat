using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Talabat.Applcation.Dtos.Product;
using Talabat.Applcation.Specification.Product;
using Talabat.Domain.Entities;
using Talabat.Domain.Interfaces;
using Talabat.Infrastructure.Persistence.Data;

namespace Talabat.Applcation.Services
{
    public class ProductServies<TResult> : IProductServies<ProductResponseDto>
    {
        private readonly IGenericRepository<Product, ProductResponseDto> _repo;
        private readonly IConfiguration _configuration;
        public ProductServies(IGenericRepository<Product, ProductResponseDto> repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }
        public async Task<IEnumerable<ProductResponseDto>> GetProducts(string? sorting, int? categoryId, int? brandId)
        {
            var products = await _repo.GetAllWithSpec(new GetAllProductSpecification(_configuration, sorting, categoryId, brandId));
            return products;
        }
        public async Task<ProductResponseDto?> GetProductById(int Id)
        {
            var product = await _repo.GetWithSpec(new GetProductByIdSpecification(Id, _configuration));
            return product;
        }

    

        }

    }

            

