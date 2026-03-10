using PokemonBlog.Models;

namespace PokemonBlog.Interfaces
{
    public interface IDeckListService
    {
        Task<DeckList> NewDeckList();

        Task UpdateDeckList();
    }
}
