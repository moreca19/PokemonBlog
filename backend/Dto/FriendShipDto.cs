namespace PokemonBlog.Dto
{
    
        public record CreateNewFriendShip(int SenderId, int RecipientId);
        public record AcceptOrDecline (string Description, int FriendShipId);
    
}
