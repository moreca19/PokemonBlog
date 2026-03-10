using PokemonBlog.Dto;
using PokemonBlog.Data;
using PokemonBlog.Interfaces;
using PokemonBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;


namespace PokemonBlog.Services
{
    public class FriendShipService : IFriendshipService
    {

        private readonly PokemonContext _context;

        public FriendShipService(PokemonContext context)
        {
            _context = context;
        }


        public async Task CreateFriendShip(CreateNewFriendShip createNewFriendShip)
        {
            var NewFriendShip = new FriendShip
            {
                FriendShipCreated = DateTime.UtcNow,
                RecieverId = createNewFriendShip.RecipientId,
                SenderId = createNewFriendShip.SenderId,
                StatusId = 1 // this is pending
            };

            if (NewFriendShip == null)  
            { 
                throw new Exception("Friendship was not able to be sent"); 
            }

            _context.FriendShips.Add(NewFriendShip);
            await _context.SaveChangesAsync();
        }

        public async Task AcceptOrDeclineFrindShip(AcceptOrDecline acceptOrDecline)
        {

            var FriendShipToUpdate = await _context.FriendShips.FirstOrDefaultAsync(f => f.Id == acceptOrDecline.FriendShipId);
            if (FriendShipToUpdate == null) 
            {
                throw new Exception("Friendship was not found");
            }

            if (acceptOrDecline.Description == "Accepted")
            {
                FriendShipToUpdate.StatusId = 2;
            }
            else
            {
                FriendShipToUpdate.StatusId = 3;
            }

            await _context.SaveChangesAsync();

        }


    }
}
