using System;
using ArgentoApp.Backend.Business.Abstract;
using ArgentoApp.Backend.Data;
using ArgentoApp.Backend.Entity.Concrete;
using ArgentoApp.Backend.Shared.DTOs;
using ArgentoApp.Backend.Shared.DTOs.Categories;
using ArgentoApp.Backend.Shared.DTOs.CategoryDto;
using ArgentoApp.Backend.Shared.DTOs.ResponseDTOs;
using ArgentoApp.Backend.Shared.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ArgentoApp.Backend.Business.Concrete;

public class CategoryService : ICategoryService
{


    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto)
    {
        string url = CustomUrlHelper.GetUrl(categoryCreateDto.Name);
        Category category = _mapper.Map<Category>(categoryCreateDto);
        var createdCategory = await _categoryRepository.CreateAsync(category);
        if (createdCategory == null)
        {
            return ResponseDto<CategoryDto>.Fail("Bir hata oluştu!", StatusCodes.Status400BadRequest);
        }
        CategoryDto categoryDto = _mapper.Map<CategoryDto>(createdCategory);
        return ResponseDto<CategoryDto>.Success(categoryDto, StatusCodes.Status201Created);
    }
    public async Task<ResponseDto<NoContent>> DeleteAsync(int id)
    {
        var category = await _categoryRepository.GetAsync(x => x.Id == id);
        if (category == null)
        {
            return ResponseDto<NoContent>.Fail($"{id} id'li kategori bulunamadı!", 404);
        }
        await _categoryRepository.DeleteAsync(category);
        return ResponseDto<NoContent>.Success(200);
    }
    public async Task<ResponseDto<List<CategoryDto>>> GetActivesAsync(bool IsActive = true)
    {
        var categoryList = await _categoryRepository.GetAllAsync();
        string statusText = IsActive ? "Aktif" : "Pasif";
        if (categoryList.Count == 0)
        {
            return ResponseDto<List<CategoryDto>>.Fail($" {statusText} kategori bulunamadı!", 404);
        }
        var categoryDtoList = _mapper.Map<List<CategoryDto>>(categoryList);
        return ResponseDto<List<CategoryDto>>.Success(categoryDtoList, 200);
    }
    public async Task<ResponseDto<int>> GetActivesCountAsync(bool IsActive = true)
    {
        var categoryList = await _categoryRepository.GetAllAsync(x => x.IsActive == IsActive);
        int count = categoryList.Count;
        string statusText = IsActive ? "Aktif " : "Pasif";
        if (count == 0)
        {
            return ResponseDto<int>.Fail($"{statusText} kategori bulunamadı!", 404);
        }
        return ResponseDto<int>.Success(count, 200);
    }
    public async Task<ResponseDto<List<CategoryDto>>> GetAllAsync()
    {
        var categoryList = await _categoryRepository.GetAllAsync();

        if (categoryList.Count == 0)
        {
            return ResponseDto<List<CategoryDto>>.Fail($"Kategori bulunamadı", 404);

        }
        var categoryDtoList = _mapper.Map<List<CategoryDto>>(categoryList);
        return ResponseDto<List<CategoryDto>>.Success(categoryDtoList, 200);
    }
    public async Task<ResponseDto<CategoryDto>> GetAsync(int id)
    {
        var category = await _categoryRepository.GetAllAsync(x => x.Id == id);
        if (category == null)
        {
            return ResponseDto<CategoryDto>.Fail($"{id}'li kategori bulunamadı", 404);
        }
        var categoryDto = _mapper.Map<CategoryDto>(category);
        return ResponseDto<CategoryDto>.Success(categoryDto, 200);
    }
    public async Task<ResponseDto<int>> GetCountAsync()
    {
        int count = await _categoryRepository.GetCountAsync();
        if (count == 0)
        {
            return ResponseDto<int>.Fail("Kategori bulunamadı!", 404);
        }
        return ResponseDto<int>.Success(count, 200);
    }
    public async Task<ResponseDto<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
    {
        var category = await _categoryRepository.GetAsync(x => x.Id == categoryUpdateDto.Id);
        if (category == null)
        {
            return ResponseDto<CategoryDto>.Fail("Böyle bir kategori bulunamadı!", 404);
        }
        category = _mapper.Map<Category>(categoryUpdateDto);
        category.ModifiedDate = DateTime.Now;
        category.Url = CustomUrlHelper.GetUrl(categoryUpdateDto.Name);
        await _categoryRepository.UpdateAsync(category);
        var categoryDto = _mapper.Map<CategoryDto>(category);
        return ResponseDto<CategoryDto>.Success(categoryDto, 200);
    }
}
