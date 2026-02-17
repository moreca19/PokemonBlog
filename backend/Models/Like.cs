namespace PokemonBlog.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int PostId { get; set; } //Fk to post liked
        public Post Post { get; set; } 
        public int UserId { get; set; } // Fk user who like the post
        public User User { get; set; }
    }
}
