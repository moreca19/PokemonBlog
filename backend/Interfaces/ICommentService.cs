using PokemonBlog.Dto;
using PokemonBlog.Models;




namespace PokemonBlog.Interfaces
{
    public interface ICommentService
    {
        void UpdateComment(int  id, string comment);

        void DeleteComment(int id);
        void NewComment     (int id);


    }
}
