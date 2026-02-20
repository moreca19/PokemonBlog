using PokemonBlog.Dto;
using PokemonBlog.Data;
using PokemonBlog.Interfaces;
using PokemonBlog.Models;
using Microsoft.EntityFrameworkCore;


namespace PokemonBlog.Services
{
    public class LikeService : ILikeService
    {

        private readonly PokemonContext _context;

        public LikeService(PokemonContext context) 
        {
            _context = context;        
        }

        public async Task<Like> CreateLike(LikeDto likeDto)
        {


            var NewLike = new Like
            {
                PostId = likeDto.PostId,
                UserId = likeDto.UserId,

            };
            if (NewLike == null)
            {
                throw new Exception("Not able to give the post a like");
            }
            
            var GetPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == likeDto.PostId);
            var NumberOflikes = GetPost.NumberOfLikes;
            NumberOflikes++;
            GetPost.NumberOfLikes = NumberOflikes;  
            

            _context.Likes.Add(NewLike);
            await _context.SaveChangesAsync();

            return NewLike;
        }




    }
}
