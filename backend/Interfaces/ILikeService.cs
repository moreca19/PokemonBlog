using PokemonBlog.Models;
using PokemonBlog.Dto;
namespace PokemonBlog.Interfaces
{
    public interface ILikeService
    {

        Task<Like> CreateLike(LikeDto likeDto);
    }
}
