using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace PokemonBlog.Dto
{
    public class PostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }

    public class UpdatePost
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Content { get; set; }


    }

    public class DeletePost
    {
        public int Id { get; set; }
    }

    public class GetAllPosts
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string OwnerOfPost { get; set; }
    }
}
