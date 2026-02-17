using PokemonBlog.Models;
using PokemonBlog.Dto;
namespace PokemonBlog.Interfaces
{
    public interface IPostService
    {

        Task<Post> CreateNewPost(PostDto post);

        Task DeletePost(DeletePost deletePost);
        Task UpdatePost(UpdatePost updatePost);

        Task <IEnumerable<GetAllPosts>> GetAllPosts();  
            
    }
}
