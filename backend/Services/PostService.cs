using PokemonBlog.Dto;
using PokemonBlog.Data;
using PokemonBlog.Interfaces;
using PokemonBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Npgsql.TypeMapping;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

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
                UserId = postDto.UserId,
                NumberOfLikes = 0
               
                
                
            };

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return Post;
        }

        public async Task DeletePost(DeletePost deletePost)
        {
            var PostToDelete = await _context.Posts.FirstOrDefaultAsync(p => p.Id == deletePost.Id);

            if(PostToDelete == null)
            {
                throw new Exception("Post does not exist");
            }

            _context.Posts.Remove(PostToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePost(UpdatePost updatePost)
        {
            var PostToUpdate = await _context.Posts.FirstOrDefaultAsync(p => p.Id == updatePost.Id);

            if (PostToUpdate == null)
            {
                throw new Exception("Post cannot be udpated becasue it doesnt exist");

            }

            PostToUpdate.Title = updatePost.Title;
            PostToUpdate.Content = updatePost.Content;
            PostToUpdate.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<GetAllPosts>> GetAllPosts()
        {
            var AllPosts = await _context.Posts
                .Select(p=> new GetAllPosts 
            {
                Title = p.Title,
                Content = p.Content,
                OwnerOfPost = p.User.Name
            })
             .ToListAsync();
            return AllPosts;

        }

        public async Task<IEnumerable<LikeByUsers>> GetUsersWhoLikedPost(int PostId)
        {
            var AllUsersWhoLikedPost = await _context.Likes
                .Where(l => l.PostId == PostId)
                .Select(l => new LikeByUsers
                {
                    name = l.User.Name
                })
                .ToListAsync();
            return AllUsersWhoLikedPost;

        }



    }
}
