using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace PokemonBlog.Dto
{
    
    public record CreateNewLike(int UserId, int PostId);

    public record UnlikePost(int PostId, int LikeId);


}
