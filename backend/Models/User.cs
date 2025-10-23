using PokemonBlog.Models;

namespace PokemonBlog.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>(); // one user can have many posts
        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); // user can have multiple comments 

        public ICollection<Decklist> Decklists { get; set; } = new List<Decklist>();

    }
}
