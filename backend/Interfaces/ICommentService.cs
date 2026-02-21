using PokemonBlog.Dto;
using PokemonBlog.Models;




namespace PokemonBlog.Interfaces
{
    public interface ICommentService
    {
        Task UpdateComment(UpdateComment updateComment);
        Task DeleteComment(DeleteComment deleteComment);
        Task<Comment> CreateNewComment (CreateNewComment createNewComment);


    }
}
