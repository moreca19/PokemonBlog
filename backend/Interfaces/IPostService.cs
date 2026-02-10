using PokemonBlog.Models;
using PokemonBlog.Dto;
namespace PokemonBlog.Interfaces
{
    public interface IPostService
    {

        Task<Post>  CreateNewPost(PostDto post);
    }
}
