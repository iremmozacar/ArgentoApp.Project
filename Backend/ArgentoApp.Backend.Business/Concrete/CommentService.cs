using System;
using ArgentoApp.Backend.Business.Abstract;
using ArgentoApp.Backend.Data.Abstract;
using ArgentoApp.Backend.Entity.Concrete;
using ArgentoApp.Backend.Shared.DTOs.CommentDTOs;
using AutoMapper;

namespace ArgentoApp.Backend.Business.Concrete;

public class CommentService : ICommentService
{

    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentDto>> GetAllCommentsAsync()
    {
        var comments = await _commentRepository.GetAllAsync();
        return _mapper.Map<List<CommentDto>>(comments);
    }

    // public async Task<CommentDto> GetCommentByIdAsync(int id)
    // {
    //     var comment = await _commentRepository.GetAsync(id);
    //     return _mapper.Map<CommentDto>(comment);
    // }

    // public async Task AddCommentAsync(CommentDto commentDto)
    // {
    //     var comment = _mapper.Map<Comment>(commentDto);
    //     await _commentRepository.AddAsync(comment);
    // }

    public async Task UpdateCommentAsync(CommentDto commentDto)
    {
        var comment = _mapper.Map<Comment>(commentDto);
        await _commentRepository.UpdateAsync(comment);
    }

    // public async Task DeleteCommentAsync(int id)
    // {
    //     await _commentRepository.DeleteAsync(id);
    // }
}

