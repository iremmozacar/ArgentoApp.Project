using System;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using ArgentoApp.Backend.Business.Abstract;
using ArgentoApp.Backend.Data;
using ArgentoApp.Backend.Data.Abstact;
using ArgentoApp.Backend.Data.Concrete.Repositories;
using ArgentoApp.Backend.Entity.Concrete.Abstact;
using ArgentoApp.Backend.Shared.DTOs.Categories;
using ArgentoApp.Backend.Shared.DTOs.CategoryDTOs;
using ArgentoApp.Backend.Shared.DTOs.ProductDTOs;
using ArgentoApp.Backend.Shared.DTOs.ResponseDTOs;
using ArgentoApp.Backend.Shared.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ArgentoApp.Backend.Business.Concrete;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<ResponseDto<ProductDto>> CreateAsync(ProductCreateDto productCreateDto)
    {
        Product product = _mapper.Map<Product>(productCreateDto);
        product.Url = CustomUrlHelper.GetUrl(productCreateDto.Name);
        product.IsActive = product.IsHome ? true : product.IsActive;
        var createdProduct = await _productRepository.CreateAsync(product);
        if (createdProduct == null)
        {
            return ResponseDto<ProductDto>.Fail("Bir hata oluştu!", 400);
        }
        ProductDto createdProductDto = _mapper.Map<ProductDto>(createdProduct);
        createdProductDto.Category = _mapper.Map<CategoryDto>(await _categoryRepository.GetAsync(x => x.Id == productCreateDto.CategoryId));
        return ResponseDto<ProductDto>.Success(createdProductDto, 201);
    }

    public async Task<ResponseDto<NoContent>> DeleteAsync(int id)
    {
        Product product = await _productRepository.GetAsync(x => x.Id == id);
        if (product == null)
        {
            return ResponseDto<NoContent>.Fail("${id} id'li ürün bulunamadı", 404);
        }
        await _productRepository.DeleteAsync(product);
        return ResponseDto<NoContent>.Success(200);
    }

    async Task<ResponseDto<List<ProductDto>>> IProductService.GetActivesAsync(bool isActive)
    {
        List<Product> productList = await _productRepository.GetAllAsync(x => x.IsActive == isActive);
        string statusText = isActive ? "Aktif " : "Pasif";
        if (productList.Count == 0)
        {
            return ResponseDto<List<ProductDto>>.Fail($"{statusText} ürün bulunamadı!", 404);

        }
        List<ProductDto> productDtoList = _mapper.Map<List<ProductDto>>(productList);
        return ResponseDto<List<ProductDto>>.Success(productDtoList, 200);
    }

    public async Task<ResponseDto<int>> GetActivesCountAsync(bool isActive = true)
    {
        int count = await _productRepository.GetCountAsync(x => x.IsActive == isActive, x => x.Include(y => y.Category));
        string statusText = isActive ? "Aktif" : "Pasif";
        if (count == 0)
        {
            return ResponseDto<int>.Fail($"{statusText} ürün bulunamadı!", 404);
        }
        return ResponseDto<int>.Success(count, 200);
    }

    public async Task<ResponseDto<List<ProductDto>>> GetAllAsync()
    {
        List<Product> productList = await _productRepository.GetAllAsync(null, x => x.Include(y => y.Category));

        if (productList.Count == 0)
        {
            return ResponseDto<List<ProductDto>>.Fail($"Ürün bulunamadı!", 404);

        }
        List<ProductDto> productDtoList = _mapper.Map<List<ProductDto>>(productList);
        return ResponseDto<List<ProductDto>>.Success(productDtoList, 200);
    }

    public async Task<ResponseDto<List<ProductDto>>> GetAllCategoryId(int categoryId)
    {
        List<Product> productList = await _productRepository.GetAllAsync(x => x.IsActive == true && x.CategoryId == categoryId, x => x.Include(y => y.Category));
        var category = await _categoryRepository.GetAsync(x => x.Id == categoryId);
        if (category == null)
        {
            return ResponseDto<List<ProductDto>>.Fail($"Böyle bir kategori bulunamadı!", 404);
        }
        if (productList.Count == 0)
        {
            return ResponseDto<List<ProductDto>>.Fail($"{category.Name} kategorisinde ürün bulunamadı!", 404);
        }

        List<ProductDto> productDtoList = _mapper.Map<List<ProductDto>>(productList);
        return ResponseDto<List<ProductDto>>.Success(productDtoList, 200);
    }

    public async Task<ResponseDto<ProductDto>> GetAsync(int id)
    {
        Product product = await _productRepository.GetAsync(x => x.Id == id, x => x.Include(y => y.Category));

        if (product == null)
        {
            return ResponseDto<ProductDto>.Fail($"{id} id'li bir ürün bulunamadı!", 404);

        }
        ProductDto productDto = _mapper.Map<ProductDto>(product);
        return ResponseDto<ProductDto>.Success(productDto, 200);
    }

    public async Task<ResponseDto<int>> GetCountAsync()
    {
        int count = await _productRepository.GetCountAsync();
        if (count == 0)
        {
            return ResponseDto<int>.Fail("Hiç ürün bulunamadı!", 404);
        }
        return ResponseDto<int>.Success(count, 200);
    }

    public async Task<ResponseDto<List<ProductDto>>> GetHomeAsync(bool isHome = true)
    {
        List<Product> productList = await _productRepository.GetAllAsync(x => x.IsHome == isHome, x => x.Include(y => y.Category));
        string statusText = isHome ? "Ana sayfa ürünü" : "Ana sayfada olmayan ürün";
        if (productList.Count == 0)
        {
            return ResponseDto<List<ProductDto>>.Fail($"{statusText} bulunamadı!", 404);
        }
        List<ProductDto> productDtoListt = _mapper.Map<List<ProductDto>>(productList);
        return ResponseDto<List<ProductDto>>.Success(productDtoListt, 200);
    }

    public async Task<ResponseDto<int>> GetHomesCountAsync(bool IsHome = true)
    {
        int count = await _productRepository.GetCountAsync(x => x.IsHome == IsHome);
        string statusText = IsHome ? "Ana sayfa ürünü" : "Ana sayfada olmayan ürün";
        if (count == 0)
        {
            return ResponseDto<int>.Fail($"{statusText} bulunamadı!", 404);
        }
        return ResponseDto<int>.Success(count, 200);
    }

    public async Task<ResponseDto<NoContent>> UpdateIsActiveAsync(int id)
    {
        var product = await _productRepository.GetAsync(x => x.Id == id);
        if (product == null)
        {
            return ResponseDto<NoContent>.Fail($"{id} id'li bir ürün bulunamadı! ", 404);
        }
        product.IsActive = !product.IsActive;
        if (!product.IsActive)
        {
            product.IsHome = false;
        }

        await _productRepository.UpdateAsync(product);
        return ResponseDto<NoContent>.Success(200);
    }

    public async Task<ResponseDto<NoContent>> UpdateIsHomeAsync(int id)
    {
        var product = await _productRepository.GetAsync(x => x.Id == id);
        if (product == null)
        {
            return ResponseDto<NoContent>.Fail($"{id} id'li ürün bulunamadı!", 404);
        }
        product.IsHome = !product.IsHome;
        product.IsActive = true;
        await _productRepository.UpdateAsync(product);
        return ResponseDto<NoContent>.Success(200);
    }


    public async Task<ResponseDto<ProductDto>> UpdateAsync(ProductUpdateDto productUpdateDto)
    {
        var product = await _productRepository.GetAsync(x => x.Id == productUpdateDto.Id);
        if (product == null)
        {
            return ResponseDto<ProductDto>.Fail($"{productUpdateDto.Id} id'li ürün bulunamadı!", 404);
        }
        var createdDate = product.CreatedDate;
        product = _mapper.Map<Product>(productUpdateDto);
        product.CreatedDate = createdDate;
        product.ModifiedDate = DateTime.Now;
        product.Url = CustomUrlHelper.GetUrl(productUpdateDto.Name);
        product.IsActive = product.IsHome ? true : product.IsActive;
        await _productRepository.UpdateAsync(product);
        var productDto = _mapper.Map<ProductDto>(product);
        productDto.Category = _mapper.Map<CategoryDto>(await _categoryRepository.GetAsync(x => x.Id == productDto.CategoryId));
        return ResponseDto<ProductDto>.Success(productDto, 200);
    }
}
