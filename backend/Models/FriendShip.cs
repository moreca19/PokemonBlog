namespace PokemonBlog.Models
{
    public class FriendShip
    {
        public int Id { get; set; }
        public DateTime FriendShipCreated {  get; set; }

        public int SenderId {  get; set; }
        public User Sender { get; set; }
        public int RecieverId {  get; set; }
        public User Reciever { get; set; }

        public FriendShipStatus status { get; set; }
        public int StatusId { get; set; }




    }
}
