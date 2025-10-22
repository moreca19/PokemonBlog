using PokemonBlog.Model;

namespace PokemonBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
        public int PostId {  get; set; }
        public Post Post { get; set; } = null!; // Navigation property - one comment belongs to one post


    }
}
