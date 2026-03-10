using PokemonBlog.Dto;
using PokemonBlog.Data;
using PokemonBlog.Interfaces;
using PokemonBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace PokemonBlog.Services
{
    public class LikeService : ILikeService
    {

        private readonly PokemonContext _context;

        public LikeService(PokemonContext context) 
        {
            _context = context;        
        }

        public async Task<Like> CreateLike(CreateNewLike createNewLike)
        {


            var NewLike = new Like
            {
                PostId = createNewLike.PostId,
                UserId = createNewLike.UserId,

            };
            if (NewLike == null)
            {
                throw new Exception("Not able to give the post a like");
            }
            
            var Post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == createNewLike.PostId);
            Post.NumberOfLikes++;
            

            _context.Likes.Add(NewLike);
            await _context.SaveChangesAsync();

            return NewLike;
        }

        public async Task UnlikePost(UnlikePost unlikePost)
        {
            var PostToUnlike = await _context.Posts.FirstOrDefaultAsync(p=> p.Id ==  unlikePost.PostId);
            PostToUnlike.NumberOfLikes--;

            var LikeToDelete = _context.Likes.FirstOrDefaultAsync(l=> l.Id == unlikePost.LikeId);

            _context.Remove(LikeToDelete);
            await _context.SaveChangesAsync();


        }




    }
}
