using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace PokemonBlog.Dto
{
    public class LikeDto // Dto for creating a like object
    {

        public int UserId { get; set; }
        public int PostId { get; set; }
    }


}
