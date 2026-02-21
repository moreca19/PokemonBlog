namespace PokemonBlog.Dto
{
    public record CreateNewComment(int PostId,int UserId, string Content);
    public record DeleteComment(int CommentId);
    public record UpdateComment (int CommentId,string Content);
    

}
