using System;

namespace ArgentoApp.Backend.Shared.DTOs.CommentDTOs;

public class CommentDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int ProductId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UserName { get; set; }
}
