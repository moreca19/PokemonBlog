
namespace PokemonBlog.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string DateOfBirth { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate {  get; set; }


        public ICollection<Post> Posts { get; set; } = new List<Post>(); // one user can have many posts
        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); // user can have multiple comments 

        public ICollection<DeckList> Decklists { get; set; } = new List<DeckList>(); // user can uplaod many decklists

        public ICollection<FriendShip> FriendShipsSent { get; set; } = new List<FriendShip>();//User can send multiple frind requests

        public ICollection<FriendShip> FriendShipsRecieved { get; set; } = new List<FriendShip>();// user can get multiple friend requests

    }
}
