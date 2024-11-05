using System;
using ArgentoApp.Backend.Entity.Concrete.Abstact;
using ArgentoApp.Backend.Shared.DTOs.CategoryDTOs;
using ArgentoApp.Backend.Shared.DTOs.ProductDTOs;
using ArgentoApp.Backend.Shared.DTOs.ResponseDTOs;

namespace ArgentoApp.Backend.Business.Abstract;

public interface IProductService
{
    Task<ResponseDto<ProductDto>> CreateAsync(ProductCreateDto productCreateDto);
    Task<ResponseDto<ProductDto>> UpdateAsync(ProductUpdateDto productUpdateDto);
    Task<ResponseDto<NoContent>> DeleteAsync(int id);
    Task<ResponseDto<ProductDto>> GetAsync(int id);
    Task<ResponseDto<List<ProductDto>>> GetAllAsync();
    Task<ResponseDto<List<ProductDto>>> GetActivesAsync(bool isActive = true);
    Task<ResponseDto<List<ProductDto>>> GetHomeAsync(bool isHome = true);
    Task<ResponseDto<List<ProductDto>>> GetAllCategoryId(int categoryId);
    Task<ResponseDto<int>> GetCountAsync();
    Task<ResponseDto<int>> GetActivesCountAsync(bool isActive = true);
    Task<ResponseDto<int>> GetHomesCountAsync(bool IsHome = true);
    Task<ResponseDto<NoContent>> UpdateIsActiveAsync(int id);
    Task<ResponseDto<NoContent>> UpdateIsHomeAsync(int id);

}
