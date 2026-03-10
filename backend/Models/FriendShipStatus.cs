namespace PokemonBlog.Models
{
    public class FriendShipStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<FriendShip> FriendShips { get; set; }



    }
}
