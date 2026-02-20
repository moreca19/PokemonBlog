namespace PokemonBlog.Models
{
    public class FriendShipStatus
    {
        public int Id { get; set; }
        public bool Description { get; set; }

        public ICollection<FriendShip> FriendShips { get; set; }



    }
}
