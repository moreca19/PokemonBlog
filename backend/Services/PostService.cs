using PokemonBlog.Dto;
using PokemonBlog.Data;
using PokemonBlog.Interfaces;
using PokemonBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Npgsql.TypeMapping;

namespace PokemonBlog.Services
{
    public class PostService : IPostService
    {
        private readonly PokemonContext _context;
        
        public PostService(PokemonContext context)
        {

            _context = context;
            
        }

        public async Task<Post> CreateNewPost(PostDto postDto)
        {
            DateTime PostCreated = DateTime.UtcNow;
            DateTime PostModified = DateTime.UtcNow;
            var Post = new Post
            {
                Title = postDto.Title,
                CreatedDate = PostCreated,
                UpdatedDate = PostModified,
                Content = postDto.Content,
                UserId = postDto.UserId
                
            };

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return Post;
        }

    }
}
