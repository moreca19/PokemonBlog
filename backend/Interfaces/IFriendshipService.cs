
using PokemonBlog.Dto;


namespace PokemonBlog.Interfaces
{
    public interface IFriendshipService
    {

        Task CreateFriendShip(CreateNewFriendShip createNewFriendShip);// need user ID whos sent it, recipient
        Task AcceptOrDeclineFrindShip(AcceptOrDecline acceptOrDecline);

    }
}
