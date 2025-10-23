using PokemonBlog.Model;

namespace PokemonBlog.Models
{
    public class Decklist
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set; }
        public string DeckListURL { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
