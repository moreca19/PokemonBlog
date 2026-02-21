using PokemonBlog.Dto;
using PokemonBlog.Data;
using PokemonBlog.Interfaces;
using PokemonBlog.Models;
using Microsoft.EntityFrameworkCore;


namespace PokemonBlog.Services
{
    public class CommentService : ICommentService 
    {
        private readonly PokemonContext _context;

        public CommentService(PokemonContext context)
        {
            _context = context;
        }


        public async Task<Comment> CreateNewComment(CreateNewComment createNewComment)
        {

            var CommentCreatedAt = DateTime.UtcNow;
            var commentUdpateAt = DateTime.UtcNow;
            var NewComment = new Comment
            {
                Content = createNewComment.Content,
                PostId = createNewComment.PostId,
                UserId = createNewComment.UserId,
                CreatedDate = CommentCreatedAt,
                UpdatedDate = commentUdpateAt

            };

            if (NewComment == null)
            {
                throw new Exception("Comment wasn't able to be created");
            }

            var Post = await _context.Posts.FirstOrDefaultAsync(p=> p.Id == createNewComment.PostId);
            Post.NumberOfComments++;

            _context.Comments.Add(NewComment);
            await _context.SaveChangesAsync();

            return NewComment;

        }

        public async Task DeleteComment(DeleteComment deleteComment)
        {
            var CommentToDelete = await _context.Comments.FirstOrDefaultAsync(c => c.Id == deleteComment.CommentId);

            _context.Comments.Remove(CommentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateComment(UpdateComment updateComment)
        {
            var CommentToUpdate = await _context.Comments.FirstOrDefaultAsync(c=> c.Id  == updateComment.CommentId);
            
            CommentToUpdate.Content = updateComment.Content;
            CommentToUpdate.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }
}
