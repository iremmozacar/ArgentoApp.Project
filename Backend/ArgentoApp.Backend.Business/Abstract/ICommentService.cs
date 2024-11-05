using System;
using ArgentoApp.Backend.Shared.DTOs.CommentDTOs;

namespace ArgentoApp.Backend.Business.Abstract;

public interface ICommentService
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetAllCommentsAsync();
        Task<CommentDto> GetCommentByIdAsync(int id);
        Task AddCommentAsync(CommentDto commentDto);

        Task DeleteCommentAsync(int id);
    }
}
