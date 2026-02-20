using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace PokemonBlog.Dto
{
    public class LikeDto
    {

        public int UserId { get; set; }
        public int PostId { get; set; }
    }


}
